using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_SuaHoaDon_NhapModel : PageModel
    {
        public HOADON A;
        public string? Chuoi;
        public bool coHoaDon;

        [BindProperty(SupportsGet = true)]
        public string Index { get; set; }
        [BindProperty]
        public string MaHD { get; set; }
        [BindProperty]
        public string Ma_TenMH { get; set; }
        [BindProperty]
        public int Gia { get; set; }
        [BindProperty]
        public int SL { get; set; }
        [BindProperty]
        public DateTime NgayLap { get; set; }
        [BindProperty]
        public int ThanhTien { get; set; }

        public void OnGet()
        {
            HOADON? HD = XL_HoaDon_NhapHang.DocHoaDon(Index);
            if (HD != null)
            {
                A = HD.Value;
            }
            else
            {
                A = new HOADON(); // co the bo
                Chuoi = "Khong tim thay hoa don";
            }
            coHoaDon = (HD != null);
            
            
        }
        public void OnPost()
        {
            A.MaHD = MaHD;
            A.SanPham = new List<MATHANGHOADON>();
            int nMucNhap = Request.Form["MatHangHoaDon"].Count;
            for (int i = 0; i < nMucNhap; i++)
            {
                MATHANGHOADON Sp = new MATHANGHOADON();
                string[] Ma_TenMH = Request.Form["MatHangHoaDon"][i].Split('|');
                Sp.MaMH = Ma_TenMH[0];
                Sp.TenMH = Ma_TenMH[1];
                Sp.SL = int.Parse(Request.Form["SL"][i]);
                Sp.Gia = int.Parse(Request.Form["Gia"][i]);
                ThanhTien += Sp.SL * Sp.Gia;
                A.SanPham.Add(Sp);
            }
            A.ThanhTien = ThanhTien;
            A.NgayLap = NgayLap;
            bool kq = XL_HoaDon_NhapHang.SuaHoaDon(Index, A.SanPham, NgayLap, ThanhTien);
            Chuoi = $"Modify a product: {kq}";
            //quay lai man hinh danh sach san pham
            if (kq)
            {
                Response.Redirect("/MH_HoaDon_NhapHang");

            }            
            Chuoi = $"Adjusting the bill: {kq}";

        }
    }
}

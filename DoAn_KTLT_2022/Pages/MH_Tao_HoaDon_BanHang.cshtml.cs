using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_Tao_HoaDon_BanHangModel : PageModel
    {
        public HOADON A;
        public string? Chuoi;
        [BindProperty]
        public string MaHD { get; set; }

        [BindProperty]
        public DateTime NgayLap { get; set; }
        [BindProperty]
        public int ThanhTien { get; set; }

        public void OnGet()
        {
            Chuoi = string.Empty;
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

            bool kq = XL_HoaDon_BanHang.TaoHoaDon(A);
            if (kq)
            {
                Response.Redirect("/MH_HoaDon_BanHang");
            }
            Chuoi = $"Adding a new product: {kq}";

        }
    }
}

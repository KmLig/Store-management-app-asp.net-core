using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_SuaHoaDon_BanModel : PageModel
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
            HOADON? HD = XL_HoaDon_BanHang.DocHoaDon(Index);
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
            string[] vs = Ma_TenMH.Split('|');
            string MaMH = vs[0];
            string TenMH = vs[1];
            ThanhTien = Gia * SL;
            bool kq = XL_HoaDon_BanHang.SuaHoaDon(Index, Index, MaMH, TenMH, Gia, SL, NgayLap, ThanhTien);
            Chuoi = $"Modify a product: {kq}";
            //quay lai man hinh danh sach san pham
            if (kq)
            {
                Response.Redirect("/MH_HoaDon_BanHang");

            }            
            Chuoi = $"Adding a new product: {kq}";

        }
    }
}

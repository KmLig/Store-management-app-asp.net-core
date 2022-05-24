using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_Tao_HoaDon_NhapHangModel : PageModel
    {
        public HOADON A;
        public string? Chuoi;
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
            Chuoi = string.Empty;           
        }
        public void OnPost()
        {
            A.MaHD = MaHD;
            string[] vs = Ma_TenMH.Split('|');
            A.MaMH = vs[0];
            A.TenMH = vs[1];
            A.Gia = Gia;
            A.SL = SL;
            A.NgayLap = NgayLap;
            A.ThanhTien = Gia * SL;
            bool kq = XL_HoaDon_NhapHang.TaoHoaDon(A);
            if (kq)
            {
                Response.Redirect("/MH_HoaDon_NhapHang");
            }
            Chuoi = $"Adding a new product: {kq}";

        }
    }
}

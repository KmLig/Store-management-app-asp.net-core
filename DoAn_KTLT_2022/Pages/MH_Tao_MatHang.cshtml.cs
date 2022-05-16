using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_Tao_MatHangModel : PageModel
    {
        public MATHANG A;
        public string? Chuoi;
        [BindProperty]
        public string MaMH { get; set; }
        [BindProperty]
        public string TenMH { get; set; }
        [BindProperty]
        public DateTime HanSD { get; set; }
        [BindProperty]
        public string CtySX { get; set; }
        [BindProperty]
        public DateTime NgaySX { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        [BindProperty]
        public int Gia { get; set; }
        public void OnGet()
        {
            Chuoi = string.Empty;
            A.MaMH = MaMH;
            A.TenMH = TenMH;
            A.HanSD = HanSD;
            A.CtySX = CtySX;
            A.NgaySX = NgaySX;
            A.LoaiHang = LoaiHang;
        }
        public void OnPost()
        {
            A.MaMH  = MaMH;
            A.TenMH = TenMH;
            A.HanSD  = HanSD;
            A.CtySX = CtySX;
            A.NgaySX = NgaySX;
            A.LoaiHang = LoaiHang;
            A.Gia = Gia;
            bool kq = XL_MatHang.TaoMatHang(A);
            if (kq)
            {
                Response.Redirect("/MH_MatHang");
            }
            Chuoi = $"Adding a new product: {kq}";
            
        }
    }
}

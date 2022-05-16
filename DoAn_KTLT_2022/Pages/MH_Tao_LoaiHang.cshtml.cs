using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_Tao_LoaiHangModel : PageModel
    {
        public string? Chuoi;        
        [BindProperty]
        public string LoaiHang { get; set; }
        
        public void OnGet()
        {
        Chuoi = string.Empty;
        }
        public void OnPost()
        {
            string Lh = LoaiHang;
            bool kq = XL_LoaiHang.TaoLoaiHang(Lh);
            if (kq)
            {
                Response.Redirect("/MH_LoaiHang");
            }
            Chuoi = $"Adding a new category: {kq}";
        }
    }
}

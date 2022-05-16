using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_DangKyModel : PageModel
    {
        public string? Chuoi;
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string PassWord { get; set; }
        [BindProperty]
        public string FullName { get; set; }
        public void OnGet()
        {
            Chuoi = string.Empty;
            //A.MaSP = "001";
            //A.TenSP = "Sneaker";
            //A.GiaSP = 20000;
        }
        public void OnPost()
        {
            bool kq = XL_NguoiDung.DangKy(UserName, PassWord, FullName);
            Chuoi = $"Ket qua la: {kq}";
            if(kq == true)
            {
                Response.Redirect("/MH_DanhSachSanPham");
            }
            

            
        }
    }
}

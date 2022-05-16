using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_DangNhapModel : PageModel
    {
        public string? Chuoi;
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string PassWord { get; set; }        
        public void OnGet()
        {
            Chuoi = string.Empty;            
        }
        public void OnPost()
        {
            NGUOIDUNG? user = XL_NguoiDung.DangNhap(UserName, PassWord);
            if(user != null)
            {
                HttpContext.Session.SetString("user", user.Value.UserName);
                Response.Redirect("/MH_MatHang");
            }
            else
            {
                Chuoi = "Dang nhap khong thanh cong!";
            }




        }
    }
}

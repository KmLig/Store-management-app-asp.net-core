using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_SuaLoaiHangModel : PageModel
    {
        public string LoaiHang;
        public string Chuoi;
        [BindProperty]
        public string LoaiHangSua { get; set; }
        public bool coLoaiHang;

        [BindProperty(SupportsGet = true)]
        public int Index { get; set; }
        public void OnGet()
        {
            string? lh = XL_LoaiHang.DocLoaiHang(Index);
            if (lh != null)
            {
                LoaiHang = lh;
            }
            else
            {
                LoaiHang = string.Empty; // co the bo
                Chuoi = "Khong tim thay san pham";
            }
            coLoaiHang = (lh != null);
        }
        public void OnPost()
        {
            string? oldLh = XL_LoaiHang.DocLoaiHang(Index);
            string newLh = LoaiHangSua;
            bool kq = XL_LoaiHang.SuaLoaiHang(Index, newLh);
            if (kq)
            {
                XL_MatHang.SuaMatHangTheoLoaiHang(oldLh, newLh);
                Response.Redirect("/MH_LoaiHang");
            }
            Chuoi = $"Modify the category: {kq}";
        }
    }
}

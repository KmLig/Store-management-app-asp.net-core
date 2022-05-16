using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;

namespace DoAn_KTLT_2022.Pages
{
    public class MH_XoaSanPhamModel : PageModel
    {
        public MATHANG SanPham;
        public string Chuoi;
        public bool coSanPham;

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }        
        public void OnGet()
        {
            MATHANG? sp = XL_MatHang.DocMatHang(Id);
            if (sp != null)
            {
                SanPham = sp.Value;
            }
            else
            {
                SanPham = new MATHANG(); // co the bo
                Chuoi = "Khong tim thay san pham";
            }
            coSanPham = (sp != null);
        }
        public void OnPost()
        {
            bool kq = XL_MatHang.XoaMatHang(Id);
            Chuoi = $"Ket qua la {kq}";
            //quay lai man hinh danh sach san pham
            Response.Redirect("/MH_MatHang");
            
        }
    }
}

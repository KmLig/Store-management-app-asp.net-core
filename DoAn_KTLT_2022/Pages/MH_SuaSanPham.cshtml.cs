using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;

namespace DoAn_KTLT_2022.Pages
{
    public class MH_SuaSanPhamModel : PageModel
    {
        public MATHANG SanPham;
        public string Chuoi;
        public bool coSanPham;

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
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
            bool kq = XL_MatHang.SuaMatHang(Id, TenMH, HanSD, CtySX, NgaySX, LoaiHang, Gia );
            Chuoi = $"Modify a product: {kq}";
            //quay lai man hinh danh sach san pham
            if (kq)
            {
                Response.Redirect("/MH_MatHang");

            }
        }
    }
}

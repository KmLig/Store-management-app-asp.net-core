using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;
using DoAn_KTLT_2022.Entities;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_MatHangModel : PageModel
    {
        public List<MATHANG> dsSanPham;
        [BindProperty]
        public string SearchLoaiHang { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string ID { get; set; }
        [BindProperty]
        public string? TuKhoa { get; set; }
        
        public void OnGet()
        {
            dsSanPham = XL_MatHang.TimKiem(string.Empty);
        }
        public void OnPost()
        {
            dsSanPham = XL_MatHang.TimKiem(TuKhoa);
            if (!string.IsNullOrEmpty(SearchLoaiHang))
            {
                dsSanPham = XL_MatHang.TimKiem(string.Empty);
                dsSanPham = XL_MatHang.TimKiemTheoLoaiHang(SearchLoaiHang);
            }            
        }
    }
}

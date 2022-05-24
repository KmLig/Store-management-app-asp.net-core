using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;
using DoAn_KTLT_2022.Entities;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_ThongKe_HetHanModel : PageModel
    {
        public List<MATHANG> dsSanPham;
        public string ConHan;
        public string HetHan;
        [BindProperty]
        public string SearchHSD { get; set; }
        [BindProperty]
        public string SearchLoaiHang { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string ID { get; set; }
        [BindProperty]
        public string? TuKhoa { get; set; }

        public void OnGet()
        {
            dsSanPham = XL_MatHang.TimKiem(string.Empty);
            ConHan = string.Empty;
            HetHan = string.Empty;
        }
        public void OnPost()
        {
            dsSanPham = XL_MatHang.TimKiem(TuKhoa);
            
            if (SearchHSD == "conHSD")
            {
                dsSanPham = XL_HetHan.TimConHSD();
                ConHan = "OK";
            }
            else if (SearchHSD == "hetHSD")
            {
                dsSanPham = XL_HetHan.TimHetHSD();
                HetHan = "Expired";
            }
            else
            {
                dsSanPham = XL_MatHang.TimKiem(string.Empty);
            }

            if (!string.IsNullOrEmpty(SearchLoaiHang))
            {
                dsSanPham = XL_MatHang.TimKiem(string.Empty);
                dsSanPham = XL_MatHang.TimKiemTheoLoaiHang(SearchLoaiHang);
            }
        }
    }
}

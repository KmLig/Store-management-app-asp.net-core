using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_LoaiHangModel : PageModel
    {
        public List<string> dsLoaiHang;
        //[BindProperty(SupportsGet = true)]
        //public string ID { get; set; }
        public int[] countMH;
        [BindProperty]
        public string TuKhoa { get; set; }
        
        public void OnGet()
        {
            dsLoaiHang = XL_LoaiHang.TimKiemLoaiHang(string.Empty);
            countMH = XL_LoaiHang.DemSoLuongMatHang(dsLoaiHang);
        }
        public void OnPost()
        {
            dsLoaiHang = XL_LoaiHang.TimKiemLoaiHang(TuKhoa);
            countMH = XL_LoaiHang.DemSoLuongMatHang(dsLoaiHang);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_HoaDon_BanHangModel : PageModel
    {
        public List<HOADON> dsHoaDon;
        //[BindProperty(SupportsGet = true)]
        //public string ID { get; set; }
        public int[] countMH;
        [BindProperty]
        public string TuKhoa { get; set; }
        
        public void OnGet()
        {
            dsHoaDon = XL_HoaDon_BanHang.TimKiemHoaDon(string.Empty);
            //countMH = XL_HoaDon.DemSoLuongMatHang(dsHoaDon);
        }
        public void OnPost()
        {
            dsHoaDon = XL_HoaDon_BanHang.TimKiemHoaDon(TuKhoa);
            //countMH = XL_LoaiHang.DemSoLuongMatHang(dsHoaDon);
        }
    }
}

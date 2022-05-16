using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;

namespace DoAn_KTLT_2022.Pages
{
    public class MH_XoaHoaDonModel : PageModel
    {
        public HOADON HoaDon;
        public string Chuoi;
        public bool coHoaDon;

        [BindProperty(SupportsGet = true)]
        public string Index { get; set; }        
        public void OnGet()
        {
            HOADON? sp = XL_HoaDon.DocHoaDon(Index);
            if (sp != null)
            {
                HoaDon = sp.Value;
            }
            else
            {
                HoaDon = new HOADON(); // co the bo
                Chuoi = "Khong tim thay san pham";
            }
            coHoaDon = (sp != null);
        }
        public void OnPost()
        {
            bool kq = XL_HoaDon.XoaHoaDon(Index);
            Chuoi = $"Ket qua la {kq}";
            //quay lai man hinh danh sach san pham
            Response.Redirect("/MH_HoaDon_NhapHang");
            
        }
    }
}

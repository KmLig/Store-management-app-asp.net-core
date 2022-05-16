using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;

namespace DoAn_KTLT_2022.Pages
{
    public class MH_XoaLoaiHangModel : PageModel
    {
        public string LoaiHang;
        public string Chuoi;
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
            string? ktLoaiHang = XL_LoaiHang.DocLoaiHang(Index);
            bool coMatHang = XL_LoaiHang.KiemTraDaCoMatHang(ktLoaiHang);
            if (!coMatHang)
            {
                bool kq = XL_LoaiHang.XoaLoaiHang(Index);
                Chuoi = $"Ket qua la {kq}";
                //quay lai man hinh danh sach san pham
                Response.Redirect("/MH_LoaiHang");
            }
            else
            {
                Chuoi = $"Khong the xoa loai hang {ktLoaiHang} vi da co mat hang, vui long sua mat hang truoc!";
            }
           
            
        }
    }
}

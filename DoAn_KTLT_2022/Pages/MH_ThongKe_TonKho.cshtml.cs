using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.Services;
using DoAn_KTLT_2022.Entities;


namespace DoAn_KTLT_2022.Pages
{
    public class MH_ThongKe_TonKhoModel : PageModel
    {
        public List<MATHANG>? dsSanPham;
        public int[] Nhap;
        public int[] Xuat;
        public int[] TonKho;
        [BindProperty]
        public string? SearchLoaiHang { get; set; }
        [BindProperty]
        public string SearchTonKho { get; set; } 
        //[BindProperty(SupportsGet = true)]
        //public string ID { get; set; }
        [BindProperty]
        public string? TuKhoa { get; set; }
        
        public void OnGet()
        {
            dsSanPham = XL_MatHang.TimKiem(string.Empty);            
            Nhap = XL_TonKho.KiemTraSLNhap(dsSanPham);
            Xuat = XL_TonKho.KiemTraSLXuat(dsSanPham);
            TonKho = XL_TonKho.KiemTraTonKho(Nhap, Xuat);
        }
        public void OnPost()
        {
            dsSanPham = XL_MatHang.TimKiem(TuKhoa);
            Nhap = XL_TonKho.KiemTraSLNhap(dsSanPham);
            Xuat = XL_TonKho.KiemTraSLXuat(dsSanPham);
            TonKho = XL_TonKho.KiemTraTonKho(Nhap, Xuat);
            if (SearchTonKho == "ConHang")
            {
                dsSanPham = XL_TonKho.ConHang(TonKho);
                Nhap = XL_TonKho.KiemTraSLNhap(dsSanPham);
                Xuat = XL_TonKho.KiemTraSLXuat(dsSanPham);
                TonKho = XL_TonKho.KiemTraTonKho(Nhap, Xuat);
            }
            else if (SearchTonKho == "HetHang")
            {
                dsSanPham = XL_TonKho.HetHang(TonKho);
                Nhap = XL_TonKho.KiemTraSLNhap(dsSanPham);
                Xuat = XL_TonKho.KiemTraSLXuat(dsSanPham);
                TonKho = XL_TonKho.KiemTraTonKho(Nhap, Xuat);
            }            

            if (!string.IsNullOrEmpty(SearchLoaiHang))
            {
                dsSanPham = XL_MatHang.TimKiem(string.Empty);
                dsSanPham = XL_MatHang.TimKiemTheoLoaiHang(SearchLoaiHang);
                Nhap = XL_TonKho.KiemTraSLNhap(dsSanPham);
                Xuat = XL_TonKho.KiemTraSLXuat(dsSanPham);
                TonKho = XL_TonKho.KiemTraTonKho(Nhap, Xuat);
            }            
        }
    }
}

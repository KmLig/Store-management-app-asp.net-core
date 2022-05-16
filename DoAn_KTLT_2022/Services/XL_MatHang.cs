using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.DAL;
namespace DoAn_KTLT_2022.Services
{
    public class XL_MatHang
    {
        public static bool TaoMatHang(MATHANG A)
        {
            // kiem tra tinh hop le cua san pham
            if (string.IsNullOrWhiteSpace(A.MaMH) || 
                string.IsNullOrWhiteSpace(A.TenMH) ||                
                string.IsNullOrWhiteSpace(A.CtySX) ||
                string.IsNullOrWhiteSpace(A.LoaiHang) ||
                A.Gia <= 0)
            {
                return false;
            }
            // luu san pham            
            return LuuTruSanPham.Luu(A); 
        } 
        public static List<MATHANG> TimKiem(string tuKhoa)
        {
            if (tuKhoa == null) tuKhoa = string.Empty;
            List<MATHANG> dssp = LuuTruSanPham.DocDanhSachSanPham();
            List<MATHANG> kq = new List<MATHANG>();
            foreach(MATHANG sp in dssp)
            {
                if (sp.TenMH.Contains(tuKhoa))
                {
                    kq.Add(sp);
                }
            }
            return kq;
        }
        public static List<MATHANG> TimKiemTheoLoaiHang(string tuKhoa)
        {
            if (tuKhoa == null) tuKhoa = string.Empty;
            List<MATHANG> dssp = LuuTruSanPham.DocDanhSachSanPham();
            List<MATHANG> kq = new List<MATHANG>();
            foreach (MATHANG sp in dssp)
            {
                if (sp.LoaiHang.Contains(tuKhoa))
                {
                    kq.Add(sp);
                }
            }
            return kq;
        }

        public static MATHANG? DocMatHang(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            List<MATHANG> dssp = LuuTruSanPham.DocDanhSachSanPham();
            foreach(MATHANG sp in dssp)
            {
                if(sp.MaMH == id)
                {
                    return sp;
                }
            }
            return null;
        }
        
        public static bool SuaMatHang(string id, string tenMH, DateTime hanSD, string ctySX, DateTime ngaySX, string loaiHang, int gia)
        {
            if(string.IsNullOrEmpty(id) || 
                string.IsNullOrEmpty(tenMH) || 
                hanSD < ngaySX ||
                string.IsNullOrEmpty(ctySX) || 
                string.IsNullOrEmpty(loaiHang) || 
                gia <= 0)
            {
                return false;
            }
            MATHANG? sp = DocMatHang(id);
            if (sp != null)
            {
                MATHANG spMoi;
                spMoi.MaMH = id;
                spMoi.TenMH = tenMH;
                spMoi.HanSD = hanSD;
                spMoi.CtySX = ctySX;
                spMoi.NgaySX = ngaySX;
                spMoi.LoaiHang = loaiHang;
                spMoi.Gia = gia;
                LuuTruSanPham.Sua(spMoi);
                return true;
            }            
            return false;
        }
        
        public static bool XoaMatHang(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            MATHANG? sp = DocMatHang(id);
            if (sp != null)
            {
                LuuTruSanPham.Xoa(id);
                return true;
            }
            return false;
        }
        public static bool SuaMatHangTheoLoaiHang(string loaiHangCu,string loaiHangMoi)
        {
            if (string.IsNullOrEmpty(loaiHangMoi))
            {
                return false;
            }
            return LuuTruSanPham.SuaTheoLoaiHang(loaiHangCu,loaiHangMoi);
        }

    }
}

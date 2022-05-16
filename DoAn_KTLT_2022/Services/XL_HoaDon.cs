using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.DAL;
namespace DoAn_KTLT_2022.Services
{
    public class XL_HoaDon
    {
        public static bool TaoHoaDon(HOADON A)
        {
            if (string.IsNullOrWhiteSpace(A.MaHD) ||
                string.IsNullOrWhiteSpace(A.MaMH) ||               
                A.Gia <= 0 || A.SL <= 0 || A.ThanhTien <= 0)
            {
                return false;
            }
            //luu
            List<HOADON> dsHoaDon = LuuTruHoaDon.DocDanhSachHoaDon();
            //Kiem tra trung loai hang
            foreach (HOADON hd in dsHoaDon)
            {
                if (hd.MaHD == A.MaHD)
                {
                    return false;
                }
            }
            return LuuTruHoaDon.Luu(A);
        }

        public static List<HOADON> TimKiemHoaDon(string tuKhoa)
        {
            if (tuKhoa == null) tuKhoa = string.Empty;
            List<HOADON> dsHoaDon = LuuTruHoaDon.DocDanhSachHoaDon();
            List<HOADON> kq = new List<HOADON>();
            foreach (HOADON hd in dsHoaDon)
            {
                if (hd.MaHD.Contains(tuKhoa))
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }
        public static HOADON? DocHoaDon(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            List<HOADON> dsHD = LuuTruHoaDon.DocDanhSachHoaDon();
            foreach (HOADON hd in dsHD)
            {
                if (hd.MaHD == id)
                {
                    return hd;
                }
            }
            return null;
        }
        public static bool XoaHoaDon(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            HOADON? hd = DocHoaDon(id);
            if (hd != null)
            {
                LuuTruHoaDon.Xoa(id);
                return true;
            }
            return false;
        }
    }
}

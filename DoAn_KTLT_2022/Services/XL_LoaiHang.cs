using DoAn_KTLT_2022.DAL;
using DoAn_KTLT_2022.Entities;
namespace DoAn_KTLT_2022.Services
{
    public class XL_LoaiHang
    {
        public static bool TaoLoaiHang(string newLoaiHang)
        {
            if (string.IsNullOrEmpty(newLoaiHang))
            {
                return false;
            }
            //luu
            List<string> dsLoaiHang = LuuTruLoaiHang.DocDanhSachLoaiHang();
            //Kiem tra trung loai hang
            foreach (string lh  in dsLoaiHang)
            {
                if (lh == newLoaiHang)
                {
                    return false;
                }
            }
            return LuuTruLoaiHang.Luu(newLoaiHang);
        }
        public static List<string> TimKiemLoaiHang(string tuKhoa)
        {
            if (tuKhoa == null) tuKhoa = string.Empty;
            List<string> dslh = LuuTruLoaiHang.DocDanhSachLoaiHang();
            List<string> kq = new List<string>();
            foreach(string lh in dslh)  
            {
                if (lh.Contains(tuKhoa))
                {
                    kq.Add(lh);
                }
            }
            return kq;
        }
        public static string? DocLoaiHang(int index)
        {
            List<string> dsLoaiHang = LuuTruLoaiHang.DocDanhSachLoaiHang();
            if (index < 0 || index > dsLoaiHang.Count - 1)
            {
                return null;
            }
            return dsLoaiHang[index];     
        }
        public static bool XoaLoaiHang(int index)
        {
            List<string> dsLoaiHang = LuuTruLoaiHang.DocDanhSachLoaiHang();
            if (index < 0 || index > dsLoaiHang.Count - 1)
            {
                return false;
            }
            string? sp = DocLoaiHang(index);
            if (sp != null)
            {
                LuuTruLoaiHang.Xoa(index);
                return true;
            }
            return false;
        }
        public static bool KiemTraDaCoMatHang(string loaiHang)
        {
            if (string.IsNullOrEmpty(loaiHang))
            {
                return false;
            }
            List<MATHANG> dsMH = LuuTruSanPham.DocDanhSachSanPham();
            foreach (MATHANG m in dsMH)
            {
                if (m.LoaiHang == loaiHang)
                {
                    return true;
                }
            }
            return false;
        }
        public static int[] DemSoLuongMatHang(List<string> dsLoaiHang)
        {
            int[] count = new int[dsLoaiHang.Count];
            List<MATHANG> dsMH = LuuTruSanPham.DocDanhSachSanPham();
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                count[i] = 0;
                
                for (int j = 0; j < dsMH.Count; j++)
                {
                    if (dsMH[j].LoaiHang == dsLoaiHang[i])
                    {
                        count[i]++;
                    }
                }
            }            
            return count;
        }        

        public static bool SuaLoaiHang(int id, string loaiHangSua)
        {
            List<string> dsLoaiHang = LuuTruLoaiHang.DocDanhSachLoaiHang();
            if (id < 0 || id > dsLoaiHang.Count - 1 || string.IsNullOrEmpty(loaiHangSua))
            {
                return false;
            }
            dsLoaiHang[id] = loaiHangSua;
            LuuTruLoaiHang.LuuDanhSachLoaiHang(dsLoaiHang);
            return true;
        }
    }
}

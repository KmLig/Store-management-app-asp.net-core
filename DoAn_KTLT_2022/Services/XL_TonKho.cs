using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.DAL;

namespace DoAn_KTLT_2022.Services
{
    public class XL_TonKho
    {
        public static int[] KiemTraSLNhap(List<MATHANG> dssp)        {
            
            List<HOADON> dshdNhap = LuuTruHoaDon_NhapHang.DocDanhSachHoaDon();
            int[] SLNhap = new int[dssp.Count];
            for (int i = 0; i < dssp.Count; i++)
            {
                for (int j = 0; j < dshdNhap.Count; j++)
                {
                    for (int k = 0; k < dshdNhap[j].SanPham.Count; k++)
                    {
                        if (dssp[i].MaMH == dshdNhap[j].SanPham[k].MaMH)
                        {
                            SLNhap[i] += dshdNhap[j].SanPham[k].SL;
                        }
                        else
                        {
                            SLNhap[i] += 0;
                        }
                    }
                }
            }
            return SLNhap;
        }
        public static int[] KiemTraSLXuat(List<MATHANG> dssp)
        {            
            List<HOADON> dshdBan = LuuTruHoaDon_BanHang.DocDanhSachHoaDon();
            int[] SLBan = new int[dssp.Count];
            for (int i = 0; i < dssp.Count; i++)
            {
                for (int j = 0; j < dshdBan.Count; j++)
                {
                    for (int k = 0; k < dshdBan[j].SanPham.Count; k++)
                    {
                        if (dssp[i].MaMH == dshdBan[j].SanPham[k].MaMH)
                        {
                            SLBan[i] += dshdBan[j].SanPham[k].SL;
                        }
                        else
                        {
                            SLBan[i] += 0;
                        }
                    }                    
                }
            }
            return SLBan;
        }
        public static int[] KiemTraTonKho(int[] Nhap, int[] Xuat)
        {
            int[] TonKho = new int[Nhap.Length];
            for (int i = 0; i < Nhap.Length; i++)
            {
                TonKho[i] = Nhap[i] - Xuat[i];
            }
            return TonKho;
        }

        public static List<MATHANG> ConHang(int[] TonKho)
        {
            List<MATHANG> dssm = LuuTruSanPham.DocDanhSachSanPham();
            List<MATHANG> dssmConHang = new List<MATHANG>();
            for (int i = 0; i < TonKho.Length; i++)
            {
                if (TonKho[i] > 0)
                {
                    dssmConHang.Add(dssm[i]);
                }
            }
            return dssmConHang;
        }

        public static List<MATHANG> HetHang(int[] TonKho)
        {
            List<MATHANG> dssm = LuuTruSanPham.DocDanhSachSanPham();
            List<MATHANG> dssmHetHang = new List<MATHANG>();
            for (int i = 0; i < TonKho.Length; i++)
            {
                if(TonKho[i] == 0)
                {
                    dssmHetHang.Add(dssm[i]);
                }
            }
            return dssmHetHang;
        }
    }
}

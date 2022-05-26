﻿using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.DAL;
namespace DoAn_KTLT_2022.Services
{
    public class XL_HoaDon_NhapHang
    {
        public static bool TaoHoaDon(HOADON A)
        {
            if (string.IsNullOrWhiteSpace(A.MaHD) ||
                !KiemTraThieuMatHangHoaDon(A.SanPham) ||    
               A.ThanhTien <= 0)
            {
                return false;
            }
            //luu
            List<HOADON> dsHoaDon = LuuTruHoaDon_NhapHang.DocDanhSachHoaDon();
            //Kiem tra trung loai hang
            foreach (HOADON hd in dsHoaDon)
            {
                if (hd.MaHD == A.MaHD)
                {
                    return false;
                }
            }
            ThemVaoTonKho(A.SanPham);
            return LuuTruHoaDon_NhapHang.Luu(A);
        }        

        public static List<HOADON> TimKiemHoaDon(string tuKhoa)
        {
            if (tuKhoa == null) tuKhoa = string.Empty;
            List<HOADON> dsHoaDon = LuuTruHoaDon_NhapHang.DocDanhSachHoaDon();
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
        public static bool ThemVaoTonKho(List<MATHANGHOADON> sp)
        {
            List<MATHANG> dssp = LuuTruSanPham.DocDanhSachSanPham();
            for (int i = 0; i < dssp.Count; i++)
            {
                for (int j = 0; j < sp.Count; j++)
                {
                    if(dssp[i].MaMH == sp[j].MaMH)
                    {
                        MATHANG newMH = dssp[i];
                        newMH.TonKho = sp[j].SL;
                        dssp[i] = newMH;
                    }
                }
            }
            LuuTruSanPham.LuuDanhSachSanPham(dssp);
            return true;
        }
        
        public static HOADON? DocHoaDon(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            List<HOADON> dsHD = LuuTruHoaDon_NhapHang.DocDanhSachHoaDon();
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
                LuuTruHoaDon_NhapHang.Xoa(id);
                return true;
            }
            return false;
        }
        public static bool KiemTraThieuMatHangHoaDon(List<MATHANGHOADON> Sp)
        {
            for (int i = 0; i < Sp.Count; i++)
            {
                if(string.IsNullOrEmpty(Sp[i].MaMH) ||
                    string.IsNullOrEmpty(Sp[i].TenMH) ||
                    Sp[i].Gia <= 0 ||
                    Sp[i].SL <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool SuaHoaDon(string MaHD, List<MATHANGHOADON> Sp, DateTime NgayLap, int ThanhTien)
        {
            if (string.IsNullOrEmpty(MaHD) ||
                !KiemTraThieuMatHangHoaDon(Sp) ||
                ThanhTien <= 0)
            {
                return false;
            }
            HOADON? hd = DocHoaDon(MaHD);
            if (hd != null)
            {
                HOADON hdMoi;
                hdMoi.MaHD = MaHD;
                hdMoi.SanPham = Sp;                
                hdMoi.NgayLap = NgayLap;
                hdMoi.ThanhTien = ThanhTien;
                LuuTruHoaDon_NhapHang.Sua(hdMoi);
                return true;
            }
            return false;
        }
    }
}

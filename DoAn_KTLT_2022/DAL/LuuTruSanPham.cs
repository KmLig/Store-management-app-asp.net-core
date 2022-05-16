using DoAn_KTLT_2022.Entities;
using Newtonsoft.Json;

namespace DoAn_KTLT_2022.DAL
{
    public class LuuTruSanPham
    {
        public static bool Luu(MATHANG A)
        {
            List<MATHANG> danhSachSanPham = DocDanhSachSanPham();
            danhSachSanPham.Add(A);
            LuuDanhSachSanPham(danhSachSanPham);

            return true;
        }

        public static List<MATHANG> DocDanhSachSanPham()
        {
            StreamReader reader = new StreamReader("D:\\CN-CNTT-FS\\HK2\\Kỹ thuật lập trình\\Đồ án\\DoAn_KTLT_2022\\DoAn_KTLT_2022\\bin\\Data\\MatHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<MATHANG> danhSachSanPham = JsonConvert.DeserializeObject<List<MATHANG>>(jsonString);
            return danhSachSanPham;
        }

        public static bool LuuDanhSachSanPham(List<MATHANG> danhSachSanPham)
        {
            StreamWriter writer = new StreamWriter("D:\\CN-CNTT-FS\\HK2\\Kỹ thuật lập trình\\Đồ án\\DoAn_KTLT_2022\\DoAn_KTLT_2022\\bin\\Data\\MatHang.json");
            string jsonString = JsonConvert.SerializeObject(danhSachSanPham);
            writer.WriteLine(jsonString);
            writer.Close();

            return true;
        }

        public static bool Sua(MATHANG s)
        {
            List<MATHANG> dssp = DocDanhSachSanPham();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].MaMH == s.MaMH)
                {
                    dssp[i] = s;
                    LuuDanhSachSanPham(dssp);
                    return true;
                }
            }
            return false;
        }
        public static bool SuaTheoLoaiHang(string loaiHangCu, string loaiHangMoi)
        {
            int counter = 0;
            string test = "";
            List<MATHANG> dsMH = DocDanhSachSanPham();
            for (int i = 0; i < dsMH.Count; i++)
            {
                if (dsMH[i].LoaiHang == loaiHangCu)
                {
                    MATHANG spSua = dsMH[i];
                    spSua.LoaiHang = loaiHangMoi;
                    test = spSua.LoaiHang;
                    dsMH[i] = spSua;
                    counter ++;
                }
            }
            if (counter > 0)
            {
                LuuDanhSachSanPham(dsMH);
                return true;
            }            
            return false;
        }

        public static bool Xoa(string id)
        {
            List<MATHANG> dssp = DocDanhSachSanPham();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].MaMH == id)
                {
                    dssp.RemoveAt(i);
                    LuuDanhSachSanPham(dssp);
                    return true;
                }
            }
            return false;
        }
    }
}

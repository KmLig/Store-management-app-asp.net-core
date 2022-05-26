using DoAn_KTLT_2022.Entities;
using Newtonsoft.Json;

namespace DoAn_KTLT_2022.DAL
{
    public class LuuTruHoaDon_NhapHang
    {
        public static bool Luu(HOADON A)
        {
            List<HOADON> danhSachHoaDon = DocDanhSachHoaDon();
            danhSachHoaDon.Add(A);
            LuuDanhSachHoaDon(danhSachHoaDon);

            return true;
        }

        public static List<HOADON> DocDanhSachHoaDon()
        {
            string deskDir = Environment.CurrentDirectory + "\\bin\\Data";
            string filePath_Read = $"{deskDir}\\HoaDon_NhapHang.json";
            StreamReader reader = new StreamReader(filePath_Read);
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<HOADON> danhSachSanPham = JsonConvert.DeserializeObject<List<HOADON>>(jsonString);
            return danhSachSanPham;
        }

        public static bool LuuDanhSachHoaDon(List<HOADON> danhSachHoaDon)
        {
            string deskDir = Environment.CurrentDirectory + "\\bin\\Data";
            string filePath_Read = $"{deskDir}\\HoaDon_NhapHang.json";
            StreamWriter writer = new StreamWriter(filePath_Read);
            string jsonString = JsonConvert.SerializeObject(danhSachHoaDon);
            writer.WriteLine(jsonString);
            writer.Close();

            return true;
        }

        public static bool Xoa(string id)
        {
            List<HOADON> dsHD = DocDanhSachHoaDon();
            for (int i = 0; i < dsHD.Count; i++)
            {
                if (dsHD[i].MaHD == id)
                {
                    dsHD.RemoveAt(i);
                    LuuDanhSachHoaDon(dsHD);
                    return true;
                }
            }
            return false;
        }

        public static bool Sua(HOADON hd)
        {
            List<HOADON> dshd = DocDanhSachHoaDon();
            for (int i = 0; i < dshd.Count; i++)
            {
                if (dshd[i].MaHD == hd.MaHD)
                {
                    dshd[i] = hd;
                    LuuDanhSachHoaDon(dshd);
                    return true;
                }
            }
            return false;
        }
    }
}

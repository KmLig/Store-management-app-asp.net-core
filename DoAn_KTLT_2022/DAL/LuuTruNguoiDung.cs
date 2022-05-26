using DoAn_KTLT_2022.Entities;
using Newtonsoft.Json;

namespace DoAn_KTLT_2022.DAL
{
    public class LuuTruNguoiDung
    {
        public static bool ThemNguoiDung(NGUOIDUNG A)
        {
            List<NGUOIDUNG> danhSachNguoiDung = DocDanhSachNguoiDung();
            danhSachNguoiDung.Add(A);
            LuuDanhSachNguoiDung(danhSachNguoiDung);

            return true;
        }

        public static List<NGUOIDUNG> DocDanhSachNguoiDung()
        {
            string deskDir = Environment.CurrentDirectory + "\\bin\\Data";
            string filePath_Read = $"{deskDir}\\NguoiDung.json";
            StreamReader reader = new StreamReader(filePath_Read);
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<NGUOIDUNG> danhSachNguoiDung = JsonConvert.DeserializeObject<List<NGUOIDUNG>>(jsonString);
            return danhSachNguoiDung;
        }

        public static bool LuuDanhSachNguoiDung(List<NGUOIDUNG> danhSachNguoiDung)
        {
            string deskDir = Environment.CurrentDirectory + "\\bin\\Data";
            string filePath_Read = $"{deskDir}\\NguoiDung.json";
            StreamWriter writer = new StreamWriter(filePath_Read);
            string jsonString = JsonConvert.SerializeObject(danhSachNguoiDung);
            writer.WriteLine(jsonString);
            writer.Close();

            return true;
        }

        public static bool Sua(NGUOIDUNG s)
        {
            List<NGUOIDUNG> dssp = DocDanhSachNguoiDung();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].UserName == s.UserName)
                {
                    dssp[i] = s;
                    LuuDanhSachNguoiDung(dssp);
                    return true;
                }
            }
            return false;
        }

        public static bool Xoa(string id)
        {
            List<NGUOIDUNG> dssp = DocDanhSachNguoiDung();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].UserName == id)
                {
                    dssp.RemoveAt(i);
                    LuuDanhSachNguoiDung(dssp);
                    return true;
                }
            }
            return false;
        }
        public static NGUOIDUNG? TimNguoiDung(string userName)
        {
            List<NGUOIDUNG> dsnd = DocDanhSachNguoiDung();
            for (int i = 0; i < dsnd.Count; i++)
            {
                if (dsnd[i].UserName == userName)
                {                    
                    return dsnd[i];
                }
            }
            return null;
        }
    }
}

using Newtonsoft.Json;

namespace DoAn_KTLT_2022.DAL
{
    public class LuuTruLoaiHang
    {
        public static bool Luu(string loaiHang)
        {
            List<string> dsLoaiHang = DocDanhSachLoaiHang();
            dsLoaiHang.Add(loaiHang);
            LuuDanhSachLoaiHang(dsLoaiHang);

            return true;    
        }

        public static List<string> DocDanhSachLoaiHang()
        {
            string deskDir = Environment.CurrentDirectory + "\\bin\\Data";
            string filePath_Read = $"{deskDir}\\LoaiHang.json";
            StreamReader reader = new StreamReader(filePath_Read);
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<string> dsLoaiHang = JsonConvert.DeserializeObject<List<string>>(jsonString);
            return dsLoaiHang;
        }

        public static bool LuuDanhSachLoaiHang(List<string> dsLoaiHang)
        {
            string deskDir = Environment.CurrentDirectory + "\\bin\\Data";
            string filePath_Read = $"{deskDir}\\LoaiHang.json";
            StreamWriter writer = new StreamWriter(filePath_Read);
            string jsonString = JsonConvert.SerializeObject(dsLoaiHang);
            writer.WriteLine(jsonString);
            writer.Close();

            return true;
        }

        public static bool Xoa(int index)
        {
            List<string> dsLoaiHang = DocDanhSachLoaiHang();
            dsLoaiHang.RemoveAt(index);
            LuuDanhSachLoaiHang(dsLoaiHang);
            return true;
        }
    }
}

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
            StreamReader reader = new StreamReader("D:\\CN-CNTT-FS\\HK2\\Kỹ thuật lập trình\\Đồ án\\DoAn_KTLT_2022\\DoAn_KTLT_2022\\bin\\Data\\LoaiHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<string> dsLoaiHang = JsonConvert.DeserializeObject<List<string>>(jsonString);
            return dsLoaiHang;
        }

        public static bool LuuDanhSachLoaiHang(List<string> dsLoaiHang)
        {
            StreamWriter writer = new StreamWriter("D:\\CN-CNTT-FS\\HK2\\Kỹ thuật lập trình\\Đồ án\\DoAn_KTLT_2022\\DoAn_KTLT_2022\\bin\\Data\\LoaiHang.json");
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

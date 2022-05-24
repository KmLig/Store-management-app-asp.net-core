using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.DAL;
namespace DoAn_KTLT_2022.Services
{
    public class XL_HetHan
    {
        public static List<MATHANG> TimConHSD()
        {
            List<MATHANG> dssp = LuuTruSanPham.DocDanhSachSanPham();
            List<MATHANG> dsspConHSD = new List<MATHANG>();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].HanSD > DateTime.Now)
                {
                    dsspConHSD.Add(dssp[i]);
                }
            }
            return dsspConHSD;
        }
        public static List<MATHANG> TimHetHSD()
        {
            List<MATHANG> dssp = LuuTruSanPham.DocDanhSachSanPham();
            List<MATHANG> dsspHetHSD = new List<MATHANG>();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].HanSD < DateTime.Now)
                {
                    dsspHetHSD.Add(dssp[i]);
                }
            }
            return dsspHetHSD;
        }
    }
}

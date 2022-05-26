namespace DoAn_KTLT_2022.Entities
{
    public struct HOADON
    {
        public string MaHD;
        public List<MATHANGHOADON> SanPham;// Mã, Tên, Số lượng, Giá 
        public DateTime NgayLap;
        public int ThanhTien;
    }
}

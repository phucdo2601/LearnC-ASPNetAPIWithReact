using System;

namespace MyWebAPIApp.Data
{
    public class DonHangChiTiet
    {
        public Guid MaDh { get; set; }
        public Guid MaHh { get; set; }

        public int SoLuong { get; set; }

        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        //Relationship with the parent table DonHang, HangHoa
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }
    }
}

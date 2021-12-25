using System;
using System.Collections.Generic;

namespace MyWebAPIApp.Data
{
    public enum TinhTrangDonDatHang
    {
        New = 0,
        Payment = 1,
        Complete = 2,
        Cancel = -1
    }

    public class DonHang
    {
        public Guid  MaDH { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public int TinhTrangDonHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDienThoai { get; set; }
        public double TongTien { get; set; }

        // Relationship with the child table - DonHangChiTiet
        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        //tra DonHangChiTiets la mot mang rong 
        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();

        }
    }
}

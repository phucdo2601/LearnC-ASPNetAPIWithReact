using System;

namespace MyWebAPIApp.Models
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }

    }

    public class HangHoa : HangHoaVM
    {
        // Kieu khi them nhieu phan tu trong c#, kieu Guid
       public Guid MaHangHoa { get; set; }

    }
}

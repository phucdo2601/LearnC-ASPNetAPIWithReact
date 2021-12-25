using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPIApp.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHh { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenHh { get; set; }
        public string MoTa { get; set; }  
        
        [Range(0,double.MaxValue)]
        public double DonGia { get; set; }

        public byte GiamGia { get; set; }

        //gan rang buot khoa ngoai cho san pham
        public int? MaLoai { get; set; }
        [ForeignKey(name: "MaLoai")]
        public Loai Loai { get; set; }

        // Relationship with the child table - DonHangChiTiet
        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        //tra DonHangChiTiets la mot mang rong 
        public HangHoa()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();

        }
    }
}

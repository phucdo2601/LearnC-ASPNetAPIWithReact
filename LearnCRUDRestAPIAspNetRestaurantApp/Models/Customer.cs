using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnCRUDRestAPIAspNetRestaurantApp.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName ="nvarchar(200)")]
        public string CustomerName { get; set; }

        public List<OrderMaster> OrderMasters { get; set; }
    }
}

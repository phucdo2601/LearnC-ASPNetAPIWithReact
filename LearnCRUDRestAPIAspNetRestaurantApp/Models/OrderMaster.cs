﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnCRUDRestAPIAspNetRestaurantApp.Models
{
    [Table(name: "OrderMasters")]
    public class OrderMaster
    {
        [Key]
        public long OrderMasterId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string OrderNumber { get; set; }
        
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string PMethod { get; set; }

        public decimal GTotal { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }  
    }
}

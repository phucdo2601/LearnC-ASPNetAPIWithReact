using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnCRUDRestAPIAspNetRestaurantApp.Models
{
    [Table(name:"FoodItems")]
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; }

        [Column(name: "FoodItemName", TypeName ="nvarchar(200)")]
        public string FoodItemName { get; set; }
        [Column(name: "Price")]
        public decimal Price { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestarauntHomeTaste.Data
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DishTypesId { get; set; }
        public DishType DishTypes { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Allergens { get; set; }
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public DateTime DateUpdate { get; set; } = DateTime.Now;
       
    }
}
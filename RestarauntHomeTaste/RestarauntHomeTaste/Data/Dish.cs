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
        public DateTime DateUpdate = DateTime.Now;
       
    }
}
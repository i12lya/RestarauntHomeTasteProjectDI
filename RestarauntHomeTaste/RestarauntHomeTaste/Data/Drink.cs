namespace RestarauntHomeTaste.Data
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DrinkTypesId {  get; set; }
        public DrinkType DrinkTypes { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
        public DateTime DateUpdate { get; set; } = DateTime.Now;

    }
}

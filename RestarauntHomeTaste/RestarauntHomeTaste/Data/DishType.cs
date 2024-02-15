namespace RestarauntHomeTaste.Data
{
    public class DishType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
        public ICollection<Dish> Dishes { get; set; }
    }
}
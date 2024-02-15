namespace RestarauntHomeTaste.Data
{
    public class DrinkType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
        public ICollection<Drink> Drinks { get; set; }
    }
}
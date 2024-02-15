namespace RestarauntHomeTaste.Data
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string ImageUrl { get; set; }
        public string Descrription { get; set; }
        public int VisitorsCount {  get; set; }
        public DateTime DateUpdate { get; set; } = DateTime.Now;
        public ICollection<Reservation> Reservations { get; set; }
    }
}

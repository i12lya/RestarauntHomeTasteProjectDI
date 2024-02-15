namespace RestarauntHomeTaste.Data
{
    public class Reservation
    {
        public int Id {  get; set; }
        public string ClientsId { get; set; }
        public Client Clients { get; set; }
        public int TablesId {  get; set; }
        public Table Tables { get; set; }
        public DateTime DateReservatoion { get; set; } = DateTime.Now;
        public DateTime HourReservation { get; set; } = DateTime.Now;
        public int GuestsCount { get; set; }
        public DateTime DateUpdate { get;set; } = DateTime.Now;


    }
}
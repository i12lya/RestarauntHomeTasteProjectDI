using Microsoft.AspNetCore.Identity;

namespace RestarauntHomeTaste.Data
{
    public class Client:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateUpdate { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
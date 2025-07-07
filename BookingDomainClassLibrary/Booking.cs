using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomainClassLibrary
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ShopUser User { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime TillDate { get; set; }
        public byte? IsCanceled { get; set; }

    }
}

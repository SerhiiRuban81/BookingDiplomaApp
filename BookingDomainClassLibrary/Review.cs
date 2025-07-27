using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomainClassLibrary
{
    public class Review
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string Text { get; set; } = default!;
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public ShopUser ShopUser { get; set; } = default!;
        public string ShopUserId { get; set; } = default!;

        public int? ApartmentId { get; set; }

        public Apartment? Apartment { get; set; }


    }
}

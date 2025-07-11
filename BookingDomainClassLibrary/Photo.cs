using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomainClassLibrary
{
    public class Photo
    {
        public int Id { get; set; }
        public int ApartmentId{ get; set; }
        public Apartment Apartment { get; set; } = default!;
        public byte[] PhotoData { get; set; } = default!;
    }
}

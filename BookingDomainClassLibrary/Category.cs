using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomainClassLibrary
{
    public class Category
    {
        int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Apartment> Apartments { get; set; }

    }
}

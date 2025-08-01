﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomainClassLibrary
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public byte[] Logo { get; set; } = default!;
        public ICollection<Apartment>? Apartments { get; set; }
    }
}

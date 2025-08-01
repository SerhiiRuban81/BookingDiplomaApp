﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomainClassLibrary
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Price { get; set; }
        public City City { get; set; } = default!;
        public int CityId { get; set; }
        public Category Category { get; set; } = default!;
        public int CategoryId { get; set; }
        public string Address { get; set; } = default!;
        public int Places { get; set; }
        public int Square { get; set; }
        public int RoomsCount { get; set; }
        public double DistanceFromCenter { get; set; }
        public ICollection<Facility>? Facilities { get; set; } = default!;
        public ICollection<Photo>? Photos { get; set; } = default!;
        public ICollection<Review>? Reviews { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    [Table("Addresses")]
    public class Address
    {
        public Address() { }
        public Address(string country, string City, string street, int buildingNumber, int apartmentNumber)
        {
            Country = country;
            this.City = City;
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
        }

        [Key, Column(Order = 0)]
        public String Country {   get;    set;    }
        [Key, Column(Order = 1)]
        public String City { get; set; }
        [Key, Column(Order = 2)]
        public String Street { get; set; }
        [Key, Column(Order = 3)]
        public int BuildingNumber { get; set; }
        [Key, Column(Order = 4)]
        public int ApartmentNumber { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Country == address.Country &&
                   City == address.City &&
                   Street == address.Street &&
                   BuildingNumber == address.BuildingNumber &&
                   ApartmentNumber == address.ApartmentNumber;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, Apartment {2}, {3}, {4}",
                Street, BuildingNumber, ApartmentNumber, City, Country);
        }
    }
}

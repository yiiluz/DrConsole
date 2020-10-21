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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AddressKey { get; set; }
        public String Country { get;    set; }
        public String City { get; set; }
        public String Street { get; set; }
        public int BuildingNumber { get; set; }
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

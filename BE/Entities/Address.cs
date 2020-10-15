using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Address
    {
        private String country;
        private String city;
        private String street;
        private int buildingNumber;
        private int apartmentNumber;

        public Address(string country, string city, string street, int buildingNumber, int apartmentNumber)
        {
            this.country = country;
            this.city = city;
            this.street = street;
            this.buildingNumber = buildingNumber;
            this.apartmentNumber = apartmentNumber;
        }

        public String Country {   get;    set;    }
        public String Sity { get; set; }
        public String Street { get; set; }
        public int BuildingNumber { get; set; }
        public int ApartmentNumber { get; set; }

        public override bool Equals(object obj)
        {
            var address = obj as Address;
            return address != null &&
                   country == address.country &&
                   city == address.city &&
                   street == address.street &&
                   buildingNumber == address.buildingNumber &&
                   apartmentNumber == address.apartmentNumber;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, Apartment {2}, {3}, {4}",
                street, buildingNumber, apartmentNumber, city, country);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;
using static BE.Configurations.Enums;

namespace BE.Entities
{
    class Person
    {
        private String firstName;
        private String lastName;
        private Gender gender;
        private int id;
        private Address address;
        private DateTime birthDate;

        public Person(string firstName, string lastName, Gender gender, int id, Address address, DateTime birthDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.id = id;
            this.address = address;
            this.birthDate = birthDate;
        }


        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        public int ID { get; set; }
        public Address Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Today.Year - birthDate.Year;
            }
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   firstName == person.firstName &&
                   lastName == person.lastName &&
                   gender == person.gender &&
                   id == person.id &&
                   EqualityComparer<Address>.Default.Equals(address, person.address) &&
                   birthDate == person.birthDate;
        }

        public override string ToString()
        {
            return String.Format("Name: {0} {1}, ID: {2}, Gender: {4}, Adress: {5}, Birth Date: {6}, Age: {7}.",
                firstName, lastName, id, Gender, address, birthDate, Age);
        }
    }
}

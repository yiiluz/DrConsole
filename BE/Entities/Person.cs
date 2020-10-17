using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;
using static BE.Configurations.Enums;

namespace BE.Entities
{
    [Table("Persons")]
    public class Person
    {
        public Person(string firstName, string lastName, Gender gender, int iD, Address address, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            ID = iD;
            Address = address;
            BirthDate = birthDate;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        public Address Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Today.Year - BirthDate.Year;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   FirstName == person.FirstName &&
                   LastName == person.LastName &&
                   Gender == person.Gender &&
                   ID == person.ID &&
                   EqualityComparer<Address>.Default.Equals(Address, person.Address) &&
                   BirthDate == person.BirthDate &&
                   Age == person.Age;
        }

        public override string ToString()
        {
            return String.Format("Name: {0} {1}, ID: {2}, Gender: {4}, Adress: {5}, Birth Date: {6}, Age: {7}.",
                FirstName, LastName, ID, Gender, Address, BirthDate, Age);
        }
    }
}

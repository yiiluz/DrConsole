﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Configurations;

namespace BE.Entities
{
    [Table("Persons")]
    public class Person
    {
        public Person() { }
        public Person(string firstName, string lastName, Gender gender, String iD, Address address, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            ID = iD;
            PersonAddress = address;
            BirthDate = birthDate;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        [Key, Column(Order = 0)]
        public String ID { get; set; }
        public Address PersonAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public String FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }
        public UserType UserType { get; set; }

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
                   EqualityComparer<Address>.Default.Equals(PersonAddress, person.PersonAddress) &&
                   BirthDate == person.BirthDate &&
                   Age == person.Age;
        }

        public override string ToString()
        {
            return String.Format("Name: {0} {1}, ID: {2}, Gender: {3}, Adress: {4}, Birth Date: {5}, Age: {6}.",
                FirstName, LastName, ID, Gender, PersonAddress, BirthDate, Age);
        }
    }
}

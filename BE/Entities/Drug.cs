using BE.Configurations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    [Table("Drugs")]
    public class Drug
    {
        public Drug() { }

        public Drug(string drugName, int expirationDays, int miligram, string manufacturer, 
            DrugType drugType, string imgSrc, string active)
        {
            DrugName = drugName;
            ExpirationDays = expirationDays;
            Miligram = miligram;
            Manufacturer = manufacturer;
            DrugType = drugType;
            ImgSrc = imgSrc;
            Active = active;
        }

        [Key]
        public string DrugName { get; set; }
        public int ExpirationDays { get; set; }
        public int Miligram { get; set; }
        public string Manufacturer { get; set; }
        public DrugType DrugType { get; set; }
        public string ImgSrc { get; set; }
        public string ImgSrcFullPath 
        {
            get
            {
                return System.IO.Path.GetFullPath(ImgSrc);
            }
        }
        public string Active { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Drug drug &&
                   DrugName == drug.DrugName &&
                   ExpirationDays == drug.ExpirationDays &&
                   Miligram == drug.Miligram &&
                   Manufacturer == drug.Manufacturer &&
                   DrugType == drug.DrugType &&
                   ImgSrc == drug.ImgSrc &&
                   Active == drug.Active;
        }

        public override string ToString()
        {
            return String.Format("Drug Name: {0}, Manufacturer: {1}, Ingredient: {2}, Miligram: {3}, Image Path: {4}, Drug Type: {5}, Expiration in days: {6}.",
                DrugName, Manufacturer, Active, Miligram, ImgSrc, DrugType, ExpirationDays);
        }
    }
}

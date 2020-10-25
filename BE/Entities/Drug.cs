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

        public Drug(string drugName, int expirationDays, int miligram, string manufacturer, DrugType drugType, string imgSrc)
        {
            DrugName = drugName;
            ExpirationDays = expirationDays;
            Miligram = miligram;
            Manufacturer = manufacturer;
            DrugType = drugType;
            ImgSrc = imgSrc;
        }

        [Key]
        public string DrugName { get; set; }
        public int ExpirationDays { get; set; }
        public int Miligram { get; set; }
        public string Manufacturer { get; set; }
        public DrugType DrugType { get; set; }
        public string ImgSrc { get; set; }
        List<ActiveIngredient> ActiveIngredients { get; set; }
        public string ActiveIngredientsString
        {
            get
            {
                string ingrediants = "";
                foreach (var item in ActiveIngredients)
                {
                    ingrediants += item.ToString() + ", ";
                }
                return ingrediants.Substring(0, ingrediants.Length -2);
            }
        }

        public override string ToString()
        {
            return String.Format("Drug Name: {0}, Manufacturer: {1}, Ingredient: {2}, Miligram: {3}, Image Path: {4}, Drug Type: {5}, Expiration in days: {6}.",
                DrugName, Manufacturer, ActiveIngredientsString, Miligram, ImgSrc, DrugType, ExpirationDays);
        }
    }
}

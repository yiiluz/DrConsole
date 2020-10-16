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
        public Drug(int rxcui, string drugName, int miligram, string manufacturer, string imgSrc)
        {
            Rxcui = rxcui;
            DrugName = drugName;
            Miligram = miligram;
            Manufacturer = manufacturer;
            ImgSrc = imgSrc;
        }

        public int Rxcui { get; set; }
        [Key]
        public string DrugName { get; set; }
        public int Miligram { get; set; }
        private string Manufacturer { get; set; }
        private string ImgSrc { get; set; }

        

        public override string ToString()
        {
            return String.Format("Drug Name: {0}, Manufacturer: {1}, Ingredient: {2}, Miligram: {3}, Image Path: {4}.",
                DrugName, Manufacturer,Rxcui, Miligram, ImgSrc);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Drug
    {
        private ActiveIngredient activeIngerdient;
        private string drugName;
        private string manufacturer;
        private int miligram;
        private string imgSrc;

        public Drug(ActiveIngredient activeIngerdient, string drugName, string manufacturer, int miligram, string imgSrc)
        {
            this.activeIngerdient = activeIngerdient;
            this.drugName = drugName;
            this.manufacturer = manufacturer;
            this.miligram = miligram;
            this.imgSrc = imgSrc;
        }

        public ActiveIngredient DctiveIngerdient { get; set; }
        public string DrugName { get; set; }
        public int Miligram { get; set; }
        private string Manufacturer { get; set; }
        private string ImgSrc { get; set; }

        public override bool Equals(object obj)
        {
            var drug = obj as Drug;
            return drug != null &&
                   EqualityComparer<ActiveIngredient>.Default.Equals(activeIngerdient, drug.activeIngerdient) &&
                   drugName == drug.drugName &&
                   manufacturer == drug.manufacturer &&
                   miligram == drug.miligram &&
                   imgSrc == drug.imgSrc;
        }

        public override string ToString()
        {
            return String.Format("Drug Name: {0}, Manufacturer: {1}, Ingredient: {2}, Miligram: {3}, Image Path: {4}.",
                drugName, manufacturer,activeIngerdient, miligram, imgSrc);
        }
    }
}

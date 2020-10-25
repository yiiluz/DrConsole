using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    [Table("ActiveIngredients")]
    public class ActiveIngredient
    {
        public ActiveIngredient() { }
        public ActiveIngredient(string name, string rxcui)
        {
            Rxcui = rxcui;
            Name = name;
        }

        [Key]
        public string Rxcui { get; set; }
        public String Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ActiveIngredient ingredient &&
                   Rxcui == ingredient.Rxcui &&
                   Name == ingredient.Name;
        }

        public override string ToString()
        {
            return String.Format("Active Ingrediente: {0}, RXCUI Code: {1}.",
                Name, Rxcui);
        }
    }
}

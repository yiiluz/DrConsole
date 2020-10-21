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
        public ActiveIngredient(int rxcui, string name, string tty)
        {
            Rxcui = rxcui;
            Name = name;
            Tty = tty;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Rxcui { get; set; }
        public String Name { get; set; }
        public String Tty { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ActiveIngredient ingredient &&
                   Rxcui == ingredient.Rxcui &&
                   Name == ingredient.Name &&
                   Tty == ingredient.Tty;
        }

        public override string ToString()
        {
            return String.Format("Active Ingrediente: {0}, RXCUI Code: {1}, TTY: {2}",
                Name, Rxcui, Tty);
        }
    }
}

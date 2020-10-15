using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class ActiveIngredient
    {
        private int rxcui;
        private String name;
        private String tty;

        public ActiveIngredient(int rxcui, string name, string tty)
        {
            this.rxcui = rxcui;
            this.name = name;
            this.tty = tty;
        }

        public int Rxcui { get; set; }
        public String Name { get { return name; } set { name = value; } }
        public String Tty { get; set; }

        public override bool Equals(object obj)
        {
            var drug = obj as ActiveIngredient;
            return drug != null &&
                   rxcui == drug.rxcui &&
                   name == drug.name &&
                   tty == drug.tty;
        }

        public override string ToString()
        {
            return String.Format("Active Ingrediente: {0}, RXCUI Code: {1}, TTY: {2}",
                name, rxcui, tty);
        }
    }
}

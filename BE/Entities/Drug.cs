using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    class Drug
    {
        private int rxcui;
        private String name;
        private String tty;

        public Drug(int rxcui, string name, string tty)
        {
            this.rxcui = rxcui;
            this.name = name;
            this.tty = tty;
        }

        public int Rxcui { get; set; }
        public String Name { get; set; }
        public String Tty { get; set; }

        public override bool Equals(object obj)
        {
            var drug = obj as Drug;
            return drug != null &&
                   rxcui == drug.rxcui &&
                   name == drug.name &&
                   tty == drug.tty;
        }

        public override string ToString()
        {
            return String.Format("Drug Name: {0}, RXCUI Code: {1}, TTY: {2}",
                name, rxcui, tty);
        }
    }
}

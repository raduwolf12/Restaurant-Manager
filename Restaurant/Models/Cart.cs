using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Cart 
    {
        private string nume;
        private int cantitate;
        private Nullable<double> pret;
        private string type;

        public string Nume
        {
            set
            {
                nume = value;
            }
            get
            {
                return nume;
            }
        }
        public int Cantitate
        {
            set
            {
                cantitate = value;
            }
            get
            {
                return cantitate;

            }
        }
        public Nullable<double> Pret
        {
            set
            {
                pret = value;
            }
            get
            {
                return pret;

            }
        }

        public string Type
        {
            set
            {
                type = value;
            }
            get
            {
                return type;

            }
        }
        public string ToString()
        {
            { return pret + nume + cantitate; }
        }

    }
}

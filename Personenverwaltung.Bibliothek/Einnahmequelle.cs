using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung.Bibliothek
{
    public class Einnahmequelle
    {

        public string Bezeichnung
        {
            get { return bezeichnung; }
            set { bezeichnung = value; }
        }


        public decimal Betrag
        {
            get { return betrag; }
            set { betrag = value; }
        }

        private string bezeichnung;
        private decimal betrag;


    }
}

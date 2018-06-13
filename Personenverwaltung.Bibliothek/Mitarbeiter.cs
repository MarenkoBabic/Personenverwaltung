using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung.Bibliothek
{
    public class Mitarbeiter : Person
    {

        public decimal Gehalt
        {
            get
            {
                return _gehalt;
            }
            set
            {
                if (value >= 0)
                {
                    _gehalt = value;
                }
                else
                {
                    //wirf eine Exception vom .Net Framework
                    throw new ArgumentException("Gehalt darf nicht kleiner 0 sein!");
                }
            }
        }

        public Mitarbeiter(string vorname, string nachname, DateTime geburtsdatum,string svnr,decimal gehalt) : base(vorname, nachname, geburtsdatum, svnr)
        {
            Gehalt = gehalt;
        }

        private decimal _gehalt;

    }
}

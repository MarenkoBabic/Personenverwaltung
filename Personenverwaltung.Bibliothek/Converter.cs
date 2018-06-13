using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung.Bibliothek
{
    public static class Converter
    {

        //double -> decimal geht nicht
        //int -> decimal geht
        //decimal literal ist am m erkennbar

        /// <summary>
        /// Wandelt den Vorgesetzten zum Mitarbeiter um 
        /// </summary>
        /// <param name="vg"></param>
        public static Mitarbeiter ToMitarbeiter(Vorgesetzter vg)
        {
            return new Mitarbeiter(vg.Vorname, vg.Nachname, vg.GeburtsDatum, vg.Svnr.Substring(0, 4), 0m);
        }

        /// <summary>
        /// Wandelt den Mitarbeiter zum Vorgesetzen
        /// </summary>
        /// <param name="mb"></param>
        public static Vorgesetzter ToVorgesetzter(Mitarbeiter mb)
        {
            return new Vorgesetzter(mb.Vorname, mb.Nachname, mb.GeburtsDatum, mb.Svnr.Substring(0,4), null);

            //Falls man eine Methode nicht gleich implementiert wird sollte man zumindest  eine Exception werfen -->throw new NotImplementedException();
        }
    }
}

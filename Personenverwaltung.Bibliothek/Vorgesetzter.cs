using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung.Bibliothek
{
    public enum Position : sbyte
    {
        //Die Werte stehen für die max. Untergebenenanzahl, -1 für unendlich
        Mentor = 2,
        TeamLeiter = 15,
        Abteilungsleiter = 50,
        Konzernleiter = -1
    }

    public class Vorgesetzter : Person
    {

        public List<Person> Untergebene
        {
            get
            {
                return _untergebene;
            }
        }


        /// <summary>
        /// Default werte falls Vorgesetzter leer ist
        /// :base nimmt die werte von der Basisklasse Person()
        /// :this neue default werte 
        /// </summary>
        /// <param name="untergebene"></param>
        public Vorgesetzter(List<Person> untergebene) : this("Charly", "Chef", DateTime.Now, "0000", untergebene)
        {
            //nicht so schön, da 
            _svnr = rnd.Next(MIN, MAX) + GeburtsDatum.ToString("ddMMyyyy");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="svnr">4stellige Zahl</param>
        /// <param name="vorname"></param>
        /// <param name="nachname"></param>
        /// <param name="geburtsdatum"></param>
        /// <param name="untergebene">Seine Untergebenen</param>
        public Vorgesetzter(string vorname, string nachname, DateTime geburtsdatum, string svnr, List<Person> untergebene) : base(vorname, nachname, geburtsdatum, svnr)
        {
            //unötig da in Basisklasse behandelt:base
            //Vorname = vorname;
            //Nachname = nachname;
            //_svnr = svnr;


            setzteStandartwerte(Position.Mentor, untergebene);//Standartmäßig wird jeder vorgesetzer zum Mentor
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="svnr">4stellige Zahl</param>
        /// <param name="vorname"></param>
        /// <param name="nachname"></param>
        /// <param name="geburtsdatum"></param>
        /// <param name="leitungsPosition">Nimmt ein Wert aus der Enum Position</param>
        /// <param name="untergebene">Seine Untergebenen</param>

        public Vorgesetzter(string vorname, string nachname, DateTime geburtsdatum, string svnr, Position leitungsPosition, List<Person> untergebene) : base(vorname, nachname, geburtsdatum, svnr)
        {
            setzteStandartwerte(leitungsPosition, untergebene);
        }

        /// <summary>
        /// Fügt eine Vorgesetzen - sofern ein Platz ist einen neuen Untergebenen hinzu
        /// </summary>
        /// <param name="p">neue Person</param>
        /// <returns>true .. ok , false.. nicht hinzugefügt</returns>
        public bool HinzufuegenUntergebenen(Person p)
        {
            //holt die max Anzahl an Untergebenen die dieser Vorgesetze haben darf
            sbyte maxUntergebenen = (sbyte)_position;
            //holt die aktuelle Anzahl der Untergebenen von dem Vorgesetzen
            int anzahlUntergebenen = _untergebene.Count;

            //wenn die Anzahl der Untergebene < ist als maxUntergebenen(dieser Wert hängt von der Position ab)
            //oder maxUntergebene ist -1(-1 steht für "unendlich")
            if (anzahlUntergebenen < maxUntergebenen || maxUntergebenen == -1)
            {
                _untergebene.Add(p);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Entfernt ein Untergebene anhand der Sozialversicherungsnummer
        /// </summary>
        /// <param name="svnr"></param>
        /// <returns> true ok , false.. Nicht entfernt</returns>
        public bool EntferneUntergebenen(string svnr)
        {
            for (int i = 0; i < _untergebene.Count; i++)
            {
                if (_untergebene[i].Svnr.Equals(Svnr))
                {
                    _untergebene.Remove(_untergebene[i]);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Entfernt alle Untergebenen die älter als das stichDatum sind.
        /// </summary>
        /// <param name="stichDatum">Alle Personen vor diesem Datum werden entfernt</param>
        /// <returns></returns>
        public int EntferneUntergebene(DateTime stichDatum)
        {
            //LINQ - Textabfrage
            //var abfrageFuerDatum = (from u in _untergebene
            //                        where u.GeburtsDatum.Date < stichDatum.Date
            //                        select u);

            //LINQ - Methodenabfrage
            var abfrageFuerDatum = _untergebene.Where(x => x.GeburtsDatum < stichDatum.Date);

            //!!!abfrageFuerDatum ist eine Abfrage die sich auf _untergebene bezieht!!!
            //foreach (var u in abfrageFuerDatum)
            //{
            //    _untergebene.Remove(u);
            //}

            var abfrageErgebnis = abfrageFuerDatum.ToList(); //Ausführen der Abfragen

            int i;
            for (i = 0; i < abfrageErgebnis.Count; i++) //Durchlaufen und entfernen - die Schleife zählt bis inkl. count, da erst dann die Abbruchbedingung false ergibt
            {
                _untergebene.Remove(abfrageErgebnis[i]);
            }

            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="unt"></param>
        private void setzteStandartwerte(Position pos, List<Person> unt)
        {
            ///EXAMP Coustom Todo/Task Keyword : Extras -> Optionen -> Umgebung -> Aufgabenliste

            ///EXAMP Chapter 1.3 conditional operator
            //_untergebene = unt!=null ? unt : new List<Person>();

            ///EXAMP Chapter 1.3 null-coalescing operator
            _untergebene = unt ?? new List<Person>();
            _position = pos;
        }

        private List<Person> _untergebene;
        private Position _position;
    }
}

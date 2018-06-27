using System;
using System.Text;


namespace Personenverwaltung.Bibliothek
{
    //EXAMP 3.4 Creating and managing compiler directives Seite 226
    //Klassen sind standartmässig internal, Member der Klasse sind standartmässig private
    [System.Diagnostics.DebuggerDisplay("Name = {VollstaendigerName}{GeburtsDatum}")]
    public abstract class Person : IComparable<Person>
    {
        protected static Random rnd = new Random();

        public string Vorname
        {
            get
            {
                return _vorname;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _vorname = value;
                }
                else
                {
                    throw new ArgumentException("Null or Whitespace not allowed");
                }
            }
        }

        public string Nachname
        {
            get
            {
                return _nachname;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nachname = value;
                }
                else
                {
                    throw new ArgumentException("Null or Whitespace not allowed");
                }

            }
        }

        public string VollstaendigerName
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Nachname);
                sb.Append(",");
                sb.Append(Vorname);
                return $"{Nachname},{Vorname}";
            }
        }

        public DateTime GeburtsDatum
        {
            get
            {
                return _geburtsDatum;
            }
        }

        public string Svnr
        {
            get
            {
                return _svnr;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 4)
                {
                    _svnr = value + GeburtsDatum.ToString("ddMMyyyy");
                }
                else
                {
                    throw new FormatException("svnr should be 4 digits");
                }
            }
        }

        public object Stringbuilder { get; private set; }

        /// <summary>
        /// Leere Konstruktor 
        /// wird automatisch mit
        /// <param name="vorname">John</param>
        /// <param name="nachname">Doe</param>
        /// <param name="geburtsdatum">Jetzt DateTime.Now</param>
        /// <param name="svnr">Random(Min 1000,Max 9999)</param>

        /// </summary>
        public Person() : this("John", "Doe", DateTime.Now, "0000")
        {
            //_vorname = "John";
            //_nachname = "Doe";
            //_geburtsDatum = DateTime.Now;
            _svnr = rnd.Next(MIN, MAX) + _geburtsDatum.ToString("ddMMyyyy");
        }

        /// <summary>
        /// Konstruktor für Person
        /// </summary>
        /// <param name="vorname"></param>
        /// <param name="nachname"></param>
        /// <param name="geburtsDatum"></param>
        /// <param name="svnr"></param>
        public Person(string vorname, string nachname, DateTime geburtsDatum, string svnr)
        {
            Vorname = vorname;
            Nachname = nachname;
            _geburtsDatum = geburtsDatum;
            Svnr = svnr;
        }

        /// <summary>
        /// Kontrolliert 2 daten typen miteinander
        /// </summary>
        /// <param name="other">Person</param>
        /// <returns>
        /// int 
        /// -1 this ist kleiner
        ///  0 this und other sind gleich
        ///  1 this ist größer
        /// </returns>
        public int CompareTo(Person other)
        {
            //This ist das aktuelle Objekt 
            //other ist das fremde Objekt
            //-1 .. this ist kleiner
            // 0 .. this und other sind gleich
            // 1 .. this ist größer

            if (this.GeburtsDatum == other.GeburtsDatum)
            {
                return 0;
            }
            else if (this.GeburtsDatum < other.GeburtsDatum)
            {
                return -1;
            }
            else
            {
                return 1; //this.GeburtsDatum > other.GeburtsDatum
            }
        }

        protected const int MIN = 1000;
        protected const int MAX = 10000;


        protected string _svnr; //protected auch erbende Klassen können drauf zugreifen;
        private string _nachname;
        private readonly DateTime _geburtsDatum;
        private string _vorname;

    }
}

using System;
using System.Text;

namespace Personenverwaltung.Bibliothek
{
    //Klassen sind standartmässig internal, Member der Klasse sind standartmässig private
    public abstract class  Person 
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

        public Person() : this("John", "Doe", DateTime.Now, "0000")
        {
            //_vorname = "John";
            //_nachname = "Doe";
            //_geburtsDatum = DateTime.Now;
            _svnr = rnd.Next(MIN, MAX) + _geburtsDatum.ToString("ddMMyyyy");
        }

        public Person(string vorname, string nachname, DateTime geburtsDatum, string svnr)
        {
            Vorname = vorname;
            Nachname = nachname;
            _geburtsDatum = geburtsDatum;
            Svnr = svnr;
        }

        protected const int MIN = 1000;
        protected const int MAX = 10000;


        protected string _svnr; //protected auch erbende Klassen können drauf zugreifen;
        private string _nachname;
        private readonly DateTime _geburtsDatum;
        private string _vorname;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung.Bibliothek
{
    ///EXAMP Buchseite 103 2.1 Create types, tieferes im Kapitel 4
    public static class MyExtensionsKlasse
    {
        public static Mitarbeiter ToMitarbeiter(this Vorgesetzter vorgesetzer)
        {
            return Converter.ToMitarbeiter(vorgesetzer);
        }

        public static Vorgesetzter ToVorgesetzter(this Mitarbeiter mitarbeiter,List<Person> untergebene)
        {
            Vorgesetzter vorgesetzer = Converter.ToVorgesetzter(mitarbeiter);

            foreach (Person person in untergebene)
            {
                vorgesetzer.HinzufuegenUntergebenen(person);
            }
            return vorgesetzer;
        }

    }
}

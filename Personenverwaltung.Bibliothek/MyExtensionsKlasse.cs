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
        /// <summary>
        /// Erweiterungsmethode
        /// Konvertiert den Vorgesetzen zum Mitarbeiter
        /// </summary>
        /// <param name="vorgesetzer">Vorgesetzter</param>
        /// <returns>Mitarbeiter</returns>
        public static Mitarbeiter ToMitarbeiter(this Vorgesetzter vorgesetzer)
        {
            return Converter.ToMitarbeiter(vorgesetzer);
        }

        /// <summary>
        /// Erweiterungsmethode
        /// Konvertiert den Vorgesetzen zum Mitarbeiter
        /// </summary>
        /// <param name="vorgesetzer">Ein Vorgesetzten</param>
        /// <param name="gehalt">Gehalt</param>
        /// <returns>Mitarbeiter</returns>
        public static Mitarbeiter ToMitarbeiter(this Vorgesetzter vorgesetzer,decimal gehalt)
        {
            return Converter.ToMitarbeiter(vorgesetzer, gehalt);
        }

        /// <summary>
        /// Erweiterungsmethode
        /// Konvertiert ein Mitarbeiter zum Vorgesetzten
        /// </summary>
        /// <param name="mitarbeiter">Ein Mitarbeiter</param>
        /// <param name="untergebene">Liste von Untergebenen</param>
        /// <returns>Vorgesetzen</returns>
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Personenverwaltung.Bibliothek
{
    public class Firma
    {
        /// <summary>
        /// Firmennamen
        /// </summary>
        public string FirmenBezeichnung
        {
            get { return firmenBezeichnung; }
            set { firmenBezeichnung = value; }
        }

        /// <summary>
        /// Liefert mit die Summe aller EinnahmenQuellen
        /// </summary>
        public decimal AktuelleEinnahmen
        {
            get
            {
                return einnahmeQuellen.Sum(a => a.Betrag);
            }
        }

        public Firma()
        {

        }

        /// <summary>
        /// Beim erstellen eine Firma muss Min. 1 Vorgesetzer sein und 1.Mitarbeiter
        /// </summary>
        /// <param name="liste"></param>
        public Firma(string bezeichnung,PersonalListe<Person> liste)
        {
            FirmenBezeichnung = bezeichnung;

            personalListeFirma = new PersonalListe<Person>();

            bool vorgesetzerVorhanden = false;
            bool untergebenerVorhanden = false;

            foreach (var item in liste.PersonenListe)
            {

                if (item is Vorgesetzter)
                {
                    personalListeFirma.Hinzufuegen(item);
                    vorgesetzerVorhanden = true;
                }
                if (item is Mitarbeiter)
                {
                    personalListeFirma.Hinzufuegen(item);
                    untergebenerVorhanden = true;
                }
            }

            if (vorgesetzerVorhanden != true && untergebenerVorhanden != true)
            {
                throw new ArgumentException("Eine Firma muss mind 1. Vorgesetzten und 1. Mitarbeiter haben");
            }
        }

        /// <summary>
        /// Einnahmequellen hinzufügen
        /// </summary>
        /// <param name="eq"> EinnahmQuelle</param>
        public void EinnahmequelleErschliessen(Einnahmequelle eq)
        {
            einnahmeQuellen.Add(eq);
        }

        /// <summary>
        /// Einnahmenquelle kündigen
        /// </summary>
        /// <param name="eq">Einnahmquelle</param>
        public void EinnahmequelleAufgeben(Einnahmequelle eq)
        {
            einnahmeQuellen.Remove(eq);
        }

        /// <summary>
        /// Person zur firma hinzufügen
        /// </summary>
        /// <param name="p"> Person</param>
        public void Einstellen(Person p)
        {
            personalListeFirma.Hinzufuegen(p);
        }

        /// <summary>
        /// Person feuern
        /// </summary>
        /// <param name="p">Person</param>
        public void Feuern(Person p)
        {
            personalListeFirma.Entfernen(p);
        }

        private string firmenBezeichnung;
        private Vorgesetzter vorgesetzer;
        private PersonalListe<Person> personalListeFirma = new PersonalListe<Person>();
        private List<Einnahmequelle> einnahmeQuellen = new List<Einnahmequelle>();
        private Mitarbeiter mitarbeiter;

    }
}

using Personenverwaltung.Bibliothek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> unt = new List<Person>
            {
                new Vorgesetzter(null)
            };
            Vorgesetzter chef = new Vorgesetzter(unt);

            Vorgesetzter chris = new Vorgesetzter(null);

            chef.HinzufuegenUntergebenen(chris);
            chef.EntferneUntergebenen(unt[0].Svnr);
            chef.EntferneUntergebenen(chris.Svnr);

            unt.Add(new Mitarbeiter("Christian", "Kloiber", DateTime.Now.AddDays(-6000), "1256", 3000m));

            Vorgesetzter masterofDesater = new Vorgesetzter( "Michael", "Meister", DateTime.Now.AddDays(-1000),"1234", Position.Konzernleiter, null);
            Vorgesetzter vorg2 = new Vorgesetzter("Robert", "Schafner", DateTime.Now.AddDays(-6000), "3214", Position.Konzernleiter, null);
            Mitarbeiter mitarbeiter1 = new Mitarbeiter("werner", "mihkolic", DateTime.Now.AddDays(-500), "1234", 3333.33m);
            Mitarbeiter mitarbeiter2 = new Mitarbeiter("Sasha", "Schufter", DateTime.Now.AddDays(-1000), "1334", 4444.44m);
            Mitarbeiter mitarbeiter3 = new Mitarbeiter("Test", "Test", DateTime.Now, "1111", 3333.33m);
          
            Vorgesetzter convVo1 = Converter.ToVorgesetzter(mitarbeiter1);
            Mitarbeiter convMa1 = Converter.ToMitarbeiter(chef);

            Vorgesetzter convVo2 = mitarbeiter2.ToVorgesetzter(unt);
            Mitarbeiter convMa2 = masterofDesater.ToMitarbeiter();

            //erstelle eine zweite Variante von ToMitarbeiter(erw. Methode) wo man auch das Gehalt übergeben kann . Nicht Cp

            PersonalListe<Person> meineSklaven = new PersonalListe<Person>();

            meineSklaven.Hinzufuegen(mitarbeiter1);
            meineSklaven.Hinzufuegen(mitarbeiter2);
            meineSklaven.Hinzufuegen(vorg2);
            meineSklaven.Hinzufuegen(masterofDesater);
            meineSklaven.Hinzufuegen(chef);
            meineSklaven.Hinzufuegen(chris);

            meineSklaven.Entfernen(chef);
            meineSklaven.Entfernen(mitarbeiter2);

            People myPeople = new People(unt);

            foreach (var item in myPeople)
            {
                Console.WriteLine(item);
            }

            myPeople.Add(chef);
            Einnahmequelle eq1 = new Einnahmequelle();
            eq1.Bezeichnung = "eq1";
            eq1.Betrag = 100m;

            Einnahmequelle eq2 = new Einnahmequelle()
            {
                Bezeichnung = "eq2",
                Betrag = 200m
            };



            Firma firma1 = new Firma();
            firma1.EinnahmequelleErschliessen(eq1);
            firma1.EinnahmequelleErschliessen(eq2);
            firma1.FirmenBezeichnung = "Firma1Eq1";
            firma1.Einstellen(mitarbeiter3);

            List<Firma> firmen = new List<Firma>
            {
                firma1
            };

            foreach (var item in firmen)
            {
                Console.WriteLine(item.FirmenBezeichnung);
                Console.WriteLine(item.AktuelleEinnahmen);
            }


            Console.ReadLine();
        }
    }
}
 
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
            Mitarbeiter mitarbeiter1 = new Mitarbeiter("werner", "mihkolic", DateTime.Now.AddDays(-500), "1234", 3333.33m);
            Mitarbeiter mitarbeiter2 = new Mitarbeiter("Sasha", "Schufter", DateTime.Now.AddDays(-1000), "1334", 4444.44m);

            Vorgesetzter convVo1 = Converter.ToVorgesetzter(mitarbeiter1);
            Mitarbeiter convMa1 = Converter.ToMitarbeiter(chef);

            Vorgesetzter convVo2 = mitarbeiter2.ToVorgesetzter(unt);
            Mitarbeiter convMa2 = masterofDesater.ToMitarbeiter();

            //erstelle eine zweite Variante von ToMitarbeiter(erw. Methode) wo man auch das Gehalt übergeben kann . Nicht Cp
            
            Console.ReadLine();
        }
    }
}

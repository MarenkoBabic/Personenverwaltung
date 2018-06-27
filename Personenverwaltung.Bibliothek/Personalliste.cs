namespace Personenverwaltung.Bibliothek
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    ///EXAMP Chapter 2.1 Using generic Types 101
    public class PersonalListe<T> where T : Person
    {

        public List<T> PersonenListe
        {
            get
            {
                return personenListe;
            }
        }

        private List<T> personenListe;

        public PersonalListe()
        {

        }
        public PersonalListe(List<T> vorhPersonen)
        {
            //Falls vorhandenPersonen null ist, wird new List<T> zugewiesen
            personenListe = vorhPersonen ?? new List<T>();
        }



        public void Hinzufuegen(T person)
        {
            //wenn kein Speicher für die Liste vorhanden, dann reservieren
            if (personenListe == null)
            {
                personenListe = new List<T>();
            }
            //person hinzufügen
            PersonenListe.Add(person);

            //PersonenListe Sortieren
            personenListe = PersonenListe.OrderByDescending(a => a.GeburtsDatum).ToList();
        }

        public void Entfernen(T person)
        {
            if (personenListe == null)
            {
                personenListe = new List<T>();
            }
            PersonenListe.Remove(person);
        }

    }

    /// EXAMP Chapter 2.4 IENUMERABLE Seite 135
    /// IEnumerable für foreach
    /// IList für das Verhalten einer Liste
    public class People : IEnumerable<Person>, IList<Person>
    {
        public People(List<Person> personalListe)
        {
            this.personalListe = personalListe;
        }


        public IEnumerator<Person> GetEnumerator()
        {
            // durchlaufe liste 
            for (int i = 0; i < personalListe.Count; i++)
            {
                //liefere aktuelle Person mit yield gibt sofort den wert zurück und läuft die dann weiter
                yield return personalListe[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //Aufruf der Generischen Variante, siehe Oben
            return GetEnumerator();
        }

        public int IndexOf(Person item)
        {
            return personalListe.IndexOf(item);
        }

        public void Insert(int index, Person item)
        {
            //personalListe.Insert(index, item);
            
            //Add-Methode der Klasse List, da people vom Typ List ist
            personalListe.Add(item);

            //AddMethoe das Klasse People
            Add(item);
        }

        public void RemoveAt(int index)
        {
            personalListe.RemoveAt(index);
        }

        public void Add(Person item)
        {
            personalListe.Add(item);
            //Sortiere die Liste nach Geburtsdatum absteigend
            //verwende einer anonymen Methode mittels lambda - Ausdruck
            personalListe.Sort((x, y) =>
                x.GeburtsDatum > y.GeburtsDatum ? -1 :  //if (x > y ) dann -1
                x.GeburtsDatum < y.GeburtsDatum ?  1 :  //else if( x < y) dann 1
                0);                                     //else (0)
            
            ////Übergabe einer Methode DELEGATE
            //personalListe.Sort(VerkehrteComparteTo);
        }

        public void Clear()
        {
            personalListe.Clear();

        }

        public bool Contains(Person item)
        {
            return personalListe.Contains(item);
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            personalListe.CopyTo(array, arrayIndex);
        }

        public bool Remove(Person item)
        {
            return personalListe.Remove(item);
        }

        public int Count => personalListe.Count;

        public bool IsReadOnly => false;

        ///EXAMP Chaperter 2.1 Adding some Data Seite 97
        public Person this[int index]
        {
            get => personalListe[index];
            set => personalListe[index] = value;
        }

        private List<Person> personalListe;
        private int VerkehrteComparteTo(Person x,Person y)
        {
          return  x.GeburtsDatum > y.GeburtsDatum ? -1 :  //if (x > y ) dann -1
                  x.GeburtsDatum < y.GeburtsDatum ? 1 :  //else if( x < y) dann 1
                  0;                                     //else (0)
        }

    }
}

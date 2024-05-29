using System.Collections.Generic;

namespace MVC_CarMarket.Models
{
    internal class Person
    {
        public static List<Person> ListPeople = new List<Person>();  

        public int ID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Money { get; set; }

        public Person(int id, string firstName, string lastName, int money)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Money = money;
            ListPeople.Add(this); 
            //Ако не е тук ще трябва при създаване на новa кола
            //в метода четящ от базата данни да го добавяме там
        }
    }
}


using MVC_CarMarket.Repositories;
using MVC_CarMarket.Models;
using MVC_CarMarket.Services;
using System;

namespace MVC_CarMarket.View
{
    internal class Display
    {
        DBConnector connector = new DBConnector();
        Service service = new Service();

        public void ShowMainMenu()
        {
            //test new branch 
            Console.WriteLine("hello");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("1) Покажи списък на хората и колекциите им");
            Console.WriteLine("2) Покажи списък на колите");
            Console.WriteLine("3) Закупуване на нова кола");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Изберете вашето действие:");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: { ShowPeopleCarCollection(); break; }
                case 2: { ShowAllCars(); break; }
                case 3: { BuyNewCar(); break; }
            }

            ShowMainMenu();
        }

        private void BuyNewCar()
        {
            Console.WriteLine("Изберете кой ще бъде купувача:");
            ShowPeople();
            Console.ForegroundColor = ConsoleColor.White;
            int buyerNum = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Изберете коя кола иска да закупи:");
            ShowAllCars();
            Console.ForegroundColor = ConsoleColor.White;
            int chosenCarNum = int.Parse(Console.ReadLine());

            Person buyer = Person.ListPeople[buyerNum - 1];
            Car chosenCar = Car.ListCars[chosenCarNum - 1];

            if (chosenCar.OwnerID is null)
            {
                if (buyer.Money >= chosenCar.Price)
                {
                    service.BuyNewCar(chosenCar, buyer);
                    ShowPeopleCarCollection();
                }
            }
            else Console.WriteLine("Тази кола вече е закупена!");
        }

        public void ShowPeople()
        {           
            int br = 0;
            foreach (Person prs in Person.ListPeople)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{br+1}) {prs.FirstName} {prs.LastName} {prs.Money}$");
                br++;
            }
        }

        private void ShowAllCars()
        {
            int br = 0;
            foreach (Car car in Car.ListCars)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{br + 1}) {car.Color} {car.Model} {car.Year} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{car.Price}$");
                br++;

                if (!(car.OwnerID is null))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(" закупена");
                }
                else Console.WriteLine();
            }
        }

        public void ShowPeopleCarCollection()
        {
            foreach (Person prs in Person.ListPeople)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{prs.FirstName} {prs.LastName} {prs.Money}$");
                Console.ForegroundColor = ConsoleColor.Blue;

                int br = 0;
                foreach (Car car in Car.ListCars)
                {
                    if (car.OwnerID == prs.ID)
                    {
                        Console.WriteLine($"--- {car.Color} {car.Model} {car.Year} {car.Price}$");
                        br++;
                    }
                }
                if (br==0) Console.WriteLine("--- няма закупени коли ---");
            }
        }
    }
}


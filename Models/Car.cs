using System;
using System.Collections.Generic;

namespace MVC_CarMarket.Models
{
    internal class Car
    {
        public static List<Car> ListCars = new List<Car>();    
        public int ID { get; }
        public string Model { get; }
        public string Color { get; }
        public int Year { get; }
        public int Price { get; }
        public int? OwnerID { get; }

        public Car(int id, string model, string color, int year, int price, int? owner_id)
        {
            this.ID = id;
            this.Price = price;
            this.Model = model;
            this.Color = color;
            this.Year = year;
            this.OwnerID = owner_id;
            ListCars.Add(this);
        }
    }
}


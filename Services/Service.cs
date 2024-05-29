using System;
using MVC_CarMarket.Models;
using MVC_CarMarket.Repositories;

namespace MVC_CarMarket.Services
{
    internal class Service
    {
        DBConnector connector = new DBConnector();

        public void LoadData()
        {
            connector.LoadPeople();
            connector.LoadCars();
        }

        public void BuyNewCar(Car chosenCar, Person buyer)
        {
            connector.MakeTransactionOnNewCarBuy(chosenCar, buyer);
            LoadData();
            //ВАЖНО! Информацията от листите трябва да се актуализира от базата данни
            //А не директно чрез код, понеже транзакцията към БД може и да не се е получила
            //Само така можем да гарантираме, че няма да се получи разминаване с информацията
            //от листите ни и Базата Данни
        }
    }
}

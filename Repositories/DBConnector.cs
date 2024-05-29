using System;
using MVC_CarMarket.Models;
using MySql.Data.MySqlClient;

namespace MVC_CarMarket.Repositories
{
    internal class DBConnector
    {
        //ВАЖНО !!!
        //Принципно този стринг не се хардкодва така,  
        //за да не се покажат в GitHub юзерът и паролата ви,
        //но за целта на упражнението е добре да видите реално какво
        //представлява.  
        string connectionString = "server=localhost; port=3306; database=car_market; user=root; password=";

        public void LoadPeople()
        {
            Person.ListPeople.Clear(); //Изчистваме листа

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, first_name, last_name, money " +
                    "FROM people";

                using (MySqlCommand command = new MySqlCommand(query, connection))

                //по-долният using всъщност Е ВГРАДЕН В ПЪРВИЯ
                //подобно на if () действие;
                //т.е. при една единствена операция не е необходимо 
                //да слагаме фигурните скоби. Би било добре да бутнем кода една идея навътре, но заради дългите кодове става трудно четим
                //* Затова обекта command се вижда и във втория using

                //създаваме обект за четене изпълняващ зададените команди
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) //чете ред по ред инстанциите
                    {
                        int id = int.Parse(reader["id"].ToString());
                        string first_name = reader["first_name"].ToString();
                        string last_name = reader["last_name"].ToString();
                        int money = int.Parse(reader["money"].ToString());
                        Person stu = new Person(id, first_name, last_name, money);
                        //* Конструктора автоматик го адва в публичния списък
                    }
                }
            }
        }

        public void LoadCars()
        {
            Car.ListCars.Clear(); //Изчистваме листа

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, model, color, year, price, owner_id " +
                    "FROM cars";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());

                        int? owner_id = null;

                        if (reader["owner_id"] != DBNull.Value)
                        {
                            int parsedOwnerId;
                            if (int.TryParse(reader["owner_id"].ToString(), out parsedOwnerId))
                            {
                                owner_id = parsedOwnerId;
                            }
                            // Ако парсването не е успешно, owner_id остава NULL
                        }

                        string model = reader["model"].ToString();
                        string color = reader["color"].ToString();
                        int year = int.Parse(reader["year"].ToString());
                        int price = int.Parse(reader["price"].ToString());
                        Car newCar = new Car(id, model, color, year, price, owner_id);
                        //* Конструктора автоматик го адва в публичния списък
                    }
                }
            }
        }

        public void MakeTransactionOnNewCarBuy(Car car, Person owner)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction(); //СТАРТИРА ТРАНЗАКЦИЯ

                try
                {
                    // Тук изпълняваме нашите mySQL заявки, включително и обновяването на таблиците people и cars
                    string updatePeopleQuery = "UPDATE people SET money = money - @carPrice WHERE id = @ownerId;";
                    string updateCarsQuery = "UPDATE cars SET owner_id = @оwnerId WHERE id = @carId;";

                    MySqlCommand updatePeopleCommand = new MySqlCommand(updatePeopleQuery, connection, transaction);
                    updatePeopleCommand.Parameters.AddWithValue("@carPrice", car.Price);
                    updatePeopleCommand.Parameters.AddWithValue("@ownerId", owner.ID);
                    updatePeopleCommand.ExecuteNonQuery();

                    MySqlCommand updateCarsCommand = new MySqlCommand(updateCarsQuery, connection, transaction);
                    updateCarsCommand.Parameters.AddWithValue("@оwnerId", owner.ID);
                    updateCarsCommand.Parameters.AddWithValue("@carId", car.ID);
                    updateCarsCommand.ExecuteNonQuery();

                    // Ако всичко е наред, потвърждавате транзакцията
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // В случай на грешка, отменяте транзакцията
                    Console.WriteLine("Error: " + ex.Message);
                    transaction.Rollback();
                }
            }
        }

        //АКО НЕ МОЖЕТЕ С ТРАНЗАКЦИЯ, МОЖЕТЕ ДА ГО НАПРАВИТЕ С 2-та ПОРЕДНИ ПО-ПРОСТИ МЕТОДА ПО-ДОЛУ:::
        //Вижте референциите - 0 Т.е. не ги използвам, но ги давам като помощни понеже са по-елементарни 

        public void UpdateCarOwner(int carID, int ownerID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE cars " +
                "SET owner_id = @ownerID " +
                "WHERE id = @carID";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ownerID", ownerID);
            command.Parameters.AddWithValue("@carID", carID);

            int rowsAffected = command.ExecuteNonQuery();
        }
        public void UpdateBuyerMoney(int ownerID, int newMoney)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE people " +
                "SET money = @newMoney " +
                "WHERE id = @ownerID";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ownerID", ownerID);
            command.Parameters.AddWithValue("@newMoney", newMoney);

            int rowsAffected = command.ExecuteNonQuery();
        }
    }
}


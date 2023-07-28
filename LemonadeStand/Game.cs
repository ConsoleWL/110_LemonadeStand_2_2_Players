﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        int currentDay;
        int numberofPlayers;
        List<Player> players;
        List<Day> days;
        Store store;

        public Game()
        {
            currentDay = 1;
            players = new List<Player>();
            store = new Store();
            days = new List<Day>
            {
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day()
            };

        }

        public int NumberOfPlayers()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter number of Players: 1, 2 , 3 , 4 , 5 :");

                    numberofPlayers = Convert.ToInt32(Console.ReadLine());

                    if (numberofPlayers > 0 && numberofPlayers <= 5)
                    {
                        return numberofPlayers;
                    }
                    else
                    {
                        Console.WriteLine("\nChoose beetween 1 and 5:");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nWrong input, must be an interger");
                }
            }
        }

        public void GeneratePlayers(int numberOfPlayers)
        {
            for (int i = 1; i <= numberofPlayers; i++)
            {
                Console.WriteLine($"\nEnter a name for player {i}");
                string name = Console.ReadLine();

                if (name == "" || name == " " || name == "  ")
                {
                    players.Add(new Player());
                    players[i - 1].name = $"Player {i}";
                }
                else
                {
                    players.Add(new Player());
                    players[i - 1].name = name;
                }
            }
        }

        public void DisplayPlayers()
        {
            Console.WriteLine("\nList of players:");

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"Player {i + 1}: {players[i].name}");
            }
        }
        public void Welcome()
        {
            Console.WriteLine("\nWelcome to Lemonade Stand!");
            Console.WriteLine("You have 7 days to make as much money as you can.");
            Console.WriteLine("The weather, along with your pricing, can affect your success.");
            Console.WriteLine("Can you make the big bucks");
            Console.WriteLine("Player with the biggest stack wins");
        }

        public void WeatherChanger()
        {
            int changeWeather = UserInterface.GenerateRandom1to9();
            if (changeWeather < 3)
            {
                //then well change it
                if (days[currentDay - 1].weather.condition == "perfect")
                {
                    days[currentDay - 1].weather.condition = "bad";
                    days[currentDay - 1].weather.temperature = 50;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay - 1].weather.weatherConditions[2];
                    days[currentDay - 1].weather.isWeatherChanged = true;
                }
                else if (days[currentDay - 1].weather.condition == "bad")
                {
                    days[currentDay - 1].weather.condition = "perfect";
                    days[currentDay - 1].weather.temperature = 80;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay - 1].weather.weatherConditions[2];
                    days[currentDay - 1].weather.isWeatherChanged = true;
                }
                else
                {
                    days[currentDay - 1].weather.condition = "perfect";
                    days[currentDay - 1].weather.temperature = 80;
                    days[currentDay - 1].weather.predictedForecast = days[currentDay - 1].weather.weatherConditions[2];
                    days[currentDay - 1].weather.isWeatherChanged = true;
                }
            }
        }

        public void CustomerPurchase()
        {
            for (int j = 0; j < players.Count; j++)
            {
                Console.WriteLine($"\tPlayer {players[j].name} is selling...");

                for (int i = 0; i < days[currentDay - 1].customers.Count - 1; i++)
                {
                    bool result = days[currentDay - 1].customers[i].Purchase(players[j], players[j].recipe, days[currentDay - 1].weather.condition);

                    if (result == true)
                    {
                        players[j].Sell();
                    }
                    else
                    {
                        Console.WriteLine("Customer pass by......");
                    }
                }
                Console.WriteLine();
            }
            
        }

        public void DisplayActualWether()
        {
            Console.WriteLine($"\nActual weather was {days[currentDay - 1].weather.condition}, Temperature: {days[currentDay - 1].weather.temperature} C");
        }

        public void AnounceStartOftheDay()
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine($"\nDay {currentDay} begins!");
            Console.WriteLine("_________________________________________________");
        }

        public void AnounceEndOftheDay()
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine($"\nDay {currentDay} is over! ");
            Console.WriteLine("_________________________________________________");
            currentDay++;
        }

        //public void GameResuts()
        //{
        //    Console.WriteLine($"\nThe week is over. Your total profit is {player.wallet.Money}");
        //}

        public void GameSimulation()
        {
            while (currentDay < 8)
            {
                AnounceStartOftheDay();

                days[currentDay - 1].weather.DisplayTemperature();

                WeatherChanger();

                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine($"\nPlayer #{i+1}");
                    players[i].OpenTheStand();
                    store.DisplayStorePrices();
                    store.SellItems(players[i]);

                    players[i].DrinkPreperation();
                }
                CustomerPurchase();
                AnounceEndOftheDay();
                int x = 0;

            }

        }

        //public void GameSimulation()
        //{
        //    while (currentDay < 8)
        //    {
        //        AnounceStartOftheDay();

        //        days[currentDay - 1].weather.DisplayTemperature();

        //        player.OpenTheStand();

        //        store.DisplayStorePrices();
        //        store.SellItems(player);


        //        player.DrinkPreperation();

        //        WeatherChanger();

        //        CustomerPurchase();

        //        DisplayActualWether();

        //        player.CloseTheStand();

        //        AcounceEndOftheDay();
        //    }
        //}

        public void RunGame()
        {
            NumberOfPlayers();
            GeneratePlayers(numberofPlayers);
            DisplayPlayers();
            Welcome();
            GameSimulation();
            
            //GameSimulation();
            // GameResuts();
        }

    }
}

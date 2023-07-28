using System;
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
        Player player;
        List<Day> days;
        Store store;

        public Game()
        {
            currentDay = 1;
            player = new Player();
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

        public void Welcome()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            Console.WriteLine("You have 7 days to make as much money as you can.");
            Console.WriteLine("The weather, along with your pricing, can affect your success.");
            Console.WriteLine("Can you make the big bucks");
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
            for (int i = 0; i < days[currentDay - 1].customers.Count - 1; i++)
            {
                bool result = days[currentDay - 1].customers[i].Purchase(player, player.recipe, days[currentDay - 1].weather.condition);

                if (result == true)
                {
                    player.Sell();
                }
                else
                {
                    Console.WriteLine("Customer pass by......");
                }
            }  
        }

        public void DisplayActualWether()
        {
            Console.WriteLine($"\nActual weather was {days[currentDay - 1].weather.condition}, Temperature: {days[currentDay - 1].weather.temperature} C");
        }

        public void AnounceStartOftheDay()
        {
            Console.WriteLine($"\nDay {currentDay} begins!");
        }

        public void AcounceEndOftheDay()
        {
            Console.WriteLine($"\nDay {currentDay} is over! ");
            currentDay++;
        }

        public void GameResuts()
        {
            Console.WriteLine($"\nThe week is over. Your total profit is {player.wallet.Money}");
        }
        
        public void GameSimulation()
        {
            while (currentDay < 8)
            {
                AnounceStartOftheDay();

                days[currentDay - 1].weather.DisplayTemperature();

                player.OpenTheStand();

                store.DisplayStorePrices();
                store.SellItems(player);


                player.DrinkPreperation();

                WeatherChanger();

                CustomerPurchase();

                DisplayActualWether();

                player.CloseTheStand();

                AcounceEndOftheDay();
            }
        }

        public void RunGame()
        {
            Welcome();
            GameSimulation();
            GameResuts();
        }

    }
}

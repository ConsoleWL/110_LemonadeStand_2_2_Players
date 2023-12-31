﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Day
    {
        internal Weather weather;
        internal List<Customer> customers;
        public Day()
        {
            weather = new Weather();
            customers = new List<Customer>();
            GenerateCustomers();
        }

        public void GenerateCustomers()
        {
            int result = CheckingTheWeather();
            CreatingCustomers(result);
        }

        public int CheckingTheWeather()
        {
            switch (weather.condition)
            {
                case "perfect":
                    return 100;
                case "good":
                    return 60;
                case "bad":
                    return 30;
                default:
                    return 0;
            }
        }

        public void CreatingCustomers(int number)
        {
            for (int i = 0; i <= number ; i++)
            {
                customers.Add(new Customer());
            }
        }

    }
}

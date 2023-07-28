using System;
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
            switch (weather.condition)
            {
                case "perfect":
                    for (int i = 0; i < 100; i++)
                    {
                        customers.Add(new Customer());
                    }
                    break;
                case "good":
                    for (int i = 0; i < 60; i++)
                    {
                        customers.Add(new Customer());
                    }
                    break;
                case "bad":
                    for (int i = 0; i < 30; i++)
                    {
                        customers.Add(new Customer());
                    }
                    break;
            }
        }
    }
}

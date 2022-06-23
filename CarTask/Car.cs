using System;
using System.Collections.Generic;
using System.Text;

namespace CarTask
{
    public class Car
    {
        public Car(decimal price, string model)
        {
            Price = price;
            Model = model;
        }

        public decimal Price { get; set; }
        public string Model { get; set; }

        public void ReducePrice (decimal amount)
        {
            Price -= amount;
        }
    }
}

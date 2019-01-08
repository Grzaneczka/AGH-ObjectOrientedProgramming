using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class SinglePayment : Payment 
    {
        private double price;
        private double quantity;

        // Konstruktory 

        public SinglePayment(string title, double price, double quantity) : base(title)
        {
            this.price = price;
            this.quantity = quantity;
        }

        // Getery i Setery

        public double Price { get => price; set => price = value; }

        public double Quantity { get => quantity; set => quantity = value; }

        // Metody dodatkowe

        public override double Amount()
        {
            return quantity * price;
        }

        // To string

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

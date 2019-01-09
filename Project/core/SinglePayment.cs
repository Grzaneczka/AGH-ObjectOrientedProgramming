using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    class SinglePayment : Payment 
    {
        private double price;
        private double quantity;

        // Konstruktory 

        public SinglePayment(string title, double price, double quantity) : base(title)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.IsPaid = isPaid;
            this.date = DateTime.Now;
        }

        public SinglePayment(string name, double price, double quantity, bool isPaid, DateTime date) : this(name, price, quantity, isPaid)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.IsPaid = isPaid;
            this.date = date;
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

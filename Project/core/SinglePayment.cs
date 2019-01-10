using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    class SinglePayment
    {
        private string name;
        private double price;
        private double quantity;
        private bool isPaid;
        private DateTime date;

        // Konstruktory 

        public SinglePayment(string name, double price, double quantity, bool isPaid)
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
        }

        // Getery i Setery 

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public bool IsPaid { get => isPaid; set => isPaid = value; }

        // Metody dodatkowe

        public virtual double Cost()
        {
            return quantity * price;
        }

        // To string

        public override string ToString()
        {
            return this.Name + "  Quantity: " + this.Quantity + "  Price: " + this.Price + "  Cost: " + Cost().ToString() + "  Is Paid: " + this.IsPaid;
        }


    }
}

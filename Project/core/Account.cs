using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Account
    {
        private Client client;
        private List<Payment> payments = new List<Payment>();

        //Konstruktory 

        public Account(Client client)
        {
            this.client = client;
        }

        //Getery i Setery 

        internal Client Client { get => client; set => client = value; }

        internal List<Payment> Payments { get => payments; set => payments = value; }

        // Metody dodatkowe

        public double AccountStatus() // Nie jestem czy to jest dobrze 
        {
            return payments.FindAll(r => !r.IsPaid).Sum(r => r.Amount());
        }

        internal void AddPayment(Payment payment)
        {
            payments.Add(payment);
        }

        //To string

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(this.client.ToString());
            builder.AppendLine("Account:  ");

            foreach (Payment payment in payments)
            {
                builder.AppendLine(payment.ToString());
            }

            return builder.ToString();
        }
    }
}
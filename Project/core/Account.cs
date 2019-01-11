using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]

    public class Account
    {
        private Client client;
        private List<Payment> payments = new List<Payment>();

        //Konstruktory 

        public Account()
        {

        }

        public Account(Client client)
        {
            this.client = client;
        }

        //Getery i Setery 

        public Client Client { get => client; set => client = value; }

        public List<Payment> Payments { get => payments; set => payments = value; }

        // Metody dodatkowe

        public double AccountDebt() // Nie jestem czy to jest dobrze 
        {
            return payments.FindAll(r => !r.IsPaid).Sum(r => r.Amount());
        }

        public void AddPayment(Payment payment)
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
                builder.Append(payment.ToString());
            }

            builder.AppendLine();

            return builder.ToString();
        }
    }
}
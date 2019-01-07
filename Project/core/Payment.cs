using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Payment : IEquatable<Client>

    {
        private Client client;
        private List<SinglePayment> singlePayments;

        //Konstruktory 

        public Payment(Client client)
        {
            this.client = client;
            this.singlePayments = new List<SinglePayment>();
        }

        // Metody dodatkowe

        public bool Equals(Client other)
        {
            if (this.client.Name != other.Name) return false;

            if (this.client.Surname != other.Surname) return false;

            if (this.client.IdClient != other.IdClient) return false;

            return true;
        }

        public void AddSinglePayment(SinglePayment singlePayment)
        {
            singlePayments.Add(singlePayment);
        }

        public void AddReserwation(Reservation reservation)
        {
            string name = "Reservation form " + reservation.CheckInDate.ToString();
            singlePayments.Add(new SinglePayment(name, reservation.Cost(), 1, false, reservation.CheckInDate));
        }

        public void AddAdvance(Reservation reservation)
        {
            string name = "Advance for reservations from " + reservation.CheckInDate.ToString();
            singlePayments.Add(new SinglePayment(name, reservation.Advance(), 1, false, DateTime.Now));
        }

        public int GetCountOfNotPaiedSinglePayment()
        {
            return singlePayments.FindAll(sp => sp.IsPaid == false).Count();
        }

        public bool AdvanceIsPaid(DateTime date)
        {
            string name = "Advance for reservations from " + date.ToString();
            if(singlePayments.Find(sp => sp.Name == name).IsPaid == true)
                return true;
            return false;
        }

        // To string

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(this.client.ToString());
            builder.AppendLine("Single Payment:  ");

            foreach (SinglePayment singlePayment in singlePayments)
            {
                builder.AppendLine(singlePayment.ToString());
            }

            return builder.ToString();
        }

    }
}

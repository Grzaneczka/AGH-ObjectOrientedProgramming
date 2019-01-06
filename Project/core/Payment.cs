using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Payment
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

        public void AddSinglePayment(SinglePayment singlePayment)
        {
            singlePayments.Add(singlePayment);
        }

        public void AddReserwation(Reservation reservation)
        {
            singlePayments.Add(new SinglePayment("Reserwation", reservation.Cost(), 1, false, reservation.CheckInDate));
        }

        public void AddAdvance(Reservation reservation)
        {
            singlePayments.Add(new SinglePayment("Advance", reservation.Advance(), 1, false, DateTime.Now));
        }

        public int GetCountOfNotPaiedSinglePayment()
        {
            return singlePayments.FindAll(sp => sp.IsPaid == false).Count();
        }

        public bool AdvanceIsPaid()
        {
            if (singlePayments.FindAll(sp => sp.Name == "Advance" && sp.IsPaid == true).Count() == singlePayments.FindAll(sp => sp.Name == "Advance").Count())
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

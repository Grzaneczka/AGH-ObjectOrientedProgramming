using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    class Payment
    {
        private DateTime date;
        private string title;
        private bool isPaid;
        private double amount;

        //Konstruktory 

        public Payment(string title)
        {
            this.date = DateTime.Now;
            this.title = title;
            this.isPaid = false;
            this.amount = Amount();
        }

        //Getery i Setery

        public string Title { get => title; set => title = value; }

        public bool IsPaid { get => isPaid; set => isPaid = value; }

        // Metody dodatkowe

        public virtual double Amount()
        {
            return 0;
        }

        // To string 
         public override string ToString()
        {
            return this.Title + " " + Amount();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Payment
    {
        private DateTime date;
        private string title;
        private bool isPaid;

        //Konstruktory 

        public Payment(string title)
        {
            this.date = DateTime.Now;
            this.title = title;
            this.isPaid = false;
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

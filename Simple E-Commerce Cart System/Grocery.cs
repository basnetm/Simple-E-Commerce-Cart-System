using System;

namespace Simple_E_Commerce_Cart_System
{
    public class Grocery : Product
    {
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

       
        public override float GetTaxRate()
        {
            return 0.02f;   
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Expiry Date: " + ExpiryDate.ToShortDateString());
        }
    }
}

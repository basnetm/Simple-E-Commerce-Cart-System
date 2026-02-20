using System;

namespace Simple_E_Commerce_Cart_System
{
    public class Clothing : Product
    {
        private string jeans;

        public string JeansName
        {
            get { return jeans; }
            set { jeans = value; }
        }

       
        public override float GetTaxRate()
        {
            return 0.10f;   
        }

       
        public override void Display()
        {
            base.Display();  

            Console.WriteLine("Jeans Name: " + JeansName);
        }
    }
}

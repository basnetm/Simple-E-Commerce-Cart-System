using System;

namespace Simple_E_Commerce_Cart_System
{
    public class Product
    {
        private int id;
        private string name;
        private float basePrice;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; }
        }

        public virtual float GetTaxRate()
        {
            if (BasePrice >= 25000)
                return 0.15f;  
            else
                return 0.05f;   
        }

        public float CalculateFinalPrice(int quantity)
        {
            float taxAmount = BasePrice * GetTaxRate();
            float finalUnitPrice = BasePrice + taxAmount;

            return finalUnitPrice * quantity;
        }

        public virtual void Display()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Base Price: " + BasePrice);
        }
    }
}

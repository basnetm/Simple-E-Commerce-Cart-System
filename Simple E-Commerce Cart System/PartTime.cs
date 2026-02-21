using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_E_Commerce_Cart_System
{
    public class PartTime : All_in_One
    {
        public float Salery { get; set; }

        public void DisplaySalery()
        {
            Display();

            Console.WriteLine("your salery is "+ Salery);


        }


    }
}

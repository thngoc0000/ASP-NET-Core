using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.@interface
{
    internal class MomoPayment: IPayment
    {
        public void pay()
        {
            Console.WriteLine("Paying with Momo");
        }
    }
}

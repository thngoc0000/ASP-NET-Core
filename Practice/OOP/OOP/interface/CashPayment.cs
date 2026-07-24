using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.@interface
{
    internal class CashPayment : IPayment
    {
        public void pay()
        {
            Console.WriteLine("Paying with cash");
        }
    }
}

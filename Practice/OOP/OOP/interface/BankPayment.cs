using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.@interface
{
    internal class BankPayment: IPayment
    {
        public void pay()
        {
            Console.WriteLine("Paying with bank transfer");
        }
    }
}

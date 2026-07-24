using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Abstract
{
    internal abstract class Animal
    {
        public abstract void makeSound();
        public void sleep()
        {
            Console.WriteLine("Sleeping...");
        }
        public virtual void stop()
        {
            Console.WriteLine("Animal stopped");
        }
    }
}

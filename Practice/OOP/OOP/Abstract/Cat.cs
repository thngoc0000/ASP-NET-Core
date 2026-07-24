using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Abstract
{
    internal class Cat: Animal
    {
        public override void makeSound()
        {
            Console.WriteLine("Meow");
        }
        public override void stop()
        {
            Console.WriteLine("Cat stopped");
        }
    }
}

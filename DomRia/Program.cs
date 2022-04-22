using System;
using DomRia.Realization;

namespace DomRia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager ma = new Manager();
            ma.AddProduct();
           // ma.AddProduct();
           // ma.AddProduct();
            Console.Clear();
           // ma.DeleteProduct("title1");
            ma.ShowAll();
        }

    }
}

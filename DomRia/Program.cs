using System;
using DomRia.Realization;

namespace DomRia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User u = new User();
            //u.ShowByRealtor("Babek", "Babekovich");
            //u.ShowByType("Apartment");
            //u.ShowByCity("Kiev");
            //u.ShowByDistrict("Kiev", "Frankovskiy");
            u.ShowByRealtor("+380981541870");
        }

    }
}

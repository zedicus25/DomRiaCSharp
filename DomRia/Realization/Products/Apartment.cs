using DomRia.AbstractClasses;
using DomRia.InfoResources;

namespace DomRia.Products
{
    public class Apartment : Product
    {
        public Apartment(string title, string description, Location location, Price cost, Contact realtor) : 
            base(title, description, location, cost, realtor)
        {
        }
    }
}
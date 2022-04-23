using DomRia.AbstractClasses;
using DomRia.InfoResources;

namespace DomRia.Products
{
    public class House : Product
    {
        public House(string title, string description, Location location, Price cost, Contact realtor) : 
            base(title, description, location, cost, realtor)
        {
        }
        
        public override string ToString()
        {
            return $"{base.ToString()}House";
        }
    }
}
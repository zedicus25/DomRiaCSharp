using System.Text;
using DomRia.InfoResources;

namespace DomRia.AbstractClasses
{
    public abstract class Product
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Location Location { get; private set; }
        public Price Cost { get; set; }
        public Contact Realtor { get; set; }

        protected Product(string title, string description, Location location, Price cost, Contact realtor)
        {
            Title = title;
            Description = description;
            Location = new Location(location);
            Cost = new Price(cost.UsdPrice);
            Realtor = new Contact(realtor);  
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Title);
            sb.AppendLine(Location.ToString());
            sb.AppendLine(Cost.ToString());
            sb.AppendLine(Description);
            sb.AppendLine(Realtor.ToString());
            return sb.ToString();
        }
    }
}
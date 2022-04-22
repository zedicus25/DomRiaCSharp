using System.Text;

namespace DomRia.InfoResources
{
    public class Location
    {
        public string City { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }

        public Location(string city, string district, string street, int houseNumber)
        {
            City = city;
            District = district;
            Street = street;
            HouseNumber = houseNumber > 0 ? houseNumber : 1;
        }

        public Location(Location location)
        {
            City = location.City;
            District = location.District;
            Street = location.Street;
            HouseNumber = location.HouseNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(City + "\t");
            sb.Append(District + "\t");
            sb.Append(Street + "\t");
            sb.Append(HouseNumber);
            sb.AppendLine();
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Location)
            {
                Location tmp = obj as Location;
                if (tmp.GetHashCode() == GetHashCode())
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return City.GetHashCode() ^ District.GetHashCode() ^ Street.GetHashCode() ^ HouseNumber.GetHashCode();
        }
    }
}
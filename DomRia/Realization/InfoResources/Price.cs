using System;
using System.Text;

namespace DomRia.InfoResources
{
    public class Price
    {
        public double GrnPrice { get; private set; }
        public double UsdPrice { get; private set; }

        public Price(double usdPrice)
        {
            UsdPrice = usdPrice;
            GrnPrice = ConvertToGrn();
        }

        public Price(string price)
        {
            string[] arr = price.Split('\t');
            UsdPrice = int.Parse(arr[0].Replace("USD", ""));
            GrnPrice = int.Parse(arr[1].Replace("GRN", ""));
        }
        
        private double ConvertToGrn() => UsdPrice * 29.94;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(UsdPrice + "USD\t");
            sb.Append(GrnPrice + "GRN\t");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Price)
            {
                Price tmp = obj as Price;
                if (tmp.GetHashCode() == GetHashCode())
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return GrnPrice.GetHashCode() ^ UsdPrice.GetHashCode();
        }
    }
}
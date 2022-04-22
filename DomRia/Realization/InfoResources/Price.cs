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
        
        private double ConvertToGrn() => UsdPrice * 29.94;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(UsdPrice + "USD\t");
            sb.Append(GrnPrice + "GRN\t");
            sb.AppendLine();
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
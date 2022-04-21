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
            GrnPrice = ConvertToUsd();
        }
        
        private double ConvertToUsd() => GrnPrice * 0.034;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(UsdPrice + "USD\t");
            sb.Append(GrnPrice + "GRN\t");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
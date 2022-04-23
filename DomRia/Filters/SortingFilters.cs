using DomRia.AbstractClasses;

namespace DomRia.Filters
{
    public static class SortingFilters
    {
        public static int Ascending(Product x, Product y) => x.Cost.Equals(y.Cost) ? 1 : 0;

        public static int Descending(Product x, Product y) => x.Cost.Equals(y.Cost) ? 0 : 1;
        
    }
}
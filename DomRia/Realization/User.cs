using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DomRia.AbstractClasses;
using DomRia.Filters;
using DomRia.InfoResources;
using DomRia.Products;

namespace DomRia.Realization
{
    public class User
    {
        private List<Product> _products;
        private List<Func<string, string, Location, Price,Contact, Product>> _create;

        public User()
        {
            _products = new List<Product>();
            _create = new List<Func<string, string, Location, Price,Contact, Product>>
            {
                CreateApartment,
                CreateHouse
            };
            ReadFromFile();
        }

        public void ShowByRealtor(string name, string lastName)
        {
            List<Product> tmp = new List<Product>();
            tmp = _products.FindAll(p => p.Realtor.Name == name && p.Realtor.LastName == lastName);
            tmp.ForEach(Console.WriteLine);
            GC.Collect(GC.GetGeneration(tmp));
        }
        public void ShowByRealtor(string number)
        {
            List<Product> tmp = new List<Product>();
            tmp = _products.FindAll(p => p.Realtor.PhoneNumber == number);
            tmp.ForEach(Console.WriteLine);
            GC.Collect(GC.GetGeneration(tmp));
        }
        
        /*public void ShowByDescending()
        {
            List<Product> tmp = new List<Product>(_products);
            tmp.Sort(SortingFilters.Descending);
            tmp.ForEach(Console.WriteLine);
            GC.Collect(GC.GetGeneration(tmp));
        }
        
        public void ShowByAscending()
        {
            List<Product> tmp = new List<Product>(_products);
            tmp.Sort(SortingFilters.Ascending);
            tmp.ForEach(Console.WriteLine);
            GC.Collect(GC.GetGeneration(tmp));
        }*/

        public void ShowByType(string type)
        {
            List<Product> tmp = new List<Product>();
            tmp = _products.FindAll(p => p.GetType().Name == type);
            tmp.ForEach(Console.WriteLine);
            GC.Collect(GC.GetGeneration(tmp));
        }

        public void ShowByCity(string city)
        {
            List<Product> tmp = new List<Product>();
            tmp = _products.FindAll(p => p.Location.City == city);
            tmp.ForEach(Console.WriteLine);
            GC.Collect(GC.GetGeneration(tmp));
        }
        
        public void ShowByDistrict(string city, string district)
        {
            List<Product> tmp = new List<Product>();
            tmp = _products.FindAll(p => p.Location.City == city && p.Location.District == district);
            tmp.ForEach(Console.WriteLine);
            GC.Collect(GC.GetGeneration(tmp));
        }
        
        private void ReadFromFile()
        {
            if (File.Exists("dataBase.txt") == false)
                throw new MissingFieldException();
            
            string allFile = File.ReadAllText("dataBase.txt");
            List<string> products = allFile.Split(new string('-',25)).ToList();
            foreach (var item in products)
            {
                List<string> product = item.Split('\n').ToList();
                for (int i = 0; i < product.Count; i++)
                    product[i] = product[i].Trim();
                product.RemoveAll(s => s == "\r" || s == "");
                if(product.Count == 0)
                    return;
                int type = GetIndexByType(product[5]);
                if(type >= 0)
                    _products.Add(_create[type]?.Invoke(product[0],product[3],
                        new Location(product[1]),new Price(product[2]),new Contact(product[4])));
            }
        }
        
        private int GetIndexByType(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "apartment":
                    return 0;
                case "house":
                    return 1;
            }

            return -1;
        }
        
        private Apartment CreateApartment(string title, string description, Location location, Price cost, Contact contact)
            => new Apartment(title, description, location, cost, contact);
        private House CreateHouse(string title, string description, Location location, Price cost, Contact contact)
            => new House(title, description, location, cost, contact);
    }
}
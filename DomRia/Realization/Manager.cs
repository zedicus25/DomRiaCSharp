using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using DomRia.AbstractClasses;
using DomRia.InfoResources;
using DomRia.Products;

namespace DomRia.Realization
{
    public class Manager
    {
        private List<Product> _products;

        private List<Func<string, string, Location, Price,Contact, Product>> _create;

        public Manager()
        {
            _products = new List<Product>();
            _create = new List<Func<string, string, Location, Price,Contact, Product>>
            {
                CreateApartment,
                CreateHouse
            };
        }

        public void AddProduct()
        {
            Console.WriteLine("Enter last name of realtor");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter name of realtor");
            string name = Console.ReadLine();
            Console.WriteLine("Enter phone number of realtor");
            string number = Console.ReadLine();
            Console.WriteLine("Enter type of product: ");
            Console.WriteLine("1-Apartment");
            Console.WriteLine("2-House");
            string str = Console.ReadLine();
            if (int.TryParse(str, out int type) == false)
            {
                Console.WriteLine("Cannot parse");
                Thread.Sleep(500);
                return;
            }
            Console.WriteLine("Enter title ads");
            string title = Console.ReadLine();
            Console.WriteLine("Enter description ads");
            string description = Console.ReadLine();
            Console.WriteLine("Enter price in dollars");
            str = Console.ReadLine();
            if (double.TryParse(str, out var price) == false)
            {
                Console.WriteLine("Cannot parse");
                Thread.Sleep(500);
                return;
            }
            Console.WriteLine("Enter city:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter district:");
            string district = Console.ReadLine();
            Console.WriteLine("Enter street:");
            string street = Console.ReadLine();
            Console.WriteLine("Enter number house:");
            str = Console.ReadLine();
            if (int.TryParse(str, out var num) == false)
            {
                Console.WriteLine("Cannot parse");
                Thread.Sleep(500);
                return;
            }
            AddProduct(_create[type-1]?.Invoke(title,description, new Location(city,district,street,num), 
                new Price(price), new Contact(name, lastName,number)));
        }

        public void AddProduct(Product product)
        {
            if(_products.Any(p => p.Title == product.Title && p.Description == product.Description) == false)
                _products.Add(product);
            else
            {
                Console.WriteLine("Cannot add because this element is has");
                Thread.Sleep(500);
            }
        }

        public void DeleteProduct(string title)
        { 
           Product forDelete = _products.FirstOrDefault(p => p.Title == title);
           _products.Remove(forDelete);
        }

        public void SaveToFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var p in _products)
            {
                sb.AppendLine(p.ToString());
            }
            if (File.Exists("dataBase.txt"))
            {
                File.AppendAllText("dataBase.txt",sb.ToString());
            }
            else
            {
                File.WriteAllText("dataBase.txt", sb.ToString());
            }
        }

        public void ReadFromFile()
        {
            
        }

        public void ShowAll()
        {
            if(_products.Count > 0)
                _products.ForEach(Console.WriteLine);
        }

        private Apartment CreateApartment(string title, string description, Location location, Price cost, Contact contact)
            => new Apartment(title, description, location, cost, contact);
        private House CreateHouse(string title, string description, Location location, Price cost, Contact contact)
            => new House(title, description, location, cost, contact);
    }
}
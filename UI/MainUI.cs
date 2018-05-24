using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.BL;
using Wozny.PW.INTERFACES;

namespace UI
{
    class MainUI
    {
        static void Main(string[] args)
        {
            var products = BusinessLogic.Instance.GetAllProducts();
            var producers = BusinessLogic.Instance.GetAllProducers();
            DisplayAllProducts(products);
            DisplayAllProducers(producers);
        }

        private static void DisplayAllProducts(IEnumerable<IProduct> products)
        {
            Console.WriteLine("Products: ");
            foreach (var product in products)
            {
                Console.WriteLine($"{product}\n");
            }
        }

        private static void DisplayAllProducers(IEnumerable<IProducer> producers)
        {
            Console.WriteLine("Producers: ");
            foreach (var producer in producers)
            {
                Console.WriteLine($"{producer}\n");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.CORE;
using Wozny.PW.INTERFACES;

namespace Wozny.PW.DAO
{
    public class DAOMock : IDAO
    {
        public IList<IProduct> Products { get; } = new List<IProduct>();
        public IList<IProducer> Producers { get; } = new List<IProducer>();

        public DAOMock()
        {
            var producer1 = new Producer(ProducerName.Lenovo, "China", "Pekin", 1984, "Yang Yuanqing");
            Producers.Add(producer1);
            var producer2 = new Producer(ProducerName.Razer, "USA", "Irvine", 1998, "Robert 'Razerguy' Krakoff");
            Producers.Add(producer2);

            var drive1 = new Drive(DriveType.HDD, 1024);
            var product1 = new Product(producer1, "P50", 12999.90, "Intel Core I7-6820 HQ", 15.5f, drive1);
            Products.Add(product1);
            var drive2 = new Drive(DriveType.SSD, 512);
            var product2 = new Product(producer2, "Blade Stealth", 7900.99, "Intel Core I5-8600k", 14, drive2);
            Products.Add(product2);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.CORE;
using Wozny.PW.DAO;
using Wozny.PW.INTERFACES;

namespace Wozny.PW.DAOMock
{
    public class DAOMockImpl: DAOAbstract
    {
        protected override void InsertStartingRecords()
        {
            var producer1 = new Producer(ProducerName.Lenovo, "China", "Pekin", 1984, "Yang Yuanqing");
            Producers.Add(producer1);
            var producer2 = new Producer(ProducerName.Razer, "USA", "Irvine", 1998, "Robert 'Razerguy' Krakoff");
            Producers.Add(producer2);

            var drive1 = new Drive(HardDriveType.HDD, 1024);
            var product1 = new Product(producer1, "P50", 12999.90, "Intel Core I7-6820 HQ", 15.5f, drive1);
            Products.Add(product1);
            var drive2 = new Drive(HardDriveType.SSD, 512);
            var product2 = new Product(producer2, "Blade Stealth", 7900.99, "Intel Core I7-8550U", 14, drive2);
            Products.Add(product2);
        }
    }
}

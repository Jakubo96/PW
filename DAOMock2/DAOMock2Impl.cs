using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.CORE;
using Wozny.PW.DAO;
using Wozny.PW.INTERFACES;

namespace Wozny.PW.DAOMock2
{
    public class DAOMock2Impl: DAOAbstract
    {
        protected override void InsertStartingRecords()
        {
            var producer1 = new Producer(ProducerName.HP, "USA", "Palo Alto", 1939, "Meg Whitman");
            Producers.Add(producer1);
            var producer2 = new Producer(ProducerName.Asus, "China", "Taipei", 1989, "Jerry Shen");
            Producers.Add(producer2);

            var drive1 = new Drive(HardDriveType.SSD, 128);
            var product1 = new Product(producer1, "Envy 13", 3299.00, "Intel Core I5-7200U", 13, drive1);
            Products.Add(product1);
            var drive2 = new Drive(HardDriveType.SSD, 256);
            var product2 = new Product(producer2, "VivoBook S14", 3199.00, "Intel Core I5-8250U", 14, drive2);
            Products.Add(product2);
        }
    }
}

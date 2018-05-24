using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.INTERFACES;

namespace Wozny.PW.DAO
{
    class Product : IProduct
    {
        public IProducer Producer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Processor { get; set; }
        public float ScreenSize { get; set; }
        public IDrive Drive { get; set; }

        public Product(IProducer producer, string model, double price, string processor, float screenSize, IDrive drive)
        {
            Producer = producer;
            Model = model;
            Price = price;
            Processor = processor;
            ScreenSize = screenSize;
            Drive = drive;
        }

        public override string ToString()
        {
            return
                $"{nameof(Producer)}: {Producer}, {nameof(Model)}: {Model}, {nameof(Price)}: {Price}, {nameof(Processor)}: {Processor}, {nameof(ScreenSize)}: {ScreenSize}, {nameof(Drive)}: {Drive}";
        }
    }
}
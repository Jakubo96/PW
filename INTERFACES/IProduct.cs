using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wozny.PW.INTERFACES
{
    public interface IProduct
    {
        IProducer Producer { get; set; }
        string Model { get; set; }
        double Price { get; set; }
        string Processor { get; set; }
        float ScreenSize { get; set; }
        IDrive Drive { get; set; }
    }
}
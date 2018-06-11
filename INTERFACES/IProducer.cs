using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.CORE;

namespace Wozny.PW.INTERFACES
{
    public interface IProducer
    {
        ProducerName? Name { get; set; }
        string Country { get; set; }
        string Headquarters { get; set; }
        int? Founded { get; set; }
        string CEO { get; set; }
    }
}

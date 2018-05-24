using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wozny.PW.INTERFACES
{
    public interface IDAO
    {
        IList<IProduct> Products { get; }
        IList<IProducer> Producers { get; }
    }
}
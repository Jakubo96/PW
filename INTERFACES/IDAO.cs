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

        void AddProduct(IProduct product);
        void AddProducer(IProducer producer);

        void RemoveProduct(IProduct product);
        void RemoveProducer(IProducer producer);
    }
}
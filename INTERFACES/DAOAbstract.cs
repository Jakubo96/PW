using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wozny.PW.INTERFACES
{
    public abstract class DAOAbstract : IDAO
    {
        public IList<IProduct> Products { get; } = new List<IProduct>();
        public IList<IProducer> Producers { get; } = new List<IProducer>();

        protected abstract void InsertStartingRecords();

        public void AddProduct(IProduct product)
        {
            Products.Add(product);
        }

        public void AddProducer(IProducer producer)
        {
            Producers.Add(producer);
        }

        public void RemoveProduct(IProduct product)
        {
            Products.Remove(product);
        }

        public void RemoveProducer(IProducer producer)
        {
            Producers.Remove(producer);
        }

        protected DAOAbstract() => InsertStartingRecords();
    }
}
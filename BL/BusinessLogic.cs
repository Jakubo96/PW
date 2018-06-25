using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.INTERFACES;

namespace Wozny.PW.BL
{
    public class BusinessLogic
    {
        public string DllName
        {
            set
            {
                Assembly assembly;
                try
                {
                    assembly = Assembly.Load(value);
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException($"Assembly {value} doesn\'t exist");
                }

                var types = assembly.GetTypes();
                if (types.Length == 0)
                {
                    throw new Exception($"No types declared inside the {value}");
                }

                _dao = Activator.CreateInstance(types[0]) as IDAO;
            }
        }

        private IDAO _dao;

        private static BusinessLogic _instance;
        public static BusinessLogic Instance => _instance ?? (_instance = new BusinessLogic());

        public IEnumerable<IProduct> GetAllProducts() => _dao.Products;

        public IEnumerable<IProducer> GetAllProducers() => _dao.Producers;

        public void RemoveProduct(IProduct product)
        {
            _dao.RemoveProduct(product);
        }

        public void RemoveProducer(IProducer producer)
        {
            _dao.RemoveProducer(producer);
        }

        public void AddProduct(IProduct product)
        {
            _dao.AddProduct(product);
        }

        public void AddProducer(IProducer producer)
        {
            _dao.AddProducer(producer);
        }
    }
}
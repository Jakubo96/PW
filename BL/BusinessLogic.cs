using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.DAO;
using Wozny.PW.DAOMock;
using Wozny.PW.DAOMock2;
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
        public static BusinessLogic Instance { get; } = new BusinessLogic();

        public IEnumerable<IProduct> GetAllProducts()
        {
            return _dao.Products;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _dao.Producers;
        }

        public void ModifyProduct(IProduct product)
        {
        }

        public void ModifyProducer(IProducer producer)
        {
        }

        public void AddEmptyProduct()
        {
            _dao.AddProduct(new Product(new Producer(), new Drive()));
        }

        public void AddEmptyProducer()
        {
            _dao.AddProducer(new Producer());    
        }
    }
}
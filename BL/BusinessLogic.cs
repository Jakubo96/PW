using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
                var assembly = Assembly.Load(value);
                var types = assembly.GetTypes();
                Console.WriteLine(assembly);
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
    }
}
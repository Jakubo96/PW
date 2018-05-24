using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.DAO;
using Wozny.PW.INTERFACES;

namespace Wozny.PW.BL
{
    public class BusinessLogic
    {
        private readonly IDAO _dao = new DAOMock();
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
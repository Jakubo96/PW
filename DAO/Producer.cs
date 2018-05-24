using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.CORE;
using Wozny.PW.INTERFACES;

namespace Wozny.PW.DAO
{
    public class Producer: IProducer
    {
        public ProducerName Name { get; set; }
        public string Country { get; set; }
        public string Headquarters { get; set; }
        public int Founded { get; set; }
        public string CEO { get; set; }

        public Producer(ProducerName name, string country, string headquarters, int founded, string ceo)
        {
            Name = name;
            Country = country;
            Headquarters = headquarters;
            Founded = founded;
            CEO = ceo;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Country)}: {Country}, {nameof(Headquarters)}: {Headquarters}, {nameof(Founded)}: {Founded}, {nameof(CEO)}: {CEO}";
        }
    }
}

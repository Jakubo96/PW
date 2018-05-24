using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.CORE;
using Wozny.PW.INTERFACES;

namespace Wozny.PW.DAO
{
    class Drive: IDrive
    {
        public DriveType Type { get; set; }
        public int Capacity { get; set; }

        public Drive(DriveType type, int capacity)
        {
            Type = type;
            Capacity = capacity;
        }

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(Capacity)}: {Capacity}";
        }
    }
}

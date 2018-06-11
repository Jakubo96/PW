using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.INTERFACES;
using Wozny.PW.CORE;

namespace Wozny.PW.DAO
{
    public class Drive : IDrive
    {
        public HardDriveType? Type { get; set; }
        public int? Capacity { get; set; }

        public Drive(HardDriveType type, int capacity)
        {
            Type = type;
            Capacity = capacity;
        }

        public Drive()
        {
        }

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(Capacity)}: {Capacity}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wozny.PW.CORE;

namespace Wozny.PW.INTERFACES
{
    public interface IDrive
    {
        HardDriveType Type { get; set; }
        int Capacity { get; set; }
    }
}
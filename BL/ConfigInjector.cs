using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wozny.PW.BL
{
    public static class ConfigInjector
    {
        public static void InjectDllNameToBL()
        {
            var settingsReader = new AppSettingsReader();
            var dllName = settingsReader.GetValue("dllName", typeof(string)) as string;
            BusinessLogic.Instance.DllName = dllName;
        }
    }
}
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.State.Registers
{
    public class Register : IRegister
    {
        private RegistryKey Rig;
        public Register()
        {
            Rig = Registry.CurrentUser.CreateSubKey("SOFTWARE\\IN Store");
        }
        public CultureInfo GetLanguage()
        {
            string Culture = (string)Rig.GetValue("Language");
            if (Culture != null && Culture != "")
            {
                return new CultureInfo(Culture);
            }
            else
            {
                SetLanguage(new CultureInfo("en-US"));
                return new CultureInfo("en-US");
            }
        }

        public void SetLanguage(CultureInfo Culture)
        {
            Rig.SetValue("Language", Culture.ToString());
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortNotify
{
    static public class RegistryMan
    {
        public enum REG_KEYS
        {
            STARTUP,
            LASTKEY,
        }

        public static Dictionary<REG_KEYS, string> KeyAddress = new Dictionary<REG_KEYS, string>()
        {
            { REG_KEYS.STARTUP, @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run" },
            { REG_KEYS.LASTKEY, @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Applets\Regedit" }
        };

        static public void OpenRegistryEditor(REG_KEYS address)
        {
            SetValue(REG_KEYS.LASTKEY, "LastKey", KeyAddress[address]);
            Process.Start("regedit");
        }

        static public void SetValue(REG_KEYS key, string valueName, string value)
        {
            if (!Enum.IsDefined(typeof(REG_KEYS), key))
            {
                throw new ArgumentException("Undefined enum value", nameof(key));
            }

            Registry.SetValue(
                KeyAddress[key],
                valueName,
                value);
        }

        static public void DeleteValue(REG_KEYS key, string valueName)
        {
            if (!Enum.IsDefined(typeof(REG_KEYS), key))
            {
                throw new ArgumentException("Undefined enum value", nameof(key));
            }

            var regkey = Registry.CurrentUser.OpenSubKey(KeyAddress[key].Replace(Registry.CurrentUser.Name + "\\", ""), true);
            if (regkey != null)
            {
                regkey.DeleteValue(valueName, false);
                regkey.Close();
            }
        }
    }
}

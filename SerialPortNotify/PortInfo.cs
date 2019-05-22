using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SerialPortNotify
{
    public class PortInfo
    {
        public string InputText { get; private set; }
        public string PortName { get; private set; }
        public int PortNum { get; private set; }
        public bool Success { get; private set; } = true;
        public PortInfo(string port)
        {
            InputText = port;

            try
            {
                var regRes = Regex.Match(
                    port,
                    $@"^(?<{nameof(PortName)}>COM(?<{nameof(PortNum)}>([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])))($|[^\d])",
                    RegexOptions.RightToLeft);

                var result = regRes?.Success;
                if (result.HasValue && result.Value)
                {
                    var gName = regRes.Groups[nameof(PortName)];
                    if (gName.Success)
                    {
                        PortName = gName.Value;
                    }
                    var gNum = regRes.Groups[nameof(PortNum)];
                    if (gNum.Success)
                    {
                        PortNum = Convert.ToInt32(gNum.Value);
                    }
                }
            }
            catch { Success = false; }
        }
    }
}

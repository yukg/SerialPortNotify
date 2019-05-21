using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortNotify
{
    static public class NativeMethods
    {
        // Device Management Messages
        public const int WM_DEVICECHANGE = 0x219;

        // Device Management Events
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;

        // Device Type
        public const int DBT_DEVTYP_DEVICEINTERFACE = 0x00000005;
        public const int DBT_DEVTYP_HANDLE = 0x00000006;
        public const int DBT_DEVTYP_OEM = 0x00000000;
        public const int DBT_DEVTYP_PORT = 0x00000003;
        public const int DBT_DEVTYP_VOLUME = 0x00000002;

        static public DEV_BROADCAST_HDR Get_DEV_BROADCAST_HDR(IntPtr lparam)
            => Marshal.PtrToStructure<DEV_BROADCAST_HDR>(lparam);

        static public string GetPortName(IntPtr lparam)
            => Marshal.PtrToStringAuto((IntPtr)(lparam.ToInt64() + 12));
    }

    [StructLayout(LayoutKind.Sequential)]
    public class DEV_BROADCAST_HDR
    {
        public int dbch_size;
        public int dbch_devicetype;
        public int dbch_reserved;
    }
}

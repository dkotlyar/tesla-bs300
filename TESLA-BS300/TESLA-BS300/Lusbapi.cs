using System;
using System.Runtime.InteropServices;

namespace LCARD_E2010
{
    struct LAST_ERROR_INFO_LUSBAPI
    {
        byte[] ErrorString;                  // строка с кратким описанием последней ошибки
        int ErrorNumber;                      // номер последней ошибки
    };

    class Lusbapi
    {
        const uint MINIMUM_VERSION = (3 << 16) | (3); // Минимальная версия Lusbapi.dll 3.3
        const int MAX_SLOTS = 128;

        [DllImport("LusbapiLib.dll")]
        private static extern uint _GetDllVersion();
        [DllImport("LusbapiLib.dll")]
        private static extern IntPtr _CreateLInstance(string DeviceName);
        [DllImport("LusbapiLib.dll")]
        private static extern bool _OpenLDevice(IntPtr p, int slot);

        protected IntPtr pModule;
        protected int _openSlot = -1;
        public int openSlot { get { return _openSlot;  } }

        public Lusbapi(string deviceName)
        {
            uint dllVersion;
            if ((dllVersion = GetDllVersion()) < MINIMUM_VERSION)
                throw new Exception(String.Format("Lusbapi.dll Version Error. Current: {0}.{1}. Required: {2}.{3}", 
                    dllVersion >> 16, dllVersion & 0xFFFF,
                    MINIMUM_VERSION >> 16, MINIMUM_VERSION & 0xFFFF));

            CreateLInstance(deviceName);
        }

        public uint GetDllVersion()
        {
            return _GetDllVersion();
        }

        protected void CheckModule()
        {
            if (pModule == null || pModule == IntPtr.Zero) throw new Exception("Module Interface -> Bad");
        }

        public void CreateLInstance(string deviceName)
        {
            pModule = _CreateLInstance(deviceName);
            CheckModule();
        }

        public void OpenLDevice()
        {
            CheckModule();

            for (int i = 0; i < MAX_SLOTS; i++)
            {
                if (_OpenLDevice(pModule, i))
                {
                    _openSlot = i;
                    return;
                }
            }

            _openSlot = -1;
            throw new Exception(String.Format("Can't find any module in first {0} virtual slots", MAX_SLOTS));
        }
    }
}

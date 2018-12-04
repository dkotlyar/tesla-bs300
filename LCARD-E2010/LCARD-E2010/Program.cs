using System;
using System.Collections.Generic;

namespace LCARD_E2010
{
    class Program
    {

        static void Main(string[] args)
        {
            LE2010 pModule = new LE2010();
            try
            {
                pModule.OpenLDevice();
                Console.WriteLine("Device opened in slot {0}", pModule.openSlot);
                Console.WriteLine("Module name: \"{0}\"", pModule.GetModuleName());
                Console.WriteLine("USB speed: {0}", pModule.PrintUsbSpeed());

                pModule.LoadModule();
                pModule.TestModule();

                //DATA_STATE_E2010 data = pModule.GetDataState();
                //IO_REQUEST_LUSBAPI req = pModule.ReadData();

                IntPtr ap = pModule.GetAdcPars();
                pModule.SetAdcParams(ap, true, E2010_SynchroStartSource.Internal, E2010_SynchroClockSource.Internal, 0, 0, E2010_SynchroAdMode.NoAnalog, 0, 0, 0, 4, 5000, E2010_AdcInputRange._3000mV);
                pModule.SetAdcPars(ap);

                List<short> result = new List<short>();
                IntPtr[] req = new IntPtr[2];

                pModule.StopAdc();
                req[0] = pModule.GetIoReq();
                pModule.StartAdc();
                int reqNumber = 0;
                for (int i = 1; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(20);
                    reqNumber ^= 1;
                    req[reqNumber] = pModule.GetIoReq();
                    short[] res = (pModule.WaitResponse(req[reqNumber ^ 1]));
                    foreach (short r in res)
                    {
                        Console.WriteLine("{0} В", pModule.AdcToVoltage(r));
                    }
                }
                result.AddRange(pModule.WaitResponse(req[reqNumber]));
                pModule.StopAdc();

                //pModule.Automatic();
                Console.WriteLine("All good");
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                pModule.CloseLDevice();
                Console.WriteLine("Close device -> Ok");
                pModule.ReleaseLInstance();
                Console.WriteLine("Release instance -> Ok");
                pModule = null;
            }

            Console.WriteLine("Press enter any key ...");
            Console.ReadKey(true);
        }

        static void logger(string msg)
        {
            Console.WriteLine(msg);
        }

        static void logger(string format, params object[] pars)
        {
            Console.WriteLine(format, pars);
        }
    }
}

using LCARD_E2010;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace E2010_Graph
{
    public partial class Form1 : Form
    {
        LE2010 pModule;
        public Form1()
        {
            InitializeComponent();
        }

        private void WriteLine(string format, params object[] pars)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new MethodInvoker(delegate
                {
                    WriteLine(format, pars);
                }));
                return;
            }

            textBox1.AppendText(String.Format(format + Environment.NewLine, pars));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

            button1.Enabled = false;
            button4.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();

            while (backgroundWorker1.IsBusy) {}
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                pModule = new LE2010();
                pModule.OpenLDevice();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return;
            }

            try
            {
                WriteLine("Device opened in slot {0}", pModule.openSlot);
                WriteLine("Module name: \"{0}\"", pModule.GetModuleName());
                WriteLine("USB speed: {0}", pModule.PrintUsbSpeed());

                pModule.LoadModule();
                pModule.TestModule();

                IntPtr ap = pModule.GetAdcPars();
                pModule.SetAdcParams(ap, true, E2010_SynchroStartSource.Internal, E2010_SynchroClockSource.Internal, 0, 0, E2010_SynchroAdMode.NoAnalog, 0, 0, 0, 4, 5000, E2010_AdcInputRange._3000mV);
                pModule.SetAdcPars(ap);

                IntPtr[] req = new IntPtr[2];
                pModule.StopAdc();
                req[0] = pModule.GetIoReq();
                pModule.StartAdc();
                int reqNumber = 0;
                while (true)
                {
                    System.Threading.Thread.Sleep(20);
                    if (((BackgroundWorker)sender).CancellationPending)
                        break;
                    
                    reqNumber ^= 1;
                    req[reqNumber] = pModule.GetIoReq();
                    short[] res = (pModule.WaitResponse(req[reqNumber ^ 1]));
                    short[,] channels = pModule.SplitToChannels(res);

                    for (int j = 0; j < channels.GetLength(1); j++) {
                        AdcVector adcVector = new AdcVector();
                        adcVector.Channel1 = pModule.AdcToVoltage(channels[j, 0]);
                        adcVector.Channel2 = pModule.AdcToVoltage(channels[j, 1]);
                        adcVector.Channel3 = pModule.AdcToVoltage(channels[j, 2]);
                        adcVector.Channel4 = pModule.AdcToVoltage(channels[j, 3]);

                        if (button3.Enabled)
                        {
                            ((BackgroundWorker)sender).ReportProgress(0, adcVector);
                        }

                        //if (chart1.InvokeRequired)
                        //{
                        //    chart1.Invoke(new MethodInvoker(delegate
                        //    {
                        //        chart1.Series[0].Points.Add(pModule.AdcToVoltage(channels[j, 0]));
                        //    }));
                        //}
                        //if ()
                    }
                    //foreach (short r in channels)
                    //{ 
                    //    WriteLine("{0} В", pModule.AdcToVoltage(r));
                    //}
                }

                pModule.ClearResponse(req[reqNumber]);
                pModule.StopAdc();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                pModule.StopAdc();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pModule.CloseLDevice();
            WriteLine("Close device -> Ok");
            pModule.ReleaseLInstance();
            WriteLine("Release instance -> Ok");
            pModule = null;

            button1.Enabled = true;
            button4.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            AdcVector adcVector = (AdcVector)e.UserState;
            chart1.Series[0].Points.Add(adcVector.Channel1);

            WriteLine("{0} В", adcVector.Channel1);
        }
    }

    class AdcVector
    {
        public double Channel1 { get; set; }
        public double Channel2 { get; set; }
        public double Channel3 { get; set; }
        public double Channel4 { get; set; }
    }
}

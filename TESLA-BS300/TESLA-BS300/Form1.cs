using LCARD_E2010;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TESLA_BS300
{
    public partial class Form1 : Form
    {
        private const string xmlPropertiesFile = "properties.xml";
        private LE2010 pModule;

        private const string buildNumber = "20190214";

        private int imageWidth_px = 833;
        private int imageHeight_px = 625;
        private int minimamHorizontalLabelDistance_px = 75;
        private int minimamVerticalLabelDistance_px = 40;

        private int kadrStart_mV = 3000;
        private int kadrFinish_mV = 0;
        private int rowStart_mV = 3000;
        private int rowFinish_mV = 0;
        private int imageWhite_mV = 3000;
        private int imageBlack_mV = 0;
        private int imageWidth_unit = 833;
        private int imageHeight_unit = 625;
        private string measurementUnit = "px";

        private double? minKadrVoltage = null;
        private double? maxKadrVoltage = null;
        private double? minRowVoltage = null;
        private double? maxRowVoltage = null;
        private double? minVideoVoltage = null;
        private double? maxVideoVoltage = null;

        private int packageCount = 0;

        Bitmap teslaImage;
        Bitmap horizontalRuler;
        Bitmap verticalRuler;

        StringBuilder logSB = new StringBuilder();

        private double cursorPositionX_mm;
        private double cursorPositionY_mm;

        private int imageCursorX = 0;
        private int imageCursorY = 0;
        //private bool imageKadrWait = true;
        //private bool imageRowWait = true;
        //private int rowPerKadr = 0;
        //private int videoPerRow = 0;
        //private int interlacedRank = 1;     // Чересстрочное видео
        //private int interlacedIndex = 0;    // Индекс текущего чересстрочного смещения

        private List<AnalysisShape> analysisShapes = new List<AnalysisShape>();
        private bool analysisShapesClear = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void WriteLine(string format, params object[] args)
        {
            //if (logForm.InvokeRequired)
            //{
            //    logForm.Invoke(new MethodInvoker(delegate
            //    {
            //        WriteLine(format, args);
            //    }));
            //    return;
            //}
            //logForm.WriteLine(format, args);

            logSB.AppendFormat(format + Environment.NewLine, args);

            //if (logTextBox == null || logTextBox.IsDisposed) return;
            //if (logTextBox.InvokeRequired)
            //{
            //    logTextBox.Invoke(new MethodInvoker(delegate
            //    {
            //        WriteLine(format, args);
            //    }));
            //    return;
            //}

            //logTextBox.AppendText(String.Format(format + Environment.NewLine, args));
        }

        public void UpdateSettings(int imageWidth_unit, int imageHeight_unit, int kadrStart_mV, int kadrFinish_mV, int rowStart_mV, int rowFinish_mV, int imageBlack_mV, int imageWhite_mV, string measurementUnit)
        {
            this.imageHeight_unit = imageHeight_unit;
            this.imageWidth_unit = imageWidth_unit;
            this.kadrStart_mV = kadrStart_mV;
            this.kadrFinish_mV = kadrFinish_mV;
            this.rowStart_mV = rowStart_mV;
            this.rowFinish_mV = rowFinish_mV;
            this.imageBlack_mV = imageBlack_mV;
            this.imageWhite_mV = imageWhite_mV;
            this.measurementUnit = measurementUnit;

            XmlTextWriter textWritter = new XmlTextWriter(xmlPropertiesFile, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("properties");
            textWritter.WriteEndElement();
            textWritter.Close();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPropertiesFile);
            XmlElement root = xmlDocument.DocumentElement;

            XmlElement xmlImageWidth = xmlDocument.CreateElement("imagewidth");
            xmlImageWidth.InnerText = imageWidth_unit.ToString();
            root.AppendChild(xmlImageWidth);

            XmlElement xmlImageHeight = xmlDocument.CreateElement("imageheight");
            xmlImageHeight.InnerText = imageHeight_unit.ToString();
            root.AppendChild(xmlImageHeight);

            XmlElement xmlKadrStart = xmlDocument.CreateElement("kadrstart");
            xmlKadrStart.InnerText = kadrStart_mV.ToString();
            root.AppendChild(xmlKadrStart);

            XmlElement xmlKadrFinish = xmlDocument.CreateElement("kadrfinish");
            xmlKadrFinish.InnerText = kadrFinish_mV.ToString();
            root.AppendChild(xmlKadrFinish);

            XmlElement xmlRowStart = xmlDocument.CreateElement("rowstart");
            xmlRowStart.InnerText = rowStart_mV.ToString();
            root.AppendChild(xmlRowStart);

            XmlElement xmlRowFinish = xmlDocument.CreateElement("rowfinish");
            xmlRowFinish.InnerText = rowFinish_mV.ToString();
            root.AppendChild(xmlRowFinish);

            XmlElement xmlImageBlack = xmlDocument.CreateElement("imageblack");
            xmlImageBlack.InnerText = imageBlack_mV.ToString();
            root.AppendChild(xmlImageBlack);

            XmlElement xmlImageWhite = xmlDocument.CreateElement("imagewhite");
            xmlImageWhite.InnerText = imageWhite_mV.ToString();
            root.AppendChild(xmlImageWhite);

            XmlElement xmlMeasurementUnit = xmlDocument.CreateElement("measurementunit");
            xmlMeasurementUnit.InnerText = measurementUnit.ToString();
            root.AppendChild(xmlMeasurementUnit);

            xmlDocument.Save(xmlPropertiesFile);

            analysisShapesClear = true;

            RedrawRuler();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(xmlPropertiesFile))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlPropertiesFile);
                XmlElement root = xmlDocument.DocumentElement;

                foreach (XmlElement el in root.ChildNodes)
                {
                    try
                    {
                        switch (el.Name)
                        {
                            case "imagewidth": this.imageWidth_unit = int.Parse(el.InnerText); break;
                            case "imageheight": this.imageHeight_unit = int.Parse(el.InnerText); break;
                            case "kadrstart": this.kadrStart_mV = int.Parse(el.InnerText); break;
                            case "kadrfinish": this.kadrFinish_mV = int.Parse(el.InnerText); break;
                            case "rowstart": this.rowStart_mV = int.Parse(el.InnerText); break;
                            case "rowfinish": this.rowFinish_mV = int.Parse(el.InnerText); break;
                            case "imageblack": this.imageBlack_mV = int.Parse(el.InnerText); break;
                            case "imagewhite": this.imageWhite_mV = int.Parse(el.InnerText); break;
                            case "measurementunit": this.measurementUnit = el.InnerText; break;
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLine(ex.Message);
                    }
                }
            }

            RedrawImage();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e2010BackgroundWorker.CancelAsync();
            //while (e2010BackgroundWorker.IsBusy) { }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            RedrawRuler();
        }

        private void TeslaStopSync()
        {
            e2010BackgroundWorker.CancelAsync();
            while (e2010BackgroundWorker.IsBusy) { }
        }

        private void ClearImage()
        {
            bool teslaIsWork = e2010BackgroundWorker.IsBusy;
            if (teslaIsWork)
            {
                TeslaStopSync();
            }

            teslaImage = new Bitmap(imageWidth_px, imageHeight_px, PixelFormat.Format24bppRgb);

            if (teslaIsWork)
            {
                e2010BackgroundWorker.RunWorkerAsync();
            }
        }

        private void RedrawImage()
        {
            ClearImage();
///            Graphics graphics = Graphics.FromImage(teslaImage);
//            graphics.FillRectangle(Brushes.White, 0, 0, imageWidth_px, imageHeight_px);
//            graphics.DrawRectangle(Pens.Black, 1, 1, imageWidth_px - 3, imageHeight_px - 3);

            Random r = new Random();
            for (int i = 0; i < imageWidth_px; i++)
            {
                for (int j = 0; j < imageHeight_px; j++)
                {
                    Color color = Color.FromArgb(r.Next(64), r.Next(64), r.Next(64, 255));
                    teslaImage.SetPixel(i, j, color);
                }
            }
            
            workAreaPictureBox.Image = new Bitmap(teslaImage);
            RedrawRuler();
        }

        private void RedrawRuler()
        {
            int rulerWidth_px, rulerHeight_px;
            double imageRate = (double)imageWidth_px / imageHeight_px;
            double pbRate = (double)workAreaPictureBox.Width / workAreaPictureBox.Height;
            if (pbRate > imageRate) // если область отображения шире изображения
            {
                rulerHeight_px = workAreaPictureBox.Height;
                rulerWidth_px = (int)(rulerHeight_px * imageRate);
            }
            else // если область отображения уже изображения
            {
                rulerWidth_px = workAreaPictureBox.Width;
                rulerHeight_px = (int)(rulerWidth_px / imageRate);
            }

            if (rulerHeight_px == 0 || rulerWidth_px == 0)
                return;

            // Рисуем линейку

            horizontalRuler = new Bitmap(rulerWidth_px, horizontalRulerPictureBox.Height);
            Graphics hrGraphics = Graphics.FromImage(horizontalRuler);
            hrGraphics.FillRectangle(Brushes.White, 0, 0, rulerWidth_px, horizontalRulerPictureBox.Height);

            Font rulerFont = new Font(FontFamily.GenericMonospace, 12);

            // Определяем шаг линий (1, 2, 5, 10, 20, 50, 100, ...)
            double horizontalMmToPxRate = (double)imageWidth_unit / rulerWidth_px;
            double horizontalLabelStep_mm = horizontalMmToPxRate * minimamHorizontalLabelDistance_px;
            double horizontalDecimalPow = Math.Log10(horizontalLabelStep_mm);
            double horizontalLabelStepKoef = 1;
            if (horizontalDecimalPow - Math.Floor(horizontalDecimalPow) > 0.5)
            {
                horizontalLabelStepKoef = 5;
            } else if (horizontalDecimalPow - Math.Floor(horizontalDecimalPow) > 0.25)
            {
                horizontalLabelStepKoef = 2;
            }
            horizontalLabelStep_mm = Math.Pow(10, Math.Floor(horizontalDecimalPow)) * horizontalLabelStepKoef;

            for (double i = 0; i < imageWidth_unit; i += horizontalLabelStep_mm)
            {
                hrGraphics.DrawLine(Pens.Black, (int)(i / horizontalMmToPxRate), 0, (int)(i / horizontalMmToPxRate), horizontalRulerPictureBox.Height);
                hrGraphics.DrawString(i.ToString(), rulerFont, Brushes.Black, (int)(i / horizontalMmToPxRate), 0);
            }
            horizontalRulerPictureBox.Image = horizontalRuler;

            verticalRuler = new Bitmap(verticalRulerPictureBox.Width, rulerHeight_px);
            Graphics vrGraphics = Graphics.FromImage(verticalRuler);
            vrGraphics.FillRectangle(Brushes.White, 0, 0, verticalRulerPictureBox.Width, rulerHeight_px);

            // Определяем шаг линий (1, 2, 5, 10, 20, 50, 100, ...)
            double verticalMmToPxRate = (double)imageHeight_unit / rulerHeight_px;
            double verticalLabelStep_mm = verticalMmToPxRate * minimamVerticalLabelDistance_px;
            double verticalDecimalPow = Math.Log10(verticalLabelStep_mm);
            double verticalLabelStepKoef = 1;
            if (verticalDecimalPow - Math.Floor(verticalDecimalPow) > 0.5)
            {
                verticalLabelStepKoef = 5;
            }
            else if (verticalDecimalPow - Math.Floor(verticalDecimalPow) > 0.25)
            {
                verticalLabelStepKoef = 2;
            }
            verticalLabelStep_mm = Math.Pow(10, Math.Floor(verticalDecimalPow)) * verticalLabelStepKoef;
            
            for (double i = 0; i < imageHeight_unit; i += verticalLabelStep_mm)
            {
                vrGraphics.DrawLine(Pens.Black, 0, (int)(i / verticalMmToPxRate), verticalRulerPictureBox.Width, (int)(i / verticalMmToPxRate));
                vrGraphics.DrawString(i.ToString(), rulerFont, Brushes.Black, 0, (int)(i / verticalMmToPxRate));
            }
            verticalRulerPictureBox.Image = verticalRuler;

            rulerMeasurementUnitLabel.Text = this.measurementUnit;
        }

        private void RedrawAnalysisShapes(bool asyncCall = false)
        {
            bool redrawImage = !e2010BackgroundWorker.IsBusy;

            if (!redrawImage && !asyncCall) return;

            Bitmap tmpImage = teslaImage;
            if (redrawImage)
            {
                tmpImage = new Bitmap(teslaImage);
            }

            if (analysisShapesClear)
            {
                analysisShapes.Clear();
                analysisShapesClear = false;
                if (redrawImage)
                    workAreaPictureBox.Image = tmpImage;
                return;
            }

            double horizontalMmPerPx = (double)imageWidth_unit / imageWidth_px;
            double verticalMmPerPx = (double)imageHeight_unit / imageHeight_px;

            Graphics g = Graphics.FromImage(tmpImage);
            Font shapeFont = new Font(FontFamily.GenericMonospace, 12);

            foreach (AnalysisShape shape in analysisShapes)
            {
                if (shape is AnalysisLine)
                {
                    AnalysisLine line = (AnalysisLine)shape;
                    g.DrawLine(line.Pen, line.GetStartLocation(horizontalMmPerPx, verticalMmPerPx), line.GetFinishLocation(horizontalMmPerPx, verticalMmPerPx));
                    g.FillRectangle(line.Brush, line.GetStartRectangle(horizontalMmPerPx, verticalMmPerPx));
                    g.FillRectangle(line.Brush, line.GetFinishRectangle(horizontalMmPerPx, verticalMmPerPx));

                    string text = Math.Round(line.GetDistance(), 2) + " " + measurementUnit;
                    Size textSize = TextRenderer.MeasureText(text, shapeFont);
                    Rectangle r = new Rectangle(line.GetCenter(horizontalMmPerPx, verticalMmPerPx), textSize);
                    g.FillRectangle(Brushes.WhiteSmoke, r);
                    TextRenderer.DrawText(g, text, shapeFont, r, Color.Black);
                }
                else if (shape is AnalysisSquare)
                {
                    AnalysisSquare square = (AnalysisSquare)shape;
                    RectangleF r = square.GetRectangle(horizontalMmPerPx, verticalMmPerPx);
                    g.DrawRectangle(square.Pen, r.X, r.Y, r.Width, r.Height);

                    string text = Math.Round(square.GetSquareArea(), 2) + " кв." + measurementUnit;
                    Size textSize = TextRenderer.MeasureText(text, shapeFont);
                    Rectangle rt = square.GetTextRectangle(horizontalMmPerPx, verticalMmPerPx, textSize);
                    g.FillRectangle(Brushes.WhiteSmoke, rt);
                    TextRenderer.DrawText(g, text, shapeFont, rt, Color.Black);
                }
                else
                {
                    g.FillEllipse(shape.Brush, shape.GetRectangle(horizontalMmPerPx, verticalMmPerPx));
                }
            }

            if (redrawImage)
                workAreaPictureBox.Image = tmpImage;
        }

        private void e2010BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            teslaStatePictureBox.Image = Properties.Resources.yellow_light;
            try
            {
                pModule = new LE2010();
                pModule.OpenLDevice();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                WriteLine("Device opened in slot {0}", pModule.openSlot);
                WriteLine("USB speed: {0}", pModule.PrintUsbSpeed());

                pModule.LoadModule();
                pModule.TestModule();

                IntPtr ap = pModule.GetAdcPars();
                pModule.SetAdcParams(ap, true, E2010_SynchroStartSource.Internal, E2010_SynchroClockSource.Internal, 0, 0, E2010_SynchroAdMode.NoAnalog, 0, 0, 0, 4, 10000, E2010_AdcInputRange._3000mV);
                pModule.SetAdcPars(ap);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try { 
                tESLABS300ToolStripMenuItem.Checked = true;
                teslaStatePictureBox.Image = Properties.Resources.green_light;

                IntPtr[] req = new IntPtr[2];
                pModule.StopAdc();
                req[0] = pModule.GetIoReq();
                pModule.StartAdc();
                int reqNumber = 0;
                while (true)
                {
                    if (((BackgroundWorker)sender).CancellationPending)
                        break;

                    reqNumber ^= 1;
                    req[reqNumber] = pModule.GetIoReq();
                    short[] res = (pModule.WaitResponse(req[reqNumber ^ 1]));
                    short[,] channels = pModule.SplitToChannels(res);

                    ImageProcessing(channels);

                    ((BackgroundWorker)sender).ReportProgress(0, new Bitmap(teslaImage));

                }

                pModule.ClearResponse(req[reqNumber]);
                pModule.StopAdc();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pModule.StopAdc();
            }
        }

        private void e2010BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateTeslaImage((Bitmap)e.UserState);
        }

        private void e2010BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pModule.CloseLDevice();
            WriteLine("Close device -> Ok");
            pModule.ReleaseLInstance();
            WriteLine("Release instance -> Ok");
            pModule = null;

            tESLABS300ToolStripMenuItem.Checked = false;
            teslaStatePictureBox.Image = Properties.Resources.red_light;
        }

        private void ImageProcessing(short[,] channels)
        {
            int width = teslaImage.Width,
                height = teslaImage.Height;
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bitmapData = teslaImage.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] rgbValues = new byte[Math.Abs(bitmapData.Stride) * height];
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, rgbValues, 0, rgbValues.Length);
           
            try
            {
                #region Координаты пикселей закодированы напряжением kadr и row
                for (int j = 0; j < channels.GetLength(0); j++)
                {
                    double kadr = pModule.AdcToVoltage(channels[j, 0]);
                    double row = pModule.AdcToVoltage(channels[j, 1]);
                    double video = pModule.AdcToVoltage(channels[j, 2]);

                    // Корректировка нелинейного сжатия-растяжения изображения по горизонтали
                    //row = 1.39823 + 0.265127 * row + 0.799727 * Math.Log(row);
                    //row = 0.801461 + 1.13118 * row - 0.304856 * row * row + 0.038662 * row * row * row + 0.498053 * Math.Log(row);

                    if (minKadrVoltage == null || kadr < minKadrVoltage) minKadrVoltage = kadr;
                    if (maxKadrVoltage == null || kadr > maxKadrVoltage) maxKadrVoltage = kadr;
                    if (minRowVoltage == null || row < minRowVoltage) minRowVoltage = row;
                    if (maxRowVoltage == null || row > maxRowVoltage) maxRowVoltage = row;
                    if (minVideoVoltage == null || video < minVideoVoltage) minVideoVoltage = video;
                    if (maxVideoVoltage == null || video > maxVideoVoltage) maxVideoVoltage = video;

                    // Обратное кодирование координат
                    int imageCursorY = (height - 1) - (int)MapConstrain(kadr, (double)kadrFinish_mV / 1000, (double)kadrStart_mV / 1000, 0, height - 1);
                    int imageCursorX = (width - 1) - (int)MapConstrain(row, (double)rowFinish_mV / 1000, (double)rowStart_mV / 1000, 0, width - 1);
                    // Прямое кодирование координат
                    //int imageCursorY = (int)MapConstrain(kadr, (double)kadrFinish_mV / 1000, (double)kadrStart_mV / 1000, 0, height - 1);
                    //int imageCursorX = (int)MapConstrain(row, (double)rowFinish_mV / 1000, (double)rowStart_mV / 1000, 0, width - 1);

                    byte videoPixel = (byte)MapConstrain(video, (double)imageBlack_mV / 1000, (double)imageWhite_mV / 1000, 0, 255);
                    rgbValues[(3 * width + 1) * imageCursorY + 3 * imageCursorX + 0] = videoPixel;
                    rgbValues[(3 * width + 1) * imageCursorY + 3 * imageCursorX + 1] = videoPixel;
                    rgbValues[(3 * width + 1) * imageCursorY + 3 * imageCursorX + 2] = videoPixel;

                    packageCount++;
                }
                #endregion

                #region Телевизионная развертка
                //for (int j = 0; j < channels.GetLength(0); j++)
                //{
                //    double kadr = pModule.AdcToVoltage(channels[j, 0]);
                //    double row = pModule.AdcToVoltage(channels[j, 1]);
                //    double video = pModule.AdcToVoltage(channels[j, 2]);

                //    //textBox1.Invoke(new MethodInvoker(delegate
                //    //{
                //    //    textBox1.AppendText(kadr.ToString() + "\t" + row.ToString() + "\t" + video.ToString() + Environment.NewLine);
                //    //}));

                //    // Получен строковый синхроимпульс
                //    if (kadr > 1 && imageKadrWait)
                //    {
                //        imageCursorX = 0;
                //        imageCursorY = interlacedIndex;
                //        imageKadrWait = false;

                //        interlacedIndex++;
                //        if (interlacedIndex >= interlacedRank) interlacedIndex = 0;

                //        rowPerKadr = 0;
                //    }
                //    else if (kadr < 1)
                //    {
                //        imageKadrWait = true;
                //    }

                //    // Получен кадровый синхроимпульск
                //    if (row > 0.7 && imageRowWait)
                //    {
                //        imageCursorY += interlacedRank;
                //        imageCursorX = 0;
                //        imageRowWait = false;

                //        videoPerRow = 0;
                //        rowPerKadr++;
                //    }
                //    else if (row < 0.7)
                //    {
                //        imageRowWait = true;
                //    }


                //    byte videoPixel = (byte)MapConstrain(video, 1, 2, 0, 255);
                //    videoPerRow++;

                //    if (imageCursorY >= imageHeight_px)
                //    {
                //        continue;
                //    }
                //    //for (int i = 0; i < (double)imageWidth_px / 80; i++)
                //    //{
                //    if (imageCursorX >= imageWidth_px)
                //        break;
                //    rgbValues[(3 * width + 1) * imageCursorY + 3 * imageCursorX + 0] = videoPixel;
                //    rgbValues[(3 * width + 1) * imageCursorY + 3 * imageCursorX + 1] = videoPixel;
                //    rgbValues[(3 * width + 1) * imageCursorY + 3 * imageCursorX + 2] = videoPixel;
                //    imageCursorX++;
                //    //}

                //    packageCount++;
                //}
                #endregion
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, bitmapData.Scan0, rgbValues.Length);
                teslaImage.UnlockBits(bitmapData);
            }

            RedrawAnalysisShapes(true);
        }

        Stopwatch sw = new Stopwatch();
        private void UpdateTeslaImage(Bitmap image)
        {
            workAreaPictureBox.Image = image;

            // Измерение производительности
            if (sw.IsRunning)
            {
                if (sw.Elapsed.TotalSeconds > 1)
                {
                    double packPerSec = packageCount / sw.Elapsed.TotalSeconds;
                    if (packPerSec > 1000000)
                    {
                        packageCountLabel.Text = Math.Round(packPerSec / 1000000, 3).ToString() + " МГц";
                    }
                    else if (packPerSec > 1000)
                    {
                        packageCountLabel.Text = Math.Round(packPerSec / 1000, 3).ToString() + " кГц";
                    }
                    else
                    {
                        packageCountLabel.Text = Math.Round(packPerSec, 1).ToString() + " Гц";
                    }
                    sw.Reset();
                    packageCount = 0;
                }
            }
            else
            {
                sw.Start();
            }
        }

        private double Constrain(double x, double a, double b)
        {
            if (a > b)
            {
                double tmp = a;
                a = b;
                b = tmp;
            }
            return Math.Max(Math.Min(x, b), a);
        }

        private double Map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        private double MapConstrain(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return Constrain(Map(x, in_min, in_max, out_min, out_max), out_min, out_max);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesForm propertiesForm = new PropertiesForm(this);
            propertiesForm.SetImageWidth_mm(imageWidth_unit);
            propertiesForm.SetImageHeight_mm(imageHeight_unit);
            propertiesForm.SetKadrStart_mV(kadrStart_mV);
            propertiesForm.SetKadrFinish_mV(kadrFinish_mV);
            propertiesForm.SetRowStart_mV(rowStart_mV);
            propertiesForm.SetRowFinish_mV(rowFinish_mV);
            propertiesForm.SetImageBlack_mV(imageBlack_mV);
            propertiesForm.SetImageWhite_mV(imageWhite_mV);
            propertiesForm.SetMeasurementUnit(measurementUnit);
            propertiesForm.ShowDialog();
        }

        private void tESLABS300ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                //teslaStatePictureBox.Image = Properties.Resources.green_light;
                if (!e2010BackgroundWorker.IsBusy)
                    e2010BackgroundWorker.RunWorkerAsync();
            } else
            {
                //teslaStatePictureBox.Image = Properties.Resources.red_light;
                if (e2010BackgroundWorker.IsBusy)
                    e2010BackgroundWorker.CancelAsync();

                packageCountLabel.Text = "нет";
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик программы:\n" +
                "Котляр Д. И. :: ИВМ-17\n" +
                "Номер сборки: " + buildNumber + "\n" +
                "Год разработки: 2018 г", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogForm logForm = new LogForm(logSB);
            logForm.ShowDialog();
        }
        
        private void workAreaPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int realImageWidth, realImageHeight;
            double imageRate = (double)imageWidth_px / imageHeight_px;
            double pbRate = (double)workAreaPictureBox.Width / workAreaPictureBox.Height;

            int imageStartX, imageStartY;
            if (pbRate > imageRate) // если область отображения шире изображения
            {
                realImageHeight = workAreaPictureBox.Height;
                realImageWidth = (int)(realImageHeight * imageRate);
                imageStartY = 0;
                imageStartX = (workAreaPictureBox.Width - realImageWidth) / 2;
            }
            else // если область отображения уже изображения
            {
                realImageWidth = workAreaPictureBox.Width;
                realImageHeight = (int)(realImageWidth / imageRate);
                imageStartX = 0;
                imageStartY = (workAreaPictureBox.Height - realImageHeight) / 2;
            }

            int mousePositionX_px = e.X - imageStartX;
            int mousePositionY_px = e.Y - imageStartY;

            if (mousePositionX_px < 0 || mousePositionX_px > realImageWidth) { workAreaMouseLeave(); return; }
            if (mousePositionY_px < 0 || mousePositionY_px > realImageHeight) { workAreaMouseLeave(); return; }

            horizontalLine.Width = verticalRulerPictureBox.Width;
            horizontalLine.Location = new Point(horizontalLine.Location.X, e.Y + workAreaPictureBox.Location.Y);
            horizontalLine.Visible = true;

            verticalLine.Height = horizontalRulerPictureBox.Height;
            verticalLine.Location = new Point(e.X + workAreaPictureBox.Location.X, verticalLine.Location.Y);
            verticalLine.Visible = true;

            double horizontalMmToPxRate = (double)imageWidth_unit / realImageWidth;
            double verticalMmToPxRate = (double)imageHeight_unit / realImageHeight;

            cursorPositionX_mm = horizontalMmToPxRate * mousePositionX_px;
            cursorPositionY_mm = verticalMmToPxRate * mousePositionY_px;

            label4.Visible = true;
            mousePositionLabel.Visible = true;
            mousePositionLabel.Text = (int)(cursorPositionX_mm) + ":" + (int)(cursorPositionY_mm) + " " + measurementUnit;
        }

        private void workAreaPictureBox_MouseLeave(object sender, EventArgs e)
        {
            workAreaMouseLeave();
        }

        AnalysisShape pointStartClick;
        private void workAreaPictureBox_Click(object sender, EventArgs e)
        {
            if (!distanceMeasurementToolStripMenuItem.Checked && !areaMeasurementToolStripMenuItem.Checked)
                return;

            if (pointStartClick == null)
            {
                pointStartClick = new AnalysisShape((float)cursorPositionX_mm, (float)cursorPositionY_mm);
                analysisShapes.Add(pointStartClick);
                
                RedrawAnalysisShapes();

                return;
            }

            PointF pointFinishClick = new PointF((float)cursorPositionX_mm, (float)cursorPositionY_mm);

            analysisShapes.Remove(pointStartClick);

            if (distanceMeasurementToolStripMenuItem.Checked)
            {
                AnalysisLine analysisLine = new AnalysisLine(pointStartClick.Location, pointFinishClick);
                analysisShapes.Add(analysisLine);

                MessageBox.Show(String.Format("Расстояние между точками: {0} {1}", analysisLine.GetDistance(), measurementUnit), "Результаты измерения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (areaMeasurementToolStripMenuItem.Checked)
            {
                AnalysisSquare analysisSquare = new AnalysisSquare(pointStartClick.Location, new SizeF(pointFinishClick.X - pointStartClick.Location.X, pointFinishClick.Y - pointStartClick.Location.Y));
                analysisShapes.Add(analysisSquare);

                MessageBox.Show(String.Format("Площадь прямоугольника: {0} кв.{1}", analysisSquare.GetSquareArea(), measurementUnit), "Результаты измерения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pointStartClick = null;

            RedrawAnalysisShapes();
        }

        private void workAreaMouseLeave()
        {
            label4.Visible = false;
            mousePositionLabel.Visible = false;
            horizontalLine.Visible = false;
            verticalLine.Visible = false;
        }

        private void distanceMeasurementToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                areaMeasurementToolStripMenuItem.Checked = false;
            }
        }

        private void areaMeasurementToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                distanceMeasurementToolStripMenuItem.Checked = false;
            }
        }

        private void clearMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            analysisShapesClear = true;
            RedrawAnalysisShapes();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TeslaStopSync();

                teslaImage = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                workAreaPictureBox.Image = new Bitmap(teslaImage);
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workAreaPictureBox.Image.Save(saveFileDialog.FileName);
            }
        }

        private void clearImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (e2010BackgroundWorker.IsBusy)
            {
                //ClearImage();
                MessageBox.Show("Остановите сбор данных и повторите попытку снова.");
            } else
            {
                RedrawImage();
            }
        }

        private void signalCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                String.Format(
                    "Начало кадрового сигнала {0} мВ\n" +
                    "Конец кадрового сигнала {1} мВ\n" +
                    "Начало строчного сигнала {2} мВ\n" +
                    "Конец строчного сигнала {3} мВ\n" +
                    "Минимум видеосигнала {4} мВ\n" +
                    "Максимум видеосигнала {5} мВ\n",
                    minKadrVoltage != null ? ((int)(minKadrVoltage * 1000)).ToString() : "н/д",
                    maxKadrVoltage != null ? ((int)(maxKadrVoltage * 1000)).ToString() : "н/д",
                    minRowVoltage != null ? ((int)(minRowVoltage * 1000)).ToString() : "н/д",
                    maxRowVoltage != null ? ((int)(maxRowVoltage * 1000)).ToString() : "н/д",
                    minVideoVoltage != null ? ((int)(minVideoVoltage * 1000)).ToString() : "н/д",
                    maxVideoVoltage != null ? ((int)(maxVideoVoltage * 1000)).ToString() : "н/д"),
                "Характеристики сигналов");
        }

        private void signalCharacterResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minKadrVoltage = null;
            maxKadrVoltage = null;
            minRowVoltage = null;
            maxRowVoltage = null;
        }
    }
}

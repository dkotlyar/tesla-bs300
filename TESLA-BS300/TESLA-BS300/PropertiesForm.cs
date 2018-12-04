using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TESLA_BS300
{
    public partial class PropertiesForm : Form
    {
        private Form1 parentForm;

        public PropertiesForm(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        public void SetImageWidth_mm(int imageWidth_mm)
        {
            this.imageWidth_mm.Value = imageWidth_mm;
        }

        public void SetImageHeight_mm(int imageHeight_mm)
        {
            this.imageHeight_mm.Value = imageHeight_mm;
        }

        public void SetKadrStart_mV(int kadrStart_mV)
        {
            this.kadrStart_mV.Value = kadrStart_mV;
        }

        public void SetKadrFinish_mV(int kadrFinish_mV)
        {
            this.kadrFinish_mV.Value = kadrFinish_mV;
        }

        public void SetRowStart_mV(int rowStart_mV)
        {
            this.rowStart_mV.Value = rowStart_mV;
        }

        public void SetRowFinish_mV(int rowFinish_mV)
        {
            this.rowFinish_mV.Value = rowFinish_mV;
        }

        public void SetImageBlack_mV(int imageBlack_mV)
        {
            this.imageBlack_mV.Value = imageBlack_mV;
        }

        public void SetImageWhite_mV(int imageWhite_mV)
        {
            this.imageWhite_mV.Value = imageWhite_mV;
        }

        public void SetMeasurementUnit(string measurementUnit)
        {
            measurementUnitTextbox.Text = measurementUnit;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            parentForm.UpdateSettings((int)imageWidth_mm.Value, (int)imageHeight_mm.Value, (int)kadrStart_mV.Value, (int)kadrFinish_mV.Value, (int)rowStart_mV.Value, (int)rowFinish_mV.Value, (int)imageBlack_mV.Value, (int)imageWhite_mV.Value, measurementUnitTextbox.Text);
            this.Close();
        }
    }
}

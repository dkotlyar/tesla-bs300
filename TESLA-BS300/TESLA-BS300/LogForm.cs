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
    public partial class LogForm : Form
    {
        private StringBuilder logSB;
        public LogForm(StringBuilder sb)
        {
            InitializeComponent();
            logSB = sb;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            logTextBox.Text = logSB.ToString();
        }
    }
}

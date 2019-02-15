namespace TESLA_BS300
{
    partial class PropertiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.imageWidth_mm = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.imageHeight_mm = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.kadrStart_mV = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.kadrFinish_mV = new System.Windows.Forms.NumericUpDown();
            this.rowFinish_mV = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.rowStart_mV = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.imageBlack_mV = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.imageWhite_mV = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.measurementUnitTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth_mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight_mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kadrStart_mV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kadrFinish_mV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowFinish_mV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowStart_mV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBlack_mV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWhite_mV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ширина изображения";
            // 
            // imageWidth_mm
            // 
            this.imageWidth_mm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageWidth_mm.Location = new System.Drawing.Point(172, 168);
            this.imageWidth_mm.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.imageWidth_mm.Name = "imageWidth_mm";
            this.imageWidth_mm.Size = new System.Drawing.Size(120, 20);
            this.imageWidth_mm.TabIndex = 1;
            this.imageWidth_mm.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Высота изображения";
            // 
            // imageHeight_mm
            // 
            this.imageHeight_mm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageHeight_mm.Location = new System.Drawing.Point(172, 195);
            this.imageHeight_mm.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.imageHeight_mm.Name = "imageHeight_mm";
            this.imageHeight_mm.Size = new System.Drawing.Size(120, 20);
            this.imageHeight_mm.TabIndex = 3;
            this.imageHeight_mm.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Начало кадра, мВ";
            // 
            // kadrStart_mV
            // 
            this.kadrStart_mV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kadrStart_mV.Location = new System.Drawing.Point(172, 12);
            this.kadrStart_mV.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.kadrStart_mV.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.kadrStart_mV.Name = "kadrStart_mV";
            this.kadrStart_mV.Size = new System.Drawing.Size(120, 20);
            this.kadrStart_mV.TabIndex = 5;
            this.kadrStart_mV.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Конец кадра, мВ";
            // 
            // kadrFinish_mV
            // 
            this.kadrFinish_mV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kadrFinish_mV.Location = new System.Drawing.Point(172, 38);
            this.kadrFinish_mV.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.kadrFinish_mV.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.kadrFinish_mV.Name = "kadrFinish_mV";
            this.kadrFinish_mV.Size = new System.Drawing.Size(120, 20);
            this.kadrFinish_mV.TabIndex = 7;
            // 
            // rowFinish_mV
            // 
            this.rowFinish_mV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowFinish_mV.Location = new System.Drawing.Point(172, 90);
            this.rowFinish_mV.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.rowFinish_mV.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.rowFinish_mV.Name = "rowFinish_mV";
            this.rowFinish_mV.Size = new System.Drawing.Size(120, 20);
            this.rowFinish_mV.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Конец строки, мВ";
            // 
            // rowStart_mV
            // 
            this.rowStart_mV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowStart_mV.Location = new System.Drawing.Point(172, 64);
            this.rowStart_mV.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.rowStart_mV.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.rowStart_mV.Name = "rowStart_mV";
            this.rowStart_mV.Size = new System.Drawing.Size(120, 20);
            this.rowStart_mV.TabIndex = 9;
            this.rowStart_mV.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Начало строки, мВ";
            // 
            // imageBlack_mV
            // 
            this.imageBlack_mV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBlack_mV.Location = new System.Drawing.Point(172, 116);
            this.imageBlack_mV.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.imageBlack_mV.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.imageBlack_mV.Name = "imageBlack_mV";
            this.imageBlack_mV.Size = new System.Drawing.Size(120, 20);
            this.imageBlack_mV.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Чёрный цвет, мВ";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(227, 260);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Отменить";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(146, 260);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Белый цвет, мВ";
            // 
            // imageWhite_mV
            // 
            this.imageWhite_mV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageWhite_mV.Location = new System.Drawing.Point(172, 142);
            this.imageWhite_mV.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.imageWhite_mV.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.imageWhite_mV.Name = "imageWhite_mV";
            this.imageWhite_mV.Size = new System.Drawing.Size(120, 20);
            this.imageWhite_mV.TabIndex = 17;
            this.imageWhite_mV.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Единицы измерения";
            // 
            // measurementUnitTextbox
            // 
            this.measurementUnitTextbox.Location = new System.Drawing.Point(172, 219);
            this.measurementUnitTextbox.Name = "measurementUnitTextbox";
            this.measurementUnitTextbox.Size = new System.Drawing.Size(120, 20);
            this.measurementUnitTextbox.TabIndex = 19;
            this.measurementUnitTextbox.Text = "мм";
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 295);
            this.Controls.Add(this.measurementUnitTextbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.imageWhite_mV);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.imageBlack_mV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rowFinish_mV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rowStart_mV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kadrFinish_mV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kadrStart_mV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imageHeight_mm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageWidth_mm);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры";
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth_mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight_mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kadrStart_mV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kadrFinish_mV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowFinish_mV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowStart_mV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBlack_mV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWhite_mV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown imageWidth_mm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown imageHeight_mm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown kadrStart_mV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown kadrFinish_mV;
        private System.Windows.Forms.NumericUpDown rowFinish_mV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown rowStart_mV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown imageBlack_mV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown imageWhite_mV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox measurementUnitTextbox;
    }
}
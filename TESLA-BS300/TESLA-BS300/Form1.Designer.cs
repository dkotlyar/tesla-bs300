namespace TESLA_BS300
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.e2010BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.устройствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tESLABS300ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.distanceMeasurementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaMeasurementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMeasurementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.signalCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signalCharacterResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.packageCountLabel = new System.Windows.Forms.Label();
            this.rulerMeasurementUnitLabel = new System.Windows.Forms.Label();
            this.verticalRulerPictureBox = new System.Windows.Forms.PictureBox();
            this.horizontalRulerPictureBox = new System.Windows.Forms.PictureBox();
            this.workAreaPictureBox = new System.Windows.Forms.PictureBox();
            this.teslaStatePictureBox = new System.Windows.Forms.PictureBox();
            this.mousePositionLabel = new System.Windows.Forms.Label();
            this.horizontalLine = new System.Windows.Forms.PictureBox();
            this.verticalLine = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalRulerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalRulerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workAreaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teslaStatePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // e2010BackgroundWorker
            // 
            this.e2010BackgroundWorker.WorkerReportsProgress = true;
            this.e2010BackgroundWorker.WorkerSupportsCancellation = true;
            this.e2010BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.e2010BackgroundWorker_DoWork);
            this.e2010BackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.e2010BackgroundWorker_ProgressChanged);
            this.e2010BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.e2010BackgroundWorker_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.устройствоToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.clearImageToolStripMenuItem,
            this.toolStripSeparator2,
            this.propertiesToolStripMenuItem,
            this.openLogToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.openImageToolStripMenuItem.Text = "Открыть изображение";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.saveImageToolStripMenuItem.Text = "Сохранить изображение";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // clearImageToolStripMenuItem
            // 
            this.clearImageToolStripMenuItem.Name = "clearImageToolStripMenuItem";
            this.clearImageToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.clearImageToolStripMenuItem.Text = "Очистить изображение";
            this.clearImageToolStripMenuItem.Click += new System.EventHandler(this.clearImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.propertiesToolStripMenuItem.Text = "Параметры";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.openLogToolStripMenuItem.Text = "Лог программы";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.exitToolStripMenuItem.Text = "Выйти из программы";
            // 
            // устройствоToolStripMenuItem
            // 
            this.устройствоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tESLABS300ToolStripMenuItem,
            this.toolStripSeparator1,
            this.distanceMeasurementToolStripMenuItem,
            this.areaMeasurementToolStripMenuItem,
            this.clearMeasurementToolStripMenuItem,
            this.toolStripSeparator4,
            this.signalCharacterToolStripMenuItem,
            this.signalCharacterResetToolStripMenuItem});
            this.устройствоToolStripMenuItem.Name = "устройствоToolStripMenuItem";
            this.устройствоToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.устройствоToolStripMenuItem.Text = "Устройство";
            // 
            // tESLABS300ToolStripMenuItem
            // 
            this.tESLABS300ToolStripMenuItem.CheckOnClick = true;
            this.tESLABS300ToolStripMenuItem.Name = "tESLABS300ToolStripMenuItem";
            this.tESLABS300ToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.tESLABS300ToolStripMenuItem.Text = "TESLA BS300";
            this.tESLABS300ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tESLABS300ToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(260, 6);
            // 
            // distanceMeasurementToolStripMenuItem
            // 
            this.distanceMeasurementToolStripMenuItem.CheckOnClick = true;
            this.distanceMeasurementToolStripMenuItem.Name = "distanceMeasurementToolStripMenuItem";
            this.distanceMeasurementToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.distanceMeasurementToolStripMenuItem.Text = "Измерение расстояния";
            this.distanceMeasurementToolStripMenuItem.CheckedChanged += new System.EventHandler(this.distanceMeasurementToolStripMenuItem_CheckedChanged);
            // 
            // areaMeasurementToolStripMenuItem
            // 
            this.areaMeasurementToolStripMenuItem.CheckOnClick = true;
            this.areaMeasurementToolStripMenuItem.Name = "areaMeasurementToolStripMenuItem";
            this.areaMeasurementToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.areaMeasurementToolStripMenuItem.Text = "Измерение площади";
            this.areaMeasurementToolStripMenuItem.CheckedChanged += new System.EventHandler(this.areaMeasurementToolStripMenuItem_CheckedChanged);
            // 
            // clearMeasurementToolStripMenuItem
            // 
            this.clearMeasurementToolStripMenuItem.Name = "clearMeasurementToolStripMenuItem";
            this.clearMeasurementToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.clearMeasurementToolStripMenuItem.Text = "Очистить измерения";
            this.clearMeasurementToolStripMenuItem.Click += new System.EventHandler(this.clearMeasurementToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(260, 6);
            // 
            // signalCharacterToolStripMenuItem
            // 
            this.signalCharacterToolStripMenuItem.Name = "signalCharacterToolStripMenuItem";
            this.signalCharacterToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.signalCharacterToolStripMenuItem.Text = "Характеристики сигнала";
            this.signalCharacterToolStripMenuItem.Click += new System.EventHandler(this.signalCharacterToolStripMenuItem_Click);
            // 
            // signalCharacterResetToolStripMenuItem
            // 
            this.signalCharacterResetToolStripMenuItem.Name = "signalCharacterResetToolStripMenuItem";
            this.signalCharacterResetToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.signalCharacterResetToolStripMenuItem.Text = "Сбросить характеристики сигнала";
            this.signalCharacterResetToolStripMenuItem.Click += new System.EventHandler(this.signalCharacterResetToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutProgramToolStripMenuItem.Text = "О программе";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(38, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "TESLA BS300";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Скорость сбора данных:";
            // 
            // packageCountLabel
            // 
            this.packageCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.packageCountLabel.AutoSize = true;
            this.packageCountLabel.Location = new System.Drawing.Point(520, 422);
            this.packageCountLabel.Name = "packageCountLabel";
            this.packageCountLabel.Size = new System.Drawing.Size(24, 13);
            this.packageCountLabel.TabIndex = 10;
            this.packageCountLabel.Text = "нет";
            // 
            // rulerMeasurementUnitLabel
            // 
            this.rulerMeasurementUnitLabel.BackColor = System.Drawing.Color.White;
            this.rulerMeasurementUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rulerMeasurementUnitLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rulerMeasurementUnitLabel.Location = new System.Drawing.Point(12, 27);
            this.rulerMeasurementUnitLabel.Name = "rulerMeasurementUnitLabel";
            this.rulerMeasurementUnitLabel.Size = new System.Drawing.Size(40, 20);
            this.rulerMeasurementUnitLabel.TabIndex = 12;
            this.rulerMeasurementUnitLabel.Text = "---";
            this.rulerMeasurementUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // verticalRulerPictureBox
            // 
            this.verticalRulerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.verticalRulerPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.verticalRulerPictureBox.Location = new System.Drawing.Point(12, 47);
            this.verticalRulerPictureBox.Name = "verticalRulerPictureBox";
            this.verticalRulerPictureBox.Size = new System.Drawing.Size(40, 365);
            this.verticalRulerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.verticalRulerPictureBox.TabIndex = 7;
            this.verticalRulerPictureBox.TabStop = false;
            // 
            // horizontalRulerPictureBox
            // 
            this.horizontalRulerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalRulerPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.horizontalRulerPictureBox.Location = new System.Drawing.Point(52, 27);
            this.horizontalRulerPictureBox.Name = "horizontalRulerPictureBox";
            this.horizontalRulerPictureBox.Size = new System.Drawing.Size(736, 20);
            this.horizontalRulerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.horizontalRulerPictureBox.TabIndex = 6;
            this.horizontalRulerPictureBox.TabStop = false;
            // 
            // workAreaPictureBox
            // 
            this.workAreaPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workAreaPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.workAreaPictureBox.Location = new System.Drawing.Point(52, 47);
            this.workAreaPictureBox.Name = "workAreaPictureBox";
            this.workAreaPictureBox.Size = new System.Drawing.Size(736, 365);
            this.workAreaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.workAreaPictureBox.TabIndex = 4;
            this.workAreaPictureBox.TabStop = false;
            this.workAreaPictureBox.Click += new System.EventHandler(this.workAreaPictureBox_Click);
            this.workAreaPictureBox.MouseLeave += new System.EventHandler(this.workAreaPictureBox_MouseLeave);
            this.workAreaPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.workAreaPictureBox_MouseMove);
            // 
            // teslaStatePictureBox
            // 
            this.teslaStatePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.teslaStatePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.teslaStatePictureBox.Image = global::TESLA_BS300.Properties.Resources.red_light;
            this.teslaStatePictureBox.InitialImage = null;
            this.teslaStatePictureBox.Location = new System.Drawing.Point(12, 418);
            this.teslaStatePictureBox.Name = "teslaStatePictureBox";
            this.teslaStatePictureBox.Size = new System.Drawing.Size(20, 20);
            this.teslaStatePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.teslaStatePictureBox.TabIndex = 3;
            this.teslaStatePictureBox.TabStop = false;
            // 
            // mousePositionLabel
            // 
            this.mousePositionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mousePositionLabel.AutoSize = true;
            this.mousePositionLabel.Location = new System.Drawing.Point(263, 422);
            this.mousePositionLabel.Name = "mousePositionLabel";
            this.mousePositionLabel.Size = new System.Drawing.Size(77, 13);
            this.mousePositionLabel.TabIndex = 13;
            this.mousePositionLabel.Text = "1000:1000 мм";
            this.mousePositionLabel.Visible = false;
            // 
            // horizontalLine
            // 
            this.horizontalLine.BackColor = System.Drawing.Color.OrangeRed;
            this.horizontalLine.Location = new System.Drawing.Point(12, 213);
            this.horizontalLine.Name = "horizontalLine";
            this.horizontalLine.Size = new System.Drawing.Size(40, 1);
            this.horizontalLine.TabIndex = 14;
            this.horizontalLine.TabStop = false;
            this.horizontalLine.Visible = false;
            // 
            // verticalLine
            // 
            this.verticalLine.BackColor = System.Drawing.Color.OrangeRed;
            this.verticalLine.Location = new System.Drawing.Point(386, 27);
            this.verticalLine.Name = "verticalLine";
            this.verticalLine.Size = new System.Drawing.Size(1, 20);
            this.verticalLine.TabIndex = 15;
            this.verticalLine.TabStop = false;
            this.verticalLine.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Позиция курсора:";
            this.label4.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(616, 341);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(172, 71);
            this.textBox1.TabIndex = 17;
            this.textBox1.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "tesla-bs300.bmp";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "tesla-bs300.bmp";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.DecimalPlaces = 4;
            this.numericUpDown1.Location = new System.Drawing.Point(673, 418);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(95, 20);
            this.numericUpDown1.TabIndex = 18;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown2.DecimalPlaces = 4;
            this.numericUpDown2.Location = new System.Drawing.Point(550, 418);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown2.TabIndex = 19;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(438, 341);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(172, 71);
            this.textBox2.TabIndex = 20;
            this.textBox2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.verticalLine);
            this.Controls.Add(this.horizontalLine);
            this.Controls.Add(this.mousePositionLabel);
            this.Controls.Add(this.rulerMeasurementUnitLabel);
            this.Controls.Add(this.packageCountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.verticalRulerPictureBox);
            this.Controls.Add(this.horizontalRulerPictureBox);
            this.Controls.Add(this.workAreaPictureBox);
            this.Controls.Add(this.teslaStatePictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TESLA BS300";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalRulerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalRulerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workAreaPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teslaStatePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker e2010BackgroundWorker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox teslaStatePictureBox;
        private System.Windows.Forms.ToolStripMenuItem устройствоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tESLABS300ToolStripMenuItem;
        private System.Windows.Forms.PictureBox workAreaPictureBox;
        private System.Windows.Forms.PictureBox horizontalRulerPictureBox;
        private System.Windows.Forms.PictureBox verticalRulerPictureBox;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label packageCountLabel;
        private System.Windows.Forms.Label rulerMeasurementUnitLabel;
        private System.Windows.Forms.Label mousePositionLabel;
        private System.Windows.Forms.PictureBox horizontalLine;
        private System.Windows.Forms.PictureBox verticalLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem distanceMeasurementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areaMeasurementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMeasurementToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem signalCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signalCharacterResetToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TextBox textBox2;
    }
}


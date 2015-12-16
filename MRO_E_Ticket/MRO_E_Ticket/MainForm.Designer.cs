namespace MRO_E_Ticket
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бинаризацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MethodBinarizationtoolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.perceptronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skeletizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nearestNeighborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TransferToGrayscaleTabPage = new System.Windows.Forms.TabPage();
            this.GrayScaleLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GrayScalePictureBox = new System.Windows.Forms.PictureBox();
            this.BinarizationTabPage = new System.Windows.Forms.TabPage();
            this.HistogrammlinkLabel = new System.Windows.Forms.LinkLabel();
            this.BinarizationImagelinkLabel = new System.Windows.Forms.LinkLabel();
            this.BinarizationPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.SegmentationPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressName = new System.Windows.Forms.Label();
            this.ImageRecognitionPictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveReconditionImageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.DividedIntoImageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RotationTextBox = new System.Windows.Forms.TextBox();
            this.ExpansionCheckBox = new System.Windows.Forms.CheckBox();
            this.ErosionCheckBox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DividedListView = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SceletizationCheckBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.DividedimageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PerceptronFromAnswer = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.NeighbLable = new System.Windows.Forms.Label();
            this.ResultLable = new System.Windows.Forms.Label();
            this.RecongnizeButton = new System.Windows.Forms.Button();
            this.LambdaArrayFromAnswer = new System.Windows.Forms.Button();
            this.ResultPerceptronFromAAnswer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TransferToGrayscaleTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrayScalePictureBox)).BeginInit();
            this.BinarizationTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BinarizationPictureBox)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentationPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageRecognitionPictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.OriginalPictureBox.Location = new System.Drawing.Point(0, 0);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(368, 587);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalPictureBox.TabIndex = 1;
            this.OriginalPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkKhaki;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageToolStripMenuItem,
            this.бинаризацияToolStripMenuItem,
            this.perceptronToolStripMenuItem,
            this.skeletizationToolStripMenuItem,
            this.nearestNeighborToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenImageToolStripMenuItem
            // 
            this.OpenImageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.OpenImageToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OpenImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenImageToolStripMenuItem.Image")));
            this.OpenImageToolStripMenuItem.Name = "OpenImageToolStripMenuItem";
            this.OpenImageToolStripMenuItem.Size = new System.Drawing.Size(103, 25);
            this.OpenImageToolStripMenuItem.Text = "Open Image";
            this.OpenImageToolStripMenuItem.Click += new System.EventHandler(this.OpenImageToolStripMenuItem_Click);
            // 
            // бинаризацияToolStripMenuItem
            // 
            this.бинаризацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MethodBinarizationtoolStripComboBox1,
            this.toolStripTextBox1});
            this.бинаризацияToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.бинаризацияToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("бинаризацияToolStripMenuItem.Image")));
            this.бинаризацияToolStripMenuItem.Name = "бинаризацияToolStripMenuItem";
            this.бинаризацияToolStripMenuItem.Size = new System.Drawing.Size(120, 25);
            this.бинаризацияToolStripMenuItem.Text = "Binarization";
            // 
            // MethodBinarizationtoolStripComboBox1
            // 
            this.MethodBinarizationtoolStripComboBox1.Items.AddRange(new object[] {
            "Метод 120",
            "Пороговый метод"});
            this.MethodBinarizationtoolStripComboBox1.Name = "MethodBinarizationtoolStripComboBox1";
            this.MethodBinarizationtoolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.MethodBinarizationtoolStripComboBox1.Tag = "";
            this.MethodBinarizationtoolStripComboBox1.Text = "Метод бинаризации";
            this.MethodBinarizationtoolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.MethodBinarizationtoolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "введите порог";
            // 
            // perceptronToolStripMenuItem
            // 
            this.perceptronToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.perceptronToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("perceptronToolStripMenuItem.Image")));
            this.perceptronToolStripMenuItem.Name = "perceptronToolStripMenuItem";
            this.perceptronToolStripMenuItem.Size = new System.Drawing.Size(113, 25);
            this.perceptronToolStripMenuItem.Text = "Perceptron";
            this.perceptronToolStripMenuItem.Click += new System.EventHandler(this.perceptronToolStripMenuItem_Click);
            // 
            // skeletizationToolStripMenuItem
            // 
            this.skeletizationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.skeletizationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("skeletizationToolStripMenuItem.Image")));
            this.skeletizationToolStripMenuItem.Name = "skeletizationToolStripMenuItem";
            this.skeletizationToolStripMenuItem.Size = new System.Drawing.Size(126, 25);
            this.skeletizationToolStripMenuItem.Text = "Skeletization";
            this.skeletizationToolStripMenuItem.Click += new System.EventHandler(this.skeletizationToolStripMenuItem_Click);
            // 
            // nearestNeighborToolStripMenuItem
            // 
            this.nearestNeighborToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.nearestNeighborToolStripMenuItem.Name = "nearestNeighborToolStripMenuItem";
            this.nearestNeighborToolStripMenuItem.Size = new System.Drawing.Size(146, 25);
            this.nearestNeighborToolStripMenuItem.Text = "Nearest Neighbor";
            this.nearestNeighborToolStripMenuItem.Click += new System.EventHandler(this.nearestNeighborToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.TransferToGrayscaleTabPage);
            this.tabControl1.Controls.Add(this.BinarizationTabPage);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 608);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.OriginalPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 582);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Original Image";
            // 
            // TransferToGrayscaleTabPage
            // 
            this.TransferToGrayscaleTabPage.Controls.Add(this.GrayScaleLinkLabel);
            this.TransferToGrayscaleTabPage.Controls.Add(this.GrayScalePictureBox);
            this.TransferToGrayscaleTabPage.Location = new System.Drawing.Point(4, 22);
            this.TransferToGrayscaleTabPage.Name = "TransferToGrayscaleTabPage";
            this.TransferToGrayscaleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TransferToGrayscaleTabPage.Size = new System.Drawing.Size(368, 582);
            this.TransferToGrayscaleTabPage.TabIndex = 1;
            this.TransferToGrayscaleTabPage.Text = "Grayscale";
            this.TransferToGrayscaleTabPage.UseVisualStyleBackColor = true;
            this.TransferToGrayscaleTabPage.Click += new System.EventHandler(this.TransferToGrayscaleTabPage_Click);
            // 
            // GrayScaleLinkLabel
            // 
            this.GrayScaleLinkLabel.AutoSize = true;
            this.GrayScaleLinkLabel.Location = new System.Drawing.Point(278, 566);
            this.GrayScaleLinkLabel.Name = "GrayScaleLinkLabel";
            this.GrayScaleLinkLabel.Size = new System.Drawing.Size(84, 13);
            this.GrayScaleLinkLabel.TabIndex = 1;
            this.GrayScaleLinkLabel.TabStop = true;
            this.GrayScaleLinkLabel.Text = "save gray image";
            this.GrayScaleLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Save_LinkClicked);
            // 
            // GrayScalePictureBox
            // 
            this.GrayScalePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrayScalePictureBox.Location = new System.Drawing.Point(0, 0);
            this.GrayScalePictureBox.Name = "GrayScalePictureBox";
            this.GrayScalePictureBox.Size = new System.Drawing.Size(368, 582);
            this.GrayScalePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GrayScalePictureBox.TabIndex = 0;
            this.GrayScalePictureBox.TabStop = false;
            // 
            // BinarizationTabPage
            // 
            this.BinarizationTabPage.Controls.Add(this.HistogrammlinkLabel);
            this.BinarizationTabPage.Controls.Add(this.BinarizationImagelinkLabel);
            this.BinarizationTabPage.Controls.Add(this.BinarizationPictureBox);
            this.BinarizationTabPage.Location = new System.Drawing.Point(4, 22);
            this.BinarizationTabPage.Name = "BinarizationTabPage";
            this.BinarizationTabPage.Size = new System.Drawing.Size(368, 582);
            this.BinarizationTabPage.TabIndex = 2;
            this.BinarizationTabPage.Text = "Binarization";
            this.BinarizationTabPage.UseVisualStyleBackColor = true;
            this.BinarizationTabPage.Click += new System.EventHandler(this.BinarizationTabPage_Click);
            // 
            // HistogrammlinkLabel
            // 
            this.HistogrammlinkLabel.AutoSize = true;
            this.HistogrammlinkLabel.Location = new System.Drawing.Point(3, 569);
            this.HistogrammlinkLabel.Name = "HistogrammlinkLabel";
            this.HistogrammlinkLabel.Size = new System.Drawing.Size(92, 13);
            this.HistogrammlinkLabel.TabIndex = 2;
            this.HistogrammlinkLabel.TabStop = true;
            this.HistogrammlinkLabel.Text = "Show Histogramm";
            this.HistogrammlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HistogrammlinkLabel_LinkClicked);
            // 
            // BinarizationImagelinkLabel
            // 
            this.BinarizationImagelinkLabel.AutoSize = true;
            this.BinarizationImagelinkLabel.Location = new System.Drawing.Point(244, 569);
            this.BinarizationImagelinkLabel.Name = "BinarizationImagelinkLabel";
            this.BinarizationImagelinkLabel.Size = new System.Drawing.Size(121, 13);
            this.BinarizationImagelinkLabel.TabIndex = 1;
            this.BinarizationImagelinkLabel.TabStop = true;
            this.BinarizationImagelinkLabel.Text = "Save Binarization Image";
            this.BinarizationImagelinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Save_LinkClicked);
            // 
            // BinarizationPictureBox
            // 
            this.BinarizationPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BinarizationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.BinarizationPictureBox.Name = "BinarizationPictureBox";
            this.BinarizationPictureBox.Size = new System.Drawing.Size(368, 582);
            this.BinarizationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BinarizationPictureBox.TabIndex = 0;
            this.BinarizationPictureBox.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.SegmentationPictureBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(368, 503);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Segmentation";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // SegmentationPictureBox
            // 
            this.SegmentationPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SegmentationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.SegmentationPictureBox.Name = "SegmentationPictureBox";
            this.SegmentationPictureBox.Size = new System.Drawing.Size(368, 537);
            this.SegmentationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SegmentationPictureBox.TabIndex = 0;
            this.SegmentationPictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.progressBar1.BackColor = System.Drawing.Color.DodgerBlue;
            this.progressBar1.Location = new System.Drawing.Point(8, 659);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(376, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // ProgressName
            // 
            this.ProgressName.AutoSize = true;
            this.ProgressName.BackColor = System.Drawing.Color.Transparent;
            this.ProgressName.ForeColor = System.Drawing.Color.White;
            this.ProgressName.Location = new System.Drawing.Point(9, 643);
            this.ProgressName.Name = "ProgressName";
            this.ProgressName.Size = new System.Drawing.Size(45, 13);
            this.ProgressName.TabIndex = 7;
            this.ProgressName.Text = "Process";
            // 
            // ImageRecognitionPictureBox1
            // 
            this.ImageRecognitionPictureBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ImageRecognitionPictureBox1.Location = new System.Drawing.Point(6, 49);
            this.ImageRecognitionPictureBox1.Name = "ImageRecognitionPictureBox1";
            this.ImageRecognitionPictureBox1.Size = new System.Drawing.Size(334, 50);
            this.ImageRecognitionPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageRecognitionPictureBox1.TabIndex = 8;
            this.ImageRecognitionPictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Image recognition";
            // 
            // SaveReconditionImageLinkLabel
            // 
            this.SaveReconditionImageLinkLabel.AutoSize = true;
            this.SaveReconditionImageLinkLabel.Location = new System.Drawing.Point(104, 27);
            this.SaveReconditionImageLinkLabel.Name = "SaveReconditionImageLinkLabel";
            this.SaveReconditionImageLinkLabel.Size = new System.Drawing.Size(32, 13);
            this.SaveReconditionImageLinkLabel.TabIndex = 10;
            this.SaveReconditionImageLinkLabel.TabStop = true;
            this.SaveReconditionImageLinkLabel.Text = "Save";
            this.SaveReconditionImageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Save_LinkClicked);
            // 
            // DividedIntoImageButton
            // 
            this.DividedIntoImageButton.Enabled = false;
            this.DividedIntoImageButton.Location = new System.Drawing.Point(6, 105);
            this.DividedIntoImageButton.Name = "DividedIntoImageButton";
            this.DividedIntoImageButton.Size = new System.Drawing.Size(334, 23);
            this.DividedIntoImageButton.TabIndex = 11;
            this.DividedIntoImageButton.Text = "divided into individual image";
            this.DividedIntoImageButton.UseVisualStyleBackColor = true;
            this.DividedIntoImageButton.Click += new System.EventHandler(this.DividedIntoImageButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(665, 593);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Panteleev R.V.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 13;
            this.button1.Text = "rotate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RotationTextBox
            // 
            this.RotationTextBox.Location = new System.Drawing.Point(5, 36);
            this.RotationTextBox.Name = "RotationTextBox";
            this.RotationTextBox.Size = new System.Drawing.Size(60, 20);
            this.RotationTextBox.TabIndex = 14;
            // 
            // ExpansionCheckBox
            // 
            this.ExpansionCheckBox.AutoSize = true;
            this.ExpansionCheckBox.Location = new System.Drawing.Point(9, 19);
            this.ExpansionCheckBox.Name = "ExpansionCheckBox";
            this.ExpansionCheckBox.Size = new System.Drawing.Size(75, 17);
            this.ExpansionCheckBox.TabIndex = 15;
            this.ExpansionCheckBox.Text = "Expansion";
            this.ExpansionCheckBox.UseVisualStyleBackColor = true;
            // 
            // ErosionCheckBox
            // 
            this.ErosionCheckBox.AutoSize = true;
            this.ErosionCheckBox.Location = new System.Drawing.Point(9, 42);
            this.ErosionCheckBox.Name = "ErosionCheckBox";
            this.ErosionCheckBox.Size = new System.Drawing.Size(61, 17);
            this.ErosionCheckBox.TabIndex = 16;
            this.ErosionCheckBox.Text = "Erosion";
            this.ErosionCheckBox.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(95, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 64);
            this.button2.TabIndex = 17;
            this.button2.Text = "create modify image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Rotate angle";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DividedListView);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ImageRecognitionPictureBox1);
            this.groupBox1.Controls.Add(this.SaveReconditionImageLinkLabel);
            this.groupBox1.Controls.Add(this.DividedIntoImageButton);
            this.groupBox1.Location = new System.Drawing.Point(398, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 231);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Divided image";
            // 
            // DividedListView
            // 
            this.DividedListView.BackColor = System.Drawing.Color.White;
            this.DividedListView.Location = new System.Drawing.Point(9, 134);
            this.DividedListView.Name = "DividedListView";
            this.DividedListView.Size = new System.Drawing.Size(331, 91);
            this.DividedListView.TabIndex = 12;
            this.DividedListView.UseCompatibleStateImageBehavior = false;
            this.DividedListView.SelectedIndexChanged += new System.EventHandler(this.DividedListView_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.RotationTextBox);
            this.groupBox2.Location = new System.Drawing.Point(398, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 67);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotate image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Input angle";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SceletizationCheckBox1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.ExpansionCheckBox);
            this.groupBox3.Controls.Add(this.ErosionCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(398, 364);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 91);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Expansion & Erosion";
            // 
            // SceletizationCheckBox1
            // 
            this.SceletizationCheckBox1.AutoSize = true;
            this.SceletizationCheckBox1.Location = new System.Drawing.Point(9, 66);
            this.SceletizationCheckBox1.Name = "SceletizationCheckBox1";
            this.SceletizationCheckBox1.Size = new System.Drawing.Size(86, 17);
            this.SceletizationCheckBox1.TabIndex = 18;
            this.SceletizationCheckBox1.Text = "Sceletization";
            this.SceletizationCheckBox1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(95, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 37);
            this.button4.TabIndex = 5;
            this.button4.Text = "λ\r\n";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DividedimageList1
            // 
            this.DividedimageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.DividedimageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.DividedimageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ResultPerceptronFromAAnswer);
            this.groupBox4.Controls.Add(this.LambdaArrayFromAnswer);
            this.groupBox4.Controls.Add(this.PerceptronFromAnswer);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.NeighbLable);
            this.groupBox4.Controls.Add(this.ResultLable);
            this.groupBox4.Controls.Add(this.RecongnizeButton);
            this.groupBox4.Location = new System.Drawing.Point(398, 461);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(346, 221);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Recondition";
            // 
            // PerceptronFromAnswer
            // 
            this.PerceptronFromAnswer.Location = new System.Drawing.Point(5, 69);
            this.PerceptronFromAnswer.Name = "PerceptronFromAnswer";
            this.PerceptronFromAnswer.Size = new System.Drawing.Size(92, 50);
            this.PerceptronFromAnswer.TabIndex = 7;
            this.PerceptronFromAnswer.Text = "Recognize perceptrom from answer";
            this.PerceptronFromAnswer.UseVisualStyleBackColor = true;
            this.PerceptronFromAnswer.Click += new System.EventHandler(this.PerceptronFromAnswer_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 140);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Recognize Neiggbor";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NeighbLable
            // 
            this.NeighbLable.AutoSize = true;
            this.NeighbLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NeighbLable.Location = new System.Drawing.Point(123, 142);
            this.NeighbLable.Name = "NeighbLable";
            this.NeighbLable.Size = new System.Drawing.Size(65, 26);
            this.NeighbLable.TabIndex = 3;
            this.NeighbLable.Text = "result";
            // 
            // ResultLable
            // 
            this.ResultLable.AutoSize = true;
            this.ResultLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLable.Location = new System.Drawing.Point(124, 29);
            this.ResultLable.Name = "ResultLable";
            this.ResultLable.Size = new System.Drawing.Size(65, 26);
            this.ResultLable.TabIndex = 2;
            this.ResultLable.Text = "result";
            // 
            // RecongnizeButton
            // 
            this.RecongnizeButton.Location = new System.Drawing.Point(5, 26);
            this.RecongnizeButton.Name = "RecongnizeButton";
            this.RecongnizeButton.Size = new System.Drawing.Size(95, 37);
            this.RecongnizeButton.TabIndex = 0;
            this.RecongnizeButton.Text = "Recognize perceptron";
            this.RecongnizeButton.UseVisualStyleBackColor = true;
            this.RecongnizeButton.Click += new System.EventHandler(this.RecongnizeButton_Click);
            // 
            // LambdaArrayFromAnswer
            // 
            this.LambdaArrayFromAnswer.Location = new System.Drawing.Point(94, 69);
            this.LambdaArrayFromAnswer.Name = "LambdaArrayFromAnswer";
            this.LambdaArrayFromAnswer.Size = new System.Drawing.Size(23, 50);
            this.LambdaArrayFromAnswer.TabIndex = 8;
            this.LambdaArrayFromAnswer.Text = "λ";
            this.LambdaArrayFromAnswer.UseVisualStyleBackColor = true;
            this.LambdaArrayFromAnswer.Click += new System.EventHandler(this.LambdaArrayFromAnswer_Click);
            // 
            // ResultPerceptronFromAAnswer
            // 
            this.ResultPerceptronFromAAnswer.AutoSize = true;
            this.ResultPerceptronFromAAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultPerceptronFromAAnswer.Location = new System.Drawing.Point(125, 79);
            this.ResultPerceptronFromAAnswer.Name = "ResultPerceptronFromAAnswer";
            this.ResultPerceptronFromAAnswer.Size = new System.Drawing.Size(65, 26);
            this.ResultPerceptronFromAAnswer.TabIndex = 9;
            this.ResultPerceptronFromAAnswer.Text = "result";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(756, 708);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressName);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "E-Ticket";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.TransferToGrayscaleTabPage.ResumeLayout(false);
            this.TransferToGrayscaleTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrayScalePictureBox)).EndInit();
            this.BinarizationTabPage.ResumeLayout(false);
            this.BinarizationTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BinarizationPictureBox)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SegmentationPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageRecognitionPictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenImageToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage TransferToGrayscaleTabPage;
        private System.Windows.Forms.TabPage BinarizationTabPage;
        private System.Windows.Forms.PictureBox GrayScalePictureBox;
        private System.Windows.Forms.PictureBox BinarizationPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox SegmentationPictureBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ProgressName;
        private System.Windows.Forms.LinkLabel GrayScaleLinkLabel;
        private System.Windows.Forms.LinkLabel BinarizationImagelinkLabel;
        private System.Windows.Forms.LinkLabel HistogrammlinkLabel;
        private System.Windows.Forms.PictureBox ImageRecognitionPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel SaveReconditionImageLinkLabel;
        private System.Windows.Forms.Button DividedIntoImageButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox RotationTextBox;
        private System.Windows.Forms.CheckBox ExpansionCheckBox;
        private System.Windows.Forms.CheckBox ErosionCheckBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem perceptronToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skeletizationToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem бинаризацияToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ImageList DividedimageList1;
        private System.Windows.Forms.ListView DividedListView;
        private System.Windows.Forms.CheckBox SceletizationCheckBox1;
        private System.Windows.Forms.ToolStripComboBox MethodBinarizationtoolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label ResultLable;
        private System.Windows.Forms.Button RecongnizeButton;
        private System.Windows.Forms.ToolStripMenuItem nearestNeighborToolStripMenuItem;
        private System.Windows.Forms.Label NeighbLable;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button PerceptronFromAnswer;
        private System.Windows.Forms.Button LambdaArrayFromAnswer;
        private System.Windows.Forms.Label ResultPerceptronFromAAnswer;
    }
}


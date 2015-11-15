namespace MRO_E_Ticket
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
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бинаризацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пороговаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.метод40ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.SuspendLayout();
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalPictureBox.Location = new System.Drawing.Point(0, 0);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(368, 501);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalPictureBox.TabIndex = 1;
            this.OriginalPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageToolStripMenuItem,
            this.бинаризацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenImageToolStripMenuItem
            // 
            this.OpenImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem});
            this.OpenImageToolStripMenuItem.Name = "OpenImageToolStripMenuItem";
            this.OpenImageToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.OpenImageToolStripMenuItem.Text = "Open Image";
            this.OpenImageToolStripMenuItem.Click += new System.EventHandler(this.OpenImageToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            // 
            // бинаризацияToolStripMenuItem
            // 
            this.бинаризацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пороговаяToolStripMenuItem,
            this.метод40ToolStripMenuItem});
            this.бинаризацияToolStripMenuItem.Name = "бинаризацияToolStripMenuItem";
            this.бинаризацияToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.бинаризацияToolStripMenuItem.Text = "Method Binarization";
            // 
            // пороговаяToolStripMenuItem
            // 
            this.пороговаяToolStripMenuItem.Checked = true;
            this.пороговаяToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.пороговаяToolStripMenuItem.Name = "пороговаяToolStripMenuItem";
            this.пороговаяToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.пороговаяToolStripMenuItem.Text = "threshold";
            // 
            // метод40ToolStripMenuItem
            // 
            this.метод40ToolStripMenuItem.Name = "метод40ToolStripMenuItem";
            this.метод40ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.метод40ToolStripMenuItem.Text = "method 40%";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.TransferToGrayscaleTabPage);
            this.tabControl1.Controls.Add(this.BinarizationTabPage);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 527);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.OriginalPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Original Image";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TransferToGrayscaleTabPage
            // 
            this.TransferToGrayscaleTabPage.Controls.Add(this.GrayScaleLinkLabel);
            this.TransferToGrayscaleTabPage.Controls.Add(this.GrayScalePictureBox);
            this.TransferToGrayscaleTabPage.Location = new System.Drawing.Point(4, 22);
            this.TransferToGrayscaleTabPage.Name = "TransferToGrayscaleTabPage";
            this.TransferToGrayscaleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TransferToGrayscaleTabPage.Size = new System.Drawing.Size(368, 501);
            this.TransferToGrayscaleTabPage.TabIndex = 1;
            this.TransferToGrayscaleTabPage.Text = "Grayscale";
            this.TransferToGrayscaleTabPage.UseVisualStyleBackColor = true;
            this.TransferToGrayscaleTabPage.Click += new System.EventHandler(this.TransferToGrayscaleTabPage_Click);
            // 
            // GrayScaleLinkLabel
            // 
            this.GrayScaleLinkLabel.AutoSize = true;
            this.GrayScaleLinkLabel.Location = new System.Drawing.Point(278, 485);
            this.GrayScaleLinkLabel.Name = "GrayScaleLinkLabel";
            this.GrayScaleLinkLabel.Size = new System.Drawing.Size(84, 13);
            this.GrayScaleLinkLabel.TabIndex = 1;
            this.GrayScaleLinkLabel.TabStop = true;
            this.GrayScaleLinkLabel.Text = "save gray image";
            this.GrayScaleLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GrayScaleLinkLabel_LinkClicked);
            // 
            // GrayScalePictureBox
            // 
            this.GrayScalePictureBox.Location = new System.Drawing.Point(0, 0);
            this.GrayScalePictureBox.Name = "GrayScalePictureBox";
            this.GrayScalePictureBox.Size = new System.Drawing.Size(368, 536);
            this.GrayScalePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
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
            this.BinarizationTabPage.Size = new System.Drawing.Size(368, 501);
            this.BinarizationTabPage.TabIndex = 2;
            this.BinarizationTabPage.Text = "Binarization";
            this.BinarizationTabPage.UseVisualStyleBackColor = true;
            this.BinarizationTabPage.Click += new System.EventHandler(this.BinarizationTabPage_Click);
            // 
            // HistogrammlinkLabel
            // 
            this.HistogrammlinkLabel.AutoSize = true;
            this.HistogrammlinkLabel.Location = new System.Drawing.Point(3, 488);
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
            this.BinarizationImagelinkLabel.Location = new System.Drawing.Point(244, 488);
            this.BinarizationImagelinkLabel.Name = "BinarizationImagelinkLabel";
            this.BinarizationImagelinkLabel.Size = new System.Drawing.Size(121, 13);
            this.BinarizationImagelinkLabel.TabIndex = 1;
            this.BinarizationImagelinkLabel.TabStop = true;
            this.BinarizationImagelinkLabel.Text = "Save Binarization Image";
            this.BinarizationImagelinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BinarizationImagelinkLabel_LinkClicked);
            // 
            // BinarizationPictureBox
            // 
            this.BinarizationPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BinarizationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.BinarizationPictureBox.Name = "BinarizationPictureBox";
            this.BinarizationPictureBox.Size = new System.Drawing.Size(368, 558);
            this.BinarizationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BinarizationPictureBox.TabIndex = 0;
            this.BinarizationPictureBox.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.SegmentationPictureBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(368, 501);
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
            this.SegmentationPictureBox.Size = new System.Drawing.Size(368, 530);
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
            this.progressBar1.Location = new System.Drawing.Point(12, 580);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(376, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // ProgressName
            // 
            this.ProgressName.AutoSize = true;
            this.ProgressName.Location = new System.Drawing.Point(13, 564);
            this.ProgressName.Name = "ProgressName";
            this.ProgressName.Size = new System.Drawing.Size(45, 13);
            this.ProgressName.TabIndex = 7;
            this.ProgressName.Text = "Process";
            // 
            // ImageRecognitionPictureBox1
            // 
            this.ImageRecognitionPictureBox1.Location = new System.Drawing.Point(394, 71);
            this.ImageRecognitionPictureBox1.Name = "ImageRecognitionPictureBox1";
            this.ImageRecognitionPictureBox1.Size = new System.Drawing.Size(350, 50);
            this.ImageRecognitionPictureBox1.TabIndex = 8;
            this.ImageRecognitionPictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Image recognition";
            // 
            // SaveReconditionImageLinkLabel
            // 
            this.SaveReconditionImageLinkLabel.AutoSize = true;
            this.SaveReconditionImageLinkLabel.Location = new System.Drawing.Point(492, 49);
            this.SaveReconditionImageLinkLabel.Name = "SaveReconditionImageLinkLabel";
            this.SaveReconditionImageLinkLabel.Size = new System.Drawing.Size(32, 13);
            this.SaveReconditionImageLinkLabel.TabIndex = 10;
            this.SaveReconditionImageLinkLabel.TabStop = true;
            this.SaveReconditionImageLinkLabel.Text = "Save";
            this.SaveReconditionImageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SaveReconditionImageLinkLabel_LinkClicked);
            // 
            // DividedIntoImageButton
            // 
            this.DividedIntoImageButton.Location = new System.Drawing.Point(394, 127);
            this.DividedIntoImageButton.Name = "DividedIntoImageButton";
            this.DividedIntoImageButton.Size = new System.Drawing.Size(350, 23);
            this.DividedIntoImageButton.TabIndex = 11;
            this.DividedIntoImageButton.Text = "divided into individual image";
            this.DividedIntoImageButton.UseVisualStyleBackColor = true;
            this.DividedIntoImageButton.Click += new System.EventHandler(this.DividedIntoImageButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(665, 593);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Panteleev R.V.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 615);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DividedIntoImageButton);
            this.Controls.Add(this.SaveReconditionImageLinkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ImageRecognitionPictureBox1);
            this.Controls.Add(this.ProgressName);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бинаризацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пороговаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem метод40ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage TransferToGrayscaleTabPage;
        private System.Windows.Forms.TabPage BinarizationTabPage;
        private System.Windows.Forms.PictureBox GrayScalePictureBox;
        private System.Windows.Forms.PictureBox BinarizationPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox SegmentationPictureBox;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
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
    }
}


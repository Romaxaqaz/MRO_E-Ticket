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
            this.label1 = new System.Windows.Forms.Label();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переводВПолутоновоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бинаризацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пороговаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.метод40ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GrayScalePictureBox = new System.Windows.Forms.PictureBox();
            this.BinarizationPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.SegmentationPictureBox = new System.Windows.Forms.PictureBox();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrayScalePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinarizationPictureBox)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавленное изображение";
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(0, 0);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(368, 536);
            this.OriginalPictureBox.TabIndex = 1;
            this.OriginalPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageToolStripMenuItem,
            this.переводВПолутоновоеToolStripMenuItem,
            this.бинаризацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenImageToolStripMenuItem
            // 
            this.OpenImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem});
            this.OpenImageToolStripMenuItem.Name = "OpenImageToolStripMenuItem";
            this.OpenImageToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.OpenImageToolStripMenuItem.Text = "открыть изображение";
            this.OpenImageToolStripMenuItem.Click += new System.EventHandler(this.OpenImageToolStripMenuItem_Click);
            // 
            // переводВПолутоновоеToolStripMenuItem
            // 
            this.переводВПолутоновоеToolStripMenuItem.Name = "переводВПолутоновоеToolStripMenuItem";
            this.переводВПолутоновоеToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            this.переводВПолутоновоеToolStripMenuItem.Text = "перевод в полутоновое";
            // 
            // бинаризацияToolStripMenuItem
            // 
            this.бинаризацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пороговаяToolStripMenuItem,
            this.метод40ToolStripMenuItem});
            this.бинаризацияToolStripMenuItem.Name = "бинаризацияToolStripMenuItem";
            this.бинаризацияToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.бинаризацияToolStripMenuItem.Text = "бинаризация";
            // 
            // пороговаяToolStripMenuItem
            // 
            this.пороговаяToolStripMenuItem.Name = "пороговаяToolStripMenuItem";
            this.пороговаяToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.пороговаяToolStripMenuItem.Text = "пороговая";
            // 
            // метод40ToolStripMenuItem
            // 
            this.метод40ToolStripMenuItem.Name = "метод40ToolStripMenuItem";
            this.метод40ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.метод40ToolStripMenuItem.Text = "метод 40%";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 562);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.OriginalPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Оригинал";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GrayScalePictureBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(368, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Полутоновое";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BinarizationPictureBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(368, 536);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Бинаризация";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // GrayScalePictureBox
            // 
            this.GrayScalePictureBox.Location = new System.Drawing.Point(0, 0);
            this.GrayScalePictureBox.Name = "GrayScalePictureBox";
            this.GrayScalePictureBox.Size = new System.Drawing.Size(368, 536);
            this.GrayScalePictureBox.TabIndex = 0;
            this.GrayScalePictureBox.TabStop = false;
            // 
            // BinarizationPictureBox
            // 
            this.BinarizationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.BinarizationPictureBox.Name = "BinarizationPictureBox";
            this.BinarizationPictureBox.Size = new System.Drawing.Size(368, 536);
            this.BinarizationPictureBox.TabIndex = 0;
            this.BinarizationPictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Выполнить сегментацию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.SegmentationPictureBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(368, 536);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Сегментация";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // SegmentationPictureBox
            // 
            this.SegmentationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.SegmentationPictureBox.Name = "SegmentationPictureBox";
            this.SegmentationPictureBox.Size = new System.Drawing.Size(368, 508);
            this.SegmentationPictureBox.TabIndex = 0;
            this.SegmentationPictureBox.TabStop = false;
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сохранитьToolStripMenuItem.Text = "сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 615);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "E-Ticket";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrayScalePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinarizationPictureBox)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SegmentationPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переводВПолутоновоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бинаризацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пороговаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem метод40ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox GrayScalePictureBox;
        private System.Windows.Forms.PictureBox BinarizationPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox SegmentationPictureBox;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
    }
}


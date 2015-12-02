namespace MRO_E_Ticket
{
    partial class PerceptronViewer
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openCollectionImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.learningPerseptronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listViewImageCollection = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PerseptronStatusLabel = new System.Windows.Forms.Label();
            this.AJElementsCountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PerseptronProgressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.NumberNameLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCollectionImageToolStripMenuItem,
            this.learningPerseptronToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openCollectionImageToolStripMenuItem
            // 
            this.openCollectionImageToolStripMenuItem.Name = "openCollectionImageToolStripMenuItem";
            this.openCollectionImageToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.openCollectionImageToolStripMenuItem.Text = "Open Collection Image";
            this.openCollectionImageToolStripMenuItem.Click += new System.EventHandler(this.openCollectionImageToolStripMenuItem_Click);
            // 
            // learningPerseptronToolStripMenuItem
            // 
            this.learningPerseptronToolStripMenuItem.Name = "learningPerseptronToolStripMenuItem";
            this.learningPerseptronToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.learningPerseptronToolStripMenuItem.Text = "Learning perseptron";
            this.learningPerseptronToolStripMenuItem.Click += new System.EventHandler(this.learningPerseptronToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewImageCollection
            // 
            this.listViewImageCollection.Location = new System.Drawing.Point(9, 48);
            this.listViewImageCollection.Margin = new System.Windows.Forms.Padding(0);
            this.listViewImageCollection.Name = "listViewImageCollection";
            this.listViewImageCollection.Size = new System.Drawing.Size(407, 227);
            this.listViewImageCollection.TabIndex = 3;
            this.listViewImageCollection.UseCompatibleStateImageBehavior = false;
            this.listViewImageCollection.SelectedIndexChanged += new System.EventHandler(this.listViewImageCollection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "perseptron status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PerseptronStatusLabel);
            this.groupBox1.Controls.Add(this.AJElementsCountTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(419, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perseptron settings";
            // 
            // PerseptronStatusLabel
            // 
            this.PerseptronStatusLabel.AutoSize = true;
            this.PerseptronStatusLabel.Location = new System.Drawing.Point(100, 52);
            this.PerseptronStatusLabel.Name = "PerseptronStatusLabel";
            this.PerseptronStatusLabel.Size = new System.Drawing.Size(59, 13);
            this.PerseptronStatusLabel.TabIndex = 6;
            this.PerseptronStatusLabel.Text = "no learning";
            // 
            // AJElementsCountTextBox
            // 
            this.AJElementsCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AJElementsCountTextBox.Location = new System.Drawing.Point(73, 19);
            this.AJElementsCountTextBox.Name = "AJElementsCountTextBox";
            this.AJElementsCountTextBox.Size = new System.Drawing.Size(47, 18);
            this.AJElementsCountTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Aj-elements";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Collection Image";
            // 
            // PerseptronProgressBar
            // 
            this.PerseptronProgressBar.Location = new System.Drawing.Point(9, 278);
            this.PerseptronProgressBar.Name = "PerseptronProgressBar";
            this.PerseptronProgressBar.Size = new System.Drawing.Size(407, 23);
            this.PerseptronProgressBar.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Number name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NumberNameLabel
            // 
            this.NumberNameLabel.AutoSize = true;
            this.NumberNameLabel.Location = new System.Drawing.Point(504, 158);
            this.NumberNameLabel.Name = "NumberNameLabel";
            this.NumberNameLabel.Size = new System.Drawing.Size(33, 13);
            this.NumberNameLabel.TabIndex = 10;
            this.NumberNameLabel.Text = "name";
            // 
            // PerceptronViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ClientSize = new System.Drawing.Size(644, 309);
            this.Controls.Add(this.NumberNameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PerseptronProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewImageCollection);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PerceptronViewer";
            this.Text = "PerceptronViewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openCollectionImageToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listViewImageCollection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AJElementsCountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem learningPerseptronToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PerseptronStatusLabel;
        private System.Windows.Forms.ProgressBar PerseptronProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label NumberNameLabel;
    }
}
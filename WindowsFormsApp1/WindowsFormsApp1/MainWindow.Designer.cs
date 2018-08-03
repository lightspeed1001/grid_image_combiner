namespace WindowsFormsApp1
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.boxWidth = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.boxHeight = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApply = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnLoadMap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Width";
            // 
            // boxWidth
            // 
            this.boxWidth.MaxLength = 2;
            this.boxWidth.Name = "boxWidth";
            this.boxWidth.Size = new System.Drawing.Size(25, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel2.Text = "Height";
            // 
            // boxHeight
            // 
            this.boxHeight.MaxLength = 2;
            this.boxHeight.Name = "boxHeight";
            this.boxHeight.Size = new System.Drawing.Size(25, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnApply
            // 
            this.btnApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(42, 22);
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Clicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 22);
            this.btnSave.Text = "Export Image";
            this.btnSave.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripLabel1,
            this.boxWidth,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.boxHeight,
            this.toolStripSeparator2,
            this.btnApply,
            this.toolStripSeparator3,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadMap,
            this.btnSaveMap,
            this.btnSettings,
            this.btnQuit});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(180, 22);
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(180, 22);
            this.btnSaveMap.Text = "Save Map";
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(180, 22);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Clicked);
            // 
            // btnQuit
            // 
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(180, 22);
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox boxWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox boxHeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnApply;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnLoadMap;
        private System.Windows.Forms.ToolStripMenuItem btnSaveMap;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.ToolStripMenuItem btnQuit;
    }
}


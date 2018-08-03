namespace WindowsFormsApp1
{
    partial class SettingsDialog
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkGreyscale = new System.Windows.Forms.CheckBox();
            this.txtTrim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScaling = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(10, 99);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(96, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkGreyscale
            // 
            this.chkGreyscale.AutoSize = true;
            this.chkGreyscale.Location = new System.Drawing.Point(12, 12);
            this.chkGreyscale.Name = "chkGreyscale";
            this.chkGreyscale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkGreyscale.Size = new System.Drawing.Size(73, 17);
            this.chkGreyscale.TabIndex = 4;
            this.chkGreyscale.Text = "Greyscale";
            this.chkGreyscale.UseVisualStyleBackColor = true;
            // 
            // txtTrim
            // 
            this.txtTrim.Location = new System.Drawing.Point(70, 36);
            this.txtTrim.MaxLength = 5;
            this.txtTrim.Name = "txtTrim";
            this.txtTrim.Size = new System.Drawing.Size(100, 20);
            this.txtTrim.TabIndex = 5;
            this.txtTrim.Text = "0";
            this.txtTrim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Side Trim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Scaling";
            // 
            // txtScaling
            // 
            this.txtScaling.Location = new System.Drawing.Point(70, 61);
            this.txtScaling.MaxLength = 5;
            this.txtScaling.Name = "txtScaling";
            this.txtScaling.Size = new System.Drawing.Size(100, 20);
            this.txtScaling.TabIndex = 8;
            this.txtScaling.Text = "1";
            this.txtScaling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(183, 134);
            this.Controls.Add(this.txtScaling);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTrim);
            this.Controls.Add(this.chkGreyscale);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkGreyscale;
        private System.Windows.Forms.TextBox txtTrim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScaling;
    }
}
namespace ConsoleListener
{
    partial class Form1
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
            this.btnListen = new System.Windows.Forms.Button();
            this.availCOMs = new System.Windows.Forms.ComboBox();
            this.textBaud = new System.Windows.Forms.TextBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(31, 165);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(193, 49);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "Launch!";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // availCOMs
            // 
            this.availCOMs.ForeColor = System.Drawing.Color.Black;
            this.availCOMs.FormattingEnabled = true;
            this.availCOMs.Location = new System.Drawing.Point(31, 30);
            this.availCOMs.Name = "availCOMs";
            this.availCOMs.Size = new System.Drawing.Size(193, 33);
            this.availCOMs.TabIndex = 1;
            // 
            // textBaud
            // 
            this.textBaud.Location = new System.Drawing.Point(31, 101);
            this.textBaud.Name = "textBaud";
            this.textBaud.Size = new System.Drawing.Size(193, 31);
            this.textBaud.TabIndex = 2;
            this.textBaud.Text = "9600";
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(276, 30);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.ReadOnly = true;
            this.textResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textResult.Size = new System.Drawing.Size(309, 178);
            this.textResult.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 237);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.textBaud);
            this.Controls.Add(this.availCOMs);
            this.Controls.Add(this.btnListen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Serial Listener";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ComboBox availCOMs;
        private System.Windows.Forms.TextBox textBaud;
        private System.Windows.Forms.TextBox textResult;
    }
}


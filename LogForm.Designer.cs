namespace PayrollV3
{
    partial class LogForm
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
            this.shift1 = new PayrollV3.shift();
            this.SuspendLayout();
            // 
            // shift1
            // 
            this.shift1.BackColor = System.Drawing.Color.Transparent;
            this.shift1.Location = new System.Drawing.Point(411, 211);
            this.shift1.Name = "shift1";
            this.shift1.Size = new System.Drawing.Size(8, 8);
            this.shift1.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.shift1);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private shift shift1;
    }
}
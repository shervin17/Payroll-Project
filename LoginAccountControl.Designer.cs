namespace PayrollV3
{
    partial class LoginAccountControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username_field = new System.Windows.Forms.TextBox();
            this.password_field = new System.Windows.Forms.TextBox();
            this.loginBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // username_field
            // 
            this.username_field.Location = new System.Drawing.Point(102, 37);
            this.username_field.Name = "username_field";
            this.username_field.Size = new System.Drawing.Size(186, 22);
            this.username_field.TabIndex = 2;
            // 
            // password_field
            // 
            this.password_field.Location = new System.Drawing.Point(102, 76);
            this.password_field.Name = "password_field";
            this.password_field.Size = new System.Drawing.Size(186, 22);
            this.password_field.TabIndex = 3;
            // 
            // loginBTN
            // 
            this.loginBTN.Location = new System.Drawing.Point(138, 114);
            this.loginBTN.Name = "loginBTN";
            this.loginBTN.Size = new System.Drawing.Size(75, 23);
            this.loginBTN.TabIndex = 4;
            this.loginBTN.Text = "login";
            this.loginBTN.UseVisualStyleBackColor = true;
            this.loginBTN.Click += new System.EventHandler(this.loginBTN_Click);
            // 
            // LoginAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loginBTN);
            this.Controls.Add(this.password_field);
            this.Controls.Add(this.username_field);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginAccountControl";
            this.Size = new System.Drawing.Size(333, 166);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_field;
        private System.Windows.Forms.TextBox password_field;
        private System.Windows.Forms.Button loginBTN;
    }
}

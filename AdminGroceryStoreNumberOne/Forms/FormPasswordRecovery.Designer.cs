
namespace AdminGroceryStoreNumberOne.Forms
{
    partial class FormPasswordRecovery
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
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.buttonGetCode = new System.Windows.Forms.Button();
            this.buttonEnterCode = new System.Windows.Forms.Button();
            this.labelCode = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(90, 6);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(142, 20);
            this.textBoxLogin.TabIndex = 3;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(12, 9);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(41, 13);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "Логин:";
            // 
            // buttonGetCode
            // 
            this.buttonGetCode.Location = new System.Drawing.Point(12, 58);
            this.buttonGetCode.Name = "buttonGetCode";
            this.buttonGetCode.Size = new System.Drawing.Size(220, 23);
            this.buttonGetCode.TabIndex = 4;
            this.buttonGetCode.Text = "Получить код";
            this.buttonGetCode.UseVisualStyleBackColor = true;
            this.buttonGetCode.Click += new System.EventHandler(this.buttonGetCode_Click);
            // 
            // buttonEnterCode
            // 
            this.buttonEnterCode.Enabled = false;
            this.buttonEnterCode.Location = new System.Drawing.Point(12, 87);
            this.buttonEnterCode.Name = "buttonEnterCode";
            this.buttonEnterCode.Size = new System.Drawing.Size(220, 23);
            this.buttonEnterCode.TabIndex = 4;
            this.buttonEnterCode.Text = "Восстановить пароль";
            this.buttonEnterCode.UseVisualStyleBackColor = true;
            this.buttonEnterCode.Click += new System.EventHandler(this.buttonEnterCode_Click);
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(12, 35);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(72, 13);
            this.labelCode.TabIndex = 2;
            this.labelCode.Text = "Код доступа:";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Enabled = false;
            this.textBoxCode.Location = new System.Drawing.Point(90, 32);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(142, 20);
            this.textBoxCode.TabIndex = 3;
            // 
            // FormPasswordRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 119);
            this.Controls.Add(this.buttonEnterCode);
            this.Controls.Add(this.buttonGetCode);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelLogin);
            this.Name = "FormPasswordRecovery";
            this.Text = "Восстановление пароля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button buttonGetCode;
        private System.Windows.Forms.Button buttonEnterCode;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.TextBox textBoxCode;
    }
}
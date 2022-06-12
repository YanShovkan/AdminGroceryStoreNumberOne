
namespace AdminGroceryStoreNumberOne.Forms
{
    partial class FormNewPassword
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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPasswordAgain = new System.Windows.Forms.TextBox();
            this.labelPasswordAgain = new System.Windows.Forms.Label();
            this.buttonCreateNewPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(182, 12);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(173, 20);
            this.textBoxPassword.TabIndex = 7;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(5, 15);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(126, 13);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Введите новый пароль:";
            // 
            // textBoxPasswordAgain
            // 
            this.textBoxPasswordAgain.Location = new System.Drawing.Point(182, 38);
            this.textBoxPasswordAgain.Name = "textBoxPasswordAgain";
            this.textBoxPasswordAgain.PasswordChar = '*';
            this.textBoxPasswordAgain.Size = new System.Drawing.Size(173, 20);
            this.textBoxPasswordAgain.TabIndex = 9;
            // 
            // labelPasswordAgain
            // 
            this.labelPasswordAgain.AutoSize = true;
            this.labelPasswordAgain.Location = new System.Drawing.Point(5, 41);
            this.labelPasswordAgain.Name = "labelPasswordAgain";
            this.labelPasswordAgain.Size = new System.Drawing.Size(171, 13);
            this.labelPasswordAgain.TabIndex = 8;
            this.labelPasswordAgain.Text = "Введите новый пароль ещё раз:";
            // 
            // buttonCreateNewPassword
            // 
            this.buttonCreateNewPassword.Location = new System.Drawing.Point(8, 64);
            this.buttonCreateNewPassword.Name = "buttonCreateNewPassword";
            this.buttonCreateNewPassword.Size = new System.Drawing.Size(347, 23);
            this.buttonCreateNewPassword.TabIndex = 10;
            this.buttonCreateNewPassword.Text = "Сохранить новый пароль";
            this.buttonCreateNewPassword.UseVisualStyleBackColor = true;
            this.buttonCreateNewPassword.Click += new System.EventHandler(this.buttonCreateNewPassword_Click);
            // 
            // FormNewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 96);
            this.Controls.Add(this.buttonCreateNewPassword);
            this.Controls.Add(this.textBoxPasswordAgain);
            this.Controls.Add(this.labelPasswordAgain);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Name = "FormNewPassword";
            this.Text = "Новый пароль";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPasswordAgain;
        private System.Windows.Forms.Label labelPasswordAgain;
        private System.Windows.Forms.Button buttonCreateNewPassword;
    }
}
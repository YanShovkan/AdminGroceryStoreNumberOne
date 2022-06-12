
namespace AdminGroceryStoreNumberOne.Forms
{
    partial class FormEnter
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.linkLabelPassword = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(13, 13);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(41, 13);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Логин:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(60, 10);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(173, 20);
            this.textBoxLogin.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(13, 39);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 0;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(60, 36);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(173, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(13, 79);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(220, 23);
            this.buttonEnter.TabIndex = 2;
            this.buttonEnter.Text = "Войти";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(13, 111);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(220, 23);
            this.buttonRegister.TabIndex = 2;
            this.buttonRegister.Text = "Зарегистрироваться";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // linkLabelPassword
            // 
            this.linkLabelPassword.AutoSize = true;
            this.linkLabelPassword.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabelPassword.Location = new System.Drawing.Point(142, 63);
            this.linkLabelPassword.Name = "linkLabelPassword";
            this.linkLabelPassword.Size = new System.Drawing.Size(91, 13);
            this.linkLabelPassword.TabIndex = 3;
            this.linkLabelPassword.TabStop = true;
            this.linkLabelPassword.Text = "Забыли пароль?";
            this.linkLabelPassword.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkLabelPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPassword_LinkClicked);
            // 
            // FormEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 146);
            this.Controls.Add(this.linkLabelPassword);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelLogin);
            this.Name = "FormEnter";
            this.Text = "Вход";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.LinkLabel linkLabelPassword;
    }
}



namespace AdminGroceryStoreNumberOne.Forms
{
    partial class FormAddTablePart
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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 64);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(238, 23);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(10, 41);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 5;
            this.labelCount.Text = "Количество:";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(9, 15);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(52, 13);
            this.labelProduct.TabIndex = 6;
            this.labelProduct.Text = "Продукт:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(81, 38);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(169, 20);
            this.textBoxCount.TabIndex = 3;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(81, 12);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(169, 21);
            this.comboBoxProduct.TabIndex = 8;
            // 
            // FormAddTablePart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 95);
            this.Controls.Add(this.comboBoxProduct);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.textBoxCount);
            this.Name = "FormAddTablePart";
            this.Text = "Поступление товара";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxProduct;
    }
}
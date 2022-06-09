
namespace AdminGroceryStoreNumberOne
{
    partial class FormReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.labelDateTo = new System.Windows.Forms.Label();
            this.buttonSaveReport = new System.Windows.Forms.Button();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonSendMail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportModelBindingSource
            // 
            this.ReportModelBindingSource.DataSource = typeof(BusinessLogic.Models.ReportModel);
            // 
            // dateTimePickerDateFrom
            // 
            this.dateTimePickerDateFrom.Location = new System.Drawing.Point(111, 19);
            this.dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
            this.dateTimePickerDateFrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDateFrom.TabIndex = 0;
            // 
            // dateTimePickerDateTo
            // 
            this.dateTimePickerDateTo.Location = new System.Drawing.Point(111, 53);
            this.dateTimePickerDateTo.Name = "dateTimePickerDateTo";
            this.dateTimePickerDateTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDateTo.TabIndex = 1;
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Location = new System.Drawing.Point(13, 19);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(92, 13);
            this.labelDateFrom.TabIndex = 2;
            this.labelDateFrom.Text = "Начало периода:";
            // 
            // labelDateTo
            // 
            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Location = new System.Drawing.Point(12, 53);
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(86, 13);
            this.labelDateTo.TabIndex = 2;
            this.labelDateTo.Text = "Конец периода:";
            // 
            // buttonSaveReport
            // 
            this.buttonSaveReport.Location = new System.Drawing.Point(292, 415);
            this.buttonSaveReport.Name = "buttonSaveReport";
            this.buttonSaveReport.Size = new System.Drawing.Size(224, 23);
            this.buttonSaveReport.TabIndex = 3;
            this.buttonSaveReport.Text = "Сохранить отчет в формате PDF";
            this.buttonSaveReport.UseVisualStyleBackColor = true;
            this.buttonSaveReport.Click += new System.EventHandler(this.buttonSaveReport_Click);
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Location = new System.Drawing.Point(16, 415);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(224, 23);
            this.buttonCreateReport.TabIndex = 4;
            this.buttonCreateReport.Text = "Сформировать отчет";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetReport";
            reportDataSource1.Value = this.ReportModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AdminGroceryStoreNumberOne.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(16, 94);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(772, 315);
            this.reportViewer.TabIndex = 5;
            // 
            // buttonSendMail
            // 
            this.buttonSendMail.Location = new System.Drawing.Point(564, 415);
            this.buttonSendMail.Name = "buttonSendMail";
            this.buttonSendMail.Size = new System.Drawing.Size(224, 23);
            this.buttonSendMail.TabIndex = 6;
            this.buttonSendMail.Text = "Отправить на почту";
            this.buttonSendMail.UseVisualStyleBackColor = true;
            this.buttonSendMail.Click += new System.EventHandler(this.buttonSendMail_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSendMail);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonCreateReport);
            this.Controls.Add(this.buttonSaveReport);
            this.Controls.Add(this.labelDateTo);
            this.Controls.Add(this.labelDateFrom);
            this.Controls.Add(this.dateTimePickerDateTo);
            this.Controls.Add(this.dateTimePickerDateFrom);
            this.Name = "FormReport";
            this.Text = "Отчет по заказам";
            ((System.ComponentModel.ISupportInitialize)(this.ReportModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.Button buttonSaveReport;
        private System.Windows.Forms.Button buttonCreateReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportModelBindingSource;
        private System.Windows.Forms.Button buttonSendMail;
    }
}
using BusinessLogic.Logic;
using BusinessLogic.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminGroceryStoreNumberOne.Forms
{
    public partial class FormMovementOfGoodsReport : Form
    {
        ReportLogic reportLogic = new ReportLogic();
        PdfLogic pdfLogic = new PdfLogic();
        UserModel user;

        public FormMovementOfGoodsReport(UserModel user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void buttonSendMail_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            SmtpClient client = new SmtpClient();
            try
            {
                using (var dialog = new OpenFileDialog { Filter = "pdf|*.pdf" })
                {
                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string basis = "Отчет по движению товаров";
                        msg.Subject = basis;

                        msg.From = new MailAddress("shovkanyanforlab@mail.ru");
                        msg.To.Add(user.login);
                        msg.IsBodyHtml = true;

                        Attachment attach = new Attachment(dialog.FileName, MediaTypeNames.Application.Octet);
                        ContentDisposition disposition = attach.ContentDisposition;

                        disposition.CreationDate = System.IO.File.GetCreationTime(dialog.FileName);
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(dialog.FileName);
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(dialog.FileName);

                        msg.Attachments.Add(attach);
                        client.Host = "smtp.mail.ru";
                        NetworkCredential basicauthenticationinfo = new NetworkCredential("shovkanyanforlab@mail.ru", "ud1Oo11iFkZ3X6zTbYMT");
                        client.Port = int.Parse("587");
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = basicauthenticationinfo;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Send(msg);

                        MessageBox.Show($"Сообщение отправлено на почту - {user.login}!", "Успех", MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private async void buttonSaveReport_Click(object sender, EventArgs e)
        {
            if (dateTimePickerDateFrom.Value.Date >= dateTimePickerDateTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var data = await reportLogic.GetReportMovementOfGoodsModels(dateTimePickerDateFrom.Value.Date, dateTimePickerDateTo.Value.Date);
                        pdfLogic.CreateReportAboutMovementOfGoods(data, dateTimePickerDateFrom.Value.Date, dateTimePickerDateTo.Value.Date, dialog.FileName);
                        MessageBox.Show("Файл сохранен успешно!", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void buttonCreateReport_Click(object sender, EventArgs e)
        {
            if (dateTimePickerDateFrom.Value.Date >= dateTimePickerDateTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
               "В период с " +
              dateTimePickerDateFrom.Value.ToShortDateString() +
               " по " +
              dateTimePickerDateTo.Value.ToShortDateString());
                reportViewer.LocalReport.SetParameters(parameter);
                var dataSource = await reportLogic.GetReportMovementOfGoodsModels(dateTimePickerDateFrom.Value.Date, dateTimePickerDateTo.Value.Date);
                reportViewer.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("DataSetMovementOfGoodsReport",
               dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormMovementOfGoodsReport_Load(object sender, EventArgs e)
        {

        }
    }
}

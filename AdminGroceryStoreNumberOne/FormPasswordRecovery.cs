using BusinessLogic.Logic;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminGroceryStoreNumberOne
{
    public partial class FormPasswordRecovery : Form
    {
        Random random = new Random();
        UserLogic userLogic = new UserLogic();
        int code;
        UserModel user;
        public FormPasswordRecovery()
        {
            InitializeComponent();
        }

        private async void buttonGetCode_Click(object sender, EventArgs e)
        {
            user = await userLogic.GetUser(textBoxLogin.Text);

            if (user == null)
            {
                MessageBox.Show("Такого пользователя не существует в системе", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }

            MailMessage msg = new MailMessage();
            SmtpClient client = new SmtpClient();
            try
            {
                code = random.Next(100000, 999999);

                string basis = $"Ваш код доступа - {code}";
                msg.Subject = basis;

                msg.From = new MailAddress("shovkanyanforlab@mail.ru");
                msg.To.Add(user.login);
                msg.IsBodyHtml = true;

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
                textBoxCode.Enabled = true;
                buttonEnterCode.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonEnterCode_Click(object sender, EventArgs e)
        {
            if(code == Convert.ToInt32(textBoxCode.Text))
            {
                Form form = new FormNewPassword(user);
                Hide();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный код доступа!", "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }
    }
}

using BusinessLogic.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminGroceryStoreNumberOne
{
    public partial class FormRegister : Form
    {
        UserLogic userLogic = new UserLogic();

        public FormRegister()
        {
            InitializeComponent();
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (textBoxPassword.Text.Length <= 3)
            {
                MessageBox.Show("Пароль должен содержать больше 3 символов", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                await userLogic.AddUser(textBoxLogin.Text, userLogic.hash(textBoxPassword.Text), "admin");
                MessageBox.Show("Регистрация прошла успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

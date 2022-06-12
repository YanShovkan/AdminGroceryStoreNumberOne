using BusinessLogic.Logic;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminGroceryStoreNumberOne.Forms
{
    public partial class FormNewPassword : Form
    {
        UserLogic userLogic = new UserLogic();
        UserModel user;
        public FormNewPassword(UserModel user)
        {
            this.user = user;
            InitializeComponent();
        }

        private async void buttonCreateNewPassword_Click(object sender, EventArgs e)
        {
            if (!textBoxPassword.Text.Equals(textBoxPasswordAgain.Text))
            {
                MessageBox.Show("Пароли должны совпадать", "Ошибка", MessageBoxButtons.OK,
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
                user.password = userLogic.hash(textBoxPassword.Text);
                await userLogic.UpdatePassword(user);
                MessageBox.Show("Пароль успешно изменен", "Сообщение",
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


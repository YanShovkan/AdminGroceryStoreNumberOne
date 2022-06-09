using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Logic;
using BusinessLogic.Models;

namespace AdminGroceryStoreNumberOne
{
    public partial class FormEnter : Form
    {
        UserLogic userLogic = new UserLogic();

        public FormEnter()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Form formRegister = new FormRegister();
            Hide();
            formRegister.ShowDialog();
            Show();
        }

        private async void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                UserModel user = await userLogic.CheckPassword(textBoxLogin.Text, userLogic.hash(textBoxPassword.Text));
                Form formMain = new FormMain(user);
                Hide();
                formMain.ShowDialog();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void linkLabelPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new FormPasswordRecovery();
            Hide();
            form.ShowDialog();
            Show();
        }
    }
}

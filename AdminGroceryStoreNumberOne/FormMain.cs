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

namespace AdminGroceryStoreNumberOne
{
    public partial class FormMain : Form
    {
        UserModel user;
        public FormMain(UserModel user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void продуктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formProducts = new FormProducts();
            formProducts.ShowDialog();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormBaskets();
            form.ShowDialog();
        }

        private void магазиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormShops();
            form.ShowDialog();
        }

        private void профильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProfile form = new FormProfile(user);
            if(form.ShowDialog() == DialogResult.Abort)
            {
                Close();
            }
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormUsers();
            form.ShowDialog();
        }

        private void отчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormReport(user);
            form.ShowDialog();
        }
    }
}

using BusinessLogic.DataGridModels;
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
    public partial class FormUsers : Form
    {
        UserLogic userLogic = new UserLogic();

        public FormUsers()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                List<CustomerModel> list = await userLogic.GetCustomers();

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormDiagram form = new FormDiagram(dataGridView.SelectedRows[0].Cells[0].Value.ToString(), dataGridView.SelectedRows[0].Cells[1].Value.ToString());
                form.ShowDialog();
            }
           
        }
    }
}

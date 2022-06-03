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

namespace AdminGroceryStoreNumberOne
{
    public partial class FormBaskets : Form
    {
        BasketLogic basketLogic = new BasketLogic();
        UserLogic userLogic = new UserLogic();
        public FormBaskets()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                List<BasketModel> list = await basketLogic.GetAllBaskets();
                List<BasketViewModel> viewList = new List<BasketViewModel>();
                List<UserModel> listUsers = await userLogic.GetAllUsers();
               
                foreach (BasketModel basket in list)
                {
                    viewList.Add(new BasketViewModel
                    {
                        id = basket.id,
                        date = new DateTime(1970,1,1).AddMilliseconds(basket.date).AddHours(4).ToString("dd/MM/yyyy HH:mm:ss"),
                        totalPrice = Math.Round(basket.totalPrice, 2),
                        userName = listUsers.FirstOrDefault(user => user.id.Equals(basket.userId)).login,
                        adress = basket.adress
                    });
                }

                if (viewList != null)
                {
                    dataGridView.DataSource = viewList;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonLook_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormBasket form = new FormBasket(dataGridView.SelectedRows[0].Cells[0].Value.ToString(), Convert.ToDecimal(dataGridView.SelectedRows[0].Cells[2].Value.ToString()));
                form.ShowDialog();
               
            }
        }
    }
}

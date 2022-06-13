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

namespace AdminGroceryStoreNumberOne.Forms
{
    public partial class FormProducts : Form
    {
        ProductLogic productLogic = new ProductLogic();
        public FormProducts()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var list = await productLogic.GetAllProducts();
                if (list != null)
                {
                    dataGridView.DataSource = list;
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

        private async void LoadData(string order)
        {
            try
            {
                var list = await productLogic.GetAllProducts();
                /*
                 По возрастанию цены
                 По убыванию цены
                 По возрастанию скидки
                 По убыванию скидки
                 Наличие скидки
                 Отсутствие скидки
                 */
                switch (order)
                {
                    case "По возрастанию цены":
                        list = list.OrderBy(p => p.price).ToList();
                        break;
                    case "По убыванию цены":
                        list = list.OrderByDescending(p => p.price).ToList();
                        break;
                    case "По возрастанию скидки":
                        list = list.OrderBy(p => p.discount).ToList();
                        break;
                    case "По убыванию скидки":
                        list = list.OrderByDescending(p => p.discount).ToList();
                        break;
                    case "Наличие скидки":
                        list = list.Where(p => p.discount > 0).ToList();
                        break;
                    case "Отсутствие скидки":
                        list = list.Where(p => p.discount == 0).ToList();
                        break;

                }
                if (list != null)
                {
                    dataGridView.DataSource = list;
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

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Form formProduct = new FormProduct();
            if (formProduct.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                    try
                    {
                        productLogic.DeleteProduct(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormProduct formProduct = new FormProduct();
                formProduct.Id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                if (formProduct.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void comboBoxSortByPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(comboBoxSortByPrice.Text);
        }
    }
}

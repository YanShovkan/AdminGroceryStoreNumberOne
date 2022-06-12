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
    public partial class FormAddTablePart : Form
    {
        ProductLogic productLogic = new ProductLogic();
        private string ProductId;
        private int Count;

        public string productId
        {
            get { return Convert.ToString(comboBoxProduct.SelectedValue); }
            set { ProductId = value;}
        }

        public int count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                Count = value;
            }
        }

        public FormAddTablePart()
        {
            LoadData();
            InitializeComponent();
        }

        public async void LoadData()
        {
            List<ProductModel> list = await productLogic.GetAllProducts();
            if (list != null)
            {
                comboBoxProduct.DisplayMember = "name";
                comboBoxProduct.ValueMember = "id";
                comboBoxProduct.DataSource = list;
                comboBoxProduct.SelectedItem = null;
            }

            if (!String.IsNullOrEmpty(ProductId))
            {
                comboBoxProduct.SelectedValue = ProductId;
                textBoxCount.Text = Count.ToString();
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

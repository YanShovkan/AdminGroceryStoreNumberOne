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
    public partial class FormProduct : Form
    {
        ProductLogic productLogic = new ProductLogic();
        public string Id { set { id = value; } }
        private string id;

        public FormProduct()
        {
            InitializeComponent();
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите название продукции", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Введите стоимость продукции", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    decimal discount = 0;
                    if (!string.IsNullOrEmpty(textBoxDiscount.Text))
                    {
                        discount = Convert.ToDecimal(textBoxDiscount.Text);
                    }
                    await productLogic.AddProduct(textBoxName.Text, Convert.ToDecimal(textBoxPrice.Text), discount);
                    MessageBox.Show("Добавление продукта прошло успешно", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    decimal discount = 0;
                    if (!string.IsNullOrEmpty(textBoxDiscount.Text))
                    {
                        discount = Convert.ToDecimal(textBoxDiscount.Text);
                    }
                    await productLogic.UpdateProduct(new ProductModel()
                    {
                        id = id,
                        name = textBoxName.Text,
                        price = Convert.ToDecimal(textBoxPrice.Text),
                        discount = discount
                    });
                    MessageBox.Show("Добавление продукта прошло успешно", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void FormProduct_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    ProductModel view = await productLogic.GetProduct(id);
                    if (view != null)
                    {
                        textBoxName.Text = view.name;
                        textBoxPrice.Text = view.price.ToString();
                        textBoxDiscount.Text = view.discount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
    }
}

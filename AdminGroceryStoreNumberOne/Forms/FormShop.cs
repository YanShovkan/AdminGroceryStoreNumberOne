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
    public partial class FormShop : Form
    {
        ShopLogic shopLogic = new ShopLogic();
        public string Id { set { id = value; } }
        private string id;
        public FormShop()
        {
            InitializeComponent();
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLatitude.Text))
            {
                MessageBox.Show("Введите широту", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxLatitude.Text))
            {
                MessageBox.Show("Введите долготу", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAdress.Text))
            {
                MessageBox.Show("Введите адрес", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    await shopLogic.AddShop(new ShopModel
                    {
                        longitude = Convert.ToDouble(textBoxLatitude.Text), 
                        latitude = Convert.ToDouble(textBoxLongitude.Text), 
                        adress = textBoxAdress.Text 
                    }
                    );
                    MessageBox.Show("Добавление продукта прошло успешно", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    await shopLogic.UpdateShop(new ShopModel()
                    {
                        id = id,
                        longitude = Convert.ToDouble(textBoxLatitude.Text),
                        latitude = Convert.ToDouble(textBoxLongitude.Text),
                        adress = textBoxAdress.Text
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

        private async void FormShop_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    ShopModel view = await shopLogic.GetShop(id);
                    if (view != null)
                    {
                        textBoxLatitude.Text = view.latitude.ToString();
                        textBoxLongitude.Text = view.longitude.ToString();
                        textBoxAdress.Text = view.adress;
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

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
    public partial class FormBasket : Form
    {
        BasketProductLogic basketProductLogic = new BasketProductLogic();
        ProductLogic productLogic = new ProductLogic();
        public FormBasket(string basketId, decimal totalPrice)
        {
            InitializeComponent();
            LoadData(basketId, totalPrice);
        }

        private async void LoadData(string basketId, decimal totalPrice)
        {
            try
            {
                List<BasketProductModel> list = await basketProductLogic.GetFiltredBasketProducts(basketId);
                List<BasketProductDataGridModel> viewList = new List<BasketProductDataGridModel>();
                List<ProductModel> listProducts = await productLogic.GetAllProducts();

                int index = 0;
                foreach (BasketProductModel basketProduct in list)
                {
                    viewList.Add(new BasketProductDataGridModel
                    {
                        id = basketProduct.id,
                        productName = listProducts.FirstOrDefault(product => product.id.Equals(basketProduct.productId)).name,
                        count = basketProduct.count,
                        totalPrice = listProducts.FirstOrDefault(product => product.id.Equals(basketProduct.productId)).price * basketProduct.count * (100 - listProducts.FirstOrDefault(product => product.id.Equals(basketProduct.productId)).discount) / 100
                    });
                    index++;
                }
                

                if (viewList != null)
                {
                    dataGridView.DataSource = viewList;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }


                labelTotal.Text = $"Итог: {Math.Round(totalPrice, 2).ToString()} рублей ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}

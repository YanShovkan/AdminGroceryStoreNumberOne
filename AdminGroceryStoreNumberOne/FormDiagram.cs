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
    public partial class FormDiagram : Form
    {
        UserLogic userLogic = new UserLogic();
        BasketLogic basketLogic = new BasketLogic();

        public FormDiagram(string userId, string login)
        {
            InitializeComponent();
            LoadData(userId, login);
        }

        private async void LoadData(string userId, string login)
        {
            try
            {
                this.Text = $"Диаграмма о заказах за {DateTime.Now.Year} год по дням";
                List<BasketModel> baskets = await basketLogic.GetAllBasketsByUserId(userId);
                List<ChartModel> data = new List<ChartModel>();

                baskets = baskets.Where(m => new DateTime(1970, 1, 1).AddMilliseconds(m.date).AddHours(4).Year == DateTime.Now.Year).ToList();
                chart.Series[0].Name =$"Сумма заказов пользователя - {login}";

                foreach (BasketModel basket in baskets)
                {
                    if (data.FirstOrDefault(m => m.date == new DateTime(1970, 1, 1).AddMilliseconds(basket.date).AddHours(4).DayOfYear) != null)
                    {
                        data.FirstOrDefault(m => m.date == new DateTime(1970, 1, 1).AddMilliseconds(basket.date).AddHours(4).DayOfYear).totalPrice = data.FirstOrDefault(m => m.date == new DateTime(1970, 1, 1).AddMilliseconds(basket.date).AddHours(4).DayOfYear).totalPrice + basket.totalPrice;
                    }
                    else
                    {
                        data.Add(new ChartModel
                        {
                            date = (new DateTime(1970, 1, 1).AddMilliseconds(basket.date).AddHours(4).DayOfYear),
                            totalPrice = basket.totalPrice
                        });
                    }
                }

                if(baskets.Count == 0)
                {
                    chart.Series[0].Points.AddXY(0, 0);
                    chart.Series[0].Points[0].IsEmpty = true;
                }

                foreach (ChartModel chartData in data)
                {
                    chart.Series[0].Points.AddXY(chartData.date, chartData.totalPrice);
                    chart.Series[0].Points[chart.Series[0].Points.Count - 1].Label = $"{Math.Round(chartData.totalPrice, 2)} руб.";
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

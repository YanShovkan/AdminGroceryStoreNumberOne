using BusinessLogic.DataGridModels;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ReportLogic
    {
        UserLogic userLogic = new UserLogic();
        BasketLogic basketLogic = new BasketLogic();

        public async Task<List<ReportModel>> GetReportModels(DateTime dateFrom, DateTime dateTo)
        {
            List<CustomerModel> users = await userLogic.GetCustomers();
            List<BasketModel> baskets = await basketLogic.GetAllBasketsByDate(dateFrom, dateTo);

            var list = new List<ReportModel>();
            foreach (CustomerModel user in users)
            {

                foreach (var basket in baskets)
                {
                    if (basket.userId.Equals(user.id))
                    {
                        ReportModel reportModel = new ReportModel
                        {
                            userLogin = user.userLogin,
                            date = new DateTime(1970, 1, 1).AddMilliseconds(basket.date).AddHours(4).ToString("dd/MM/yyyy HH:mm:ss"),
                            adress = basket.adress,
                            totalPrice = Math.Round(basket.totalPrice, 2)
                        };
                        list.Add(reportModel);
                    }
                }
            }
            return list;
        }
    }
}

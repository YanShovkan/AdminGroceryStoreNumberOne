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
        ProductLogic productLogic = new ProductLogic();
        MomentOfGoodsLogic momentOfGoodsLogic = new MomentOfGoodsLogic();
        public async Task<List<ReportModel>> GetReportModels(DateTime dateFrom, DateTime dateTo)
        {
            List<UserDataGridModel> users = await userLogic.GetCustomers();
            List<BasketModel> baskets = await basketLogic.GetAllBasketsByDate(dateFrom, dateTo);

            var list = new List<ReportModel>();
            foreach (UserDataGridModel user in users)
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

        public async Task<List<ReportMovementOfGoodsModel>> GetReportMovementOfGoodsModels(DateTime dateFrom, DateTime dateTo)
        {
            List<ProductModel> products = await productLogic.GetAllProducts();
            List<MovementOfGoodsDataGridModel> movementsOfGoods = await momentOfGoodsLogic.GetMovementOfGoodsForReport();

            List<ReportMovementOfGoodsModel> list = new List<ReportMovementOfGoodsModel>();

            Dictionary<string, (int, int, int)> productDictionary = new Dictionary<string, (int, int, int)>();

            foreach (MovementOfGoodsDataGridModel movementOfGood in movementsOfGoods)
            {
                if (dateFrom > new DateTime(Convert.ToInt32(movementOfGood.date.Split('.')[2]), Convert.ToInt32(movementOfGood.date.Split('.')[1]), Convert.ToInt32(movementOfGood.date.Split('.')[0])))
                {
                    if (movementOfGood.type.Equals("поступление"))
                    {
                        foreach (TablePartModel tablePart in movementOfGood.tableParts)
                        {
                            if (!productDictionary.ContainsKey(tablePart.productId))
                            {
                                productDictionary.Add(tablePart.productId, (tablePart.count, 0, 0));
                            }
                            else
                            {
                                productDictionary[tablePart.productId] = (productDictionary[tablePart.productId].Item1 + tablePart.count, productDictionary[tablePart.productId].Item2, productDictionary[tablePart.productId].Item3);
                            }
                        }
                    }
                    else
                    {
                        foreach (TablePartModel tablePart in movementOfGood.tableParts)
                        {
                            if (!productDictionary.ContainsKey(tablePart.productId))
                            {
                                productDictionary.Add(tablePart.productId, (-tablePart.count, 0, 0));
                            }
                            else
                            {
                                productDictionary[tablePart.productId] = (productDictionary[tablePart.productId].Item1 - tablePart.count, productDictionary[tablePart.productId].Item2, productDictionary[tablePart.productId].Item3);
                            }
                        }
                    }
                }
                if (dateFrom <= new DateTime(Convert.ToInt32(movementOfGood.date.Split('.')[2]), Convert.ToInt32(movementOfGood.date.Split('.')[1]), Convert.ToInt32(movementOfGood.date.Split('.')[0])) &&
                    dateTo >= new DateTime(Convert.ToInt32(movementOfGood.date.Split('.')[2]), Convert.ToInt32(movementOfGood.date.Split('.')[1]), Convert.ToInt32(movementOfGood.date.Split('.')[0])))
                {
                    if (movementOfGood.type.Equals("поступление"))
                    {
                        foreach (TablePartModel tablePart in movementOfGood.tableParts)
                        {
                            if (!productDictionary.ContainsKey(tablePart.productId))
                            {
                                productDictionary.Add(tablePart.productId, (0, tablePart.count, 0));
                            }
                            else
                            {
                                productDictionary[tablePart.productId] = (productDictionary[tablePart.productId].Item1, productDictionary[tablePart.productId].Item2 + tablePart.count, productDictionary[tablePart.productId].Item3);
                            }
                        }
                    }
                    else
                    {
                        foreach (TablePartModel tablePart in movementOfGood.tableParts)
                        {
                            if (!productDictionary.ContainsKey(tablePart.productId))
                            {
                                productDictionary.Add(tablePart.productId, (0, 0, tablePart.count));
                            }
                            else
                            {
                                productDictionary[tablePart.productId] = (productDictionary[tablePart.productId].Item1, productDictionary[tablePart.productId].Item2, productDictionary[tablePart.productId].Item3 + tablePart.count);
                            }
                        }
                    }
                }
            }

            foreach(var product in productDictionary)
            {
                list.Add(new ReportMovementOfGoodsModel
                {
                    productName = products.FirstOrDefault(p => p.id.Equals(product.Key)).name,
                    startCount = product.Value.Item1,
                    income = product.Value.Item2,
                    spending = product.Value.Item3,
                    endCount = product.Value.Item1 + product.Value.Item2 - product.Value.Item3
                });
            }



            return list;
        }
    }
}

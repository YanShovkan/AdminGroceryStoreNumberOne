using BusinessLogic.DataGridModels;
using BusinessLogic.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class TablePartLogic
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://grocerystorenumberone-default-rtdb.firebaseio.com/");

        public async Task<List<TablePartModel>> GetAllTableParts()
        {
            return (await firebase.Child("TableParts").OnceAsync<TablePartModel>()).Select(item => new TablePartModel
            {
                id = item.Key,
                movmentOfGoodId = item.Object.movmentOfGoodId,
                productId = item.Object.productId,
                count = item.Object.count
            }).ToList();
        }

        public async Task<List<TablePartModel>> GetTablePartsByMovmentOfGoodId(string movmentOfGoodId)
        {
            List<TablePartModel> allTableParts = await GetAllTableParts();
            allTableParts = allTableParts.Where(m => m.movmentOfGoodId.Equals(movmentOfGoodId)).ToList();

            ProductLogic productLogic = new ProductLogic();
            List<ProductModel> products = new List<ProductModel>();

            List<TablePartModel> tableParts = new List<TablePartModel>();

            foreach (TablePartModel tablePart in allTableParts)
            {
                ProductModel product = products.FirstOrDefault(m => m.id.Equals(tablePart.productId));

                tableParts.Add(new TablePartModel
                {
                    id = tablePart.id,
                    movmentOfGoodId = tablePart.movmentOfGoodId,
                    productId = tablePart.productId,
                    count = tablePart.count
                });
            }

            return tableParts;
        }

        public async Task AddTablePart(TablePartModel model)
        {
            await firebase.Child("TableParts").PostAsync(new TablePartModel()
            {
                movmentOfGoodId = model.movmentOfGoodId,
                productId = model.productId,
                count = model.count
            });
        }

        public async Task DeleteTablePart(string id)
        {
            await firebase.Child("TableParts/" + id).DeleteAsync();
        }

        public async Task UpdateTablePart(TablePartModel model)
        {
            await firebase.Child("TableParts/" + model.id).PutAsync(new TablePartModel()
            {
                movmentOfGoodId = model.movmentOfGoodId,
                productId = model.productId,
                count = model.count
            });
        }
    }
}

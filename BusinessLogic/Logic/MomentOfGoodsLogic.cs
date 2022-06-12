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
    public class MomentOfGoodsLogic
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://grocerystorenumberone-default-rtdb.firebaseio.com/");

        public async Task<List<MovementOfGoodModel>> GetAllMovementOfGoods()
        {
            return (await firebase.Child("MovementOfGoods").OnceAsync<MovementOfGoodModel>()).Select(item => new MovementOfGoodModel
            {
                id = item.Key,
                date = item.Object.date,
                type = item.Object.type
            }).ToList();
        }

        public async Task<List<MovementOfGoodModel>> GetMovementOfGoodsByDate(DateTime dateForm, DateTime dateTo)
        {
            List<MovementOfGoodModel> allMovementOfGoods = await GetAllMovementOfGoods();
            return allMovementOfGoods
                .Where(m => new DateTime(Convert.ToInt32(m.date.Split('.')[2]), Convert.ToInt32(m.date.Split('.')[1]), Convert.ToInt32(m.date.Split('.')[0])) >= dateForm &&
                             new DateTime(Convert.ToInt32(m.date.Split('.')[2]), Convert.ToInt32(m.date.Split('.')[1]), Convert.ToInt32(m.date.Split('.')[0])) <= dateTo)
                .ToList();
        }

        public async Task<List<MovementOfGoodsModel>> GetAdmissions()
        {
            List<MovementOfGoodModel> allMovementOfGoods = await GetAllMovementOfGoods();
            allMovementOfGoods = allMovementOfGoods.Where(m => m.type.Equals("поступление")).ToList();

            TablePartLogic tablePartLogic = new TablePartLogic();

            List<MovementOfGoodsModel> addmissions = new List<MovementOfGoodsModel>();

            foreach (MovementOfGoodModel movementOfGood in allMovementOfGoods)
            {
                addmissions.Add(new MovementOfGoodsModel
                {
                    id = movementOfGood.id,
                    date = movementOfGood.date,
                    type = movementOfGood.type,
                    tableParts = await tablePartLogic.GetTablePartsByMovmentOfGoodId(movementOfGood.id)
                });
            }

            return addmissions;
        }

        public async Task<MovementOfGoodsModel> GetAdmissionById(string id)
        {
            List<MovementOfGoodModel> allMovementOfGoods = await GetAllMovementOfGoods();
            MovementOfGoodModel movementOfGood = allMovementOfGoods.FirstOrDefault(m => m.id.Equals(id));

            TablePartLogic tablePartLogic = new TablePartLogic();

            List<MovementOfGoodsModel> addmissions = new List<MovementOfGoodsModel>();

            MovementOfGoodsModel admission = new MovementOfGoodsModel
            {
                id = movementOfGood.id,
                date = movementOfGood.date,
                type = movementOfGood.type,
                tableParts = await tablePartLogic.GetTablePartsByMovmentOfGoodId(movementOfGood.id)
            };

            return admission;
        }

        public async Task<MovementOfGoodsModel> GetEmptyAdmission()
        {
            List<MovementOfGoodsModel> allAdmissions = await GetAdmissions();
            return allAdmissions.FirstOrDefault(m => m.tableParts.Count == 0);
        }

        public async Task AddAdmission(MovementOfGoodModel model)
        {
            await firebase.Child("MovementOfGoods").PostAsync(new MovementOfGoodModel()
            {
                date = model.date,
                type = model.type
            });
        }

        public async Task DeleteAdmission(string id)
        {
            TablePartLogic tablePartLogic = new TablePartLogic();
            MovementOfGoodsModel admission = await GetAdmissionById(id);

            await firebase.Child("MovementOfGoods/" + id).DeleteAsync();

            foreach(TablePartModel tablePart in admission.tableParts)
            {
                await tablePartLogic.DeleteTablePart(tablePart.id);
            }
        }

        public async Task UpdateAdmission(MovementOfGoodModel model)
        {
            await firebase.Child("MovementOfGoods/" + model.id).PutAsync(new MovementOfGoodModel()
            {
                date = model.date,
                type = model.type
            });
        }
    }
}

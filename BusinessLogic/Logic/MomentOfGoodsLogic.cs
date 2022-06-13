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

        public async Task<List<MovementOfGoodsDataGridModel>> GetMovementOfGoodsForReport()
        {
            List<MovementOfGoodModel> allMovementOfGoods = await GetAllMovementOfGoods();

            TablePartLogic tablePartLogic = new TablePartLogic();

            List<MovementOfGoodsDataGridModel> addmissions = new List<MovementOfGoodsDataGridModel>();

            foreach (MovementOfGoodModel movementOfGood in allMovementOfGoods)
            {
                addmissions.Add(new MovementOfGoodsDataGridModel
                {
                    id = movementOfGood.id,
                    date = movementOfGood.date,
                    type = movementOfGood.type,
                    tableParts = await tablePartLogic.GetTablePartsByMovmentOfGoodId(movementOfGood.id)
                });
            }

            return addmissions;
        }

        public async Task<List<MovementOfGoodsDataGridModel>> GetAdmissions()
        {
            List<MovementOfGoodModel> allMovementOfGoods = await GetAllMovementOfGoods();
            allMovementOfGoods = allMovementOfGoods.Where(m => m.type.Equals("поступление")).ToList();

            TablePartLogic tablePartLogic = new TablePartLogic();

            List<MovementOfGoodsDataGridModel> addmissions = new List<MovementOfGoodsDataGridModel>();

            foreach (MovementOfGoodModel movementOfGood in allMovementOfGoods)
            {
                addmissions.Add(new MovementOfGoodsDataGridModel
                {
                    id = movementOfGood.id,
                    date = movementOfGood.date,
                    type = movementOfGood.type,
                    tableParts = await tablePartLogic.GetTablePartsByMovmentOfGoodId(movementOfGood.id)
                });
            }

            return addmissions;
        }

        public async Task<MovementOfGoodsDataGridModel> GetAdmissionById(string id)
        {
            List<MovementOfGoodModel> allMovementOfGoods = await GetAllMovementOfGoods();
            MovementOfGoodModel movementOfGood = allMovementOfGoods.FirstOrDefault(m => m.id.Equals(id));

            TablePartLogic tablePartLogic = new TablePartLogic();

            List<MovementOfGoodsDataGridModel> addmissions = new List<MovementOfGoodsDataGridModel>();

            MovementOfGoodsDataGridModel admission = new MovementOfGoodsDataGridModel
            {
                id = movementOfGood.id,
                date = movementOfGood.date,
                type = movementOfGood.type,
                tableParts = await tablePartLogic.GetTablePartsByMovmentOfGoodId(movementOfGood.id)
            };

            return admission;
        }

        public async Task<MovementOfGoodsDataGridModel> GetEmptyAdmission()
        {
            List<MovementOfGoodsDataGridModel> allAdmissions = await GetAdmissions();
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
            MovementOfGoodsDataGridModel admission = await GetAdmissionById(id);

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

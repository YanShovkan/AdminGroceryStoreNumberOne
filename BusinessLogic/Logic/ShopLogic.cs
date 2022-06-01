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
    public class ShopLogic
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://grocerystorenumberone-default-rtdb.firebaseio.com/");

        public async Task<List<ShopModel>> GetAllShops()
        {
            return (await firebase.Child("Shops").OnceAsync<ShopModel>()).Select(item => new ShopModel
            {
                id = item.Key,
                latitude = item.Object.latitude,
                longitude = item.Object.longitude,
                adress = item.Object.adress
            }).ToList();
        }

        public async Task<ShopModel> GetShop(string id)
        {
            List<ShopModel> allShops = await GetAllShops();
            return allShops.FirstOrDefault(m => m.id == id);
        }

        public async Task AddShop(ShopModel model)
        {
            await firebase.Child("Shops").PostAsync(new ShopModel()
            {
                latitude = model.latitude,
                longitude = model.longitude,
                adress = model.adress
            });
        }

        public async void DeleteShop(string id)
        {
            await firebase.Child("Shops/" + id).DeleteAsync();
        }

        public async Task UpdateShop(ShopModel model)
        {
            await firebase.Child("Shops/" + model.id).PutAsync(new ShopModel()
            {
                latitude = model.latitude,
                longitude = model.longitude,
                adress = model.adress
            });
        }
    }
}

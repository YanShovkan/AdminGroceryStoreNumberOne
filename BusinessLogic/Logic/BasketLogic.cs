using BusinessLogic.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class BasketLogic
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://grocerystorenumberone-default-rtdb.firebaseio.com/");

        public async Task<List<BasketModel>> GetAllBaskets()
        {
            return (await firebase.Child("Baskets").OnceAsync<BasketModel>()).Select(item => new BasketModel
            {
                id = item.Key,
                date = item.Object.date,
                totalPrice = item.Object.totalPrice,
                userId = item.Object.userId,
                adress = item.Object.adress
            }).ToList();
        }

        public async Task<List<BasketModel>> GetAllBasketsByUserId(string userId)
        {
            List<BasketModel> allBaskets = await GetAllBaskets();
            return allBaskets.Where(m => m.userId == userId).ToList();

        }
        public async Task<List<BasketModel>> GetAllBasketsByDate(DateTime dateForm, DateTime dateTo)
        {
            List<BasketModel> allBaskets = await GetAllBaskets();
            return allBaskets
                .Where(m => new DateTime(1970, 1, 1).AddMilliseconds(m.date).AddHours(4) >= dateForm &&
                             new DateTime(1970, 1, 1).AddMilliseconds(m.date).AddHours(4) <= dateTo)
                .ToList();
        }
    }
}

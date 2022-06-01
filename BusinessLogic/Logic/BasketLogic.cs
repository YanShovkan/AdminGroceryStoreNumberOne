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
                userId = item.Object.userId
            }).ToList();
        }
    }
}

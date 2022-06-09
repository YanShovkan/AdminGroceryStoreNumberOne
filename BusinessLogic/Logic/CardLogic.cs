using BusinessLogic.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class CardLogic
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://grocerystorenumberone-default-rtdb.firebaseio.com/");

        public async Task<List<CardModel>> GetAllCards()
        {
            return (await firebase.Child("Cards").OnceAsync<CardModel>()).Select(item => new CardModel
            {
                id = item.Key,
                userId = item.Object.userId,
                discount = item.Object.discount
            }).ToList();
        }
    }
}

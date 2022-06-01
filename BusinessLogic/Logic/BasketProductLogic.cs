using BusinessLogic.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class BasketProductLogic
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://grocerystorenumberone-default-rtdb.firebaseio.com/");

        public async Task<List<BasketProductModel>> GetAllBasketProducts()
        {
            return (await firebase.Child("BasketProducts").OnceAsync<BasketProductModel>()).Select(item => new BasketProductModel
            {
                id = item.Key,
                basketId = item.Object.basketId,
                productId = item.Object.productId,
                count = item.Object.count
            }).ToList();
        }

        public async Task<List<BasketProductModel>> GetFiltredBasketProducts(string basketId)
        {
            List<BasketProductModel> allBasketProducts = await GetAllBasketProducts();
            return allBasketProducts.Where(basketProduct => basketProduct.basketId == basketId).ToList();
        }
    }
}

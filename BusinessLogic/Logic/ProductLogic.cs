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
    public class ProductLogic
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://grocerystorenumberone-default-rtdb.firebaseio.com/");

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return (await firebase.Child("Products").OnceAsync<ProductModel>()).Select(item => new ProductModel
            {
                id = item.Key,
                name = item.Object.name,
                price = item.Object.price,
                discount = item.Object.discount
            }).ToList();
        }

        public async Task<ProductModel> GetProduct(string id)
        {
            List<ProductModel> allProducts = await GetAllProducts();
            return allProducts.FirstOrDefault(m => m.id == id);
        }

        public async Task AddProduct(string name, decimal price, decimal discount)
        {
            List<ProductModel> allProducts = await GetAllProducts();
            int numberOfUsers = allProducts.Where(u => u.name.ToLower().Equals(name.ToLower())).Count();
            if (numberOfUsers != 0)
            {
                throw new Exception("Продукт с таким названием уже существует!");
            }
            await firebase.Child("Products").PostAsync(new ProductModel()
            {
                name = name,
                price = price,
                discount = discount
            });
        }

        public async void DeleteProduct(string id)
        {
            await firebase.Child("Products/" + id).DeleteAsync();
        }

        public async Task UpdateProduct(ProductModel productModel)
        {
            await firebase.Child("Products/" + productModel.id).PutAsync(productModel);
        }

    }
}

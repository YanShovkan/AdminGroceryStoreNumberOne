using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataGridModels;
using BusinessLogic.Models;
using Firebase.Database;
using Firebase.Database.Query;

namespace BusinessLogic.Logic
{
    public class UserLogic
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://grocerystorenumberone-default-rtdb.firebaseio.com/");

        public async Task<List<UserModel>> GetAllUsers()
        {
            return (await firebase.Child("Users").OnceAsync<UserModel>()).Select(item => new UserModel
            {
                id = item.Key,
                login = item.Object.login,
                password = item.Object.password,
                status = item.Object.status
            }).ToList();
        }

        public async Task<UserModel> GetUser(string login)
        {
            List<UserModel> allUsers = await GetAllUsers();
            return allUsers.FirstOrDefault(m => m.login == login);
        }

        public async Task<List<UserDataGridModel>> GetCustomers()
        {
            List<UserModel> allUsers = await GetAllUsers();
            allUsers = allUsers.Where(m => m.status.Equals("user")).ToList();

            CardLogic cardLogic = new CardLogic();
            List<CardModel> cards = await cardLogic.GetAllCards();

            List<UserDataGridModel> customers = new List<UserDataGridModel>();

            foreach (UserModel user in allUsers)
            {
                CardModel card = cards.FirstOrDefault(m => m.userId.Equals(user.id));
                UserDataGridModel customer = new UserDataGridModel
                {
                    id = user.id,
                    userLogin = user.login,
                };

                if (card != null)
                {
                    customer.cardDiscount = $"{card.discount} %";
                }
                else
                {
                    customer.cardDiscount = "Пользователь не имеет карты лояльности";
                }
                customers.Add(customer);
                
            }

            return customers;
        }

        public async Task AddUser(string login, string password, string status)
        {
            List<UserModel> allUsers = await GetAllUsers();
            int numberOfUsers = allUsers.Where(u => u.login.ToLower().Equals(login.ToLower())).Count();
            if (numberOfUsers != 0)
            {
                throw new Exception("Пользователь с таким логином уже зарегистрирован!");
            }
            await firebase.Child("Users").PostAsync(new UserModel()
            {
                login = login,
                password = password,
                status = status
            });
        }

        public async Task<UserModel> CheckPassword(string login, string password)
        {
            UserModel admin = await GetUser(login);

            if (admin == null)
            {
                throw new Exception("Неверный логин!");
            }

            if (admin.status.Equals("admin"))
            {
                if (admin.password.Equals(password))
                {
                    return admin;
                }

                throw new Exception("Неверный пароль!");
            }

            throw new Exception("Пользователь не является администратором!");
        }

        public async void DeleteUser(string id)
        {
            await firebase.Child("Users/" + id).DeleteAsync();
        }

        public async Task UpdatePassword(UserModel model)
        {
            await firebase.Child("Users/" + model.id).PutAsync(new UserModel()
            {
                login = model.login,
                password = model.password,
                status = model.status
            });
        }

        public string hash(string password)
        {
            char[] passwd = password.ToCharArray();

            int newPassword = 0;

            for (int i = 0; i < passwd.Length; i++)
            {
                newPassword += newPassword + passwd[i] * 3 - 10;
            }

            for (int i = 0; i < passwd.Length; i++)
            {
                newPassword += newPassword + (passwd[i] - 10) / 3;
            }

            return newPassword.ToString();
        }
    }
}

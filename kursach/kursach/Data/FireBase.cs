using System.Text.RegularExpressions;
using FireSharp;
using kursach.Exceptions;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using kursach.Models;

namespace kursach.Data
{
    public class FireBaseService
    {
        private IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "AIzaSyA2Q-XyJhG3pmnJNA2lpTghd2Vkoavc3l8",
            BasePath = "https://mauitravelagencyapp-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        private IFirebaseClient client;

        public FireBaseService()
        {
            try
            {
                client = new FirebaseClient(ifc);
                
            }
            catch
            { 
                throw new NoInternetException();
            }
        }

        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            await client.SetAsync("Vacancies/" + vacancy.Id, vacancy);
        }

        public async void AddUserAsync(User user)
        {
            await client.SetAsync("Users/" + user.Id + "/UserInfo", user);
        }

        public async Task RemoveVacancyAsync(Vacancy vacancy)
        {
            await client.DeleteAsync("Vacancies/" + vacancy.Id);
        }

        public async void RemoveUserAsync(User user)
        {
            await client.DeleteAsync("Users/" + user.Id);
        }

        public async void UpdateUserAsync(User user)
        {
            await client.DeleteAsync("Users/" + user.Id);
            await client.SetAsync("Users/" + App.User.Id + "/UserInfo", App.User);
        }   

        public async Task<List<Vacancy>> GetVacanciesAsync()
        {
            FirebaseResponse response = await client.GetAsync("Vacancies/");
            var mList = JsonConvert.DeserializeObject<IDictionary<string, Vacancy>>(response.Body);
            return mList.Values.ToList();
        }

        public Vacancy GetVacancy(string id)
        {
            FirebaseResponse response = client.Get("Vacancy/" + id);
            return JsonConvert.DeserializeObject<Vacancy>(response.Body);
        }
    }
}

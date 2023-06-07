using System.Text.RegularExpressions;
using FireSharp;
using kursach.Exceptions;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using kursach.Models;

namespace kursach.Services
{
    public class DatabaseService
    {
        private IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "BBnK9h2kAiGX8iY8YGhHJ2RAR14OQEbtb8nHlpmP",
            BasePath = "https://employmentagencyauth-default-rtdb.firebaseio.com/"
        };

        private IFirebaseClient client;

        public DatabaseService()
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
            await client.SetAsync("Vacancy/" + vacancy.Id, vacancy);
        }

        public async Task RemoveVacancyAsync(Vacancy vacancy)
        {
            await client.DeleteAsync("Vacancy/" + vacancy.Id);
        }

        public async Task<List<Vacancy>> GetVacanciesAsync()
        {
            FirebaseResponse response = await client.GetAsync("Vacancy/");
            var mList = JsonConvert.DeserializeObject<IDictionary<string, Vacancy>>(response.Body);
            if (mList == null)
                return null;
            return mList.Values.ToList();
        }

        public async Task<Vacancy> GetVacancyAsync(string id)
        {
            FirebaseResponse response = await client.GetAsync("Vacancy/" + id);
            return JsonConvert.DeserializeObject<Vacancy>(response.Body);
        }

        public async Task AddUserAsync(User user)
        {
            await client.SetAsync("Users/" + user.Id, user);
        }

        public async Task<User> GetUserAsync(string id)
        {
            FirebaseResponse response = await client.GetAsync("Users/" + id); 
            var user = JsonConvert.DeserializeObject<User>(response.Body);
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            await client.DeleteAsync("Users/" + user.Id);
            await client.SetAsync("Users/" + user.Id, user);
        }
    }
}

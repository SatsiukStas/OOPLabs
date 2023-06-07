using Firebase.Auth;
using kursach.Models;
using kursach.Views;
using kursach.Data;
using kursach.Services;

namespace kursach;

public partial class App : Application
{
    public static Models.User User;
    private string webApiKey = "AIzaSyA2Q-XyJhG3pmnJNA2lpTghd2Vkoavc3l8";
    public static string Token;
    public static FirebaseAuthProvider authProvider;
    public static DatabaseService firebase;
    public App()
    {
        authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        firebase = new DatabaseService();
        InitializeComponent();
        MainPage = new MenuShell();
        //AddVacancies();
    }

    private async void AddVacancies()
    {
        Vacancy tour1 = new Vacancy()
        {
            Description =
                "Start in Rome and end in Milan! With the In-depth Cultural tour Discover Italy end Milan, you have a 7 days tour package taking you through Rome, Italy and 6 other destinations in Italy. Discover Italy end Milan includes accommodation in a hotel as well as an expert guide, insurance, meals, transport and more. ",
            Name = "Italy",
            
            Salary = "999$"
        };
        Vacancy tour2 = new Vacancy()
        {
            Description =
                "Start and end in Cairo! With the In-depth Cultural tour Wonders of Egypt, you have a 9 days tour package taking you through Cairo, Egypt and 7 other destinations in Egypt. Wonders of Egypt includes accommodation in a hotel as well as flights, an expert guide, insurance, meals, transport and more. ",
            Name = "Egyptian pyramids",
            Salary = "899$"
        };
        Vacancy tour3 = new Vacancy()
        {
            Description =
               "Start and end in Zurich! With the In-depth Cultural tour Country Roads of Switzerland (Classic, 14 Days), you have a 14 days tour package taking you through Zurich, Switzerland and 15 other destinations in Europe. Country Roads of Switzerland (Classic, 14 Days) includes accommodation in a hotel as well as an expert guide, meals, transport and more. ",
            Name = "Country Roads of Switzerland",
            Salary = "699$"
        };
        Vacancy tour4 = new Vacancy()
        {
            Description =
                "Start and end in Paris! With the In-depth Cultural tour France Mon Amour, you have a 7 days tour package taking you through Paris, France and 13 other destinations in France. France Mon Amour includes accommodation in a hotel as well as an expert guide, transport. ",
            Name = "France Mon Amour",
            Salary = "1099$"
        };
        Vacancy tour5 = new Vacancy()
        {
            Description = "Start and end in London! With the In-depth Cultural tour Devon & Cornwall Small Group (from London) - 5 Days, you have a 5 days tour package taking you through London, England and 11 other destinations in England. Devon & Cornwall Small Group (from London) - 5 Days includes accommodation in a hotel as well as an expert guide, transport and more. ",
            Name = "England tour",
            Salary = "999$"
        };
        Vacancy tour6 = new Vacancy()
        {
            Description = "From the remote wilderness of Alaska to vibrant New York, an American vacation is what you make it. Discover Hawaii's volcanic wonders, satisfy your inner child in Florida's theme parks, be lost for words on the Golden Gate Bridge, or enjoy a laid-back cruise along the Mississippi. We've got you covered with the best adventure packages in the United States, and a guide to the best times to visit the Land of the Free.",
            Name = "USA tour",
            Salary = "1199$"
        };
        await App.firebase.AddVacancyAsync(tour1);
        await App.firebase.AddVacancyAsync(tour2);
        await App.firebase.AddVacancyAsync(tour3);
        await App.firebase.AddVacancyAsync(tour4);
        await App.firebase.AddVacancyAsync(tour5);
        await App.firebase.AddVacancyAsync(tour6);
    }
}

using oop2.Services;
using oop2.Entities;
using oop2.Services;
using System.Security.Principal;
using System.Xml.Linq;
using SerializerLib;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace oop2
{
    public class Program
    {
        public static void Main()
        {
            Serializer ser = new Serializer();

            Database database = new();
            var admin = new Admin();

            //Repository repository = new Repository(database);
    
            List<User> users = database.Allusers;

            while (true)
            {
                //Console.Clear();
                Console.WriteLine("Choose:\n1. SIGN IN\n2. SIGN UP\n3. EXIT\n Answer: ");

                string? enter = Console.ReadLine();
                int userId;


                if (enter == "1")
                {
                    Console.WriteLine("***************** ENTRANCE *************** \nEnter login and password\n Login: ");
                    string? login = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string? password = Console.ReadLine();
                    Console.WriteLine();

                    bool adm = false;
                    if (login == "admin" && password == "admin")
                    {
                        Console.WriteLine("Вход от АДМИНА");
                        adm = true;
                    }

 
                    if (database.VerifyCheck(login, password) || adm)
                    {

                        Console.WriteLine("Successful entry attempt");

                        var user = database.CurrentUser(login, password);

                        // дальнейшее развитие и вывод списка возможных команд
                        while (true)
                        {
                            bool buttonExit = false;

                            Console.WriteLine("\nSelect the command from the shown: ");
                            Console.WriteLine("1. Добавить вакансию\n" +
                                              
                                              "4. отозваться на вакансию \n" +
                                              "5. АДМИН удалить вакансию\n" +
                                              "6. АДМИН изменить вакансию\n" +
                                              "7. Изменить вакансию\n" +
                                              "8. Просмотр своих вакансий\n" +
                                              "9. Просмотр всех вакансий\n" +

                                              "0. Выход из аккаунта");
                            string? nameOfCommand = Console.ReadLine();

                            switch (nameOfCommand)
                            {

                                case "1":

                                    if (adm) break;
                                    Console.WriteLine("Введите наименование вакансии: ");
                                    string? name1 = Console.ReadLine();

                                    Console.WriteLine("Введите зарплату вакансии: ");
                                    string? temp1 = Console.ReadLine();

                                    Console.WriteLine("Введите описание вакансии: ");
                                    string? temp2 = Console.ReadLine();
                                    

                                    double cost1 = Convert.ToDouble(temp1);
                                    DateTime dateTime = DateTime.Now;

                                    user.vacancies.Add(new Vacancy(name1, cost1, temp2));
                                    database.Allvacancies.Add(new Vacancy(name1, cost1, temp2));


                                    Console.WriteLine("Your vacancy has been successfully added\n");
                                    
                                    break;

                                
                                 

                                case "4":

                                    Console.WriteLine();
                                    foreach (var item in database.Allvacancies)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }

                                    Console.WriteLine("Выберите вакансию чтобы узнать подробности про работодателя");

                                    string? name4 = Console.ReadLine();
                                    if(database.FindUserByVacancy(name4) != null)
                                    {
                                        Console.WriteLine("Вот Email для свази с работодателем:" + database.FindUserByVacancy(name4).Login);

                                    }
                                    else
                                    {
                                        Console.WriteLine("нет вакансий");
                                    }

                                    break;


                                case "5":

                                    


                                    if (adm)
                                    {
                                        Console.WriteLine();
                                        foreach (var item in database.Allvacancies)
                                        {
                                            Console.WriteLine(item.ToString());
                                        }

                                        Console.WriteLine("Введите наименование вакансии которую хотите удалить: ");
                                        string? name5 = Console.ReadLine();
                                        Console.WriteLine("Эта вакансия была пользователя:" + database.FindUserByVacancy(name5).Name);

                                        database.FindUserByVacancy(name5).DeleteVacancyUser(name5);
                                        database.DeleteVacancy(database.FindVacancy(name5));


                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы не админ");
                                    }

                                    break;

                                case "6":

                                    if (adm)
                                    {
                                        Console.WriteLine();
                                        foreach (var item in database.Allvacancies)
                                        {
                                            Console.WriteLine(item.ToString());
                                        }

                                        Console.WriteLine("Введите наименование вакансии которую хотите изменить: ");
                                        string? name6 = Console.ReadLine();

                                        Console.WriteLine("Введите новое наименование вакансии: ");
                                        string? new61 = Console.ReadLine();
                                        Console.WriteLine("Введите новую зарплату вакансии: ");
                                        string? new620 = Console.ReadLine();
                                        Console.WriteLine("Введите новое описание вакансии: ");
                                        string? new63 = Console.ReadLine();
                                        double new62 = Convert.ToDouble(new620);

                                        Console.WriteLine("Эта вакансия была пользователя:" + database.FindUserByVacancy(name6).Name);


                                        database.FindUserByVacancy(name6).EditVacancyUser(name6, new61, new62, new63);
                                        database.EditVacancy(name6, new61, new62, new63);


                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы не админ");
                                    }

                                    break;


                                case "7":

                                    
                                    Console.WriteLine("Введите наименование вакансии: ");
                                    string? name7 = Console.ReadLine();


                                    Console.WriteLine("Введите новое наименование вакансии: ");
                                    string? new7 = Console.ReadLine();
                                    Console.WriteLine("Введите новую зарплату вакансии: ");
                                    string? new710 = Console.ReadLine();
                                    Console.WriteLine("Введите новое описание вакансии: ");
                                    string? new72 = Console.ReadLine();
                                    double new71 = Convert.ToDouble(new710);

                                    user.EditVacancyUser(name7, new7, new71, new72);

                                    Console.WriteLine("Вакансия изменена ");

                                    break;


                                case "8":

                                    if (adm) break;
                                    Console.WriteLine();
                                    foreach (var item in user.vacancies)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    break;

                                case "10":

                                    ser.SerializeJson<User>(database.Allusers, "ser");
                                    break;

                                

                                case "9":

                                    Console.WriteLine();
                                    foreach (var item in database.Allvacancies)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    break;

                                

                                case "0": // выход на начальную страницу сделан
                                    buttonExit = true;
                                    break;

                                default:
                                    Console.WriteLine("\nError, try again\n");
                                    continue;
                            }
                            if (buttonExit)
                            {
                                break;
                            }
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("This user doesn't exist, try again");
                        continue;
                    }
                }
                else if (enter == "2")
                {
                    Console.WriteLine("***************** REGISTRATION *************** \nEnter your name, login and password\n Name: ");
                    string? name = Console.ReadLine();
                    Console.WriteLine(" Login: ");
                    string? login = Console.ReadLine();
                    Console.WriteLine(" Password: ");
                    string? password = Console.ReadLine();
                    Console.WriteLine();

                    database.AddUser(new User(users.Count + 1, name, login, password));
                    users.Add(new User(users.Count + 1, name, login, password));

                    //repository.AddAsync(new User(users.Count + 1, name, login, password));
                    //repository.Save();
                    
                }
                else if (enter == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("***************** ERROR ***************\n");
                    continue;
                    // Ошибка и переход к началу 
                }
            }

           
        }
    }
}



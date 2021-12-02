using ConsoleTools;
using System;
using ZT2Y9R_HFT_2021221.Models;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:5828");

            var clubs = new ConsoleMenu()
                .Add("Create Club", () => CreateClub(rest))
                .Add("Get Club", () => GetClub(rest))
                .Add("Go back to the previes menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = " --> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                });
        }

        private static void CreateClub(RestService rest)
        {
            Console.WriteLine(".....Creating new club.....");
            Console.WriteLine("\n Give the name of club");
            string name = Console.ReadLine();
            Console.WriteLine("\n Give the Number Of Trophies");
            int NumberOfTrophies = int.Parse(Console.ReadLine());
            rest.Post(new Clubs
            {
                Name = name,
                NumberOfTrophies = NumberOfTrophies
            }, "club");
            Console.WriteLine("Club is created");
            Console.ReadKey();
        }
        private static void GetClub(RestService rest)
        {
            try
            {
                Console.WriteLine(".....List all clubs.....");
                var serv = rest.Get<Clubs>("Club");
                serv.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to search");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}

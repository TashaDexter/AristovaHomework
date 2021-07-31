using System;

namespace ListOfClients
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client() {PassportID=14578, FirstName="Alex", LastName="Smith", Ammount=1465 };
            Client client2 = new Client() { PassportID = 10878, FirstName = "Misty", LastName = "Edwards", Ammount = 3261 };
            Client client3 = new Client() { PassportID = 13578, FirstName = "Liza", LastName = "Goyan", Ammount = 1873 };
            
            Clients clients = new Clients();
            clients.Add(client1);
            clients.Add(client2);
            clients.Add(client3);

            Console.WriteLine("\n----------------------------------\n" +
                "Enter passportID to search:");
            int passportID = Convert.ToInt32(Console.ReadLine());
            clients.SearchByPassportID(passportID);

            Console.WriteLine("\n----------------------------------\n" +
                "Enter ammount to search:");
            int ammount = Convert.ToInt32(Console.ReadLine());
            clients.AmmountLessThan(ammount);

            Console.WriteLine("\n----------------------------------");
            clients.MinAmmount();

            Console.WriteLine("\n----------------------------------");
            clients.SumAmmount();

            Console.ReadKey();
        }
    }
}

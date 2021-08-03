using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client() { PassportID = 14578, FirstName="Alex", LastName="Smith"};
            Client client2 = new Client() { PassportID = 10878, FirstName = "Misty", LastName = "Edwards"};
            Client client3 = new Client() { PassportID = 13578, FirstName = "Liza", LastName = "Goyan"};

            Ruble ruble=new Ruble() { ValueInDollars = 0.014 };
            Euro euro = new Euro() { ValueInDollars = 1.19 };
            Dollar dollar = new Dollar() { ValueInDollars = 1};

            Account account1 = new Account() { Currency = ruble, Ammount = 1415.452 };
            Account account2 = new Account() { Currency = euro, Ammount = 160.4565};
            Account account3 = new Account() { Currency = dollar, Ammount = 10004.154 };

            Bank bank=new Bank();
            bank.Add(client1, new List<Account>(){ account1, account2, account3});
            bank.Add(client2, new List<Account>() { account1, account3 });
            bank.Add(client3, new List<Account>() { account2, account3 });

            Console.WriteLine("\n----------------------Dictionary----------------------\n");
            foreach(var client in bank.clients)
            {
                Console.WriteLine($"Client: " +
                    $"PassportID={client.Key.PassportID}, " +
                    $"FirstName={client.Key.FirstName}, " +
                    $"LastName={client.Key.LastName}");
                foreach (var acc in client.Value)
                {
                    Console.WriteLine($"\nAccount: " +
                     $"Currency={acc.Currency}, " +
                     $"Ammount={acc.Ammount}" +
                     $"\nValue in dollars: {ConvertCurrency(acc.Currency,acc.Ammount, dollar)}" +
                     $"\nValue in rubles: { ConvertCurrency(acc.Currency, acc.Ammount, ruble)}" +
                     $"\nValue in euro: {ConvertCurrency(acc.Currency, acc.Ammount, euro)}");
                }
                Console.WriteLine("-------------------------------------------------------");
            }

            Console.ReadKey();
        }
        public static double ConvertCurrency(Currency currencyIn, double ammount, Currency currencyOut)
        {
            return ammount*currencyIn.ValueInDollars/currencyOut.ValueInDollars;
        }
}

}

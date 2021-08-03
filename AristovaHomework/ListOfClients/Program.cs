using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client() {PassportID=14578, FirstName="Alex", LastName="Smith"};
            Client client2 = new Client() { PassportID = 10878, FirstName = "Misty", LastName = "Edwards"};
            Client client3 = new Client() { PassportID = 13578, FirstName = "Liza", LastName = "Goyan"};

            Ruble ruble=new Ruble() { ValueInDollars = 0.014 };
            Euro euro = new Euro() { ValueInDollars = 1.19 };
            Dollar dollar = new Dollar() { ValueInDollars = 1};

            Account account1 = new Account() { Currency = ruble, Ammount = 1415.452 };
            Account account2 = new Account() { Currency = euro, Ammount = 160.4565};
            Account account3 = new Account() { Currency = dollar, Ammount = 10004.154 };

            Dictionary<Client, Account> dictionary= new Dictionary<Client, Account>();
            dictionary.Add(client1, account1);
            dictionary.Add(client2, account2);
            dictionary.Add(client3, account3);

            Console.WriteLine("\n----------------------Dictionary----------------------\n");
            foreach (var d in dictionary)
            {
                Console.WriteLine($"Client: " +
                    $"PassportID={d.Key.PassportID}, " +
                    $"FirstName={d.Key.FirstName}, " +
                    $"LastName={d.Key.LastName}" +
                    $"\nAccount: " +
                    $"Currency={d.Value.Currency}, " +
                    $"Ammount={d.Value.Ammount}" +
                    $"\nValue in dollars: {ConvertCurrency(d.Value.Currency, d.Value.Ammount, dollar)}" +
                    $"\nValue in rubles: { ConvertCurrency(d.Value.Currency, d.Value.Ammount, ruble)}"+
                    $"\nValue in euro: {ConvertCurrency(d.Value.Currency, d.Value.Ammount, euro)}\n");
            }

            Console.ReadKey();
        }
        public static double ConvertCurrency(Currency currencyIn, double ammount, Currency currencyOut)
        {
            return ammount*currencyIn.ValueInDollars/currencyOut.ValueInDollars;
        }
}

}

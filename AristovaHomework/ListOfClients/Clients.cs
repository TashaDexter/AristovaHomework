using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfClients
{
    public class Clients
    {
        private List<Client> clients;

        public Clients() { clients = new List<Client>(); }

        public void Add(Client client)
        {
            if (!(clients.Contains(client)))
            {
                clients.Add(client);
                Console.WriteLine($"Client with passportID={client.PassportID} was successfully added!");
            }
            else
                Console.WriteLine($"Error! Client with passportID={client.PassportID} already exists!");
        }

        //метод поиска клиента по номеру паспорта
        public void SearchByPassportID(int passportID)
        {
            IEnumerable<Client> query = from client in clients
                                        where client.PassportID == passportID
                                        select client;
            if (query.Any())
            {
                Console.WriteLine($"Client with passportID={passportID}:" +
                $"\nFirstName={query.First().FirstName}" +
                $"\nLastName={query.First().LastName}" +
                $"\nAmmount={query.First().Ammount}");
            }
            else
                Console.WriteLine($"Client with passportID={passportID} was not found");
        }

        //метод выборки клиентов, у которых сумма на счету ниже определенного значения
        public void AmmountLessThan(int ammount)
        {
            IEnumerable<Client> query = from client in clients
                                        where client.Ammount< ammount
                                        select client;
            if (query.Any())
            {
                foreach (var q in query)
                {
                    Console.WriteLine($"Client with ammount less than {ammount}:" +
                        $"\nPassportID={q.PassportID}" +
                        $"\nFirstName={q.FirstName}" +
                        $"\nLastName={q.LastName}" +
                        $"\nAmmount={q.Ammount}");
                }
            }
            else
                Console.WriteLine($"Client with ammount less than {ammount} was not found");
        }

        //метод поиска клиента с минимальной суммой на счете
        public void MinAmmount()
        {
            var min = clients.Min(n => n.Ammount);
            IEnumerable<Client> query = from client in clients
                                        where client.Ammount==min
                                        select client;
            if (query.Any())
            {
                foreach (var q in query)
                {
                    Console.WriteLine($"Client with minimal ammount:" +
                        $"\nPassportID={q.PassportID}" +
                        $"\nFirstName={q.FirstName}" +
                        $"\nLastName={q.LastName}" +
                        $"\nAmmount={q.Ammount}");
                }
            }
        }

        //метод подсчитывающий сумму денег у всех клиентов банка
        public void SumAmmount()
        {
            var sum = clients.Sum(n => n.Ammount);
            Console.WriteLine($"The amount of money for all clients: {sum}");
        }
    }
}

using AdventureWorks.Domain;
using AdventureWorks.Domain.Models;
using System;
using System.Reflection;

namespace AdventureWorks.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("AdventureWorks 'Customers' Console App");
            System.Console.WriteLine("  Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            System.Console.WriteLine();

            // Ophalen argument
            string idOrKeyword = null;
            if (args.Length == 0)
            {
                System.Console.WriteLine("ID or keyword: ");
                idOrKeyword = System.Console.ReadLine();
            } 
            else
            {
                idOrKeyword = args[0];
            }

            // Ophalen klant/klanten
            CustomerManager cm = new CustomerManager();
            int id = -1;
            if (int.TryParse(idOrKeyword, out id))
            {
                Customer c = cm.GetCustomer(id);
                if (c != null)
                {
                    WriteCustomer(c);
                }
                else
                {
                    System.Console.WriteLine($"Customer with ID {id} does not exist.");
                }
            }
            else
            {
                var customers = cm.SearchCustomers(idOrKeyword);
                if (customers.Count > 0)
                {
                    foreach (Customer customer in customers)
                    {
                        WriteCustomer(customer); 
                        System.Console.WriteLine(" ---");
                    }
                }
                else 
                {
                    System.Console.WriteLine($"No customers found.");
                }
            }
        }

        private static void WriteCustomer(Customer c)
        {
            System.Console.WriteLine($"  ID         : {c.ID}");
            System.Console.WriteLine($"  First name : {c.FirstName}");
            System.Console.WriteLine($"  Last name  : {c.LastName}");
        }
    }
}

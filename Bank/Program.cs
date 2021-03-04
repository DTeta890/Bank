using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bank.Data;

namespace Bank
{
    class Program
    {
        private static List<Account> Accounts = new List<Account>();
        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("1)Create Account\n2)List Accounts\n3)Select Accounts\n0)Exit");
                Console.Write("Choose Action then Enter: ");
                choice = int.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    Console.Write("\nEnter Owner's full name: ");
                    var account = new Account(Console.ReadLine());
                    Accounts.Add(account);
                    Console.WriteLine($"Account under the name of {account.Owner} with number:{account.Iban} was successfuly created.\n");
                } 
                else if(choice == 2)
                {
                    var raport = new StringBuilder();
                    raport.AppendLine("\nNr\tOwner\tIBAN\tBalance\tDate Created");
                    var i = 0;
                    foreach (var a in Accounts)
                    {
                        i++;
                        var dateCreated = a.Transactions.First().Date;
                        raport.AppendLine($"{i}\t{a.Owner}\t{a.Iban}\t{a.Balance}\t{dateCreated}");
                    }
                    Console.WriteLine($"{raport}\n");
                } 
                else if(choice == 3)
                {
                    // Te selekt trajtoje si arrey, jep perdoruesi 1, dmth pozicioni 0 ne liste
                    // Shto submenu
                }
            }
        }
    }
}

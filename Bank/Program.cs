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
                Console.Clear();
                Console.WriteLine("1)Create Account\n2)List Accounts\n3)Select Account\n0)Exit");
                Console.Write("\nChoose Action then Enter: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                if (choice == 1)
                {
                    Console.Write("Enter Owner's full name: ");
                    var account = new Account(Console.ReadLine());
                    Accounts.Add(account);
                    Console.WriteLine($"\nAccount under the name of {account.Owner} with number:{account.Iban} was successfuly created.");
                    Console.ReadLine();
                }
                else if(choice == 2)
                {
                    DisplayUsers();
                    Console.ReadLine();
                } 
                else if(choice == 3)
                {
                    DisplayUsers();
                    Console.Write("Enter Account Nr: ");
                    var selectedIndex = int.Parse(Console.ReadLine());
                    if (selectedIndex > Accounts.Count)
                    {
                        Console.WriteLine("\nAccount dosn't exist! Try again.");
                        Console.ReadLine();
                    }
                    else
                    {
                        var subChoice = -1;
                        var selectedAccount = Accounts[selectedIndex - 1];
                        while(subChoice != 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Account under the name of {selectedAccount.Owner}\nIBAN: {selectedAccount.Iban}\tBalance: ${selectedAccount.Balance}\n");
                            Console.WriteLine("1)Make Deposit\n2)Make Withdraw\n3)Show Account History\n0)Exit");
                            Console.Write("\nChoose Action then Enter: ");
                            subChoice = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if(subChoice == 1)
                            {
                                Console.Write("Amount you want to deposit: ");
                                selectedAccount.MakeDeposit(int.Parse(Console.ReadLine()));
                                Console.ReadLine();
                            }
                            else if (subChoice == 2)
                            {
                                Console.Write("Amount you want to withdraw: ");
                                selectedAccount.MakeWithdraw(int.Parse(Console.ReadLine()));
                                Console.ReadLine();
                            }
                            else if (subChoice == 3)
                            {
                                selectedAccount.ShowHistory();
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
        }
        static void DisplayUsers()
        {
            var raport = new StringBuilder();
            raport.AppendLine("Nr\tOwner\tIBAN\tBalance\tDate Created");
            var i = 0;
            foreach (var a in Accounts)
            {
                i++;
                var dateCreated = a.Transactions.First().Date;
                raport.AppendLine($"{i}\t{a.Owner}\t{a.Iban}\t{a.Balance}\t{dateCreated}");
            }
            Console.WriteLine(raport);
        }
    }
}

using Bank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Clear();
                    if (choice == 1)
                    {
                        Console.Write("Enter Owner's full name: ");
                        var account = new Account(Console.ReadLine());
                        Accounts.Add(account);
                        Console.WriteLine($"\nAccount under the name of {account.Owner} with number:{account.Iban} was successfuly created.");
                        Console.ReadLine();
                    }
                    else if (choice == 2)
                    {
                        DisplayUsers();
                        Console.ReadLine();
                    }
                    else if (choice == 3)
                    {
                        DisplayUsers();
                        var selectedIndex = -1;
                        Console.Write("Enter Account Nr: ");
                        if (int.TryParse(Console.ReadLine(), out selectedIndex))
                        {
                            if (selectedIndex > Accounts.Count || selectedIndex < 0)
                            {
                                Console.WriteLine("\nAccount dosn't exist! Try again.");
                                Console.ReadLine();
                            }
                            else
                            {
                                var subChoice = -1;
                                var selectedAccount = Accounts[selectedIndex - 1];
                                while (subChoice != 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Account under the name of {selectedAccount.Owner}\nIBAN: {selectedAccount.Iban}\tBalance: ${selectedAccount.Balance}\n");
                                    Console.WriteLine("1)Make Deposit\n2)Make Withdraw\n3)Show Account History\n0)Exit");
                                    Console.Write("\nChoose Action then Enter: ");
                                    if (int.TryParse(Console.ReadLine(), out subChoice))
                                    {
                                        Console.Clear();
                                        if (subChoice == 1)
                                        {
                                            var amount = 0;
                                            Console.Write("Amount you want to deposit: ");
                                            if (int.TryParse(Console.ReadLine(), out amount))
                                            {
                                                selectedAccount.MakeDeposit(amount);
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nInvalid amount! Try again.");
                                                Console.ReadLine();
                                            }
                                        }
                                        else if (subChoice == 2)
                                        {
                                            var amount = 0;
                                            Console.Write("Amount you want to withdraw: ");
                                            if (int.TryParse(Console.ReadLine(), out amount))
                                            {
                                                selectedAccount.MakeWithdraw(amount);
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nInvalid amount! Try again.");
                                                Console.ReadLine();
                                            }
                                        }
                                        else if (subChoice == 3)
                                        {
                                            selectedAccount.ShowHistory();
                                            Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid input! Try again.");
                                        subChoice = -1;
                                        Console.ReadLine();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input! Try again.");
                            choice = -1;
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input! Try again.");
                    choice = -1;
                    Console.ReadLine();
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

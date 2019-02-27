using System;
using System.Globalization;
using CashMachine.Entities.Services;
using CashMachine.Entities.Exceptions;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            char c;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$ === *CASH MACHINE* === $");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter the withdraw amount: ");

                try
                {
                    double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    WithdrawService withdraw = new WithdrawService();

                    withdraw.MakeWithdraw(amount);

                    Console.WriteLine(withdraw);
                }
                catch (WithdrawException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! " + e.Message);
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! " + e.Message);
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nContinue (y/n)? ");
                c = char.Parse(Console.ReadLine());

            } while (c == 'y');
        }
    }
}

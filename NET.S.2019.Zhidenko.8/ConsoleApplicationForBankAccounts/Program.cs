using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccounts;
using BankAccounts.AccountTypes;
using BankAccounts.BonusTypes;

namespace ConsoleApplicationForBankAccounts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var account = new Account(1, "Andrei", "Zhidenko", new FileStorage("D:\\Курсы\\file.dat"), new BaseType(), new BasicBonus());

            account.AddMoney(1000);

            Account newAccount = account.Storage.Get();

            Console.WriteLine("{0} {1} {2} {3} {4}", newAccount.Number, newAccount.Name, newAccount.Surname, newAccount.Money, newAccount.BonusPoints);

            newAccount.WithdrawMoney(100);

            Console.WriteLine("{0} {1} {2} {3} {4}", newAccount.Number, newAccount.Name, newAccount.Surname, newAccount.Money, newAccount.BonusPoints);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccounts.AccountTypes;

namespace BankAccounts.BonusTypes
{
    public interface IBonus
    {
        int AddMoney(AccountType accountType, decimal allMoney, decimal addedMoney);

        int WithdrawMoney(AccountType accountType, decimal allMoney, decimal withdrewMoney);
    }
}

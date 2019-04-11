using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccounts.AccountTypes;

namespace BankAccounts.BonusTypes
{
    public class BasicBonus : IBonus
    {
        public int AddMoney(AccountType accountType, decimal allMoney, decimal addedMoney)
        {
            return (int)((0.01 * accountType.BalanceCost * (double)allMoney) + (0.05 * accountType.AddMoneyCost * (double)addedMoney));
        }

        public int WithdrawMoney(AccountType accountType, decimal allMoney, decimal withdrewMoney)
        {
            return (int)-((0.01 * accountType.BalanceCost * (double)allMoney) + (0.01 * accountType.AddMoneyCost * (double)withdrewMoney));
        }
    }
}

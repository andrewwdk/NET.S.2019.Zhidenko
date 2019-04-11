using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.AccountTypes
{
    public abstract class AccountType
    {
        //public abstract int BalanceCost { get; }
        //public abstract int AddMoneyCost { get; }

        protected int balanceCost;
        protected int addMoneyCost;

        public int BalanceCost
        {
            get
            {
                return balanceCost;
            }
        }

        public int AddMoneyCost
        {
            get
            {
                return addMoneyCost;
            }
        }
    }
}

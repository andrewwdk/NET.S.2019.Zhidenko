using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.AccountTypes
{
    [Serializable]
    public abstract class AccountType
    {
        public int BalanceCost { get; protected set; }

        public int AddMoneyCost { get; protected set; }
    }
}

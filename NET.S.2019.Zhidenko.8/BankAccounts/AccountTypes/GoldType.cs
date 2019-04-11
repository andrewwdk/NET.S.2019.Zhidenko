using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.AccountTypes
{
    [Serializable]
    public class GoldType : AccountType
    {
        public GoldType()
        {
            this.BalanceCost = 2;
            this.AddMoneyCost = 2;
        }
    }
}

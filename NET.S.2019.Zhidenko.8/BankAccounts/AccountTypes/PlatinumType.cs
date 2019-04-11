using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.AccountTypes
{
    public class PlatinumType : AccountType
    {
        public PlatinumType()
        {
            this.BalanceCost = 5;
            this.AddMoneyCost = 5;
        }
    }
}

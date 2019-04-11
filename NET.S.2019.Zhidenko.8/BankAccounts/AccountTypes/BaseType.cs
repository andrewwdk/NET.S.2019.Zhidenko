using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.AccountTypes
{
    public class BaseType : AccountType
    {
        public BaseType()
        {
            this.BalanceCost = 1;
            this.AddMoneyCost = 1;
        }
    }
}

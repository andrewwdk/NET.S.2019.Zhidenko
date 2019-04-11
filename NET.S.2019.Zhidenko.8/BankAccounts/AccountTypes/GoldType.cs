using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.AccountTypes
{
    public class GoldType : AccountType
    {
        public GoldType()
        {
            balanceCost = 2;
            addMoneyCost = 2;
        }
    }
}

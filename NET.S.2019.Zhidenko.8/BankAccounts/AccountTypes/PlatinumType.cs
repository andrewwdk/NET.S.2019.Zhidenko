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
            balanceCost = 5;
            addMoneyCost = 5;
        }
    }
}

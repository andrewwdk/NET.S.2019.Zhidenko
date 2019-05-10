using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccounts.AccountTypes;
using BankAccounts.BonusTypes;

namespace BankAccounts
{
    [Serializable]
    public class Account
    {
        private int number;
        private string name;
        private string surname;
        private decimal money;
        private int bonusPoints;
        private bool isClosed;
        private IStoragable storage;
        private AccountType accountType;

        public Account(int number, string name, string surname, IStoragable storage, AccountType accountType, IBonus bonusLogic)
        {
            Number = number;
            Name = name;
            Surname = surname;
            money = 0;
            bonusPoints = 0;
            isClosed = false;
            Storage = storage;
            AccountType = accountType;
            BonusLogic = bonusLogic;

            storage.Save(this);
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Account number can't be negative!");
                }

                number = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value ?? throw new ArgumentNullException("Owner's name can't be null!");
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value ?? throw new ArgumentNullException("Owner's surname can't be null!");
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money on the account can't be negative!");
                }

                money = value;
            }
        }

        public IStoragable Storage
        {
            get
            {
                return storage;
            }

            set
            {
                storage = value ?? throw new ArgumentNullException("Account storage can't be null");
            }
        }

        public AccountType AccountType
        {
            get
            {
                return accountType;
            }

            set
            {
                accountType = value ?? throw new ArgumentNullException("Account type can't be null");
            }
        }

        public int BonusPoints
        {
            get
            {
                return bonusPoints;
            }

            private set
            {
            }
        }

        public IBonus BonusLogic { get; set; }

        /// <summary> Add money to account. </summary>
        /// <param name="addedMoney"> Money to add. </param>
        public void AddMoney(decimal addedMoney)
        {
            if (isClosed)
            {
                throw new Exception("Account is already closed!");
            }

            Money += addedMoney;
            bonusPoints += BonusLogic.AddMoney(AccountType, Money, addedMoney);

            storage.Save(this);
        }

        /// <summary> Withdraw money from account. </summary>
        /// <param name="withdrewMoney"> Money to withdraw. </param>
        public void WithdrawMoney(decimal withdrewMoney)
        {
            if (isClosed)
            {
                throw new Exception("Account is already closed!");
            }

            Money -= withdrewMoney;
            bonusPoints += BonusLogic.WithdrawMoney(AccountType, Money, withdrewMoney);

            storage.Save(this);
        }

        /// <summary> Create new account of current owner. </summary>
        /// <param name="storage"> Storage type. </param>
        /// <param name="accountType"> Account type. </param>
        /// <param name="bonusLogic"> Bonus type. </param>
        /// <returns>  New account. </returns>
        public Account CreateNewAccount(IStoragable storage, AccountType accountType, IBonus bonusLogic)
        {
            return new Account(new Random().Next(1, int.MaxValue), Name, Surname, storage, accountType, bonusLogic);
        }

        /// <summary> Close owner's account. </summary>
        public void CloseAccount()
        {
            isClosed = true;
            Money = 0;
        }
    }
}

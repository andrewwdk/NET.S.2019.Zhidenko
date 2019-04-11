using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BankAccounts
{
    [Serializable]
    public class FileStorage : IStoragable
    {
        private string storagePath;

        public FileStorage(string path)
        {
            StoragePath = path;
        }

        public string StoragePath
        {
            get
            {
                return storagePath;
            }

            private set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Path to account storage can't be empty string or null");
                }

                storagePath = value;
            }
        }

        /// <summary> Read account data from file. </summary>
        /// <returns> Account. </returns>
        public Account Get()
        {
            var bf = new BinaryFormatter();

            using (var fs = File.Open(StoragePath, FileMode.Open))
            {
                return (Account)bf.Deserialize(fs);
            }
        }

        /// <summary> Save account data into file. </summary>
        /// <param name="account"> Account to save. </param>
        public void Save(Account account)
        {
            var bf = new BinaryFormatter();

            using (var fs = File.Open(StoragePath, FileMode.Create))
            {
                bf.Serialize(fs, account);
            }
        }
    }
}

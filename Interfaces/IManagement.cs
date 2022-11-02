using Mod_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_Manager.Interfaces
{
    internal interface IManagement
    {
        public void AddAccount(Account user, List<Account> users);
        public void RemoveAccount(Account user, List<Account> users);
        public void BanAccount(Account user, List<Account> users);
        public void FindAccount(Account user, List<Account> users);
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mod_Manager.Enums;
using Mod_Manager.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Mod_Manager.Classes
{
    internal class Account
    {
        internal List<Account> users = new();

        private string name;
        private string email;
        private string country;
        private string password;
        private string phoneNumber;
        private Guid id;
        private Status status;
        private DateTime joinDate;
        private DateTime lastActive;
        private static int accountCount = 0;

        public Account() { Interlocked.Increment(ref accountCount); }
        ~Account() { Interlocked.Decrement(ref accountCount); }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name cannot be empty.");
                name = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Email cannot be empty.");
                else if (!Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    throw new FormatException("Address format is wrong.");

                email = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Password cannot be empty.");
                else if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
                    throw new FormatException("Password format is wrong.");

                password = value;
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Addres cannot be empty.");
                country = value;
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Phone number cannot be empty.");
                else if (!Regex.IsMatch(value, @"^\+\d{1,13}$"))
                    throw new FormatException("Phone number format is wrong.");

                phoneNumber = value;
            }
        }

        public Guid ID => id;
        public Status Status => status;
        public DateTime JoinDate => joinDate;
        public DateTime LastActive => lastActive;
        public static int AccountCounter => accountCount;

        public void AddAccount(Account user, List<Account> users) => users.Add(user);
        public void RemoveAccount(Account user, List<Account> users) => users.Remove(user);
    }
}


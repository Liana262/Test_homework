using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj_1
{
    /// <summary>
    /// Данные для  входа
    /// </summary>
    public class AccountData
    {
        public AccountData(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}

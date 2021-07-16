using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using OneLock.Model;

namespace OneLock.Controlls
{
    public class UserControler
    {
        private User _user;

        /// <summary>
        /// Regestry new User
        /// </summary>
        /// <param name="login">Login User</param>
        /// <param name="password">Password User</param>
        public void Regestry(string login,string password)
        {
            if (File.Exists(login + ".ol"))
                throw new FileNotFoundException("User exists");

            _user = new User(login, password);

            SaveUsers();
        }

        /// <summary>
        /// Authorization user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public void Authorization(string login,string password)
        {
            if (!File.Exists(login + ".ol"))
                throw new FileNotFoundException("User not found");

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "" + login + ".ol"))
            {
                _user = (User)bf.Deserialize(fs);
            }

            if (_user.PasswordUser != password)
            {
                _user = null;
                throw new Exception("Password not correct");
            } 
        }

        public List<string> GetNameAccount()
        {
            List<string> nameAccount = new List<string>();

            foreach (var item in _user.AccountArray)
            {
                nameAccount.Add(item.NameAccount);
            }

            return nameAccount;
        }

        public string GetLognAccount(int index)
        {
            return _user.AccountArray[index].Login;
        }

        public string GetPasswordAccount(int index)
        {
            return _user.AccountArray[index].Password;
        }

        public void AddAccount(Account account)
        {
            _user.AccountArray.Add(account);
        }

        public void EditAccount(Account account,int index)
        {
            _user.AccountArray[index] = account;
        }

        public void DeleteAccount(int index)
        {
            _user.AccountArray.RemoveAt(index);
        }

        public void EditUser(string newPassword)
        {
            _user.PasswordUser = newPassword;
        }

        public string GetUserPassword()
        {
            return _user.PasswordUser;
        }

        public void SaveUsers()
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + "" + _user.LoginUser + ".ol"))
            {
                bf.Serialize(fs, _user);
            }
        }
    }
}

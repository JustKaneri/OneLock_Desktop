using System;
using System.Collections.Generic;

namespace OneLock.Model
{
    [Serializable]
    class User
    {
        private string loginUser;
        private string passwordUser;

        public string PasswordUser
        {
            get
            {
              return  EncoderDll.Encoder.Decoder(passwordUser);
            }
            set
            {
                passwordUser = EncoderDll.Encoder.Ecoder(value);
            }

        }

        public string LoginUser
        {
            get
            {
                return loginUser;
            }
        }

        public List<Account> AccountArray { get; set; }

        public User(string login,string password)
        {
            loginUser = login;
            passwordUser = EncoderDll.Encoder.Ecoder(password);

            AccountArray = new List<Account>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneLock.Model
{
    [Serializable]
    public class Account
    {
        private string login;

        private string password;

        public string NameAccount { get; set; }

        public string Login
        {
            get
            {
                return EncoderDll.Encoder.Decoder(login);
            }
            set
            {
                login = EncoderDll.Encoder.Ecoder(value);
            }
        }

        public string Password
        {
            get
            {
                return EncoderDll.Encoder.Decoder(password);
            }
            set
            {
                password = EncoderDll.Encoder.Ecoder(value);
            }
        }
    }
}

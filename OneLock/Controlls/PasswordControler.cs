using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneLock.Model;

namespace OneLock.Controlls
{
    public static class PasswordControler
    {
        /// <summary>
        /// Генерация пароля.
        /// </summary>
        /// <param name="lengt">Lenght password</param>
        /// <param name="IsRuAlf">Use Rus char</param>
        /// <param name="IsEngAlf">Use Eng char</param>
        /// <param name="IsDigt">Use Dight</param>
        /// <param name="IsChar">Use spech char</param>
        /// <returns></returns>
        public static string GeneratingPassword(int lengt, bool IsRuAlf, bool IsEngAlf, bool IsDigt, bool IsChar)
        {
            string value = "";

            string Alfa = "";

            if(IsRuAlf)
                for (char i = 'а'; i <= 'я'; i++)
                {
                    Alfa += i;
                    Alfa += Char.ToUpper(i);
                }

            if (IsEngAlf)
                for (char i = 'a'; i <= 'z'; i++)
                {
                    Alfa += i;
                    Alfa += Char.ToUpper(i);
                }

            if (IsDigt)
                Alfa += "0123456789";

            if (IsChar)
                Alfa += "!@/_-";



            Random rnd = new Random();

            for (int i = 0; i < lengt; i++)
            {
                value += Alfa[rnd.Next(Alfa.Length)];
            }
            return value;
        }
    }
}

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
        private static string rusAlfa = "АаБбВвГгДдЕеЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщъЫыьЭэЮюЯя";
        private static string engAlfa = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static string numAlfa = "0123456789";
        private static string otherAlfa = "!@/_-";


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

            if (IsRuAlf)
                Alfa += rusAlfa;

            if (IsEngAlf)
                Alfa += engAlfa;

            if (IsDigt)
                Alfa += numAlfa;

            if (IsChar)
                Alfa += otherAlfa;

            Random rnd = new Random();


            for (int i = 0; i < lengt; i++)
            {
                char rndChar = Alfa[rnd.Next(Alfa.Length)];

                value += rndChar;
            }

            return value;
        }
    }
}

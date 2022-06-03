using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Managers
{
    public class EncryptionManager
    {

        static SoliteraxLibrary.SonsuzLock locker = new SoliteraxLibrary.SonsuzLock("h@x+@r", 3);

        public static string EncryptTexts(string[] data)
        {
            string str = "";
            foreach (string value in data)
                str += locker.sifrele(value) + "$";

            return str.Substring(0, str.Length - 1).Replace("$", Environment.NewLine);
        }

        public static string[] DecryptTexts(string[] data)
        {
            LinkedList<string> str = new LinkedList<string>();
            foreach (string value in data)
                str.AddLast(locker.sifrecoz(value));

            return str.ToArray();
        }

    }
}

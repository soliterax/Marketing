using Marketing.Utils.Base_Classes;
using SoliteraxLibrary.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Utils.Managers
{
    public class PermissionManager
    {

        static LinkedList<Permissions> items = new LinkedList<Permissions>();

        static string path = Environment.CurrentDirectory + "/Permissions";

        public PermissionManager()
        {
            LoadAllSaves();
        }

        public static void LoadAllSaves()
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                SoliteraxFile data = new SoliteraxFile(file);
                items.AddLast(CalculateAndGetProduct(data.ReadAllLines()));
            }
        }

        public static void SaveAllSaves()
        {
            foreach(Permissions perm in items)
            {
                SoliteraxFile file = new SoliteraxFile(path + "/" + perm.permission_Id.ToString() + ".permission");
                file.Write(perm.ToString());
            }
        }

        public static Permissions GetPermission(int id)
        {
            foreach(Permissions perm in items)
            {
                if (perm.permission_Id == id)
                    return perm;
            }
            return null;
        }

        private static Permissions CalculateAndGetProduct(string[] data)
        {

            Permissions perm = new Permissions();

            perm.permission_Id = int.Parse(data[0]);
            perm.permission_Name = data[1];

            return perm;
        }
    }
}

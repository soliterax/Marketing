using Marketing.Utils.Base_Classes;
using SoliteraxLibrary.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Managers
{
    public class CategoryManager
    {

        static LinkedList<Category> items = new LinkedList<Category>();

        static string path = Environment.CurrentDirectory + "/Categories";

        public CategoryManager()
        {
            LoadAllSaves();
        }

        public static void LoadAllSaves()
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                SoliteraxFile data = new SoliteraxFile(file);
                items.AddLast(CalculateAndGetCategory(data.ReadAllLines()));
            }
        }

        public static void SaveAllSaves()
        {
            foreach(Category item in items)
            {
                SoliteraxFile file = new SoliteraxFile(path + "/" + item.category_Id.ToString() + ".category");
                file.Write(item.ToString());
            }
        }

        public static Category GetCategory(int id)
        {
            foreach(Category item in items)
            {
                if (item.category_Id == id)
                    return item;
            }
            return null;
        }

        static Category CalculateAndGetCategory(string[] data)
        {
            Category ct = new Category();
            ct.category_Id = int.Parse(data[0]);
            ct.category_Name = data[1];
            ct.KDV = int.Parse(data[2]);

            return ct;
        }

    }
}

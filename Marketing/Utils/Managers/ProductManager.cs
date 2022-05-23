using Marketing.Utils.Base_Classes;
using SoliteraxLibrary.FileSystem;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Managers
{
    public class ProductManager
    {

        static LinkedList<Product> products = new LinkedList<Product>();

        static string path = Environment.CurrentDirectory + "/Products";

        public ProductManager()
        {
            LoadAllSaves();
        }

        public static void LoadAllSaves()
        {
            string[] files = Directory.GetFiles(path);
            foreach(string file in files )
            {
                SoliteraxFile data = new SoliteraxFile(file);
                string _data = data.Read();
                products.AddLast(CalculateAndGetProduct(_data));
            }
        }

        public static void SaveAllSaves()
        {

        }

        public static Product GetProduct(int index)
        {
            return products.ToArray()[index];
        }

        public static Product[] GetAllProducts()
        {
            return products.ToArray();
        }

        static Product CalculateAndGetProduct(string data)
        {


            return null;
        }

    }
}

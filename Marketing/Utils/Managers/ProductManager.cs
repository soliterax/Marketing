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
                products.AddLast(CalculateAndGetProduct(data.ReadAllLines()));
            }
        }

        public static void SaveAllSaves()
        {
            foreach(Product product in products)
            {
                SoliteraxFile file = new SoliteraxFile(path + "/" + product.product_Id + ".product");
                file.Write(product.ToString());
                
            }
        }

        public static Product GetProduct(int index)
        {
            return products.ToArray()[index];
        }

        public static void SetProduct(Product product)
        {
            foreach (Product item in products)
            {
                if(item.product_Id == product.product_Id)
                {
                    item.product_Name = product.product_Name;
                    item.product_Price = product.product_Price;
                    item.product_Category = product.product_Category;
                }
            }
        }

        public static void SaveProduct(Product product)
        {
            SoliteraxFile file = new SoliteraxFile(path + "/" + product.product_Id.ToString() + ".product");
            file.Write(product.ToString());
        } 

        public static Product[] GetAllProducts()
        {
            return products.ToArray();
        }

        static Product CalculateAndGetProduct(string[] data)
        {

            Product pr = new Product();
            pr.product_Id = int.Parse(data[0]);
            pr.product_Name = data[1];
            pr.product_Category = CategoryManager.GetCategory(int.Parse(data[2]));
            pr.product_Price = decimal.Parse(data[3]);
            
            return pr;
        }

    }
}

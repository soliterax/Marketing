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
    public class HistoryManager
    {

        public class History
        {
            public int receipt_Id;
            public decimal Price;
            //Payment Method Class
            public DateTime dateTime;
            public Product[] products;

            public override string ToString()
            {
                string text = receipt_Id.ToString() + Environment.NewLine +
                    Price.ToString() + Environment.NewLine +
                    "" + Environment.NewLine +
                    dateTime.Day.ToString() + "-" + dateTime.Month.ToString() + "-" + dateTime.Year.ToString();

                foreach(Product product in products)
                {
                    text += Environment.NewLine + product.product_Id.ToString() + ":" + product.product_Amount.ToString();
                }

                return text;
            }
        }

        static LinkedList<History> items = new LinkedList<History>();

        static History nonPaymentHistory;

        static string path = Environment.CurrentDirectory + "/History";

        public HistoryManager()
        {

        }

        static void LoadAllSaves()
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                SoliteraxFile data = new SoliteraxFile(file);
                items.AddLast(CalculateAndGetProduct(data.ReadAllLines()));
            }

            SoliteraxFile _data = new SoliteraxFile(path + "/latest.txt");
            nonPaymentHistory = CalculateAndGetProduct(_data.ReadAllLines());
        }

        static History CalculateAndGetProduct(string[] data)
        {
            History history = new History();

            history.receipt_Id = int.Parse(data[0]);
            history.Price = decimal.Parse(data[1]);
            string[] date = data[3].Split('-');
            string[] time = data[4].Split(':');
            history.dateTime = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
            LinkedList<Product> pr = new LinkedList<Product>();
            for(int i = 5; i < data.Length; i++)
            {
                Product p = new Product();
                string id = "";
                string amount = "";
                for(int a = 0; a < data[i].ToCharArray().Length; a++)
                {
                    if(data[i].ToCharArray().GetValue(a).Equals(':'))
                    {
                        amount = data[i].Substring(0, a);
                        break;
                    }
                    id += data[i].ToCharArray().GetValue(a);
                }
                p = ProductManager.GetProduct(int.Parse(id));
                p.product_Amount = long.Parse(amount);
                pr.AddLast(p);
            }
            history.products = pr.ToArray();

            return history;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Base_Classes
{
    public class Cart
    {
        LinkedList<Product> products = new LinkedList<Product>();
        public long cart_Id { get; set; }

        public void AddProduct(Product product)
        {
            products.AddLast(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public void RemoveProduct(int id)
        {
            foreach(Product product in products)
            {
                if(product.product_Id == id)
                {
                    products.Remove(product);
                    break;
                }
            }
        }

        public void AddProduct(Product[] products)
        {
            foreach (Product value in products)
            {
                if(this.products.Contains(value))
                {
                    this.products.Find(value).Value.product_Amount = value.product_Amount;
                    continue;
                }
                this.products.AddLast(value);
            }
        }
    }
}

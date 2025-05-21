using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLearing.Application.Models;

namespace GenericsLearing.Application.Stores
{
    internal class ProductStore
    {
        List<Mobile> products = new List<Mobile>();
        Dictionary<string, Mobile> ProductDict = new Dictionary<string, Mobile>();
        internal void AddProduct(Mobile product)
        {
            products.Add(product);
            ProductDict.Add(product.ID, product);
        }
        internal List<Mobile> GetAllProducts()
        {
            return products;
        }
        internal Mobile GetProductById(string id)
        {
            if (ProductDict.ContainsKey(id))
            {
                return ProductDict[id];
            }
            else
            {
                return null;
            }
        }
        internal void RemoveProduct(string id)
        {
            if (ProductDict.ContainsKey(id))
            {
                products.Remove(ProductDict[id]);
                ProductDict.Remove(id);
            }
        }
    }
}

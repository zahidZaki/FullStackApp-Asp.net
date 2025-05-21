using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLearing.Application.Models;

namespace GenericsLearing.Application.Stores
{
    //internal class GenericStore<T> where T : class //that we tell that what we recive at development time 
    internal class GenericStore<ProductType,KeyType> where ProductType : Product
    {
        List<ProductType> products = new List<ProductType>();
        Dictionary<KeyType, ProductType> ProductDict = new Dictionary<KeyType, ProductType>();
        internal void AddProduct(ProductType product,KeyType ID)
        {
            products.Add(product);
            ProductDict.Add(ID, product);
        }
        internal List<ProductType> GetAllProducts()
        {
            return products;
        }
        internal ProductType GetProductById(KeyType id)
        {
            if (ProductDict.ContainsKey(id))
            {
                return ProductDict[id];
            }
            else
            {
               Console.WriteLine("Product not found");
                return default(ProductType);
            }
        }
        internal void RemoveProduct(KeyType id)
        {
            if (ProductDict.ContainsKey(id))
            {
                products.Remove(ProductDict[id]);
                ProductDict.Remove(id);
            }
        }
    }
}

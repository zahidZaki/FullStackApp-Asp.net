using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLearing.Application.Models;

namespace GenericsLearing.Application.Stores
{
    internal class BookStore
    {
        List<Mobile> books = new List<Mobile>();
        Dictionary<string, Mobile> booksDict = new Dictionary<string, Mobile>();
        internal void AddBook(Mobile book)
        {
            books.Add(book);
            booksDict.Add(book.ID, book);
        }
        internal List<Mobile> GetAllBooks()
        {
            return books;
        }
        internal Mobile GetBookById(string id)
        {
            if (booksDict.ContainsKey(id))
            {
                return booksDict[id];
            }
            else
            {
                return null;
            }
        }
        internal void RemoveBook(string id)
        {
            if (booksDict.ContainsKey(id))
            {
                books.Remove(booksDict[id]);
                booksDict.Remove(id);
            }
        }
    }
}

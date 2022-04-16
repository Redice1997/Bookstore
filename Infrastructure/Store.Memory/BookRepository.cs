using System;
using System.Linq;
using Bookstore;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art Of Programming"),
            new Book(2, "Refactoring"),
            new Book(3, "C Programming Language")
        };
        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(b => b.Title.Contains(titlePart)).ToArray();
        }
    }
}

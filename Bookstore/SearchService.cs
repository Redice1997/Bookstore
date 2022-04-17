using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    public class SearchService
    {
        private readonly IBookRepository bookRepository;
        public SearchService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return bookRepository.GetAllByIsbn(query);

            return bookRepository.GetAllByTitleOrAuthor(query);
        }
    }
}

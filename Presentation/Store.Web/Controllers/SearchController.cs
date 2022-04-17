using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {        
        private readonly SearchService searchService;

        public SearchController(SearchService searchService)
        {
            this.searchService = searchService;
        }
        public IActionResult Index(string query)
        {
            var books = searchService.GetAllByQuery(query);
            return View(books);
        }
    }
}

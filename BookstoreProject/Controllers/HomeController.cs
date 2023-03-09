using BookstoreProject.Models;
using BookstoreProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreProjectRepository repo;

        public HomeController (IBookstoreProjectRepository temp)
        {
            repo = temp;
        }
     

        public IActionResult Index(string Category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(B => B.Category == Category || Category == null)
                .OrderBy(B => B.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = 
                        (Category == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == Category).Count()),
                   
                        
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };


            return View(x);
        }


    }
}

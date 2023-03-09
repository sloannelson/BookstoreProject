using BookstoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreProjectRepository repo { get; set; }

        public TypesViewComponent(IBookstoreProjectRepository temp)
        {
            repo = temp; 
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["Category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class ShopModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public ShopModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
       
        public void OnGet(Basket b)
        {
            basket = b;
        }

        public IActionResult OnPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket = new Basket();
            basket.AddItem(b, 1);

            return RedirectToPage(basket);
        }
    }
}

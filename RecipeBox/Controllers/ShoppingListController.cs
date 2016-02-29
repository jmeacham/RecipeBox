using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RecipeBox.Models;
using System.Data.Entity;

namespace RecipeBox.Controllers
{
    public class ShoppingListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingList
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            Recipe recipe = await db.Recipes.Where(r => r.ApplicationUserId == userId)
                                            .Include(r => r.Files)
                                            .SingleOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
            
        }
    }
}
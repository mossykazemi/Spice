using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hotingEnvironment;

        public MenuItemController(ApplicationDbContext db, IWebHostEnvironment hotingEnvironment)
        {
            _db = db;
            _hotingEnvironment = hotingEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            var menuItem = await _db.MenuItem.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync();
            return View(menuItem);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models.ViewModels;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public MenuItemViewModel MenuItemVM { get; set; }


        public MenuItemController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            MenuItemVM = new MenuItemViewModel()
            {
                Category = _db.Category,
                MenuItem = new Models.MenuItem()
            };
        }


        public async Task<IActionResult> Index()
        {
            var menuItem = await _db.MenuItem.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync();
            return View(menuItem);
        }


        //GET - Create
        public IActionResult Create()
        {
           return View(MenuItemVM);
        }
    }
}

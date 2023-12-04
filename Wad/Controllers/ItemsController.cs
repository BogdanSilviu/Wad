using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wad.Models;
using Wad.Services;
using Wad.Services.Interfaces;

namespace Wad.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IEmployeeService _employeeService;
        private readonly IBidService _bidService;
        private readonly UserManager<IdentityUser> _userManager;

        public ItemsController(IItemService itemService,UserManager<IdentityUser> userManager, IBidService bidService, IBrandService brandService,ICategoryService categoryService,IEmployeeService employeeService)
        {
            _itemService = itemService;
            _brandService = brandService;
            _categoryService = categoryService;
            _employeeService = employeeService;
            _bidService = bidService;
            _userManager = userManager;

        }

        // GET: Items
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_itemService.GetItems());
        }

        // GET: Items/Details/5
        public IActionResult Details(int id)
        {
           
            var item = _itemService.GetItemById(id);
            ViewData["HighestBid"]= _bidService.GetHighestBid(id).Price;
               
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("AddBid")]
        public IActionResult AddBid(int price, int itemId)
        {
            var newBid = new Bid()
            {
                ItemId = itemId,
                Price = price,
                UserId = _userManager.GetUserId(User)
            };
            _bidService.CreateBid(newBid);
            return RedirectToAction("Details", "Items", new {id=itemId});
        }

        // GET: Items/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_employeeService.GetEmployees(), "Id", "Id");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,Photo,CategoryId,BrandId,EmployeeId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _itemService.CreateItem(item);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_employeeService.GetEmployees(), "Id", "Id");
            return View(item);
        }

        // GET: Items/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {


            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_employeeService.GetEmployees(), "Id", "Id");
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,Photo,CategoryId,BrandId,EmployeeId")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _itemService.UpdateItem(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_employeeService.GetEmployees(), "Id", "Id");
            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {


            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var item = _itemService.GetItemById(id);
            if (item != null)
            {
                _itemService.DeleteItem(item);
            }
            
            return RedirectToAction(nameof(Index));
        }

       
    }
}

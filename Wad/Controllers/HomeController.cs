using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wad.Models;
using Wad.Services.Interfaces;

namespace Wad.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IItemService _itemService;

        public HomeController( IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            return View(_itemService.GetItems());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Linq;
using Products.Models;

namespace Products.Controllers
{
    public class HomeController : Controller
    
    {
        private YourContext _context;
        public HomeController(YourContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("NewProduct")]
        public IActionResult NewProduct(Product newProduct)
        {
            
            if(ModelState.IsValid){
                _context.Add(newProduct);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("productId", newProduct.Id);
                return Redirect($"ViewProduct/{newProduct.Id}");
            }
        
            return View("Index",newProduct.Id);
        }


        [HttpGet]
        [Route("ViewProduct/{newProductId}")]
        
        public IActionResult ViewProduct(int newProductId )
        {
            Product product = _context.Products.SingleOrDefault(prod=> prod.Id == newProductId);
            ViewBag.product = product;
            var allCategories = _context.Categories.ToList();                                           
            ViewBag.allCategories = allCategories;
            return View();
        }
        [HttpGet]
        [Route("AllList")]
        
        public IActionResult AllList()
        {
            var allProducts = _context.Products.Where(p=> p.Id == 1).ToList();            
            ViewBag.allProducts = allProducts;

            var allCategories = _context.Categories.ToList();
            ViewBag.allCategories =allCategories;
         
            return View();
        }







        [HttpPost]
        [Route("NewCategory")]
        public IActionResult NewCategory(Category newCategory)
        {
            if(ModelState.IsValid){
                _context.Add(newCategory);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("categoryId", newCategory.Id);
                return Redirect($"ViewCategory/{newCategory.Id}");
            }
            return View("NewCategory",newCategory);
        }


        [HttpPost]
        [Route("addCatToProd")]
        public IActionResult addCatToProd(int categoryId)
        {
           System.Console.WriteLine("********************************" + Request.Form["categoryId"]);
           
            return RedirectToAction("ViewProduct/{1}");
        }













        [HttpGet]
        [Route("ViewCategory/{newCategoryId}")]
        
        public IActionResult ViewCategory(int newCategoryId )
        {
            Category category = _context.Categories.SingleOrDefault(cat=> cat.Id == newCategoryId);
            ViewBag.category = category;

            return View();
        }

        [HttpGet]
        [Route("CreatCategoryPage")]
        
        public IActionResult CreatCategoryPage( )
        {
           

            return View("NewCategory");
        }








        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

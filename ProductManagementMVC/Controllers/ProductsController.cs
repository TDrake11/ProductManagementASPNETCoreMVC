using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Services.Services.CategoryService;
using PRN222.Lab1.Services.Services.ProductService;
using PRN222.Lab1.Repositories.Data;
using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.ProductManagementMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;

		public ProductsController(ICategoryService categoryService, IProductService productService)
        {
			_categoryService = categoryService;
			_productService = productService;

		}

		// GET: Products
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("UserId") == null)
			{
				// Redirect to the login page or display an error message
				return RedirectToAction("Login", "Account");
			}
			var myStoreDbContext = _productService.GetProducts();
			return View(myStoreDbContext.ToList());
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryId");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,CategoryId,UnitsInStock,UnitPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.SaveProduct(product);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryId", product.Category);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryId", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,CategoryId,UnitsInStock,UnitPrice")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productService.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryId", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _productService.GetProductById((int)id);
            if (product != null)
            {
                _productService.DeleteProduct(product);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            var tmp =_productService.GetProductById(id);
            return (tmp != null)?true : false;
        }
    }
}

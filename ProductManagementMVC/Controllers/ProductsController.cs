using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Services.Services.CategoryService;
using PRN222.Lab1.Services.Services.ProductService;
using PRN222.Lab1.Repositories.Entities;
using Microsoft.AspNetCore.Authorization;

namespace PRN222.Lab1.ProductManagementMVC.Controllers
{
	[Authorize]
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
			var myStoreDbContext = await _productService.GetProducts();
			return View(myStoreDbContext);
		}


		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
        {
			if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetCategories(), "CategoryId", "CategoryName");
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
                await _productService.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetCategories(), "CategoryId", "CategoryName", product.Category);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
			if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);
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
            ViewData["CategoryId"] = new SelectList( await _categoryService.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
			if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById((int)id);
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
            var product = await _productService.GetProductById((int)id);
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

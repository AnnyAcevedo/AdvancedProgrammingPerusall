using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdvancedProgramming.Data;
using AdvancedProgramming.Repository;

namespace AdvancedProgramming.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository productRepository;
        public ProductsController()
        {
            productRepository = new ProductRepository();
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = productRepository.GetAllProducts();
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            /*
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "ModifiedBy");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            */
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,InventoryID,SupplierID,Description,Rating,CategoryID,LastModified,ModifiedBy")] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            /*
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "ModifiedBy", product.InventoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            */
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            /*
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "ModifiedBy", product.InventoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            */
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,InventoryID,SupplierID,Description,Rating,CategoryID,LastModified,ModifiedBy")] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            /*
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "ModifiedBy", product.InventoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            */
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = productRepository.GetProductById(id);
            productRepository.DeleteProduct(id);
        
            return RedirectToAction("Index");
        }

        
    }
}

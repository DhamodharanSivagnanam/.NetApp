using ClientMVC.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientMVC.Controllers
{
    public class ProductSupplierController : Controller
    {
        private Repository repository = new Repository();
        static List<Product_Details>  test = new List<Product_Details>
            {
                new Product_Details{Product_Id=1,ProductName="Laptop",Supplier_Id=2},
                 new Product_Details{Product_Id=2,ProductName="Mobile",Supplier_Id=3},
                  new Product_Details{Product_Id=3,ProductName="System",Supplier_Id=4}
            };
        // GET: ProductSupplier
        public ActionResult Index()
        {
           
            return View("Index",test);
        }

        // GET: ProductSupplier/Details/5
        public ActionResult Details(int id)
        {

            var item =test.FirstOrDefault(x => x.Product_Id == id);
            return View(item);
        }

        // GET: ProductSupplier/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ProductSupplier/Create
        [HttpPost]
        public ActionResult Create(Product_Details prod)
        {
            
                // TODO: Add insert logic here

                if(ModelState.IsValid)
                {
                test.Add(prod);
                    //repository.Create(prod);
                    return RedirectToAction("Index");
                }
            return View(prod);

        }

        // GET: ProductSupplier/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = test.FirstOrDefault(x=>x.Product_Id==id);//repository.find(id);
            return View(prod);
        }

        // POST: ProductSupplier/Edit/5
        [HttpPost]
        public ActionResult Edit(Product_Details prod)
        {
            if (ModelState.IsValid)
            {
                var product = test.FirstOrDefault(x => x.Product_Id ==prod.Product_Id);
                test.Remove(product);
                test.Add(prod);
                //repository.Edit(prod);
                return RedirectToAction("Index");
            }
            return View(prod);
        }

        // GET: ProductSupplier/Delete/5
        public ActionResult Delete(int id=0)
        {
            var product = test.FirstOrDefault(x => x.Product_Id == id);
           // test.Remove(product);
            //var prod = repository.find(id);
            return View(product);
        }

        // POST: ProductSupplier/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var product = test.FirstOrDefault(x => x.Product_Id == id);
                test.Remove(product);
                // repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

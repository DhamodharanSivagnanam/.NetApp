using ClientMVC.Controllers;
using ClientMVC.Controllers.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClientMVCTest
{
    [TestFixture]
    public class ProductSupplierControllerTest
    {
        private Repository repository = new Repository();
        [Test]
        public void IndexActionReturnsIndexView()
        {
            string expected = "Index";
            ProductSupplierController controller = new ProductSupplierController();
            var test = new List<Product_Details>
            {
                new Product_Details{Product_Id=1,ProductName="Laptop",Supplier_Id=2}
            };
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void TestDetails()
        {
            // Arrange.
            var productId = 1;

            // Act
            var result = repository.find(productId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Product_Id, productId);
        }

        [Test]
        public void TestUpdate()
        {
            // Arrange.
            var productId = 1;
            var nameToChange = "Mobile";

            // Act
            var result = repository.find(productId);
            result.ProductName = nameToChange;
            var editResult = repository.Edit(result);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(editResult, true);            
        }

        [Test]
        public void TestProductSupplierCreateRedirect()
        {
            var obj = new ProductSupplierController();

            RedirectToRouteResult result = obj.Create(new Product_Details()
            {
                Product_Id = 190,
                ProductName = "Laptop",
                Supplier_Id = 150
            }) as RedirectToRouteResult;


            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));

        }

        /// <summary>
        /// Test to return Error View is the Model is Invalid
        /// </summary>
        [Test]
        public void TestProductSupplierCreateErrorView()
        {
            var obj = new ProductSupplierController();

            ViewResult result = obj.Create(new Product_Details()
            {
                Product_Id = 190,
                ProductName = "Laptop",
                Supplier_Id = 150
            }) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }

        /// <summary>
        /// Index Returns AllRoows
        /// </summary>
        [Test]
        public void IndexReturnsAllRoows()
        {
            var obj = new ProductSupplierController();

            var result = repository.findAll();
            Assert.AreEqual(10, result.Count());
        }
    }
}

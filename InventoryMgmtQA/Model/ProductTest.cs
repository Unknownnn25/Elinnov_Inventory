using InventoryMgmt.Model;
using System.ComponentModel.DataAnnotations;

// guide: https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022

namespace InventoryMgmtQA.Model
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestAddProduct()
        {
            // create a new product with compliant attribute values
            Product product = new()
            {
                Name = "TestProduct",
                QuantityInStock = 1,
                Price = 1.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            // the product must be valid since all attributes values validated correctly
            Assert.IsTrue(isProductValid);
        }
        [TestMethod]
        public void TestAddProductPriceNegative()
        {
            Product product = new()
            {
                Name = "TestProduct",
                QuantityInStock = 1,
                Price = -1.0M // test for negative price
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            // the product must NOT be valid since the Price attribute has invalid value
            Assert.IsFalse(isProductValid);
        }

        // Added Test Case
        [TestMethod]
        public void TestAddProductQuantityNegative()
        {
            Product product = new()
            {
                Name = "TestProduct",
                QuantityInStock = -1, // test for negative quantity
                Price = 1.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            // the product must NOT be valid since the QuantityInStock attribute has invalid value
            Assert.IsFalse(isProductValid);
        }


        [TestMethod]
        public void TestAddProductNoName()
        {
            // create a new product without a name
            Product product = new()
            {
                Name = null, // no name provided
                QuantityInStock = 1,
                Price = 1.0M
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(product, null, null);
            bool isProductValid = Validator.TryValidateObject(product, context, results, true);

            // the product must NOT be valid since the Name attribute is required
            Assert.IsFalse(isProductValid);
}


            }

    
}
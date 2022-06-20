using NUnit.Framework;
using ProductReviewManagement;
using System.Collections.Generic;

namespace PRTest
{
    public class Tests
    {
        ProductReview product = new ProductReview();
        List<Product> ProductList;

        [SetUp]
        public void Setup()
        {
            ProductReview product;
            ProductList = new List<Product>();
        }
        /// <summary>
        /// TC 1: Adding a Productreview details in list and returns the count
        /// </summary>
        [Test]
        public void GivenCreateFunction_returnCountofListCreated()
        {
            int expected = 25;
            int actual = product.AddProductReview();
            Assert.AreEqual(expected, actual);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class ProductReview
    {
        public List<Product> ProductList = new List<Product>();
        DataTable productdt;

        // UC 1: Adding a Productreview details
        public int AddProductReview()
        {
            ProductList.Add(new Product() { ProductId = 03, UserId = 10, Review = "Bad", Rating = 3, IsLike = false });
            ProductList.Add(new Product() { ProductId = 02, UserId = 8, Review = "Average", Rating = 3, IsLike = false });
            ProductList.Add(new Product() { ProductId = 03, UserId = 7, Review = "Nice", Rating = 2, IsLike = true });
            ProductList.Add(new Product() { ProductId = 04, UserId = 5, Review = "Good", Rating = 4, IsLike = false });
            ProductList.Add(new Product() { ProductId = 06, UserId = 4, Review = "Average", Rating = 2, IsLike = true });
            ProductList.Add(new Product() { ProductId = 05, UserId = 6, Review = "Bad", Rating = 4, IsLike = false });
            ProductList.Add(new Product() { ProductId = 06, UserId = 8, Review = "Good", Rating = 5, IsLike = false });
            ProductList.Add(new Product() { ProductId = 02, UserId = 9, Review = "Good", Rating = 5, IsLike = true });
            ProductList.Add(new Product() { ProductId = 04, UserId = 5, Review = "Average", Rating = 3, IsLike = false });
            ProductList.Add(new Product() { ProductId = 06, UserId = 4, Review = "Bad", Rating = 3, IsLike = true });
            ProductList.Add(new Product() { ProductId = 07, UserId = 9, Review = "Bad", Rating = 1, IsLike = false });
            ProductList.Add(new Product() { ProductId = 06, UserId = 10, Review = "Nice", Rating = 1, IsLike = true });
            ProductList.Add(new Product() { ProductId = 06, UserId = 3, Review = "Good", Rating = 5, IsLike = false });
            ProductList.Add(new Product() { ProductId = 02, UserId = 10, Review = "Nice", Rating = 3, IsLike = false });
            ProductList.Add(new Product() { ProductId = 02, UserId = 9, Review = "Bad", Rating = 4, IsLike = false });
            ProductList.Add(new Product() { ProductId = 09, UserId = 12, Review = "Good", Rating = 2, IsLike = true });
            ProductList.Add(new Product() { ProductId = 04, UserId = 14, Review = "Nice", Rating = 5, IsLike = false });
            ProductList.Add(new Product() { ProductId = 05, UserId = 15, Review = "Average", Rating = 6, IsLike = true });
            ProductList.Add(new Product() { ProductId = 1, UserId = 10, Review = "Average", Rating = 2, IsLike = false });
            ProductList.Add(new Product() { ProductId = 1, UserId = 1, Review = "Bad", Rating = 1, IsLike = true });
            ProductList.Add(new Product() { ProductId = 2, UserId = 10, Review = "Average", Rating = 2, IsLike = false });
            ProductList.Add(new Product() { ProductId = 4, UserId = 7, Review = "Good", Rating = 4, IsLike = true });
            ProductList.Add(new Product() { ProductId = 5, UserId = 8, Review = "Bad", Rating = 3, IsLike = false });
            ProductList.Add(new Product() { ProductId = 3, UserId = 9, Review = "Nice", Rating = 7, IsLike = false });
            ProductList.Add(new Product() { ProductId = 5, UserId = 10, Review = "Average", Rating = 3, IsLike = true });

            return ProductList.Count;
        }

        public string AverageofRatingBasedonProductId()
        {
            throw new NotImplementedException();
        }

        // UC 2: Retrieve Top Three Records Whose Rating is High
        public int RetrieveTopThreeRating()
        {
            AddProductReview();
            var res = (from product in ProductList orderby product.Rating descending select product).Take(3).ToList();
            DisplayList();
            return res.Count;
        }
        // UC 3: Retrieve  records from list based on productid and Rating > 3  
        public string RetrieveRecordsBasedOnRatingAndProductId()
        {
            AddProductReview();
            string nameList = "";
            var productList = (from product in ProductList where product.Rating > 3 && (product.ProductId == 1 || product.ProductId == 4 || product.ProductId == 9) select product);
            foreach (var product in productList)
            {
                nameList += product.UserId + " ";
                Console.WriteLine("ProductId: {0} || UserId: {1} || Review: {2} || Rating: {3} || IsLike:{4}\n", product.ProductId, product.UserId, product.Review, product.Rating, product.IsLike);
            }
            return nameList;
        }
        // UC 4: Retrieve count of Product ID
        public string CountingProductId()
        {
            string nameList = "";
            AddProductReview();
            var productList = ProductList.GroupBy(x => x.ProductId).Select(a => new { ProductId = a.Key, count = a.Count() });
            foreach (var element in productList)
            {
                Console.WriteLine("ProductId " + element.ProductId + " " + "Count " + " " + element.count);
                nameList += element.count + " ";
            }
            return nameList;
        }
        // UC 5: Retrieving the product id and Review from list
        public string RetrieveOnlyProductIdAndReviews()
        {
            string result = "";
            AddProductReview();
            var productList = ProductList.Select(product => new { ProductId = product.ProductId, Review = product.Review }).ToList();
            foreach (var element in productList)
            {
                Console.WriteLine("ProductId: " + element.ProductId + "\tReview: " + element.Review);
                result += element.ProductId + " ";
            }
            return result;
        }
        // UC 6: Skip top Five records
        public string SkipTop5Record()
        {
            AddProductReview();
            string nameList = "";
            var result = (from product in ProductList orderby product.Rating descending select product).Skip(5).ToList();
            foreach (var element in result)
            {
                nameList += element.ProductId + " ";
            }
            return nameList;
        }
        // UC 8: Adding a Productreview details in Data Table
        public int CreateDataTable()
        {
            AddProductReview();
            productdt = new DataTable();
            productdt.Columns.Add("ProductId", typeof(Int32));
            productdt.Columns.Add("UserId", typeof(Int32));
            productdt.Columns.Add("Rating", typeof(Int32));
            productdt.Columns.Add("Review", typeof(string));
            productdt.Columns.Add("IsLike", typeof(bool));

            foreach (var data in ProductList)
            {
                productdt.Rows.Add(data.ProductId, data.UserId, data.Rating, data.Review, data.IsLike);
            }

            return productdt.Rows.Count;
        }
        // UC 9: Retrieve the records whose column islike has true using DataTable
        public string ReturnsOnlyIsLikeFieldAsTrue()
        {
            List<Product> ProductList = new List<Product>();
            CreateDataTable();
            string nameList = "";
            var res = from product in productdt.AsEnumerable() where product.Field<bool>("IsLike") == true select product;
            foreach (var p in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["ProductId"], p["UserId"], p["Rating"], p["Review"], p["IsLike"]);
                nameList += p["UserId"] + " ";
            }
            return nameList;
        }
        //UC 11: Retrieve records where Review is Nice
        public string ReturnsReviewMessageContainsNice()
        {
            CreateDataTable();
            List<Product> ProductList = new List<Product>();

            string nameList = "";
            var res = from product in productdt.AsEnumerable() where product.Field<string>("Review") == "Nice" select product;
            foreach (var p in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["ProductId"], p["UserId"], p["Rating"], p["Review"], p["IsLike"]);
                nameList += p["UserId"] + " ";
            }
            return nameList;
        }
        //UC 12: Retrieve Record based on Rating where userid=10 
        public string RetrieveRecordsBasedOnRating()
        {
            CreateDataTable();
            string nameList = "";
            var res = (from product in productdt.AsEnumerable() where product.Field<Int32>("UserId") == 10 orderby product.Field<int>("Rating") select product).ToList();
            foreach (var p in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["ProductId"], p["UserId"], p["Rating"], p["Review"], p["IsLike"]);
                nameList += p["Rating"] + " ";
            }
            return nameList;
        }
        public void DisplayList()
        {
            foreach (Product product in ProductList)
            {
                Console.WriteLine("ProductId: {0} || UserId: {1} || Review: {2} || Rating: {3} || IsLike:{4}\n", product.ProductId, product.UserId, product.Review, product.Rating, product.IsLike);
            }
        }
    }
}

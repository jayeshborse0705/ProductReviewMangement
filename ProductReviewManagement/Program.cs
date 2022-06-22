using ProductReviewManagement;
using System;
namespace ProductReviewLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductReview productReview = new ProductReview();
            productReview.AddProductReview();
            productReview.DisplayList();
            productReview.RetrieveTopThreeRating();


        }
    }
}
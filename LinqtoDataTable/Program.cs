using System;
using System.Data;
using System.Collections.Generic;

namespace LinqtoDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Data Table demo");
            Console.WriteLine("==========================");

            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductID=1,UserID=1,Rating=2,Review="Good",IsLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductID=3,UserID=1,Rating=5,Review="Good",IsLike=true},
                new ProductReview(){ProductID=4,UserID=10,Rating=6,Review="Good",IsLike=false},
                new ProductReview(){ProductID=5,UserID=1,Rating=2,Review="nice",IsLike=true},
                new ProductReview(){ProductID=6,UserID=1,Rating=1,Review="bas",IsLike=true},
                new ProductReview(){ProductID=8,UserID=1,Rating=1,Review="Good",IsLike=false},
                new ProductReview(){ProductID=8,UserID=1,Rating=9,Review="nice",IsLike=true},
                new ProductReview(){ProductID=2,UserID=10,Rating=10,Review="nice",IsLike=true},
                new ProductReview(){ProductID=10,UserID=1,Rating=8,Review="nice",IsLike=true},
                new ProductReview(){ProductID=11,UserID=1,Rating=3,Review="nice",IsLike=true},
                new ProductReview() { ProductID = 11, UserID = 4, Rating = 3, Review = "nice", IsLike = true },
                new ProductReview() { ProductID = 8, UserID = 3, Rating = 5, Review = "nice", IsLike = true },
                new ProductReview() { ProductID = 9, UserID = 4, Rating = 2, Review = "bad", IsLike = false },
                new ProductReview() { ProductID = 2, UserID = 5, Rating = 7, Review = "Good", IsLike = true },
                new ProductReview() { ProductID = 4, UserID = 8, Rating = 3, Review = "bad", IsLike = true },
                new ProductReview() { ProductID = 11, UserID = 3, Rating = 6, Review = "nice", IsLike = false },
                new ProductReview() { ProductID = 7, UserID = 5, Rating = 8, Review = "Good", IsLike = true },
                new ProductReview() { ProductID = 6, UserID = 10, Rating = 7, Review = "nice", IsLike = false },
                new ProductReview() { ProductID = 4, UserID = 3, Rating = 7, Review = "nice", IsLike = false },
                new ProductReview() { ProductID = 9, UserID = 2, Rating = 4, Review = "bad", IsLike = true },
                new ProductReview() { ProductID = 3, UserID = 7, Rating = 6, Review = "nice", IsLike = true },
                new ProductReview() { ProductID = 1, UserID = 10, Rating = 8, Review = "nice", IsLike = false },
                new ProductReview() { ProductID = 8, UserID = 10, Rating = 9, Review = "Good", IsLike = false },
                new ProductReview() { ProductID = 5, UserID = 10, Rating = 4, Review = "bad", IsLike = true },
                new ProductReview() { ProductID = 10, UserID = 1, Rating = 7, Review = "nice", IsLike = true },

            };

            /*foreach (var list in productReviewList)
            {
                Console.WriteLine($"{list.ProductID},{list.UserID},{list.Rating},{list.Review},{list.IsLike}");
            }*/
            foreach (var list in productReviewList)
            {
                Console.WriteLine("ProductID: " + list.ProductID + "UserID: " + list.UserID + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }

            ManagementClass management = new ManagementClass();
            //UC2 top 3 records
            Console.WriteLine("Top 3 records with highest rating\n");
            management.Top3Records(productReviewList);
            Console.WriteLine("\n\n\n");

            //UC3 Records(1/4/9) with rating>3
            Console.WriteLine("Products with rating greater than 3 and productID among 1,4 or 9\n");
            management.SelectedRecords(productReviewList);
            Console.WriteLine("\n\n\n");

            //UC4 counts of all records for each ProductID
            Console.WriteLine("Counts of all records for each ProductID");
            management.RetrieveCountOfRecords(productReviewList);
            Console.WriteLine("\n\n\n");

            //UC5 ProductID and reviews of all records
            Console.WriteLine("ProductID and reviews of all records");
            management.RetrieveProductIdAndReview(productReviewList);
            Console.WriteLine("\n\n\n");

            //UC6 List all except the top 5 records
            Console.WriteLine("Data after skipping top 5 records");
            management.RetrieveProductsBySkippingTop5(productReviewList);
            Console.WriteLine("\n\n\n");

            //UC8CreateTableUsingLINQ
            LinqToDT linqDT = new LinqToDT();
            DataTable productTable= linqDT.AddToDataTableDemo(productReviewList);

            //UC9 Retrieve products which have isLike value is true
            Console.WriteLine("\nproducts which have isLike value is true");
            linqDT.RetrieveIsLikeTrueProductsFromDataTable(productTable);
            Console.WriteLine("\n\n\n");

            //UC10 Average Rating of each ProductID using LinQ
            Console.WriteLine("\nAverage Rating of each ProductID using LinQ");
            linqDT.GetAverageRatingByProductId(productTable);
            Console.WriteLine("\n\n\n");

            //UC11 Nice Review Products
            Console.WriteLine("Products with Nice Review are: ");
            linqDT.RetrieveNiceReviewProducts(productTable);
            Console.WriteLine("\n\n\n");

            //UC12 Order the products with UserID =10 by their rating
            Console.WriteLine("Prodcuts with UserID=10 ordered by Rating");
            linqDT.OrderProductsByRating(10, productTable);
            Console.WriteLine("\n\n\n");
        }
    }
}
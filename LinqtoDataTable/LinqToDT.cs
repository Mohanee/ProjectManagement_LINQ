using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace LinqtoDataTable
{
    class LinqToDT
    {
        /// <summary>
        /// Adds and displays the data from productReviewList into Datatable
        /// </summary>
        /// <param name="listProductReviews">Product Reviw List</param>
        public DataTable AddToDataTableDemo(List<ProductReview> listProductReviews)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId",typeof(int));
            table.Columns.Add("UserId",typeof(int));
            table.Columns.Add("Rating",typeof(double));
            table.Columns.Add("Review",typeof(string));
            table.Columns.Add("IsLike",typeof(bool));

            foreach (ProductReview product in listProductReviews)
            {
                table.Rows.Add(product.ProductID, product.UserID, product.Rating, product.Review, product.IsLike);
            }
            return table;
        }

        /// <summary>
        /// Retrieve all data from datatable
        /// </summary>
        /// <param name="table">DataTable</param>
        public void RetrieveData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Retrieves products with IsLike = true
        /// </summary>
        /// <param name="table">DataTable</param>
        public void RetrieveIsLikeTrueProductsFromDataTable(DataTable table)
        {
            var productNames = from products in table.AsEnumerable()
                               where products.Field<bool>("IsLike") == true
                               select products;
            foreach (var row in productNames)
            {
                Console.Write(row.Field<int>("ProductId") + "\t" + row.Field<int>("UserId") + "\t" + row.Field<double>("Rating") + "\t" + row.Field<string>("Review") + "\t" + row.Field<bool>("IsLike") + "\n");
            }
        }

        /// <summary>
        /// Method to print the average rating of each ProductID
        /// </summary>
        /// <param name="table">DataTable</param>
        public void GetAverageRatingByProductId(DataTable table)
        {
            var recordedData = from products in table.AsEnumerable()
                               group products by products.Field<int>("ProductId") into g
                               select new { ProductId = g.Key, Average = g.Average(a => a.Field<double>("Rating")) };
            foreach (var row in recordedData)
            {
                Console.Write(row.ProductId + "\t" + row.Average + "\n");
            }
        }

        /// <summary>
        /// Retrieves products which contain nice in their review
        /// </summary>
        /// <param name="table"></param>
        public void RetrieveNiceReviewProducts(DataTable table)
        {
            var recordedData = from products in table.AsEnumerable()
                               where products.Field<string>("Review").Contains("nice")
                               select products;
            foreach (var row in recordedData)
            {
                Console.Write(row.Field<int>("ProductId") + "\t" + row.Field<int>("UserId") + "\t" + row.Field<double>("Rating") + "\t" + row.Field<string>("Review") + "\t" + row.Field<bool>("IsLike") + "\n");
            }
        }

        /// <summary>
        /// Method to order the products according to their ratings
        /// </summary>
        /// <param name="userId">UserID of the product</param>
        /// <param name="table">DataTable</param>
        public void OrderProductsByRating(int userId, DataTable table)
        {
            var recodedData = from products in table.AsEnumerable()
                              where products.Field<int>("UserId") == userId
                              orderby products.Field<double>("Rating")
                              select products;
            foreach (var row in recodedData)
            {
                Console.Write(row.Field<int>("ProductId") + "\t" + row.Field<int>("UserId") + "\t" + row.Field<double>("Rating") + "\t" + row.Field<string>("Review") + "\t" + row.Field<bool>("IsLike") + "\n");
            }
        }
    }
}


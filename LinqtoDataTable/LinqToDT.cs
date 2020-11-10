using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

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
    }
}

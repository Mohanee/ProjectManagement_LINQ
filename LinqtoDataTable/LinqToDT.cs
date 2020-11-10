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
        public void AddToDataTableDemo(List<ProductReview> listProductReviews)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId");
            table.Columns.Add("UserId");
            table.Columns.Add("Rating");
            table.Columns.Add("Review");
            table.Columns.Add("IsLike");

            foreach (ProductReview product in listProductReviews)
            {
                table.Rows.Add(product.ProductID, product.UserID, product.Rating, product.Review, product.IsLike);
            }
        }
    }
}

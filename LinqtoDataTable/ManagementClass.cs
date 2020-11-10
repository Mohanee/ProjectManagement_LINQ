using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LinqtoDataTable
{
    class ManagementClass
    {
        //UC1 Create DatatTable
        /// <summary>
        /// Creating the datatTable
        /// </summary>
        public readonly DataTable dataTable = new DataTable();

        //UC2 List top 3 records with high ratings
        public void Top3Records(List<ProductReview> listProductReview)
        {
            var recordedData = (from ProductReviews in listProductReview
                                orderby ProductReviews.Rating descending
                                select ProductReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID);
            }
        }

        //UC3
        /// <summary>
        /// Method to retrieve records with rating >3 and project id = 1/4/9
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordData = from productReviews in listProductReview
                             where (productReviews.ProductID == 1 || productReviews.ProductID == 4 || productReviews.ProductID == 9)
                             && productReviews.Rating > 3
                             select productReviews;
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductID: "+list.ProductID);
            }
        }

        //UC4
        /// <summary>
        /// Method to List count of review present for each record
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordData)
            {
                Console.WriteLine((list.ProductID)+"\t" + list.Count);
            }
        }

        /// <summary>
        /// Method to List product ID and review of all the records
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               select new
                               {
                                   productReviews.ProductID,
                                   productReviews.Review
                               };
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product Id:- " + list.ProductID + "\t" + "Review: " + list.Review);
            }
        }
    }
}
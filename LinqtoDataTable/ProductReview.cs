using System;
using System.Collections.Generic;
using System.Text;

namespace LinqtoDataTable
{
    public class ProductReview
    {
        //UC1
        /// <summary>
        /// Fields of project review class
        /// </summary>
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool IsLike { get; set; }
    }
}
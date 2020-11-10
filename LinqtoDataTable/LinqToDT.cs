using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LinqtoDataTable
{
    class LinqToDT
    {
        public void AddToDataTableDemo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("ProductName");

            table.Rows.Add("1", "Chai");
            table.Rows.Add("2", "Queso Carbels");
            table.Rows.Add("3", "Tofu");
            DisplayProductFromTable(table);
        }

        public void DisplayProductFromTable(DataTable table)
        {
            var productNames = from products in table.AsEnumerable() select products.Field<string>("ProductName");
            Console.WriteLine("Product Name: ");
            foreach (string productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }
    }
}

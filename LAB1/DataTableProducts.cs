using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    public class DataTableProducts
    {
        static DataTable dataTableProducts;
        public static void AddColumns()
        {
            dataTableProducts = new DataTable();
            dataTableProducts.Columns.Add("Code", typeof(string));
            dataTableProducts.Columns.Add("Name", typeof(string));
            dataTableProducts.Columns.Add("Price", typeof(string));
            dataTableProducts.Columns.Add("Date", typeof(string));
            dataTableProducts.Columns.Add("Category", typeof(string));
        }
        public static DataTable AddRows()
        {
            AddColumns();
            DataRow dataRow1;
            dataRow1 = dataTableProducts.NewRow();
            dataRow1["Code"] = "SEM42015";
            dataRow1["Name"] = "Experia M4 Aqua";
            dataRow1["Price"] = "6,490,000";
            dataRow1["Date"] = "01/06/2015";
            dataRow1["Category"] = "Sony";
            dataTableProducts.Rows.Add(dataRow1);

            DataRow dataRow2;
            dataRow2 = dataTableProducts.NewRow();
            dataRow2["Code"] = "SGS62015";
            dataRow2["Name"] = "SamSung Galaxy S6";
            dataRow2["Price"] = "16,590,000";
            dataRow2["Date"] = "01/06/2015";
            dataRow2["Category"] = "SamSung";
            dataTableProducts.Rows.Add(dataRow2);

            return dataTableProducts;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace Ledger_AutomationTesting.ExcelUtilities
{
    class ExcelLib
    {
        public DataTable ExcelToDataTable(string fileName)
        {
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml; HDR = YES;'", fileName);
            var dataTable = new DataTable();
            OleDbConnection con = new OleDbConnection(connectionString);
            string query = string.Format("SELECT * FROM [Sheet1$]");
            con.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
            adapter.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        List<DataCollection> dataCol = new List<DataCollection>();
        
        //This function populate the DataCollection class
        public void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            for(int row = 1; row <= table.Rows.Count; row++)
            {
                for(int col = 0; col<table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }
        }

        //This method can be directly use to read the data from Excel, just pass the row no and cloumn name Example (1, "UserName")
        public string ReadData(int RowNumer, string columnName)
        {
            try
            {
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == RowNumer
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public class DataCollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}

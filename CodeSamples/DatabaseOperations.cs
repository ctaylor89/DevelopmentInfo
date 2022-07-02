using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// Need to run script C:\Users\CraigsI7\Dropbox\_samples\TSQL\Northwind\NorthwindPractice.sql - to build stored procedures

namespace DevelopmentInfo.CodeSamples
{
    public class DatabaseOperations
    {
//        private const string CONNECT_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=northwind;
//                                            Integrated Security=false;User Id=sa;Password=Aztec45^;";
        
        string CONNECT_STRING = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;

        public void SelectEmployeeStoredProcedureNorthwind()
        {
            Console.WriteLine("Starting method: SelectEmployeeStoredProcedureNorthwind()");
            const int EMPLOYEE_ID = 7;

            using (var con = new SqlConnection(CONNECT_STRING))
            using (var cmd = new SqlCommand("ProcEmployeeDetails", con))  // Pass in the name of stored Proc and connection object
            {
                try
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", EMPLOYEE_ID));

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("FirstName: {0}, LastName: {1}, Title: {2}, HireDate: {3}",
                                dataReader["FirstName"], dataReader["LastName"], dataReader["Title"],
                                dataReader["HireDate"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred: {0}", ex);
                }
            }
        }
                
        /// <summary>
        /// Call store proc to get custormer order details for each customer specified.
        /// Demonstrates sending a list of params and an OUT param.
        /// Help from: http://www.codeproject.com/Articles/113458/TSQL-Passing-array-list-set-to-stored-procedure-MS
        /// </summary>
        public void GetCustomerOrdersByNamesNorthwind(IEnumerable<string> customerNames)
        {
            Console.WriteLine("\nStarting method: GetCustomerOrdersByNamesNorthwind()");

            using (var con = new SqlConnection(CONNECT_STRING))
            using (var cmd = new SqlCommand("GetCustomerOrdersByNames", con))  // Pass in the name of stored Proc and connection object
            {
                try
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    var inputCustomersTable = new DataTable();
                    inputCustomersTable.Columns.Add("CustomerNames", typeof(string));
                    customerNames.ToList<string>().ForEach(c => inputCustomersTable.Rows.Add(c));

                    cmd.Parameters.Add(new SqlParameter("@CustNames", inputCustomersTable));  // Pass in the name of the "Stored Proc Param" and table of params
                    //cmd.Parameters.AddWithValue("@CustNames", inputCustomersTable);         // Alternative  
                    
                    var rowCountParam = new SqlParameter("@RowCount", SqlDbType.Int);
                    rowCountParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(rowCountParam);
                    
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("CompanyName: {0}, OrderID: {1}, Quantity: {2:000}, UnitPrice: {3:00.00}",
                                dataReader["CompanyName"], dataReader["OrderID"], dataReader["Quantity"],
                                dataReader["UnitPrice"]);
                        }
                    }

                    // Display the out parameter here
                    Console.WriteLine("\nRowCount: {0}", rowCountParam.Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred: {0}", ex);
                }
            }
        }
    }
}

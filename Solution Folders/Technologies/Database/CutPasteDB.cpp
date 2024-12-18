// -- DB -- READ_MARK
"Articles_Links"
"Classes"
"Common_Operations"
"Command_Building"
"Connection_Strings"
"DataReader_Operations"
"DataSet_Operations"
"DataTable_Operations"
"DataView_Operations"
"Execute_Non_Querys"   	
"MYSQL_NOTES"
"SQL_Statements"
"SQLite"
"Ref_Notes"   // Holds random notes by reference
Stored Procedure Templates
"SQL_Notes"   // Holds random notes

"***********************************************"
"Articles_Links"
"***********************************************"
// Save, Delete, Search And Update Record Using SqlParameter Class in ADO.NET
http://www.c-sharpcorner.com/UploadFile/718fc8/save-delete-search-and-update-record-using-sqlparameter-cl/

"***********************************************"
"Common_Operations"
"***********************************************"
// Format time string to format used in mysql
string strCurTm = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
// Update a column in a row with a time value(formatted to a string)
string szUpdateCmd = "UPDATE TBL_SOMTHING SET LastDwnldTm = '" + strCurTm + "' WHERE SerialNum = '" + strVehSN + "'";

// Extract a DT value from a Database table(MySql)
DateTime dtStartTm = (DateTime)dt_Trips.Rows[i]["StartTime"];
string strTime = dtStartTm.ToString("yyyy-MM-dd hh:mm:ss");
// Update or add DT value to database with a string value

"***********************************************"
"DataTable_Operations"
"***********************************************"
// One way to create and populate a datatable
DataTable DataLabelTable = new DataTable();
DataLabelTable.Columns.Add("Speed");
DataLabelTable.Rows.Add(new object[1] {"60 MPH"});

// The following code adds an expression-based column that can be bound to. DTOP1
dataTable.Columns.Add(“EmployeeName”, typeof(string), “lastname + ‘ , ‘ + firstname”);

"***********************************************"
"DataView_Operations"
"***********************************************"
// Populate a DataView object using a DataTable
DataTable dt = new DataTable();

// Define the columns of the table.
dt.Columns.Add(new DataColumn("ColorTextField", typeof(String)));
dt.Columns.Add(new DataColumn("ColorValueField", typeof(String)));

// Populate the table with sample values.
dt.Rows.Add(CreateRow("White", "White", dt));
dt.Rows.Add(CreateRow("Silver", "Silver", dt));
dt.Rows.Add(CreateRow("Dark Gray", "DarkGray", dt));
dt.Rows.Add(CreateRow("Khaki", "Khaki", dt));
dt.Rows.Add(CreateRow("Dark Khaki", "DarkKhaki", dt));

// Create a DataView from the DataTable to act as the data source for the DropDownList control.
DataView dv = new DataView(dt)

// DataViewRowState Enumerations: Added, CurrentRows, Deleted, ModifiedOriginal, ModifiedCurrent, OriginalRows, Unchanged
DataViewRowState dvrs = DataViewRowState. ModifiedOriginal |
                     DataViewRowState.Deleted;
//Set Table, RowFilter, Sort and RowStateFilter separately
DataView vue = new DataView();
vue.Table = tbl;
vue.RowFilter = "Country = ' USA'";
vue.Sort = "City DESC";
vue.RowStateFilter = dvrs;
//Or set all properties at once via the DataView' s constructor
vue = new DataView(tbl, "Country = 'USA'", "City DESC", dvrs);

// Use the DataRowView class to examine data from a row
DataView vue = new DataView(tbl);
DataRowView row = vue[0];
Console. WriteLine(row["CompanyName"]);
// Access the CompanyName column in all rows in the DataView
foreach(DataRowView rowview in vue)
    Console.WriteLine(rowview["CompanyName"]) ;
// Or
DataRowView row;
for (int i = 0; i < vue.Count; i++)
{
    row = vue[i];
    Console. WriteLine(row["CompanyName"] ) ;
}

// Use the Find method to search based on the column. Returns one index even if there are multiple matches
vue.Sort = "ContactName";
int intIndex = vue.Find("Fran Wilson") ;
if (intIndex == -1)
    Console.WriteLine("Row not found! ") ;
else
    Console.WriteLine(vue[intIndex]["CompanyName"] ) ;   

// Use the FindRows method to return an array of multiple matches    
vue.Sort = "Country";
DataRowView[] aRows = vue.FindRows("Spain") ;
if (aRows.Length == 0)
    Console.WriteLine("No rows found! ") ;
else
    foreach(DataRowView row in aRows)
        Console. WriteLine(row["City"] ) ;
"***********************************************"
"DataSet_Operations"
"***********************************************"
using System.Data.Odbc;
// Example #1 Open a db connection and fill a dataset
DataSet dsVehSettings = new DataSet("dsVehSettings");
string szVehQuery = "SELECT * FROM TBL_VEH_SETTINGS WHERE VehName = '" + szSelName + "'";

// Build connection string to open DB in server MySQL. 
string MyConString = "DRIVER={MySQL ODBC 3.51 Driver};SERVER=localhost;" +
   "DATABASE=DB_RS2100;USER=" + szLoggedInName + ";PASSWORD=" + szLoggedInPwd + ";OPTION=3"; 

// DRIVER={MySQL ODBC 3.51 Driver};SERVER=localhost;DATABASE=DB_RS2100;USER=NotLogged;PASSWORD=NotLog4596;OPTION=3;    
// SELECT VehName, SerialNum, Odom, ClassName, LastDist, DwnldStatus, FwStatus FROM tbl_veh_settings t;
OdbcConnection DBConn = new OdbcConnection(MyConString);      
OdbcDataAdapter daVehQuery = new OdbcDataAdapter(szVehQuery, DBConn);
      
// Fill the dataset with all fields for the selected vehicle.
try{daVehQuery.Fill(dsVehSettings, "TBL_VEH_SETTINGS");}
catch(Exception ex){}

// Example #2  Iterate through a table in a DataSet to get field values
if(dsVehSettings.Tables["TBL_VEH_SETTINGS"].Rows.Count > 0)
{
   szVehName = dsVehSettings.Tables["TBL_VEH_SETTINGS"].Rows[0]["VehName"].ToString();
   // DateTime field from db 
   strLogDt = dsItems.Tables[0].Rows[i]["OccurTm"].ToString();
   DateTime dtLogTm = DateTime.Parse(strLogDt);
   // Integer field from db
   string strMsgCode = dsItems.Tables[0].Rows[i]["MsgCode"].ToString();
   bool bParsed = Int32.TryParse(strMsgCode, out nMsgCode);
   if(!bParsed)
      nMsgCode = 0;
}
	
// Example #3  Get the data type used in a column
DataColumn colGetType = new DataColumn();
colGetType.DataType = dsVehTrend.Tables["tbl_Trips"].Columns["Idle_Tm"].DataType;
// Get the name of the data type used in a column. Result = "System.Int16"
string strTypeName = dsTrips.Tables["tbl_Trips"].Columns["Idle_Tm"].DataType.ToString();      

// Fill a dataset with a table schema via the DataAdapter.
try{daVehQuery.FillSchema(dsVehClass, SchemaType.Mapped, "TBL_VEH_CONN_CLASSES");}

"***********************************************"
"**** Execute_Non_Querys ******"   	
"***********************************************"      
// Update a column in a row. All the code is here 
string MyConString = "DRIVER={MySQL ODBC 3.51 Driver};SERVER=localhost;" +
   "DATABASE=DB_RS2100;USER=" + UserName + ";PASSWORD=" + UserPwd + ";OPTION=3";
OdbcConnection DBConn = new OdbcConnection(MyConString);
DBConn.Open();
string szUpdateCmd = "UPDATE TBL_VEH_SETTINGS SET DwnldStatus = '" + ErrorType.ToString() + "' WHERE SerialNum = '" + strVehSN + "'";
OdbcCommand UpdateCmd = new OdbcCommand(szUpdateCmd, DBConn);

try{ UpdateCmd.ExecuteNonQuery(); }
catch(Exception e){}
finally
{
   DBConn.Close();
}

// Update two columns in a row with an int value and a time value(formatted to a string)
string strCurTm = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
string szUpdateCmd = "UPDATE TBL_VEH_SETTINGS SET DwnldStatus = '" + ErrorType.ToString() + "',LastDwnldTm = '" + strDwnLdTm + "' WHERE SerialNum = '" + strVehSN + "'";

// Delete a column
UpdateCmd = new OdbcCommand("DELETE FROM MYSQL.USER WHERE User = 'Dog1'", DBConn);
try{UpdateCmd.ExecuteNonQuery();} catch(Exception ex){}

// Change user password in user table
string szUpdateCmd = "UPDATE user SET password = PASSWORD('" + szNewPassword + "') WHERE User = '" + szName + "'";
OdbcCommand UpdateCmd = new OdbcCommand(szUpdateCmd, DBConn);
try{UpdateCmd.ExecuteNonQuery();}

Cmd = new OdbcCommand("OPTIMIZE TABLE TBL_DRIVERS", DBConn);
try{Cmd.ExecuteNonQuery();}

"***********************************************"      
"**** Classes ****"
"***********************************************"        
// Pass in a connection string to the constructor
OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder(ConStrSet.ConnectionString);
// Alter some of the parameters
builder["USER"] = Name;
builder["PASSWORD"] = Password;
builder["DATABASE"] = "mysql";
builder["Server"] = txtBoxIPAddress.Text;
DBConn = new OdbcConnection(builder.ConnectionString);
// In the config file it looks like this
<connectionStrings>
  <add name="DB_RS2100" connectionString="Driver={MySQL ODBC 3.51 Driver};Server=127.0.0.1;DATABASE=DB_RS2100;OPTION=3" />
</connectionStrings>
"***********************************************"      
"**** Command_Building ****"
"***********************************************"      
// From EditTripsTbl() class1.cs
daTripQuery.UpdateCommand = DBConn.CreateCommand();
daTripQuery.UpdateCommand.CommandText = "Update tbl_Trips SET Distance = ? WHERE TripNum = ?";
daTripQuery.UpdateCommand.Parameters.Add("Distance", OdbcType.Double, 2, "Distance");
daTripQuery.UpdateCommand.Parameters.Add("TripNum", OdbcType.Int, 2, "TripNum");
try { daTripQuery.Fill(m_dsEditTripsTable, "tbl_Trips"); }

"***********************************************"
"Connection_Strings"
"***********************************************"
// Connection string properties for SqlConnection
http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring.aspx
// SQL Server 2012 connection strings
http://www.connectionstrings.com/sql-server-2012/
using System.Data.Common;
using System.Data.SqlClient; // .NET Framework Data Provider for SQL Server

// To open Sql Express on local machine
Server = .\SQLExpress; AttachDbFilename = | DataDirectory | mydbfile.mdf; Database = dbname;
Trusted_Connection = Yes;

@"Data Source=.\SQLEXPRESS;Initial Catalog=ZEDS;User Id=sa;Password=!Password1;"
// This was generated by Server Explorer in Visual Studio 2010
@"Data Source=CTAYLORDT2\SQLEXPRESS;Initial Catalog=ZEDS;User ID=sa;Password=***********
// Beginning in .NET Framework 4.5, you can also connect to a LocalDB database as follows:
server=(localdb)\\myInstance

// Addional Properties
Integrated Security -or- Trusted_Connection
When false, User ID and Password are specified in the connection. When true Windows Authentication is being used.
Recognized values are true, false, yes, no, and sspi (strongly recommended), which is equivalent to true. SSPI stands for Security Support Provider Interface.

"***********************************************"
"DataReader_Operations"
"***********************************************"
OdbcDataReader reader = null;
string szVehQuery = "SELECT LastDwnLdTm FROM TBL_VEH_SETTINGS WHERE SerialNum = '21003445'";
OdbcCommand command = new OdbcCommand(szVehQuery, DBConn);
DBConn.Open();
// Read all the results(rows)
reader = command.ExecuteReader();
            
if (reader.HasRows)
{
   reader.Read(); // Read a row at a time from result set
   szLastDwnLdTm = reader.GetString(0);
}
reader.Close();

"***********************************************"
"**** SQL_Statements ******"   	
"***********************************************"
// Update a column value to NULL
UPDATE db_rs2100.tbl_veh_settings SET DwnldStatus = NULL where SerialNum='23000000';

// Delete a row based on the field "ClassName"
DELETE FROM db_rs2100.tbl_veh_classes where ClassName="CamrySilver";
// Delete all rows in a table
DELETE FROM db_rs2100.tbl_trips;

// Here is better where clause to "take records that are more than a month old"
WHERE last_modified < NOW() - INTERVAL 1 MONTH 
// or
WHERE last_modified < CURDATE() - INTERVAL 1 MONTH

// ODBC 3.51 Local database:
"DRIVER={MySQL ODBC 3.51 Driver};SERVER=localhost;DATABASE=myDatabase;USER=myUsername;PASSWORD=myPassword;OPTION=3;" 
// ODBC 3.51 Remote database:
"DRIVER={MySQL ODBC 3.51 Driver};SERVER=data.domain.com;PORT=3306;DATABASE=myDatabase;USER=myUsername;PASSWORD=myPassword;OPTION=3;"

// Example of inserting data without dataset. Insert a null value for an auto increment column
INSERT INTO user_table VALUES('localhost','monty',PASSWORD('some_pass'),'Y','Y','Y');
// Two columns are inserted into a new row. All other columns are NULL
INSERT INTO user_table (col1, col5) VALUES('localhost','Y');

// Insert into table specific columns from another table based on a condition
INSERT INTO TABLE2 (<column_list>) SELECT <column_list> FROM TABLE1 WHERE COL1 = 'A';
// Copy one table to another as long as there are no identity columns
INSERT INTO Table2 SELECT * FROM Table1 WHERE [Conditions];
// Insert into table a single value
INSERT INTO VEHICLE_LOOKUP (VehicleIdentifierKey) VALUES('8F043018-ADE9-E211-AC62-005056AF0048');

INSERT INTO Driver_LookUp VALUES(NULL, "C6000000EAD40F08", "36AD13E1-F1DC-E211-AC62-005056AF0048", "2013-07-11");

// Updates columns in existing table rows with new values. SET clause indicates columns to modify
// and values they should be given. WHERE clause, if given, specifies which rows should be updated.
UPDATE db_rs2100.tbl_veh_settings SET LastDwnLdTm = "2007-07-11 00:00:00" WHERE VehName = "Pilot";
UPDATE db_rs2100.tbl_drivers SET LName = 'O\'Hara' WHERE RefNum ='000052';

SELECT VehName, SerialNum, LastDwnLdTm FROM db_rs2100.tbl_veh_settings t;
SELECT DISTINCT SerialNum FROM TBL_TRIPS order by SerialNum;

SELECT SerialNum, VehName FROM tbl_trips where VehName IS NULL;
SELECT SerialNum, VehName FROM tbl_trips where VehName IS NOT NULL;

// *** Drivers table ***
SELECT * FROM tbl_drivers order by LName;
SELECT * FROM tbl_Drivers Drvs WHERE (Drvs.LName = 'Hocking' AND Drvs.FName = 'Bryan')
SELECT * FROM tbl_deleted_drivers;
// *** Trips table ***
// Query by date/time
SELECT * FROM db_rs2100.tbl_trips where StartTime = '2007-11-20 09:11:09'; // Exact tm
SELECT * FROM db_rs2100.tbl_trips t where t.StartTime BETWEEN '2006-9-1' AND '2008-2-2'; // Include end points
SELECT * FROM db_rs2100.tbl_trips t where t.StartTime > '2007-9-1';
SELECT * FROM tbl_trips where StartTime like '2009-04-06%'; // All rows this day
// Get the sum
SELECT SUM(Distance) FROM tbl_trips t where SerialNum = '';
SELECT SUM(Run_Tm) Runtime FROM db_rs2100.tbl_trips t WHERE t.EmployeeNum = '9906' 
  AND (t.StartTime BETWEEN '2006-9-1' AND '2008-2-2') AND t.Distance >= 0 ORDER BY t.StartTime;
SELECT SUM(Distance) * 0.6214 Total_Dist FROM tbl_trips t where t.SerialNum = '';

// Get the Max distance value *Also MIN
SELECT MAX(Distance) FROM tbl_trips;

// Calculate the total distance for each employee
SELECT EmployeeNum, SUM(Distance) TotalDistance FROM tbl_trips t GROUP BY EmployeeNum;

// Calculate the average distance for each employee
SELECT EmployeeNum, AVG(Distance) AverageDistance FROM tbl_trips t GROUP BY EmployeeNum;
// Calculate the average distance for each employee who's total distance is > 790
SELECT EmployeeNum, AVG(Distance) AverageDistance FROM tbl_trips t GROUP BY EmployeeNum 
  HAVING SUM(Distance) > 790.0;

// Get the number of trips for employee 0
SELECT COUNT(EmployeeNum) "Total Count" FROM tbl_trips WHERE EmployeeNum = '0';
// Get the number of trips for each employee where the distance is > 5
SELECT EmployeeNum, COUNT(*) TripCount FROM tbl_trips WHERE Distance > 5.0 
  GROUP BY EmployeeNum;
// Get the number of rows in employees table
SELECT Count(*) FROM employees;
// Get the number of values in this column that are not null
SELECT Count(ColName) FROM employees;
// Returns the number of distinct values in the specified column
SELECT COUNT(DISTINCT column_name) FROM table_name
// Restart auto increment column after deleting all data in table
ALTER TABLE tbl_trips AUTO_INCREMENT = 0;
// Empty table completely and restart any auto increment columns.
TRUNCATE TABLE tbl_name;

// Remove a column
ALTER TABLE db_rs2100.TBL_VEH_CLASSES DROP COLUMN GPS_ON
// Add a column
ALTER TABLE db_rs2100.tbl_veh_classes ADD COLUMN RF_ON TINYINT(0);
Update db_rs2100.tbl_veh_classes Set RF_ON = '0' WHERE name = 'Chevy2';
// OR
ALTER TABLE db_rs2100.tbl_veh_classes ADD COLUMN RF_ON TINYINT DEFAULT 0;
// Add a column with a default value that contains a string
ALTER TABLE tbl_veh_settings ADD COLUMN LastDriver char(12) DEFAULT '0';
// Add a column setting with a default value
ALTER TABLE tbl_veh_classes ADD COLUMN RF_SAFE TINYINT DEFAULT 0
// Add a column with a default value and field length of 2(50 will be displayed)
ALTER TABLE tbl_veh ADD COLUMN RF_SAFE MEDIUMINT(2) DEFAULT 500
// Change data type of a column
ALTER TABLE tbl_trips CHANGE Idle_Tm Idle_Tm MEDIUMINT;
// Rename a column and optionaly change the data type
ALTER TABLE tbl_veh_classes CHANGE GPS_ON OPTIONS TINYINT(0);

DROP TABLE IF EXISTS db_rs2100.tbl_logmsgs;

// Get the name of all columns in a table
SHOW COLUMNS FROM TBL_VEH_CLASSES;

// UNION is used to combine the result from many SELECT statements into one result set.
SELECT ...
UNION [ALL | DISTINCT] // DISTINCT is the default
SELECT ...
  [UNION [ALL | DISTINCT]
   SELECT ...]

// 
SELECT p.LastName, p.FirstName, o.OrderNo
FROM Persons p JOIN Orders o
WHERE p.P_Id = o.P_Id
 
// Execute a stored procedure
EXEC or EXECUTE


"***********************************************"
"**** MYSQL_NOTES ******"   	
"***********************************************"
A user cannot create new users with the GRANT statement unless the user has the INSERT privilege for 
the mysql.user table. If you want a user to have the ability to create new users with those privileges 
that the user has right to grant, you should grant the user the following privilege: 
mysql> GRANT INSERT(user) ON mysql.user TO 'user'
You can do it a couple of ways:

// Start the cmd line tool
mysql --user=NotLogged --password=NotLog4596 db_rs2100
mysql> DELETE FROM db_rs2100.tbl_Trips WHERE SerialNum = '20015579' AND StartTime = '2008-06-19 08:54:25';
mysql>\q

// Two ways to run a script file
1) mysql -u<your user name> -p<yourpassword> Databasename < scriptfile.txt
2)From the mysql prompt: Mysql> \. Scriptfile.sql

// To fix the permissions for the supervisor level
// This will need to be run after every time a supervisor is added until we get an updated software version sent to you.
// On the Database Server go to the RoadSafety\RS-2100\mysql\bin directory. Type and execute the following except replace 
// XXXXX with your user name and password:

mysql --user=XXXXX --password=XXXXX mysql

// The prompt 'mysql>' should appear, then at this prompt type and execute these three lines 
mysql> UPDATE mysql.`user` SET Delete_priv = 'Y', Insert_priv = 'Y', Update_priv = 'Y' WHERE Create_priv = 'Y';
mysql> FLUSH PRIVILEGES; 
mysql>\q

"***********************************************"
"**** Ref_Notes ****"
"***********************************************"
// DTOP1 It does not need to be flled explicitly. The values for all the cells in the column are 
// calculated and cached when the column is added to the table.

"***********************************************"
"**** SQLite ****"
"***********************************************"
// Main site
http://www.sqlite.org/sitemap.html

// Writing parameterized queries in SQLite
http://sqlite.phxsoftware.com/forums/t/83.aspx

// Transactions  See example below
http://zetcode.com/db/sqlitecsharp/trans/

// Views, triggers, transactions
http://zetcode.com/db/sqlite/viewstriggerstransactions/

// To run console manager put sqlite.exe into the same directory as the *.db file.
Use 'sqlite.exe mydatabase.db' to start.
Use .exit to quit.
End each sql query with a ';'.
// View all schemas or list all tables
.schema  .tables
// Check if table exists
"SELECT * FROM sqlite_master WHERE name = 'DRIVE_RECORDS' and type = 'table';"
// Check if a record exists
"IF EXISTS(SELECT * FROM mytable WHERE Id = @id;"
// Get names of columns in table
PRAGMA table_info(tablename);

// Example: Create a table if it does not exist using parameters.
using (var factory = new System.Data.SQLite.SQLiteFactory())
using (DbConnection dbConn = factory.CreateConnection())
{
   try
   {
      dbConn.ConnectionString = driveRecordsConnectString;
      dbConn.Open();
      log.Debug("Connection opened to local database");
   }
   catch (Exception ex){}
            
   using (DbCommand cmd = dbConn.CreateCommand())
   {
      cmd.CommandText = @"CREATE TABLE IF NOT EXISTS DRIVE_RECORDS (
                        RecordID integer primary key,
                        EventTime DATETIME,
                        VehicleID TEXT,
                        Speed INTEGER)";
      try
      {
         cmd.ExecuteNonQuery();
      }
      catch (Exception ex){}

      cmd.CommandText = @"INSERT INTO DRIVE_RECORDS (RecordID, EventTime, VehicleID, DriverID, Speed, HiOverSpeed,
               LowOverSpeed, LowOverSpeedWarning, Rpm, XForce, YForce, ExtremeOverForce, HiOverForce, LowOverForce, 
               OverForceWarning, Event1, Event2, Event3, Event4, Event5, Event6, Event7, Event8, Inputs, 
               Spotter, SeatBelt, Odometer, SettingsReference, RecordCompleted) 
               VALUES(@RecordID, @EventTime, @VehicleID, @DriverID, @Speed, @HiOverSpeed, @LowOverSpeed, 
               @LowOverSpeedWarning, @Rpm, @XForce, @YForce, @ExtremeOverForce, @HiOverForce, @LowOverForce, 
               @OverForceWarning, @Event1, @Event2, @Event3, @Event4, @Event5, @Event6, @Event7, @Event8,
               @Inputs, @Spotter, @SeatBelt, @Odometer, @SettingsReference, @RecordCompleted)";

      var param1 = cmd.CreateParameter();
      param1.ParameterName = "@RecordID";
      param1.Value = null;
      cmd.Parameters.Add(param1);

      var param2 = cmd.CreateParameter();
      param2.ParameterName = "@EventTime";
      param2.Value = secondRecord.EventTime; // .ToString("YYYY-MM-dd hh:mm:ss"); 
      cmd.Parameters.Add(param2);

      var param3 = cmd.CreateParameter();
      param3.ParameterName = "@VehicleID";
      param3.Value = secondRecord.VehicleID;
      cmd.Parameters.Add(param3);

      var param5 = cmd.CreateParameter();
      param5.ParameterName = "@Speed";
      param5.Value = secondRecord.Speed;
      cmd.Parameters.Add(param5);

      try
      {
         cmd.ExecuteNonQuery();
      }
      catch (Exception ex){}
   }
}

// Example: Get the downloaded file from the local database table
var downloadData = new DownloadData();
using (var factory = new System.Data.SQLite.SQLiteFactory())
using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
{
   try
   {
      dbConn.ConnectionString = connectString;
      dbConn.Open();
   }
   catch (Exception ex){}
   using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
   {
      var cmdText = new StringBuilder();
      cmdText.Append(@"SELECT ID, InsertionTime, FileName, FileData FROM RS3000_FILES WHERE FileName='");
      cmdText.Append(fileName);
      cmdText.Append("';");
      cmd.CommandText = cmdText.ToString();

      try
      {
         using (System.Data.Common.DbDataReader reader = cmd.ExecuteReader())
         {
            reader.Read();
            long id = reader.GetInt64(0);
            downloadData.DownloadTime = reader.GetDateTime(1);
            downloadData.FileName = reader.GetString(2);

            // Get the download file bytes
            int dataCount = (int)reader.GetBytes(3, 0, null, 0, int.MaxValue);
            byte[] dataBuffer = new byte[dataCount];
            long count = reader.GetBytes(3, 0, dataBuffer, 0, dataCount);
            downloadData.FileData = dataBuffer;
         }
      }
      catch (Exception ex){}
   }
}

// Example: Check if a record exists in a table using a parameter
private bool FileAlreadyInDatabase(string fileName)
{
   using (var factory = new System.Data.SQLite.SQLiteFactory())
   using (DbConnection dbConn = factory.CreateConnection())
   {
      try
      {
         dbConn.ConnectionString = connectString;
         dbConn.Open();

         using (DbCommand cmd = dbConn.CreateCommand())
         {
            cmd.CommandText = @"IF EXISTS(SELECT FileName FROM RS3000_FILES WHERE FileName = @FileName)";            
                  
            var param1 = cmd.CreateParameter();
            param1.ParameterName = "@FileName";
            param1.Value = fileName;
            cmd.Parameters.Add(param1);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
               if(!reader.Read())
                  return false;
               else
                  return true;
            }
         }
      }
      catch(Exception ex){}
   }
}

// Example: Adding records in a transaction
using(SQLiteConnection connection = new SQLiteConnection(driveRecordsConnectString))
{
   try
   {
      connection.Open();
   }
   catch (Exception ex)
   {
      log.FatalFormat("Failed to open DriveRecords table to add a new record: {0}", ex.ToString());
      return false;
   }

   using (SQLiteTransaction trans = connection.BeginTransaction())
   {
      foreach (var second in parsedSeconds)
      {
         InsertDriveRecordIntoDb(second, connection);
      }
         
      trans.Commit();
   }
}

"***********************************************"
"**** SQL_Notes ****"
"***********************************************"
JOIN - Returns rows when there is atleast one match in both tables.
LEFT JOIN - Returns all rows from the left table even if there is no match in the right table
RIGHT JOIN - Returns all rows from the right table even if there is no match in the left table
FULL JOIN - Returns rows when there is a match in one of the tables.
OUTER JOIN - Returns all rows from both left and right tables. Null values are assigned to 
             fields that have no matching value.

"***********************************************"
"**** ADO notes and examples******"   	
"***********************************************"
// Example of updating a column using the dataset.
OdbcDataAdapter da1 = new OdbcDataAdapter("SELECT * FROM tbl_Users",DBConn);
OdbcCommandBuilder cb = new OdbcCommandBuilder(da1);

// Create the DataSet object
DataSet ds1 = new DataSet();
da1.Fill(ds1);

// Get the number of rows in dsUser.tbl_Users.
int nUserRowCnt = ds1.Tables[0].Rows.Count;      
for(int i = 0; i < nUserRowCnt; i++)
{
   szNameResult = ds1.Tables[0].Rows[i]["UserName"].ToString();               
   // If requested add name matches name already in database.
   if(szName == szNameResult)
   {      
      ds1.Tables[0].Rows[i]["Password"] = szNewPassword;
      // Add changes to table in database 
      DataTable tblUsers = ds1.Tables[0].GetChanges(DataRowState.Modified);
      da1.Update(tblUsers);
   }
}

// ***********************************************
// Dataset commands
// ***********************************************
// Test contents
string szException = dsDrvTrend.GetXml();

// Check for table then check for rows existing.
if(ds1.Tables != null)
   nDrvRowCnt = ds1.Tables[0].Rows.Count;

private void EditGrid(DataGrid myGrid)
{
   // Get the selected row and column through the CurrentCell.
   int colNum;
   int rowNum;
   colNum = dataGrid1.CurrentCell.ColumnNumber;
   rowNum = dataGrid1.CurrentCell.RowNumber;
   // Get the selected DataGridColumnStyle.
   DataGridColumnStyle dgCol;
   dgCol = dataGrid1.TableStyles[0].GridColumnStyles[colNum];
   // Invoke the BeginEdit method to see if editing can begin.
   if (dataGrid1.BeginEdit(dgCol, rowNum)){
       // Edit row value. Get the DataTable and selected row.
       DataTable myTable;
       DataRow myRow;
       // Assuming the DataGrid is bound to a DataTable.
       myTable = (DataTable) dataGrid1.DataSource;
       myRow = myTable.Rows[rowNum];
       // Invoke the Row object's BeginEdit method.
       myRow.BeginEdit();
       myRow[colNum] = "New Value";
       // You must accept changes on both DataRow and DataTable.
       myRow.AcceptChanges();
       myTable.AcceptChanges();
       dataGrid1.EndEdit(dgCol, rowNum, false);
   }
   else
      Console.WriteLine("BeginEdit failed");
}
 
// Manually building an update cmd instead of using CommandBuilder
OdbcDataAdapter daTripQuery = new OdbcDataAdapter(szTripsQuery, DBConn);  
daTripQuery.UpdateCommand = DBConn.CreateCommand();
string cmd = "Update tbl_Trips SET EmployeeNum = ?, SerialNum = ?, Distance = ? WHERE EmployeeNum = 'Dog'";
daTripQuery.UpdateCommand.CommandText = cmd;
daTripQuery.UpdateCommand.Parameters.Add("EmployeeNum", OdbcType.Char, 12, "EmployeeNum");
daTripQuery.UpdateCommand.Parameters.Add("SerialNum", OdbcType.Char, 8, "SerialNum");
daTripQuery.UpdateCommand.Parameters.Add("Distance", OdbcType.Double, 5, "Distance");
try{daTripQuery.Fill(m_dsEditTripsTable, "tbl_Trips");}

// ***********************************************
// Notes
// ***********************************************  
13.5.5.3. KILL Syntax
KILL [CONNECTION | QUERY] thread_id
Each connection to mysqld runs in a separate thread. You can see which threads are running 
with the SHOW PROCESSLIST statement and kill a thread with the KILL thread_id statement. 

As of MySQL 5.0.0, KILL allows the optional CONNECTION or QUERY modifiers: 

KILL CONNECTION is the same as KILL with no modifier: It terminates the connection associated 
with the given thread_id. 

KILL QUERY terminates the statement that the connection currently is executing, but leaves 
the connection intact. 

If you have the PROCESS privilege, you can see all threads. If you have the SUPER privilege, 
you can kill all threads and statements. Otherwise, you can see and kill only your own threads 
and statements. 

You can also use the mysqladmin processlist and mysqladmin kill commands to examine and kill threads. 

// **********************************************
// To fix the permissions for the supervisor level
// **********************************************
This will need to be run after each time a supervisor is added until we get an updated software 
version sent to you. On the Database Server go to the RoadSafety\RS-2100\mysql\bin directory. Type 
and execute the following except replace XXXXX with your user name and password:

mysql --user=XXXXX --password=XXXXX mysql

// The prompt 'mysql>' should appear, then at this prompt type and execute this command: 
mysql> UPDATE mysql.`user` SET Delete_priv = 'Y', Insert_priv = 'Y', Update_priv = 'Y' WHERE Create_priv = 'Y';
mysql> FLUSH PRIVILEGES;
// Quit the command line tool:
mysql>\q

//********************************************  
// Temp area
//********************************************
// Reset db cmds
SELECT ClassName, OvrSpeed FROM db_rs2100.tbl_veh_classes t where t.ClassName like 'DLC/NO DRIVER ID/TON';
SELECT VehName, LastDwnldTm, DwnldStatus FROM db_rs2100.tbl_veh_settings t where t.VehName like 'Toyota-Grey';
UPDATE db_rs2100.tbl_veh_settings t SET LastDwnLdTm = '1969-12-31 17:00:00' where t.SerialNum='21002638'

SELECT * FROM db_rs2100.tbl_veh_classes t;
ALTER TABLE db_rs2100.tbl_trips CHANGE ExcIdle_Tm ExcIdle_Tm SMALLINT;
ALTER TABLE db_rs2100.tbl_trips CHANGE Idle_Tm Idle_Tm SMALLINT;
ALTER TABLE tbl_Trips DROP COLUMN SerialNum;
ALTER TABLE tbl_Trips ADD COLUMN VehName char(20);

SELECT TripNum, Idle_Tm, ExcIdle_Tm FROM db_rs2100.tbl_trips t;

SELECT VehName, SerialNum, odom, LastDwnLdTm, DwnldStatus FROM db_rs2100.tbl_veh_settings t;
UPDATE db_rs2100.tbl_veh_settings t SET DwnldStatus = NULL where SerialNum='23000000';

UPDATE db_rs2100.tbl_veh_settings t SET LastDwnLdTm = '1969-12-31 17:00:00' where t.SerialNum='21002608'OR t.SerialNum='00987654'OR t.SerialNum='09876543';

// Reset Test Vehicle
UPDATE db_rs2100.tbl_veh_settings t SET LastDwnLdTm = '1969-12-31 17:00:00' where t.SerialNum='21002638'; 
UPDATE db_rs2100.tbl_veh_settings t SET DwnldStatus = '4' where t.SerialNum='21002638'
// Reset all Vehicles
UPDATE db_rs2100.tbl_veh_settings t SET LastDwnLdTm = '1969-12-31 17:00:00' 
UPDATE db_rs2100.tbl_veh_settings t SET DwnldStatus = '3'
UPDATE db_rs2100.tbl_veh_settings t SET t.LastDist='0', t.LastUnknDist='0';
UPDATE db_rs2100.tbl_veh_settings t SET LastDwnLdTm = '1969-12-31 17:00:00', DwnldStatus = '3', LastDist='0', LastUnknDist='0'; 

// Delete one record from tbl_Trips
DELETE FROM db_rs2100.tbl_Trips WHERE SerialNum = '20015579' AND StartTime = '2008-06-19 08:54:25';

192.168.1.132

DROP TABLE IF EXISTS db_rs2100.tbl_logmsgs;

CREATE TABLE  db_rs2100.tbl_logmsgs (
  Machine_Src varchar(30) NOT NULL,, 
  MsgCode varchar(7) NOT NULL,
  OccurTm datetime NOT NULL,
  Message varchar(45) NOT NULL,
  ValName1 varchar(25) NOT NULL,
  Value1 varchar(15) NOT NULL,
  ValName2 varchar(25) NOT NULL,
  Value2 varchar(15) NOT NULL,
  Ref int(7) unsigned NOT NULL auto_increment,
  PRIMARY KEY  (Ref)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 ROW_FORMAT=FIXED;

<connection connectionString="Provider=SQLNCLI;Server=dbis0001\zoll2008r2;Database=ZEDSTarget;UID=sa;PWD=d@rk5t@r;" name="SecurityDB"/>

//********************************************  
// Tutorials
//********************************************
// Foreign Key example. Invoices table references Supplier table
CREATE TABLE Supplier (
   SupplierNumber  INTEGER NOT NULL,
   Name            VARCHAR(20) NOT NULL,
   Address         VARCHAR(50) NOT NULL,
   TYPE            VARCHAR(10),
   CONSTRAINT supplier_pk PRIMARY KEY(SupplierNumber),
   CONSTRAINT number_value CHECK (SupplierNumber > 0) )
 
CREATE TABLE Invoices (
   InvoiceNumber   INTEGER NOT NULL,
   SupplierNumber  INTEGER NOT NULL,
   Text            VARCHAR(4096),
   CONSTRAINT invoice_pk PRIMARY KEY(InvoiceNumber),
   CONSTRAINT inumber_value CHECK (InvoiceNumber > 0),
   CONSTRAINT supplier_fk FOREIGN KEY(SupplierNumber)
      REFERENCES Supplier(SupplierNumber)
      ON UPDATE CASCADE ON DELETE RESTRICT ) // Referential Actions. Could also NO ACTION, SET NULL, SET DEFAULT
   }

//Temp stuff
<add name="TestConnectionString" connectionString="Data Source=.\SQLEXPRESS; Initial Catalog=EF6Test; User Id=sa;Password=!Password1;MultipleActiveResultSets=true;" providerName="System.Data.SqlClient" />

--------------------------------------------------
Stored Procedure Templates

IF OBJECT_ID('dbo.Get', 'P') IS NOT NULL
DROP PROC dbo.Get;
GO

------------------------------------
--Get Template
------------------------------------
IF OBJECT_ID('dbo.Get', 'P') IS NOT NULL
DROP PROC dbo.Get;
GO

CREATE PROCEDURE dbo.Get
@Key uniqueidentifier
AS
BEGIN
SET NOCOUNT ON;
SELECT
FROM dbo.WITH(NOLOCK)
WHERE Key = @Key;
END;
GO

------------------------------------
--Save Template
------------------------------------
IF OBJECT_ID('dbo.Save', 'P') IS NOT NULL
DROP PROC dbo.Save;
GO

CREATE PROCEDURE dbo.Save
@
AS
BEGIN
DECLARE @SearchKeyCount int;
SELECT @SearchKeyCount = COUNT(Key) FROM dbo.WHERE Key = @Key;

IF(@SearchKeyCount = 0)
BEGIN
INSERT INTO dbo.
(

)
Values
(
@
);
END
ELSE
UPDATE dbo.SET


WHERE Key = @Key
END
GO

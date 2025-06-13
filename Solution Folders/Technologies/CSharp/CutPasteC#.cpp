// --- C# -----  READ_MARK
"Algorithms"   	
"Application_functions"
"Arrays"
"Attributes"
"C#_3.0"
"Collections_Generic"
"Configuration"
"Console_functions"
"Convertions_Data"   	
"DataGridView"
"DateTime_functions"
"Debugging"
"Delegates"
"Directory_functions"
"Drive_functions"
"Enumerations" 
"Environment_Class"   // System information - Common data dir, current user, operating system etc
"Extension_Methods"
"Exceptions"
"File_Operations"
"Form_functions"  "Sub_DataBinding"
"Frequent_Operations" 
"Interfaces"
"List_Box_functions"
"List_View_functions"
"Logging_Messages"
"Math_Code"
"Message_Boxes"
"Nullable_Types"
"Processes_Threads"
"Properties_Sample"   // set and get
"Random_functions"
// "String_Convertions"
"String_formating"
"String_functions"
"StringBuilder_functions"
"Threading"
"Utility_Tasks"
"XML_functions"
// READ_MARK
"***********************************************"
"**** Frequent_Operations ******"   	
"***********************************************"
// Autmatic property - default value must be set in contructor if one is desired.
public string LastName{get;set;}
public string LastName{get; private set;} // read only

public bool ParkState{get{return Park;}}
public bool {get{return ;}} // For copy\paste

   public bool boxOne
   {
      get { return BoxOne;}
      set { BoxOne = value;}
   }

CUtility Utility = new CUtility();
CUtility^ pcsUtility = gcnew CUtility();
// Pass a string value from C++
pcsUtility->OpenFileRead((gcnew String(csFilePath));

CLogMsg LogMsg = new CLogMsg();
LogMsg.LogMessage("G", "");
LogMsg.LogMessage("G", "", "", "");
LogMsg.LogMessage("G", "", "", "", "", "");
// Log msg w/No value
CLogMsg lm = new CLogMsg("G1", "");
// Log msg w/single value
CLogMsg lm = new CLogMsg("G1", "", "", ToString());
// Log msg w/single value
CLogMsg lm = new CLogMsg("G1", "", "", ToString());
// Log msg w/double value
CLogMsg lm = new CLogMsg("G1", "", "", ToString(), "", ToString());

// Set a region
#region
#endregion

// Access the C# dll component from C++ application (C++/cli)
#using "C:/Program Files/Road Safety/RS-2100/CSDBControl.dll"
CSqlDBAccess^ hndlDB = gcnew CSqlDBAccess();
CVehSettings^ pcsVehClass = gcnew CVehSettings();
delete pcsVehClass; // To call Dispose()

// Add arguments to a string in a console application
string ConfigFilePath = "";
if (args.Length > 0)
{
   for (int i = 0; i < args.Length; i++)
   {
      ConfigFilePath += args[i];
      if ((i + 1) < args.Length)
         ConfigFilePath += " ";
   }
}

"***********************************************"
"**** Form_functions ******"   	
"***********************************************"
// Launch a modal dialog
DBBackUpForm dbBackUpForm = new DBBackUpForm();                  
if(DBBackUpForm.ShowDialog() != DialogResult.OK)
    return 1;
// Add data binding to text box in the dlg constructor.
txtBoxTripNum.DataBindings.Add("Text", CSqlDBAccess.m_dsEditTripsTable, "TBL_TRIPS.TripNum");
// Close a form
this.Close();
// If a Windows Forms app, close application
Application.Exit();
Environment.Exit(-1);
// Process events
Application.DoEvents();
// To make the Ok button the default button
this.AcceptButton = buttonOK;
// To make a button active
btnOK.Select();
// Set focus to a text box.         
textBoxHour.Focus();
// Check if input textbox is empty
if (txtLat.Text == string.Empty){...};
// Make a form stay on top
this.TopMost = true;
// Display a Wait Cursor
this.Cursor = Cursors.WaitCursor;
this.Cursor = Cursors.Default;

// Convert a textbox input string to integer
bool ret = int.TryParse(txtPort.Text, out nOutResult);

// Set the color of text in a label
labelTagStatus.ForeColor = System.Drawing.Color.Crimson;

// Check for non-numeric char in textbox
foreach(char ch in txtBoxDist.Text)
{
   if(!Char.IsNumber(ch))
   {
      MessageBox.Show("You can only enter a numeric value.","Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      break;
   }   
}
// Or another way
try{nValue = Convert.ToInt32(szEntry);}
catch(System.FormatException ex)
{
   string szException = ex.ToString();
   MessageBox.Show("Invalid Entry. Must be numeric.","Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);         
   return false;
}

// Catch a hot key. Override ProcessCmdKey method
protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
   if (keyData.ToString() == "F2")
   {
      chkBoxVehicle.Checked = true;
      LBVehicles.Focus();
   }   
   else if (keyData.ToString() == "F4")   
   {
      txtBoxMinDist.Focus();
   }   
   return base.ProcessCmdKey(ref msg, keyData);
}

// // // List and combo boxes // // // 
"*** Sub_DataBinding ***"
// Bind a table and column to a combo box
comboBoxAddress.DataSource = tbl_ConnIDs;
comboBoxAddress.DisplayMember = "Column_VehP";

// Bind a table and columns to text boxes in form constructor
public EditTripsTblForm()
{
	InitializeComponent(); // Required for Windows Form Designer support
	txtBoxTripNum.DataBindings.Add("Text", dsEditTrips, "TBL_TRIPS.TripNum");
	txtBoxDrvRefNum.DataBindings.Add("Text", dsEditTrips, "TBL_TRIPS.EmployeeNum");
	txtBoxVehSerNum.DataBindings.Add("Text", dsEditTrips, "TBL_TRIPS.SerialNum");
}

// Implement Previous and next buttons for indexing through bound data
private void buttonPrev_Click(object sender, EventArgs e)
{
   int nCurPos = (this.BindingContext[dsVehInfo, "tbl_VehData"].Position - 1);
   if (nCurPos < 0)
      nCurPos = 0;

   this.BindingContext[dsVehInfo, "tbl_VehData"].Position = nCurPos;
}

private void buttonNext_Click(object sender, EventArgs e)
{
   int nCurPos = (this.BindingContext[dsVehInfo, "tbl_VehData"].Position + 1);
   this.BindingContext[dsVehInfo, "tbl_VehData"].Position = nCurPos;
}

// Add items to a ListBox
ListBoxFiles.Items.Add( dsFileList.Tables[0].Rows[i]["FileName"].ToString() );
// Get selected item from a ListBox
selectedFile = ListBoxFiles.SelectedItem.ToString();
// Get collection of currently selected items from a ListBox
selectedFile = ListBoxFiles.SelectedItems[i].ToString();
// Get count of currently selected items
int Cnt = ListBoxFiles.SelectedItems.Count;
// Clear only Selected Items
LBDrivers.ClearSelected();
// Clear all Items
LBDrivers.Items.Clear();
// Selected all Items in List Box
for(int i = 0; i < LBVehicles.Items.Count; i++)
   LBVehicles.SetSelected(i, true); // false will deselect item
// ***********************************************
//To Validate data input, use the Control.Validating event for each control. 
//The ErrorProvider gives feedback to the user in case something 
//happens. Assuming an ErrorProvider instance on your form called 
//errorProvider1 and a TextBox on your form called textBox1, the following 
//will validate that the user enters something before moving focus out of the control: 
void textBox1_Validating(object sender, CancelEventArgs e) 
{ 
  string  error = ""; 
  if(textBox1.Text.Length == 0 ) { 
    error = "Please enter something"; 
    e.Cancel = true; 
  } 
  errorProvider1.SetError(textBox1, error); 
}

// *** DateTmPicker control ***
// Set the value of the control with a string
FromDateTmPicker.Value = DateTime.Parse("08-31-2009");

//Two situations: 
//-Set your Cancel button's CausesValidation to false to prohibit the 
//Validating event when clicking on it or your user will have to enter 
//valid data to cancel your form. 
//-Controls only get Validating events when they lose focus, so only controls 
//that get focus can be validated in this way. If you'd like to 
//manually trigger validation on all controls in the OK button handler, you 
//can do so like this: 
//
//void okButton_Click(object sender, EventArgs e) 
//{ 
//  foreach( Control control in Controls ) { 
//    control.Focus(); 
//    if( !this.Validate() ) { 
//      this.DialogResult = DialogResult.None; // Assumes 
//    okButton.DialogResult = OK 
//      break; 
//  } 
// *********************************************** 

"***********************************************"
"**** Debugging ******"   	
"***********************************************"
Trace.Listeners.Add(new TextWriterTraceListener("CComPort.txt"));
Trace.AutoFlush = true;
Trace.WriteLine("Time Out: RecData  = " + strRecData);
Trace.WriteLine("Time Out: Value  = " + Value.ToString());
"***********************************************"
"**** Combo_Box_functions ******"   	
"***********************************************"
// Get the input from the text box of a combo box
string SelectedIP = comboBoxAddress.Text.ToString();
// Get the selection from a combo box when it has been bound to a datatable
string SelectedIP = ((DataRowView)comboBox1.SelectedValue).Row["VehicleIP"].ToString();
// Bind a combobox to a List<string>
cbDataBnd.DataSource = TheList; 

"***********************************************"
"**** C#_3.0 ******"   	
"***********************************************"
string[] names = { "Bill", "Jane", "Bob", "Frank" };
// Generic Type Inference - the 's' does not require a type designation. It is inferred.
IEnumerable<string> Bs = names.Where(s => s.StartsWith("B")); 

// Object and Collection Initializers
// Instead of doing this:
Person person = new Person(); 
person.Name = "Steve"; 
person.Age = 93; 
RegisterPerson(person); 
// Code in the curly braces is called an object initializer. 
RegisterPerson(new Person { Name = "Steve", Age = 93 }); 

// An annonymous object initialized
var newMonkey = new { Name = "Ted", Age = 98, Color = "blue" };

var countries = new List<string>(); 
countries.Add("England");
countries.Add("Ireland");
countries.Add("Scotland");
// Can now be reduced to this: 
var countries = new List<string> { "England", "Ireland", "Scotland" }; 
// Or for dictionaries
Dictionary<int, string> zipCodes = new Dictionary<int,string>{{90210, "Bell Hill"}, {73301, "Austin"}};

// Type inference
var what = DateTime.Now;
int day = what.Day;

// Delegate with parameters practice
// Declared: delegate int delGetNewNum(int val);
// delGetNewNum GNN = delegate(int n){int i = n*n; return i;};                           

// Annonymous type making use of object initializers and type inference.
var salesData = new { Day = new DateTime(2009, 01, 03), DollarValue = 353000 };
Console.WriteLine("In {0}, we sold {1:c}", salesData.Day, salesData.DollarValue); 

// Collection Initializers
// If you are writing your own collections and want them to work with collection initializer syntax, 
// they must implement the ICollection<T> interface and must all be of the same type.
var Jungle = new List<Animals>{new Tiger(), new Zebra(), new Alligator()};



"***********************************************"
"**** Interfaces ******"
"***********************************************"
// The interface IEmployee has a read-write property, Name, and a read-only property, Counter
interface IEmployee
{
	string Name
	{
		get;
		set;
	}

	int Counter
	{
		get;
	}
}


"***********************************************"
"**** List_Box_functions ******"   	
"***********************************************"
//Set the SelectedIndex to -1 so no items are selected.
// The new item will be set as the selected item when it is added.
DropDownList1.SelectedIndex = -1;
// Add the selected item to DropDownList1.
DropDownList1.Items.Add(ListBox1.SelectedItem);
// Delete the selected item from ListBox1.
ListBox1.Items.Remove(ListBox1.SelectedItem);
// Select first item in list
if(LBArchNames.Items.Count > 0)
   LBArchNames.SetSelected(0,true); // false unSelects
// Remove all items
LBArchNames.Items.Clear();   
 
// How to make the listbox scroll down to show it's last entry when the page loads?     
listBoxRec.SelectedIndex = listBoxRec.Items.Count - 1;
 // How to populate a listbox with the Column Names in a Table?     
foreach (DataColumn dc in ds.Tables[0].Columns) 
   ListBox1.Items.Add(dc.ColumnName); 
// How to add items dynamically to a ListBox using an ArrayList?
ArrayList arrList = new ArrayList(); 
arrList.Add("One"); 
arrList.Add("Two"); 
arrList.Add("Three"); 
ListBox1.DataSource = arrList; 
ListBox1.DataBind(); 
 
"***********************************************"
"**** List_View_functions ******"   	
"***********************************************"
// Configure List Box Properties
// Set the view to show details.
listViewDrvs.View = View.Details;
// Allow the user to edit item text.
listViewDrvs.LabelEdit = true;
// Allow the user to rearrange columns.
listViewDrvs.AllowColumnReorder = true;
// Select the item and subitems when selection is made.
listViewDrvs.FullRowSelect = true;
// Sort the items in the list in ascending order.
listViewDrvs.Sorting = SortOrder.Ascending;
// Allow multi-line select
listViewDrvs.MultiSelect = true;

// Example to add items to ListView from an array
string [] szDriver = new string[7];
ListViewItem [] ListItems = new ListViewItem[nNumDrvs];

// Add Rows to the ListViewItem collection
for(int i = 0; i < nNumDrvs; i++)
{
   szDriver[0] = CSqlDBAccess.m_dsEditDrvTable.Tables[0].Rows[i]["LName"].ToString();
   szDriver[1] = CSqlDBAccess.m_dsEditDrvTable.Tables[0].Rows[i]["FName"].ToString();            
   
   ListViewItem item1 = new ListViewItem(szDriver);
   ListItems[i] = item1;
}

// Create columns for the items and subitems.
listViewDrvs.Columns.Add("Last Name", -2, HorizontalAlignment.Left);
listViewDrvs.Columns.Add("First Name", -2, HorizontalAlignment.Left);

// Add the items collection to the ListView.
listViewDrvs.Items.AddRange(ListItems);
listViewDrvs.Select();
// Select the first item in list
listViewDrvs.Items[0].Selected = true;

// Get the selected item(s) and put into the collection object
ListView.SelectedListViewItemCollection SelItemCol = listViewDrvs.SelectedItems;
// Test for selected items
if(SelItemCol.Count > 0){}

// Example to add a single row of items to a ListView
string[] DisplayMsg = new string[] { Setting, CardValue, SavedValue };
ListViewItem lvi = new ListViewItem(DisplayMsg);
MsgView.Items.Add(lvi);

"***********************************************"
"**** Logging_Messages *******"
"***********************************************"
// Uses the new C# 5.0 attributes for logging information
public void LogMessage(string message,
[CallerMemberName] string memberName = "",
[CallerFilePath] string sourceFilePath = "",
[CallerLineNumber] int sourceLineNumber = 0)
{
	Trace.WriteLine("message: " + message);
	Trace.WriteLine("member name: " + memberName);
	Trace.WriteLine("source file path: " + sourceFilePath);
	Trace.WriteLine("source line number: " + sourceLineNumber);

	Console.WriteLine("message: {0}", message);
	Console.WriteLine("member name: {0}", memberName);
	Console.WriteLine("source file path: {0}", sourceFilePath);
	Console.WriteLine("source line number: {0}", sourceLineNumber);
}

// A simple logging function
private void LogMsg(string msg, int val)
{
   try
   {
      StreamWriter sw = File.AppendText(@"C:\_A\LogMsgs.txt");
      sw.WriteLine(string.Concat(msg, val.ToString()));
      sw.Close();
   }
   catch (Exception ex)
   {
      Console.WriteLine("LogMsg Error: " + ex.Message);
   }
}

// *** Event Logging ***
See the EventLogHelper class in DeveloperUtilitys.cpp

"***********************************************"
"**** Math_Code *******"
"***********************************************"
// Perform scientific notation and return a double
double dVal = 14.3, dPow = 3.0;
double dPwrRes = Math.Pow(dVal, dPow);

// Get a float value from integer division instead of 
// float fOdom = (float)(nOdometer / 10). This strips off the tenths. 
float fOdomTemp = nOdometer;
float fOdom = fOdomTemp / 10.0f;       

// Round MPH value out to nearest kilometer
int nMPHValue = 66;
// Truncates the number by removing the below the decimal value
int nSpd = (int)(nMPHValue * 1.609347);
double dSpd = (double)(nMPHValue * 1.609347);
// Remove above decimal value so only the fractional part remains
double dFrac = dSpd - nSpd;
if(dFrac > 0.5)
   nSpd++;

"***********************************************"
"**** String_functions ******"   	
"***********************************************"
// **** Comparison ****  FirstStr > SecondStr = 1
// Compare two strings, true argument indicates a case-insensitive comparison. 
// * Note that Trim() returns a new string, does not chng existing string
bool eq = String.Compare(s1, EditFrm.employeeNum.Trim(), true) == 0;

// Comparison returns nonzero if not equal. eq will be false.  == does a booleon comparison
bool eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;

// Compare two strings at each Start Index for Max length, ignore case
int result = String.Compare(s1, nStartIndex1, s2, nStartIndex2, len, true);

// **** Searches **** 
// Search for a sub string Within a string(case sensitive, returns -1 if not found)
string searchWithinThis = "ABCDEFGHIJKLMNOP";
string searchForThis = "DEF";
int firstChar = searchWithinThis.IndexOf(searchForThis);

// Check if string contains a specific sub string or char(case sensitive)
bool b = s1.Contains(s2);
int Pos = szGreekLetters.IndexOf('C');
int Pos = szGreekLetters.LastIndexOf('Z');  // Char
int Pos = szGreekLetters.LastIndexOf("Vehicle"); // string

// Test a string for content
if (!string.IsNullOrEmpty(_userData.Password){...}

// **** Parsing **** 
// Pull a sub string out of a string builder object (start index, count)
string szReadSecretNum = sbBuffer.ToString().Substring(0, 4);
// Get the file name without the extension using the Path class
string FilePath = @"..\RS-2100\DataFiles\May08\CamryV6PwrMay14080843AM.rsf";
string FileName = Path.GetFileNameWithoutExtension(FilePath);

// Parse a string with tab delimiters
int nSubStrCnt = 0;
char[] Seps = new char[]{'\t'};

foreach (string SearchStr in szBuffStr.Split(Seps))
{
   switch(nSubStrCnt)
   {
      case 0:
         szReadSecretNum = SearchStr;
         break;
      case 1:
         txtBoxFName.Text = SearchStr;
         break;
      case 2:
         txtBoxLName.Text = SearchStr;                           
         break;
   }   
   nSubStrCnt++;
}
// Change start/end time formats from (month/day/year) to (year - month - day)
int nSubStrCnt = 0;
string Year = "", Month = "", Day = "";
char[] Seps = new char[] { '/' };
foreach (string SearchStr in szStartDTFileLoc.Split(Seps))
{
   switch (nSubStrCnt)
   {
      case 0:
         Month = SearchStr;
         break;
      case 1:
         Day = SearchStr;
         break;
      case 2:
         Year = SearchStr;
         break;
   }
   nSubStrCnt++;
}

// Split string s1 into separate strings delimited by the array of separators. Uses StringSplitOptions enumeration.
arrStrings = s1.Split(arrCharSeparators, StringSplitOptions.RemoveEmptyEntries);
// Use the join method to assemble a string from an array of strings with delimiter
s1 = String.Join("|", arrStrings);

FileListFrm.StartDateTime = Year + "-" + Month + "-" + Day;

// Check if string contains a Number
bool bIsNum = true;   
foreach(char ch in employeeNum)
{
   if(!Char.IsNumber(ch))
   {
      bIsNum = false;
      break;
   }
}
// Or get the count of numbers in the string
int numberCount = employeeNum.Count(ch = > Char.IsNumber(ch));


// Replace a substring (case sensitive)
string szReplaced = szDrvQuery.Replace("(deleted)", "");
// Replace chars (case sensitive)
string szReplaced = szDrvQuery.Replace('c', 'k');

// Remove chars
string szRemoved = szDrvQuery.Remove(2, 5);
string szRemoved = szDrvQuery.Remove('\r');

// Left justify in a 20 char column. Spaces are default, chars optional
string szJustified = VehName.PadLeft(20);

// Return true if a word document using the Path class
return Path.GetExtension(strFileName).ToLower() == ".doc";

// **** Conversions **** 
// Convert a byte array to a char array
byte [] RecData = client.GetRecievedData( ar );
char [] arrCb = new char[RecData.Length];

for (int i=0; i < RecData.Length; i++)
   arrCb[i] = (char)RecData[i];

// Convert a char array to a string by passing it to the constructor
string szRecData = new String(arrChar);

// Convert a string to a char array 
char chArray[] = szRecData.ToCharArray();
// Convert a sub-string to a char array 
char chArray[] = szRecData.ToCharArray(0, 8);
 
// Convert a string to a byte array
Encoding encodingUTF8 = Encoding.UTF8;
Byte[] arrOutData = encodingUTF8.GetBytes(AdminEntry.ToString());
 // or
Byte[] byteDateArray = Encoding.ASCII.GetBytes(szData.ToCharArray());
 // or
BoxID[i] = Convert.ToByte(strBoxID[i]);

// Init an empty string
string lat = string.Empty;

// Test a string if null or empty
if (string.IsNullOrWhiteSpace(model.UserName)) {...}
"***********************************************"
"**** String_formating ******"   	
"***********************************************"
http://msdn.microsoft.com/en-us/library/system.string.format(v=vs.110).aspx
// Format 2 char hex value  "e4" or "03"
szIDButton += String.Format("{0:x2}", nSNByte);
"---- Data to String----"   	
// Display an int as a hex value in a string
string IDButton = nSN.ToString("x");
// Display an int as a currency
string MyInt = theInt.ToString("c");

// Format a double value into a string (1.22). Remove insignificant zeros.
string CardVal = String.Format("{0:#.##}", fCardValue);
// or
string Speed = fSpdResult.ToString("##.#");
// Format a double value into a string. Default value is 0
string Distance = String.Format("{0:0.#}", fDist);
// DateTime to String
string StartTm = dateObj.ToString("MM/dd/yyyy  hh:mm:ss tt");
// Convert number of seconds to string showing Hrs, Mins, Secs            
TimeSpan tsRunTm = new TimeSpan(0,0,numSecs);
string szRunTm = string.Format("{0:00}:{1:00}:{2:00}", tsRunTm.Hours, tsRunTm.Minutes, tsRunTm.Seconds); 
// Format an int value into a string. Default value is 00
szVehName = "Vehicle" + nRef.ToString("00");
// *** Using format strings ****
// C or c for Currency
string.Format("{0:C}", 2.5);  // $2.50
string.Format("{0:C}", -2.5); // ($2.50)
// D or d for Decimal
Console.Write("{0:D5}", 25);  // 00025
// E or e for Scientific
Console.Write("{0:E}", 250000); // 2.500000E+005
// F or f for Fixed-point
Console.Write("{0:F2}", 25); // 25.00
Console.Write("{0:F0}", 25); // 25
// G or g for General
Console.Write("{0:G}", 2.5); // 2.5
// N or n for Number
Console.Write("{0:N}", 2500000); // 2,500,000.00
// X or x for Hexadecimal
Console.Write("{0:X}", 250); // FA
Console.Write("{0:X}", 0xffff); // FFFF

"***********************************************"
"**** StringBuilder_functions ******"   	
"***********************************************"
// Use System.Text namespace
using System.Text;
StringBuilder myStringBuilder = new StringBuilder(50);
myStringBuilder.Append("1");
myStringBuilder.Append("2");
// Append a byte to char conversion and add to string
myStringBuilder.Append((char)RecDataBytes[i]);

myStringBuilder.AppendFormat("{0}::{1}", "tomslick", "Driver");
System.Console.WriteLine(myStringBuilder.ToString());

string RegularString = sb.ToString();

// Clear a Stringbuilder
sb.Remove(0, sb.Length);    
or
sb.Length = 0;     

StringBuilder fullAddress = new StringBuilder();
fullAddress.Append(address1);
fullAddress.Append(string.IsNullOrEmpty(address2) ? string.Empty : string.Format(", {0}", address2));
fullAddress.Append(string.IsNullOrEmpty(city) ? string.Empty : string.Format(", {0}", city));
 
// Using AppendFormat() and putting a new line in format
subject.AppendFormat("{1}Task Name: {0}", System.Environment.NewLine, task.Name);
"***********************************************"
"**** Convertions_Data ******"   	
"***********************************************"
// Convert a string to a byte array.
const string teststring = "modem=123456789ABCWE003040";
var bytesFromString = Encoding.UTF8.GetBytes(teststring);
// OR
byte[] receivedBtyes = new System.Text.ASCIIEncoding().GetBytes(teststring);
// Convert a byte array to a string.
byte[] myBytes = { 0x65, 0x66, 0x67, 0x68, 0x69, 0x70 };
var displayString = Encoding.ASCII.GetString(myBytes);
// OR
string stringFromBytes = new System.Text.ASCIIEncoding().GetString(myBytes);
// Or
foreach (byte bt in dBytes)
   myStringBuilder.Append((char)bt); 

// Get string representing the value of the byte(decimal)
string st = arrBytes[0].ToString();
// Get string representing the value of the byte(hex)
string st = arrBytes[0].ToString("X");

// Display contents of a byte array using a string
StringBuilder sbTest = new StringBuilder(30);
foreach(byte bt in SendMsg)
{
   sbTest.AppendFormat("{0:x2}", bt);
   sbTest.Append(' ');
}

// Displays 00 00 0d 0a b0 b0 b0 b0 b0 b0 b0 b0 b2 b1 b0 b0 b2 b6 b3 b8 43 6d 00 04 01 00 04 00 0b cf 
string strtest = sbTest.ToString();
         
// int to char c1 = 'A'
char c1 = (Char) 65;
// char to int n1 = 65 
int n1 = (Int32) c;
// int to char allowing overflow  c1 = 'A'. Prevents complilation Error due to overflow
char c1 = unchecked{ (Char) (65536 + 65) };
// Convert byte array to char equivalent array using for loop
arrVehicleInfo[i] = (char)ComPort.pktIn.RecDataBytes[i];
// Convert a signed byte to an int
int Lon = (int)(sbyte)(Data[subRecordIndex++]);

"---- Using Convert class ----"   	
// Convert number to char  c2 = 'A'
char c2 = Convert.ToChar(65);
// Convert char to number  n1 = 65
int n1 = Convert.ToInt32(c);
// Convert a char to a byte
DByte = Convert.ToByte(szBuffer[i]);
// This demonstrates Convert's range checking (checked conversion)
try {c = Convert.ToChar(70000);} // Too big for 16-bits
catch (OverflowException) {Console.WriteLine("Can't convert 70000 to a Char.");}
// Convert number <-> character using IConvertible
c = ((IConvertible) 65).ToChar(null);
Console.WriteLine(c);                  // Displays "A"
n = ((IConvertible) c).ToInt32(null);  // Inefficeint, causes value to be boxed
Console.WriteLine(n);                  // Displays "65"

"---- Integer and Bool to Bytes using BitConverter class ----"   	
byte [] IntBytes = BitConverter.GetBytes(nInput1); // Also char, double, long, short, float etc.
byte [] BoolBytes = BitConverter.GetBytes(bInput);
// Convert four byte array elements to an int
int value = BitConverter.ToInt32( arrBytes, StartIndex );
// Convert eight byte array elements to a double
double value = BitConverter.ToDouble( arrBytes, StartIndex );

"---- String to Data ----"   	
// All numeric types have a Parse and TryParse method, which takes a string representation
// of a number and returns its equivalent numeric value.
int i = int.Parse("12345");
int j = Int32.Parse("12345");
double d = Double.Parse("1.2345E+6");
// Returns its equivalent numeric value if it is able.
bool ParseResult = int.TryParse(textBoxComPort.Text, out nOutResult);
// Get the absolute value using the Math class
double dLngSpan = Math.Abs(dLngSpan);

double dv = 3.33;

string r = dv.ToString();

"---- String to DateTime ----"         
DateTime dateTm = DateTime.Parse(szStartTm);
// Append to string builder, 2 char width hex value after left shift 3 bytes
sbDisplayTagNumber.AppendFormat("{0:x2}", ((UInt32)ROM[n] << 24)); 

"---- Data to String ----"   	
// Convert char array to string
char [] InputBuf = new char[100];
string TransmitData = new string(InputBuf);
// Append the char value of each byte to a string
myStringBuilder.Append((char)RecDataBytes[i]);
// This will call the default ToString() for each byte(string representation of integer value)
myStringBuilder.Append(RecDataBytes[i]);

"***********************************************"
"**** DataGridView ******"   	
"***********************************************"
// http://www.codeproject.com/KB/books/PresentDataDataGridView.aspx
// Remove a row
dataGridViewAlarm.Rows.RemoveAt(nRowNum);
// Add a row
dataGridViewAlarm.Rows.Add(VehEx.m_IdleTm, VehEx.m_Force, VehEx.m_BatVolt, bmEmLights);
// Add a row with booleons
dgvEditSettings.Rows.Add(true, kvp.Key.ToString(), bAlarm, bStatus);
// Get a string value from a cell
VehName = (string)dgvEditSettings.Rows[i].Cells[1].Value;
// Get a bool value from a cell that has a checkbox
bAlarm = (bool)dgvEditSettings.Rows[i].Cells[2].Value;
// Color text in selected cell
dataGridViewAlarm.Rows[nRowNum].Cells[1].Style.ForeColor = Color.Red;                           

// To remove row headers from your DGV, set its RowHeadersVisible property to false.
// To add a row for adding new rows appearing as the last row, use AllowUserToAddRows property

//When you bind a DataGridView control and set the AutoGenerateColumns property to true, 
//columns are automatically generated using default column types appropriate for the data 
//types contained in the bound data source

// If you want to respond immediately when users click a check box cell, you can handle the 
//CellClick event, but this event occurs before the cell value is updated. If you need the new 
//value at the time of the click, one option is to calculate what the expected value will be 
//based on the current value. Another approach is to commit the change immediately, and handle 
//the CellValueChanged event to respond to it. To commit the change when the cell is clicked, 
//you must handle the CurrentCellDirtyStateChanged event. In the handler, if the current cell 
//is a check box cell, call the CommitEdit method and pass in the Commit value. 

// You can respond to user clicks in button cells by handling the CellClick event.

// Button columns, Combo box columns and Link columns are not generated automatically when 
// data-binding a DataGridView control. To use link columns, you must create them manually and 
// add them to the collection returned by the Columns property.


"***********************************************"
"**** Arrays ******"   	
"***********************************************"
string[] names = { "Bill", "Jane", "Bob", "Frank", "Bifford", "Sam" };
var bList = names.Where(s => s.StartsWith("B"));
// Syntax similar to assigning a string literal to a string type.
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
// Sort an array
Array.Sort(MyArray);
// Copy a single dim array to another starting at specified destination Array index
Arr1.CopyTo(Arr2, nStartingDestIndex);   
// Copy an array to another
Array.Copy(source_array_1, source_start_1, source_array_2, source_start_2, number_of_elements);           
// Reverse the order
Array.Reverse(Arr2);
// Copy a string or part of a string to an array 
szDisplayBtnID.CopyTo(0, Arr3, 0, szDisplayBtnID.Length);
// Call the default constructor of the value type of each element
arrInData.Initialize();
// Length will equal (20) which is the number of elements
char [] VehicleName = new char[20];
hdrPos = VehicleName.Length;

// Declare a multi-dimensional array and assign values to it
string[,] arrSavedDrvs = new string[nRowCnt,3];
for(int j = 0; j < nRowCnt; j++)
{
   arrSavedDrvs[j, 0] = CSqlDBAccess.m_dsEditDrvTable.Tables[0].Rows[j]["LName"].ToString();
   arrSavedDrvs[j, 1] = CSqlDBAccess.m_dsEditDrvTable.Tables[0].Rows[j]["FName"].ToString();
}   

// Create 2 dim rect array
int [,] twoDim = new int[,]{
{110, 120, 130},
{210, 220, 230},
{310, 320, 330}            
};
// Index through above array assigning values to singleDim and singleString
int [] singleDim = new int[9];
string [] singleString = new string[9];
   
for (int i = 0, ResultCnt = 0; i < twoDim.GetLength(0); i++)
   for (int j = 0; j < twoDim.GetLength(1); j++)
   {
      singleDim[ResultCnt] = twoDim[i, j];
      singleString[ResultCnt] = twoDim[i, j].ToString();
      ResultCnt++;         
   }
// Declare a 2-dimensional array as a jagged array (a vector of vectors)
Int32[][] aJagged = new Int32[numElements][];

for (Int32 x = 0; x < numElements; x++)
   aJagged[x] = new Int32[numElements];

"***********************************************"
"**** Attributes ******"
"***********************************************"
// false sets the IsError property to produce a compiler warning(default).
[ObsoleteAttribute("This property is obsolete. Use NewProperty instead.", false)]
public static string OldProperty
{ get{ return "The old property value."; } }

// true sets the IsError property to produce a compiler error.
[ObsoleteAttribute("This method is obsolete. Call CallNewMethod instead.", true)]
public static string CallOldMethod()

"***********************************************"
"**** Enumerations ******" 
"***********************************************"
// Example of enumeration used in a class
internal class Employee
{
	public enum GenderType{ Male = 1, female = 2 } // This can only be accessed when called from outside the class by the class name.
	public string Name{ get; set; }
	public long Age{ get; set; }
	public GenderType gender{ get; set; }
}
---
enum ViewStateVal { NoDisplay = 0, DisplayAlarm = 1, DisplayStatus = 2, DisplayAll = 3 };
// Assign enum value to an integer by using a cast to it's base type
int selectedViewState = (int)ViewStateVal.DisplayAll;

// Create an instance of the enum type and assign it a value
ViewStateVal viewStateVal = ViewStateVal.DisplayAll;

// Switch an int value against an enum value
switch (selectedViewState)
{
   case (int)ViewStateVal.DisplayAlarm:
      VehExcp.IsDisplayAlarm = true;
   break;
   case (int)ViewStateVal.DisplayStatus:
      VehExcp.IsDisplayStatus = true;   
   break;
   case (int)ViewStateVal.NoDisplay:
      return;
   break;
}

// Get int value from enum
int something = (int)Question.Role;

// To get a name from an enum value
Enum.GetName(typeof(ViewStateVal), 1));
Enum.GetName(typeof(ViewStateVal), ViewStateVal.DisplayAlarm));

// another
// Declared in class: enum cars{Mustang = 1, Corvette = 2, F150 = 3};
int selectedCar = 1;
string firstCar = Enum.GetName(typeof(cars), selectedCar);
string secondCar = Enum.GetName(typeof(cars), 2);

// Get ID from Name of an enum property
ReasonName = "OutReach"; // This name is a name used in the ContactReasonsEnum enum
ContactReasonsEnum contactReason = (ContactReasonsEnum)Enum.Parse(typeof(ContactReasonsEnum), ReasonName);
ReasonID = (int)contactReason;

// Declare an enum type in the class (FileListForm)
public enum DBReportType { DrvSummaryType = 0, VehSummaryType = 1 };
public DBReportType ReportType;            

// Create a file selection form. Pass in list of Vehicles
FileListForm fileListForm = new FileListForm();
// Instance variable of the form is assigned from the static enum field
fileListForm.ReportType = FileListForm.DBReportType.DrvSummaryType;

// Get enum values from FNLevels enumeration
InputParameterValueSelectorBox.ItemsSource = Enum.GetValues(typeof(FNLevels));

// From a string to an enum:
YourEnum foo = (YourEnum)Enum.Parse(typeof(YourEnum), yourString);
// From an int to an enum:
YourEnum foo = (YourEnum)yourInt;
// Or
YourEnum foo = (YourEnum)Enum.ToObject(typeof(YourEnum), yourInt);

// Returns an array of integer values
Array possibleValues = Enum.GetValues(enumType);

// Not sure about this
InputParameterValueSelector.SelectedValue = String.CompareOrdinal(selectedParam.Value, "False") == 0 ? (Bools)1 : (Bools)2;

"***********************************************"
"****  Message_Boxes ******"   	
"***********************************************"
// When calling from a class that is not a form include:
using System.Windows.Forms;

MessageBox.Show(ex.ToString(),"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
if(MessageBox.Show("?","", MessageBoxButtons.YesNo) == DialogResult.No)
result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
            MessageBoxOptions.RightAlign);
if(MessageBox.Show(szMsg,"Warning!", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2) == DialogResult.No)

"***********************************************"
"**** Environment_Class ******"
"***********************************************"
// Invoke this sample with an arbitrary set of command line arguments.
Console.WriteLine("CommandLine: {0}", Environment.CommandLine);

String[] arguments = Environment.GetCommandLineArgs();
Console.WriteLine("GetCommandLineArgs: {0}", String.Join(", ", arguments));
Console.WriteLine("CurrentDirectory: {0}", Environment.CurrentDirectory);
Console.WriteLine("MachineName: {0}", Environment.MachineName);
Console.WriteLine("OSVersion: {0}", Environment.OSVersion.ToString());
Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);
Console.WriteLine("SystemDirectory: {0}", Environment.SystemDirectory);
Console.WriteLine("UserDomainName: {0}", Environment.UserDomainName);
Console.WriteLine("UserName: {0}", Environment.UserName);
// Gets a Version object that describes the major, minor, build, and revision numbers of the clr
Console.WriteLine("Version: {0}", Environment.Version.ToString());
// If program being installed in Windows 7
if(Environment.OSVersion.Version.Build >= 7600 && Environment.OSVersion.Version.Major >= 6  && 
                                                  Environment.OSVersion.Version.Minor >= 1)
Environment.Exit(-1);
Environment.FailFast("Reason for failure");
// Get the file name and version for the windows installer.
string path = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\MSI.DLL";
// Get the path for the ProgramData dir in win 7 or the all users dir in XP
string strPublicFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(path);// using System.Diagnostics for FileVersionInfo class

string path = System.IO.Path.GetPathRoot(System.Environment.SystemDirectory); // "C:\\"
string systemDir = System.Environment.SystemDirectory; // "C:\Windows\system32"
string docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments); // "C:\Users\Craig\Documents"

Environment.GetEnvironmentVariable("ALLUSERSPROFILE");
Environment.GetEnvironmentVariable("WINDIR")
Environment.GetEnvironmentVariable("APPDATA") // Get Application Data directory

// File: Windows Installer3.1.4001.5512"
txtBox.Text = "File: " + myFileVersionInfo.FileDescription + myFileVersionInfo.FileVersion;
"***********************************************"
"**** Extension_Methods ******"   	
"***********************************************"
http://msdn.microsoft.com/en-us/library/bb383977.aspx
// Extension methods are only in scope when you import the namespace 
// into your source code with a using directive.

// Call an extension method
string MyStr = "Thisxxx is my five string full string.";
string MySub = MyStr.GetSubStr5char();

// Static class to define Extension Methods on a type and on an Interface
public static class MyExtensions
{
   // This func is now available on any string instance
   public static string GetSubStr5char(this string strVal)
   {
      string strSub = strVal.Substring(0, 5);
      return strSub;
   }

   // This func is now available on any class that implements IEnumerable
   public static IEnumerable<int> WhereEven(this IEnumerable<int> values) 
   { 
      foreach (int i in values) 
         if (i % 2 == 0) 
               yield return i; 
   } 
}
   
"***********************************************"
"**** File_Operations ******"   	
"***********************************************"
using System.IO;

"*** Sub_FileStreams ***"
// Construct a FileStream object in different ways

// Opens an existing file or creates a new file for writing.
FileStream fStream = File.OpenWrite("theFile.txt"); 
// If file does not exist, FileNotFoundException is thrown
FileStream fStream = File.OpenRead("theFile.txt"); 
// Specify how to open the file and the way to access it
FileStream fStream = File.Open("theFile.txt", FileMode.Create, FileAccess.Write);
// Creates or overwrites a file
FileStream fStream = File.Create("theFile.txt"); 
// Using one of the FileStream object constructors: 
FileStream fStream = new FileStream("theFile.txt",FileMode.OpenOrCreate,
                                          FileAccess.Write,FileShare.None);
// FileMode enumerations
Create - creates a file and if the file already exists, it will be overwritten. 
CreateNew - creates a file and if the file already exists, an IOException is thrown.  
Append - If the file does not exist a file is created. Use FileMode.Append only with FileAccess.Write
Open - opens the file if it exists. If file does not exist, FileNotFoundException is thrown. 
OpenOrCreate - opens the file if it exists. If file does not exist, the file will be created.  
Truncate - opens an existing file and truncates it to make it a size of zero bytes. 

// Note:StreamWriter is designed for char output in a particular Encoding, whereas classes 
// derived from Stream are designed for byte input and output.

// One way to create or overwrite a text file
StreamWriter sw = File.CreateText("theFile.txt");
// One way to open a text file for reading only
StreamReader sr = File.OpenText("theFile.txt")

// *** StreamWriter Construction
// If bAppend == true append text to file, otherwise overwrite if already exists(default behavior)
StreamWriter swFromFileTrue = new StreamWriter(fileName, bAppend);

// Read bytes from a file stream
var bytes = new byte[fStream.Length];
fStream.Read(bytes, 0, bytes.Length);
// or
while((temp = fStream.ReadByte()) != -1)
{
  Console.WriteLine(temp);
}
// or
while(fStream.Position < fStream.Length)
{
  Console.Write(" {0} ", fStream.ReadByte());
}

// StreamReader: Read and display lines from a text file until eof is reached.
try{
   using (StreamReader reader = new StreamReader("TestFile.txt")) 
   {
      string line = string.empty;
      
	  while ((line = reader.ReadLine()) != null)
      {
         Console.WriteLine(line);
      }
   }
}
catch (IOException e) 
{
   Console.WriteLine("The file could not be read:");
   Console.WriteLine(e.Message);
}

// StreamWriter: Write a line to a text file. Create file if not existing
// Each time it opens file it will over write contents.
using System.IO;
StreamWriter writer = new StreamWriter("TestFile.txt");
writer.WriteLine("Button Write Thread started");
writer.Flush(); // This is necessary
writer.Close();

// Functions to log a message to a text file. 
// @@Test Only
private void LogMsg(string msg)
{
	try
	{
		StreamWriter writer = File.AppendText(@"C:\_A\LogMsgs.txt");
		writer.WriteLine(msg);
		writer.Close();
	}
	catch (Exception ex)
	{
		Console.WriteLine("LogMsg Error: " + ex.Message);
	}
}
private void LogMsg(string msg, int value)
{
   try
   {
      StreamWriter writer = File.AppendText(@"C:\_A\LogMsgs.txt");
	  writer.WriteLine(string.Format("{0} : {1}", msg, value));
	  writer.Close();
   }
   catch (Exception ex)
   {
      Console.WriteLine("LogMsg Error: " + ex.Message);
   }
}
public static void LogDebug(string pstrFile, string pstrText)
{
   try
   {
	  StreamWriter writer;
	  writer = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + pstrFile);
	  writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " " + pstrText);
	  writer.Close();
   }
   catch (Exception ex)
   {
      Console.WriteLine("Error: " + ex.Message);
   }
}

// Open a file using File class. Create file to write to.
FileStream fsOut = File.Open("MemStreamOut.rsf", FileMode.Create, FileAccess.Write);

// Write the header to the output file
fsOut.Write(arrInData, 0, byteCnt);

// Open a file using FileStream class and clear the contents.
var fsCellLink = new FileStream("CellLink.xml", FileMode.Truncate, FileAccess.Write, 
                              FileShare.None, 100, false);

// Write data out to file from array the max bytes out
fsCellLink.Write(arrOutData, 0, BytesOut);

// Reset file ptr to begining of file
fsCellLink.Seek(0, SeekOrigin.Begin);

// Create a file using File class
FileStream fs = File.Create(strPath, bufferSize, FileOptions);

// Check File Exists
FileInfo RenamedFile = new FileInfo(FilePath);
return (RenamedFile.Exists);
// Or
// Call the File Class static function
if (File.Exists("CellLink.xml")){}

// Rename a File
FileInfo FileToRename = new FileInfo(srcFilePath);
if(FileToRename.Exists)
   FileToRename.MoveTo(targFilePath);

// Moves file to a new location, providing the option to specify a new file name. 
File.Move(@"c:\temp\MySrc.txt", @"c:\temp\MyTarg.txt")

// Delete a file
File.Delete(@"c:\temp\MyTest.txt")

// Get size of a file using FileInfo class
FileInfo fi = new FileInfo("MemStreamOut.rsf");
long len = fi.Length;

// Create an Open or Save File Dialog
OpenFileDialog openFileDlg = new OpenFileDialog(); // or SaveFileDialog()
openFileDlg.Filter = "Query files (*.txt)|*.txt";
openFileDlg.FilterIndex = 1;
openFileDlg.RestoreDirectory = true; // See Note: 1
openFileDlg.InitialDirectory = "..\\RS-2000\\Querys";
if(openFileDlg.ShowDialog() == DialogResult.OK)
{
   // Open file to transmit
   using (StreamReader sr = new StreamReader(openFileDlg.OpenFile()))
   {
      while (sr.Peek() >= 0) 
      {
         StrReadData = sr.ReadLine();
         ...
      }
   }
}

// Position file ptr after hdr in a file
fsProg.Seek(sizeof(_FileVersion) + sizeof(_FileHeader), SeekOrigin.Begin);
// Note:1)True if directory should be restored after a search; false to use whatever directory 
// string remained from search. The default is false. Has no effect when set on OpenFileDialog

// Use \r\n to append a line to a text file
string DataStr = "---------------------\r\n";
// or if using a StreamWriter
sw.WriteLine();

"***********************************************"
"**** Exceptions ******"
"***********************************************"
using System.Runtime.Serialization;

/// <summary>
/// Example of an exception created
/// </summary>
[Serializable]
public class BoxCommunicationException : Exception
{
   public BoxCommunicationException(){}
   public BoxCommunicationException(string message) : base(message){}
   public BoxCommunicationException(string message, Exception innerException) : base(message, innerException) { }
   protected BoxCommunicationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

// An example of the above exception being called
catch (Exception ex)
{
   StatusMessage = string.Format("{0}.{1} {2}", ClassName, methodName, ex.Message);
   throw new BoxCommunicationException(StatusMessage, ex);
}
// Another example of the above exception being called
throw new BoxCommunicationException(StatusMessage);

"***********************************************"
"**** Delegates ******"
"***********************************************"
// * Delegate used in events
// This says that the method must take two doubles as the inputs, and return void.
public delegate void PositionReceivedEventHandler(double latitude, double longitude);

// Create the PositionRecieved event that calls a method with the same definition as the PositionReceivedEventHandler delegate.
public event PositionReceivedEventHandler PositionReceived;

// The method_Name parameter must match the delegate
PositionRecieved += new PositionReceivedEventHandler(method_Name);

// * An Action is a type of delegate. It returns no value. It may take 0 to 16 parameters.
//For example the following Action can encapsulate a method taking two integers as input parameters and returning void.
Action<int, int> MyDelegate;

// So if you have a method like this:
static void Display(int a, int b) { Console.WriteLine("Total = {0}", a + b); }

// You can encapsulate the method Display in Action MyDelegate as below :
MyDelegate = Display;
MyDelegate(40, 60);

// or create an annonymous delegate
MyDelegate = r = > Console.WriteLine("Total = {0}", r);


"***********************************************"
"**** Directory_functions ******"
"***********************************************"
using System.IO;
// Create a sub directory if it does not already exist
string userDocumentFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
DirectoryInfo configurationsDirectory = new DirectoryInfo(Path.Combine(userDocumentFolder, "NewDirectory"));

if (!configurationsDirectory.Exists)
{
	configurationsDirectory.Create();
}

// Create a sub directory in the above sub directory
DirectoryInfo clientDirectory = new DirectoryInfo(System.IO.Path.Combine(configurationsDirectory.ToString(), "NewDirectory2"));
clientDirectory.Create();

clientDirectory.Delete();
--------

// Returns the subdirectories of the current directory
DirectoryInfo[] diArr = dirInfo.GetDirectories();
// Create a subdirectory in the directory just created.
DirectoryInfo dis = dirInfo.CreateSubdirectory("SubDir");
// Get a reference to each file in that directory.
FileInfo[] fiArr = dirInfo.GetFiles();
FileInfo[] fiArr = dirInfo.GetFiles(szSearchPattern);

// Get Path to Current Directory to read xml file into dataset
string path = Directory.GetCurrentDirectory();
path += @"\MapData.txt";
DataSet ds1 = new DataSet();
ds1.ReadXml(path);

// Get FileInfo for each file. Gives you a Dictionary<string, FileInfo>
var queryResult = 
    (from d in directoryInfo.GetFiles()
     where d.Name.EndsWith(suffix) 
     select d).ToDictionary(k=>k.Name, v=>v);

// Get path to media folder in system dir
string sysRoot = System.Environment.SystemDirectory;
string MediaPath = sysRoot + @"\..\Media";	

"***********************************************"
"**** Drive_functions ******"
"***********************************************"
List<string> DriveNames = new List<string>();
DriveInfo[] allDrives = DriveInfo.GetDrives();
string DrvName;

foreach (DriveInfo drv in allDrives)
{
   if(drv.DriveType == DriveType.CDRom)
      DrvName = "CD-ROM/DVD [" + drv.Name + "]";
   else if(drv.DriveType == DriveType.Network)
      DrvName = "Network Drive [" + drv.Name + "]";
   else if(drv.DriveType == DriveType.Removable)
      DrvName = "Removable [" + drv.Name + "]";
   else
      DrvName = drv.Name;
      
   DriveNames.Add(DrvName);
} 

"***********************************************"
"**** Application_functions ******"
"***********************************************"
// Check if current app is running. Place this at start of Main()
private void frmMain_Load(object sender, EventArgs e)
{
   bool createdNewMutex;
   
   // Create mutex to allow only one instance of this app to run
   Mutex m = new Mutex(true, "BackUpDB", out createdNewMutex);

   if (!createdNewMutex)
   {
      Application.Exit();
      Environment.Exit(-1); // Try this if Application.Exit() does not exit
      
      return;
   }

   // Keep the mutex reference alive until the normal termination of the program
   GC.KeepAlive(m);     
}

"***********************************************"
"****  Algorithms ******"   	
"***********************************************"


// ********************************************************************************
// Use a Stopwatch and a wait handle to wait for an event when running from a form
// ********************************************************************************
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

while (stopWatch.IsRunning)
{
   index = WaitHandle.WaitAny((new ManualResetEvent[] { m_EventRecdPacket }), 20, false);

   // If event signaled
   if (index == 0)
      stopWatch.Stop();   
   else if (stopWatch.ElapsedMilliseconds >= 4000) // Tm period to wait
      stopWatch.Stop();   

   Application.DoEvents(); // This allows form to not lock up
}
// If event was never signaled
if (index != WaitHandle.WaitTimeout){...}

"***********************************************"
"**** Nullable_Types ******"
"***********************************************"
Nullable<int> n1 = new Nullable<int>();
Nullable<int> n2 = 50;
Nullable<int> n3 = null;
Nullable<int> n4 = new Nullable<int>(125);
int ? n5 = new int ? ();
int ? n6 = 30;
int ? n7 = null;

// Change their values
n1 = 60;
n2 = null;
n3 = 22;
n4 = 50;

if (n1.HasValue && n3.HasValue)
n2 = n1 + n3;

n5 = 100;
n7 = n6 + n5 + n4;

"***********************************************"
"**** Processes_Threads ******"   	
"***********************************************"
// Launch another process
using System.Diagnostics; 
Process proc = new Process();
proc.StartInfo.FileName = "Notepad.exe";
proc.StartInfo.Arguments = @"C:\CurrentProjects\FTDIquestion2.txt";
proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
proc.Start();
// or
Shell("Notepad.exe", AppWinStyle.NormalFocus)
// Start Internet explorer
Process.Start("IExplore.exe", "www.northwindtraders.com");

//Declare and instantiate a new process component.
System.Diagnostics.Process process1;
process1= new System.Diagnostics.Process();

// Do not receive an event when the process exits.
process1.EnableRaisingEvents = false;

// End a process
Process.GetCurrentProcess().Kill();

//The "/C" Tells Windows to Run The Command then Terminate 
// cmd.exe is the command line interpreter
string strCmdLine;
// strCmdLine = "C:\\Program Files\\Road Safety\\RS-2000\\mysql\\bin\\mysqlbinlog \"C:\\Program Files\\Road Safety\\RS-2000\\mysql\\data\\rslog.001 > filelog1.txt\"";
strCmdLine = "C:\\Program Files\\Road Safety\\RS-2000\\mysql\\bin\\simboxdata";
System.Diagnostics.Process.Start("CMD.exe",strCmdLine);
process1.Close();

// Launching a thread
using System.Threading; // Include this
namespace Test
{
   class TestApp
   {
      static void Main(string[] args)
      {
         TestApp myProc = new TestApp();

         Thread myThread = new Thread(new ThreadStart(myProc.SendErrorReport));
         myThread.Start();
         Console.WriteLine("Started SendErrorReport().");
         Console.ReadLine();
      }

      public void SendErrorReport()
      {
         Thread.Sleep(2000);
         Console.WriteLine("Running SendErrorReport.");
      }
   }
}
//Note: If you open resources within your thread, you must
//release them before the thread finishes.

// This event type does not auto reset after being signaled
ManualResetEvent m_EventStopListen;
m_EventStopListen = new ManualResetEvent(false); // Parameter sets initial state
m_EventStopListen.Reset();
m_EventStopListen.Set();
// Blocks current thread until event is signaled. nWaitTm holds number of seconds to wait
bool bSignaled = m_EventStopListen.WaitOne(nWaitTm, false);
// or
if (WaitHandle.WaitAll((new ManualResetEvent[] { m_EventListenStopped }), 10, true))
   break;

// Start a thread with an object parameter
Thread thrdDwnld = new Thread(new ParameterizedThreadStart(DownloadVehicle));
thrdDwnld.Start(m_EventDwnLdStopped);

// m_Event specifies an object containing data to be used by the method
ThreadPool.QueueUserWorkItem(new WaitCallback(DownloadVehicle), m_Event);
// or
// No argument. Function still must have (Object someObj) as a parameter listing even though not used.
ThreadPool.QueueUserWorkItem(new WaitCallback(DownloadVehicle));

// *** Setting display fields in form from another thread ***
// Place this in the namespace before the class
public delegate void DelegateUpdateDisplay(string Status, string Time);
// Place this in the global class data
public DelegateUpdateDisplay m_DelUpdateDisplay;
// Place this in the class constructor
m_DelUpdateDisplay = new DelegateUpdateDisplay(UpdateDisplayFunc);
// Place this in the global class data
MyForm m_form = null;
// Place this in the class constructor. Thread has access to class members, just not UI controls.
m_form = this; 
m_form.Invoke(m_form.m_DelegateDispListenStatus, new Object[] { szStatusMsg });

"***********************************************"
"**** Properties_Sample ******"   	
"***********************************************"
// Shorthand syntax for a read\write property. No backing field required
public bool IsError {get; set;}
public bool IsError {get; private set;}
// Must initialize value in constructor
this.IsError = false;

private string LoggedInName = ""; // Backing field
public string LogInName
{
   set { LoggedInName = value; }
   get { return LoggedInName; }
}

private bool bIsError = false; // Backing field
public bool IsError
{
   set { bIsError = value; }
   get { return bIsError; }
}


"***********************************************"
"**** Random_functions ******"   	
"***********************************************"
// Regular expression for IP address chk
Regex rx = new Regex(@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
if (!rx.IsMatch(txtBoxVehIP.Text)){...}


"***********************************************"
"**** DateTime_functions ******"   	
"***********************************************"
// C# Date Time Formats including single character formats.
https://www.dotnetperls.com/datetime-format

// Custom Date and Time Format Strings
http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx
using System.DateTime;
// Create DateTime object that contains the current year, month, day of month
DateTime dtNow = DateTime.Now;
DateTime dtYMDNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);

// Use a format string to create "Jan01080325PM"
string strCurTm = DateTime.Now.ToString("MMMddyyhhmmtt");

// Use a format string to create "2008-05-15 04:32:23  Note: HH for 24 hr"
string strCurTm = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

// Create DateTime object initializing it with a string
DateTime dateTmObj = DateTime.Parse("12/30/2005");

// Set the min value for a DateTime
criteria.InsertionDateTimeMax = DateTime.MinValue;

// Add seconds to a DateTime object from a text field
int numSeconds = Convert.ToInt32(textBoxAddRun.Text.ToString());
dateTmObj.Add(new TimeSpan(0, 0, numSeconds));
 // or
dateTmObj += new TimeSpan(0, 0, numSeconds);
// Note: Also AddDays, AddHours, AddSeconds, AddMilliSeconds, AddMonths, AddYears etc.
 
// To convert a DateTime object into a string  
string szTestDt = dtLastDwnLdTm.ToString("yyyy/dd/MM HH:mm:ss");

// To compare 2 DateTime objects using static method. 
if(DateTime.Compare(t1, t2) >  0) Console.WriteLine("t1 > t2"); 

// Use CompareTo() for instance comparison
if (dtNow.CompareTo(dtLastDwnld) > 0)

// To convert number of secs to Hr:Min:Secs
TimeSpan tsRunTm = TimeSpan.FromSeconds(numSecs);
string szRunTm = string.Format("{0:##00}:{1:##00}:{2:##00}", tsRunTm.Hours, tsRunTm.Minutes, tsRunTm.Seconds);

// Use TimeSpan.Parse method to parse in span string.
TimeSpan span = TimeSpan.Parse("0:00:01");
Console.WriteLine(span);  // Result is 00:00:01

// Use TimeSpan.TryParse to try to parse an invalid span. The result is TimeSpan.Zero.
TimeSpan span2;
TimeSpan.TryParse("X:00:01", out span2);
Console.WriteLine(span2);  // Result is 00:00:00

// Avoid these TimeSpan methods because they take about double the time to run compared to using constructors:
TimeSpan.FromDays(3)
TimeSpan.FromHours(3)
TimeSpan.FromMilliseconds(300000)
TimeSpan.FromMinutes(5)
TimeSpan.FromSeconds(400)

// Prefer these TimeSpan constructors :
new TimeSpan(long)				// Initialize with the number of ticks
new TimeSpan(int, int int)

TimeSpan ts = TimeSpan.Zero;

// DateTimeFormatInfo Class

// Change time string format from (month/day/year) to (year - month - day)
int nSubStrCnt = 0;
string Year = "", Month = "", Day = "";
char[] Seps = new char[] { '/' };
foreach (string SearchStr in szStartDTFileLoc.Split(Seps))
{
   switch (nSubStrCnt)
   {
      case 0:
         Month = SearchStr;
         break;
      case 1:
         Day = SearchStr;
         break;
      case 2:
         Year = SearchStr;
         break;
   }
   nSubStrCnt++;
}

FileListFrm.StartDateTime = Year + "-" + Month + "-" + Day;

// Get number of seconds from a TimeSpan
UInt32 SecsSinceUnix = (UInt32)tsSinceUnix.TotalSeconds

// DateTime to time_t
// Get number of seconds from a DateTime(since Jan 01, 0001)
UInt32 time_tFileCreateTmCE = Convert.ToUInt32(dtCreationTm);

/// Function to convert a UInt32 value to a UTC date and time
private DateTime GetUtcFromUint(UInt32 Time)
{
   DateTime UnixUTC = new DateTime(1970, 1, 1, 0, 0, 0, 0);
   DateTime calcultedUTC = UnixUTC.AddSeconds(Convert.ToDouble(Time));
   return calcultedUTC;
}
// Convert UTC/Unix seconds to common era local time. Day light Savings Tm included
DateTime UnixUTC = new DateTime(1970, 1, 1, 0, 0, 0, 0);
DateTime dtComEraTm = UnixUTC.AddSeconds(dfUnixUtcSeconds).ToLocalTime();

// Get the starting unix time
DateTime unixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
// Convert Common Era time to unix time, subtract the unix start tm
time_tFileCreateTmCE -= Convert.ToUInt32(UnixUTC);

//  // // // // // // // // // // // 
// Convert Common Era time to unix time
DateTime dtBoxLocTm = Radio.dtBoxTime;
// Get the starting unix time
DateTime unixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
// Get the difference between unix time and Anno Domini(Common Era) time
TimeSpan timeDif = dtBoxLocTm - unixStartTime;
TimeSpan timeSpanDST = new TimeSpan(1, 0, 0); 
if (dtBoxLocTm.IsDaylightSavingTime())
   timeDif -= timeSpanDST;

// Convert the download time to a time_t value
time_tTripEndTM = Convert.ToUInt32(timeDif.TotalSeconds);

// Get value from a DateTimePicker
string szFromTime = FromDateTmPicker.Value.ToString("MM-dd-yyyy");

// // // // // // // // // // // // // 
public static DateTime ToCSharpTime(long unixTime)
{
   DateTime unixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
   return unixStartTime.AddSeconds(Convert.ToDouble(unixTime));
}

"***********************************************"
"**** Configuration ****"
"***********************************************"
// http://www.codeproject.com/KB/dotnet/mysteriesofconfiguration.aspx
using System.Configuration; 

// *Get an application setting
string durationSetting = ConfigurationManager.AppSettings["CheckRecordsDuration"];
int duration = 0;
if(int.Parse(durationSetting, out int duration) {...}

NameValueCollection AppSettings = ConfigurationManager.AppSettings;
string strStartStop = AppSettings["StartStopServer"];
bool bStartStop = bool.Parse(strStartStop);

string result = appSettings["key"] ?? "Not Found";
Console.WriteLine(result);

// *Build the connection string to add to the configuration file.
OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
builder.Driver = "MySQL ODBC 3.51 Driver";
builder["Server"] = "192.168.1.132";
builder["DATABASE"] = "DB_RS2100";
builder["OPTION"] = "3";
string myConnectString = builder.ConnectionString;

// Open the default configuration file into the Configuration object.
Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

// Get a reference to the config.ConnectionStrings
ConnectionStringsSection connectStringSection = config.ConnectionStrings;

// Add the connection string to the config.ConnectionStrings reference
connectStringSection.ConnectionStrings.Add(new ConnectionStringSettings("DB_RS2100", myConnectString));

// Save the configuration file. If it does not exist, it will be created.
config.Save(ConfigurationSaveMode.Modified);

// *Read the connection string from the configuration file and connect to database
ConnectionStringSettings connectStringSettings = ConfigurationManager.ConnectionStrings["DB_RS2100"];
var builder = new OdbcConnectionStringBuilder(connectStringSettings.ConnectionString);
builder["USER"] = name;
builder["PASSWORD"] = password;
OdbcConnection dbConnection = new OdbcConnection(builder.ConnectionString);

// *Remove and add a setting in the AppSettingsSection of the config file
Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
AppSettingsSection appSettingsSection = config.AppSettings;
appSettingsSection.Settings.Remove("StartStopServer");
appSettingsSection.Settings.Add("StartStopServer", "true");
config.Save(ConfigurationSaveMode.Modified);
// Force a reload of the changed section so that application does not have to restart.
ConfigurationManager.RefreshSection("appSettings");

// *Open a mapped configuration for updating
ExeConfigurationFileMap map = new ExeConfigurationFileMap();
map.ExeConfigFilename = ConfigFilePath;
Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
AppSettingsSection appSection = (AppSettingsSection)config.GetSection("appSettings");
KeyValueConfigurationCollection configItems = (KeyValueConfigurationCollection)appSection.Settings;
// Get each of the key/values in the appSettings Section
// store the values in local variables
foreach (KeyValueConfigurationElement keyValElem in configItems)
{
   if(keyValElem.Key == "StartStopServer")
      startStopServer = keyValElem.Value;
   else if (keyValElem.Key == "ClearCards")
      clearCards = keyValElem.Value;   
}

// *Open a mapped configuration to get a connection string
var mappedConfig = new ExeConfigurationFileMap();
mappedConfig.ExeConfigFilename = "RS2100.exe.config";
Configuration config = ConfigurationManager. (mappedConfig, ConfigurationUserLevel.None);
string strConn = config.ConnectionStrings.ConnectionStrings["DB_RS2100"].ConnectionString;

// Use ConfigurationUserLevel to specify which configuration file is to be represented by the Configuration 
// object returned by ConfigurationManager.OpenExeConfiguration and WebConfigurationManager.OpenMachineConfiguration.
// Applications use a global configuration that applies to all users, separate configurations that apply to 
// individual users, and configurations that apply to roaming users.

"***********************************************"
"**** Console_functions ****"
"***********************************************"
Console.WriteLine("connection worked");
// Wait for user to press key
Console.ReadKey();

"***********************************************"
"**** Collections_Generic ******"   	
"***********************************************"
System.Collections.Generic
// List
public List<string> SelDrvs = new List<string>();
SelDrvs.Add("New string"); 
// One way to initialize a List
List<int> list = new List<int>(); 
list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

// Dictionary (can use any type for value or key)
Dictionary<string, string> VehIpAddresses = new Dictionary<string, string>(20);
VehIpAddresses.Add("VehName", "127.0.0.1"); // Throws ArgumentException if attempting to add a duplicate key
VehIpAddresses[VehName] = StrIPAddr;
Console.WriteLine("For key VehName, value = {0}.", VehIpAddresses["VehName"]); // KeyNotFoundException possible

if(VehIpAddresses.ContainsKey("VehName")){...};

foreach (KeyValuePair<string, string> de in VehIpAddresses)
{
   swTest.WriteLine("Key: " + de.Key + " Value: " + de.Value);
}

VehIpAddresses.Remove("VehName");

// To get the values alone, use the Values property(also a Keycollection property).
Dictionary<string, string>.ValueCollection valueColl = VehIpAddresses.Values;
foreach( string s in valueColl ){...}

"***********************************************"
"**** Threading ****"
"***********************************************"
http://www.albahari.com/threading/

// Start a new thread and pass in an annonymous function parameter
Thread t = new Thread ( () => Print ("Hello from t!") );
t.Start();
 
static void Print (string message) { Console.WriteLine (message);}

"***********************************************"
"**** Utility_Tasks ****"
"***********************************************"
// Check for disk space
[DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)] 
[return:MarshalAs(UnmanagedType.Bool)] 
public static extern bool GetDiskFreeSpaceEx( 
string lpDirectoryName, 
out long lpFreeBytesAvailable, 
out long lpTotalNumberOfBytes, 
out long lpTotalNumberOfFreeBytes); 
   // or
using System.Management;
ManagementObject disk = new ManagementObject( "win32_logicaldisk.deviceid=\"­c:\""); 
disk.Get(); 
Console.WriteLine(disk["FreeSpace"] );//in bytes 
// Get disk size
Console.WriteLine("Logical Disk Size = " + disk["Size"] + " bytes");

// Example of a union in C#
using System.Runtime.InteropServices;
[StructLayout (LayoutKind.Explicit)]
struct IntTo4ByteConv
{
   [FieldOffset(0)] public uint nVal;  // 4 bytes
   [FieldOffset(0)] public byte byte0;
   [FieldOffset(1)] public byte byte1;
   [FieldOffset(2)] public byte byte2;
   [FieldOffset(3)] public byte byte3;
}

"***********************************************"
"**** XML_functions ****"
"***********************************************"
// Read an XML file using the XmlTextReader. *This is actually a Configuration file that I have used in a Road Safety program.
using System.Xml;
FileStream fs = new FileStream("CellLink.xml", FileMode.Open, FileAccess.Read, FileShare.Read, 100, false);
XmlTextReader ReadSettings = new XmlTextReader(fs);

while(ReadSettings.Read())
{
   if(ReadSettings.NodeType == XmlNodeType.Element)
   {
      if(ReadSettings.Name.Equals("ComPort"))
         szComPortNum = ReadSettings.ReadString();
      
      if (ReadSettings.Name.Equals("UDP_PortNumber"))
         UdpPortNumber = ReadSettings.ReadString();        
   }
}

ReadSettings.Close();
fs.Close();

// Write an XML file using the XmlTextWriter. Note: FileMode.Trundcate will clear the file contents when opened.
fsCellLink = new FileStream("CellLink.xml", FileMode.Truncate, FileAccess.Write, FileShare.None, 100, false);
         
using(fsCellLink)
{
   XmlTextWriter WritePortNum = new XmlTextWriter(fsCellLink, null);
   try
   {
      WritePortNum.Formatting = Formatting.Indented;
      WritePortNum.Indentation = 6;
      WritePortNum.Namespaces = false;
      
      WritePortNum.WriteStartDocument();
      WritePortNum.WriteStartElement("Program_State");
      
      WritePortNum.WriteStartElement("ComPort");
      WritePortNum.WriteString(szComPortNum);
      WritePortNum.WriteEndElement();

      WritePortNum.WriteStartElement("UDP_PortNumber");
      WritePortNum.WriteString(UdpPortNumber);
      WritePortNum.WriteEndElement();
      
      WritePortNum.WriteEndElement();
      WritePortNum.Flush();
   }
   catch(Exception e)
   {
      string error = e.ToString();
   }
   finally
   {
      if (WritePortNum != null)
         WritePortNum.Close();
   }   
}// End using   
// // // // // // // //             

"***********************************************"
"**** Drills ****"
"***********************************************"
Convert bytes to strings, chars, ints

// ***********************************************
Occurrence, disable, successful, successfully, business, previously, Necessary


What are the differnet ways to pass a class to a method?

1) As an out parameter
// Do not have to initialize kittyAsOut before passing to to method
Cat kittyAsOut; // Initialization is optional here

// Compiler error if param not assigned a new ref in method, even if it was already the initialized in calling method.
// Making an assignment to one of it's properties does not satisfy the requirement.
PassInClassWithTheOutParam(out kittyAsOut);


2) As a ref parameter
// Changes the properties of the passed in object
var kittyAsRef1 = new Cat{ Feet = 4, Name = "kittyOrig", Tail = "long" };
PassInClassWithRefParam(ref kittyAsRef1);


var people = nameData.Where(p = > String.Compare(p, "Jimmy") != 0)
.Select(new
{
	Name = p,
	LengthOfName = p.Length,
	HasLongName = p.Length > 5
});
























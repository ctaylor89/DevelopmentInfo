// --- C++\MFC ----- READ_MARK
"CString_functions"
"Convertion_functions"   	
"Dialog_functions"   	
"Dialog_Controls"   	
"File_functions"   	
"Framewrk_functions"   	
"Math_Code"
"Managed_function_calls" // C++/Cli
"Managed_Resources"      // C++/Cli
"MessageBox_calls"
"Project_Specific "
"Time_functions"   	
"Utility_functions"   	
"Win32_functions"   	

"***********************************************"
"**** Convertion_functions ******"   	
"***********************************************"
// Convert a CString into an int 
sprintf(nValue, "%i", csInput);
// or
int nValue = atoi(csInput); 

//********************************************  
// Converts a nibble into a char. nNibbleOrder 
// determines nibble to be processed from the integer nConv.
//********************************************
char NibbleToAlpha(int nConv, int nNibbleOrder)
{
   int ResultChar = '0';
   int nNibble = 0;

   // If processing most significant nibble in byte.
   if(nNibbleOrder == 1)
      nNibble = nConv >> 4;
   else
      nNibble = nConv & 0x0F;

   switch(nNibble)
   {
      case 0:
         ResultChar = '0';         
      break;
      case 1:
         ResultChar = '1';         
      break;
      case 2:
         ResultChar = '2';         
      break;
      case 3:
         ResultChar = '3';         
      break;
      case 4:
         ResultChar = '4';         
      break;
      case 5:
         ResultChar = '5';         
      break;
      case 6:
         ResultChar = '6';         
      break;
      case 7:
         ResultChar = '7';         
      break;
      case 8:
         ResultChar = '8';         
      break;
      case 9:
         ResultChar = '9';         
      break;
      case 10:
         ResultChar = 'A';         
      break;
      case 11:
         ResultChar = 'B';         
      break;
      case 12:
         ResultChar = 'C';         
      break;
      case 13:
         ResultChar = 'D';         
      break;
      case 14:
         ResultChar = 'E';         
      break;
      case 15:
         ResultChar = 'F';         
      break;
   }

   return ResultChar;
}

"***********************************************"
"**** Dialog_functions ******"   	
"***********************************************"
CEdit* pEdit1 = (CEdit*)GetDlgItem(IDC_EDTPASSWORD);
CButton* pBtnInternet = (CButton*)GetDlgItem(IDC_RADIOINTERNET); // check boxes, radio btn, etc.		
CComboBox* pCBVehName = (CComboBox*)GetDlgItem(IDC_COMBOVEHSEL);

 // Update dlg values displayed on dlg.
UpdateData(FALSE);

// From Property page, dissable buttons.
GetParent()->GetDlgItem(IDOK)->Enable(FALSE);
GetParent()->GetDlgItem(ID_APPLY_NOW)->Enable(FALSE);

// Change the displayed Property page.	
CSetupBox* pPropSheet;
pPropSheet = (CSetupBox*)GetParent();
pPropSheet->SetActivePage(1);       	

// Hide a control
GetDlgItem(IDCANCEL)->ShowWindow(SW_HIDE);

// Add color to a dialog box
m_Brush.CreateSolidBrush(RGB(214,184,139)); // In OnInitDialog()
HBRUSH CBoxSettings::OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor)// Handle the WM_CTLCOLOR msg
{
   HBRUSH hbr = CPropertyPage::OnCtlColor(pDC, pWnd, nCtlColor);
   pDC->SetBkColor(RGB(214,184,139));
   return m_Brush;
}

// Enable start btn so that it excepts enter key.
pStartBtn->SetButtonStyle(pStartBtn->GetButtonStyle()&~BS_DEFPUSHBUTTON); // ~ One's comp operator
pStartBtn->EnableWindow(true);
pStartBtn->SetFocus();
pStartBtn->SetState(false);

// Set font of a dialog item
CStatic *lpLabel = (CStatic *)GetDlgItem(IDC_STATIC1);
CFont LabelFont;
LabelFont.CreateFont(20,20,0,0,FW_BOLD,FALSE,FALSE,0,DEFAULT_CHARSET,  OUT_CHARACTER_PRECIS,CLIP_CHARACTER_PRECIS,DEFAULT_QUALITY, DEFAULT_PITCH,NULL);
lpLabel->SetFont(&LabelFont,TRUE);  

// Note: To add an override or event to a dlg derived class, go to class view. R-click, 
// select properties. From properties screen, select overrides or events.
"***********************************************"
"**** Dialog_Controls ******"   	
"***********************************************"
// **** CEdit Box ****
CEdit* pEdit1 = (CEdit*)GetDlgItem(IDC_EDTPASSWORD);

// Get the text value from an edit control
GetDlgItem(IDC_EDITVEHNAME)->GetWindowTextA(m_csVehName);

// Set text into CEdit control
SetDlgItemText(IDC_EDIT_SERNUM, csInput);
 or
pEdit1->SetWindowText(csInput);   
 
pEdit1->SetReadOnly(true);
pEdit1->SetPasswordChar('*'); 
pEdit1->LimitText(g_nVehLen);

m_pEdit->GetWindowText(csText);

// Test input that only numeric chars were entered
for(int iPos = 0, nLen = csText.GetLength(); iPos < nLen; iPos++)
{
	TCHAR c = csText[iPos];
	if(!_istdigit(c))
   {
		MessageBox("Must contain only numeric digits.", "Data Entry Error", MB_OK);
		return;
	}	
}
// Add this code to text box OnChange event to filter input
CString csInput;
pEdit1->GetWindowText(csInput);
// Remove any commas
if(csInput.Find(",", 0) >= 0)
{
   csInput.Replace(",", "");
   pEdit1->SetWindowText(csInput);   
}

// **** ComboBox ****
// Clear the contents of a combo box
pComboSelectName->ResetContent();

// Get or Set the text from or to the 'TEXT FIELD' of a combo box
GetDlgItemText(IDC_COMBOVEHCLASS, csSelClassName);
SetDlgItemText(IDC_COMBOVEHCLASS,csSelClassName);

// Get the selection from a combo box
int nSelIndex = pComboSelectName->GetCurSel();
pComboSelectName->GetLBText(nSelIndex, csSelName);

// Add a string to a combo box and then select it.
int nIndex = pVehClassBox->AddString(csSelClassName);
pVehClassBox->SetCurSel(nIndex);

// Select the item that begins with the specified string.
int nIndex = pmyComboBox->SelectString(0, lpszmyString);

// Remove string from combobox.
nIndex = pVehClassBox->FindString(0, csSelClassName);   
pVehClassBox->DeleteString(nIndex);   

// Make edit field of combobox readonly
CEdit* pEdit = (CEdit*)pCBVehName->GetWindow(GW_CHILD);
pEdit->SetReadOnly(true);

// Limit text lenght in edit field of combobox
pCBVehName->LimitText(g_nVehLen);

// ******** Spin button ********
// Create a spin button next to an edit control
// In properties, set Auto Buddy to true. Set tab order in dlg edit screen
pBtnSpinOvrSpdAlarm = (CSpinButtonCtrl*)GetDlgItem(IDC_SPINOVRSPDALARM);
pBtnSpinOvrSpdAlarm->SetRange32(1,200);

// Handle spin button scroll message (WM_VSCROLL).
void CBoxSettings::OnVScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar) 
{
   // This spin btn control has auto buddy enabled
   if(pScrollBar == (CWnd*)pBtnSpinOvrSpdAlarm)
   {
      // If first time access
      if(nFirstOvrSpdAlarmScrollFlag)
      {
         nFirstOvrSpdAlarmScrollFlag = 0;
         nSpdPos = m_nOvrSpeed;         
         pBtnSpinOvrSpdAlarm->SetPos(nSpdPos);         
      }
      nAdjPos = pBtnSpinOvrSpdAlarm->GetPos32();
      m_nOvrSpeed = nAdjPos;   
   }

   // This spin btn control does not have auto buddy enabled. Edit field updated manually
   if(pScrollBar == (CWnd*)pBtnSpinTimeOut)   
   {
      if(bFirstTmoScrollFlag)
      {
         bFirstTmoScrollFlag = FALSE;
         // Put edit field text into CString. Note: Autobuddy turned Off
         pEditTmo->GetWindowTextA(csTmoValueRef);
         int nValue = atoi(csTmoValueRef);
         // Set spin pos based on edit field value
         int nSpinPos = nValue / 10;
         pBtnSpinTimeOut->SetPos(nSpinPos);
      }
      
      // Get spin btn position and update the edit field display
      int nAdjPos = pBtnSpinTimeOut->GetPos32();
      m_nTimeOut =  nAdjPos * 10;
      csTmoValue.Format("%d", m_nTimeOut);
      pEditTmo->SetWindowTextA(csTmoValue);
   }
   
   UpdateData(FALSE);
 	CPropertyPage::OnVScroll(nSBCode, nPos, pScrollBar);
}

"***********************************************"
"**** Framewrk_functions******"   	
"***********************************************"
#include "MainFrm.h"

// Get a ptr to the doc object.
CMainFrame* pFrame = (CMainFrame*)AfxGetApp()->m_pMainWnd;
CTeenAppDoc* pDoc = (CTeenAppDoc*)pFrame->GetActiveDocument();
// From the CView class call GetDocument() to get a ptr to the doc object.:
CTeenAppDoc* pDoc = (CTeenAppDoc*)GetDocument(); 
// Close a current application
AfxGetMainWnd()->PostMessage(WM_CLOSE);
// or
this->pFrame->CloseApp();
// or
AfxGetMainWnd()->PostMessage(WM_QUIT);

// To control min and max window size of main window, add this msg handler to CMainFrame message map 
MESSAGE_HANDLER(WM_GETMINMAXINFO, OnGetMinMaxInfo)
LRESULT OnGetMinMaxInfo(UINT, WPARAM, LPARAM lParam, BOOL&)
{ // load size structure with lParam values
  LPMINMAXINFO lpMMI = (LPMINMAXINFO)lParam;
  // change values in size structure to desired values
  lpMMI->ptMinTrackSize.x = 200; // min width
  lpMMI->ptMinTrackSize.y = 150; // min height
  lpMMI->ptMaxTrackSize.x = 600; // max width
  lpMMI->ptMaxTrackSize.y = 450; // max height
  return 0; 
}

// Changing the menu text using the ON_UPDATE_COMMAND_UI handler
void CFrameWnd::OnUpdateToolbar(CCmdUI* pCmdUI) 
{
    BOOL bVisible = IsToolbarVisible(...);
    pCmdUI->SetText(bVisible ? "Hide &Toolbar" : "Show &Toolbar"); 
} 
 
"***********************************************"
"**** MessageBox_calls ******"   	
"***********************************************"
AfxMessageBox("");
MessageBox(NULL,"", "CAPTION", MB_OK);
MessageBox("Unable to apply changes.", "Setup Error", MB_OK);
MessageBox("Help, Something went wrong.", "Error", MB_ICONERROR | MB_OK);
MessageBox("Unable to apply changes.", "Setup Error", MB_YESNOCANCEL );
int nRet = MessageBox("", "Information", MB_YESNO);
if(nRet == IDYES)

MessageBox("Unable to apply changes.", "Setup Error", MB_RETRYCANCEL );		
MB_SYSTEMMODAL MB_TASKMODAL MB_ICONEXCLAMATION MB_ICONINFORMATION MB_ICONQUESTION 
MB_ICONSTOP MB_DEFBUTTON1 MB_DEFBUTTON2 or MB_DEFBUTTON3 

"***********************************************"
"**** Win32_functions ******"   	
"***********************************************"
HCURSOR OrigCursor = SetCursor(LoadCursor(NULL, IDC_WAIT)); 
SetCursor(OrigCursor);

// // // Create a Thread Example // // // 
CEvent TransEvent;  // Declare in header	
// Declare in header outside of class declaration
static DWORD WINAPI DownLoadDataThrdProc(CDataStream* pDataStream);
HANDLE   hThread;   // Declare in calling procedure
DWORD ThreadID;     // Declare in calling procedure  

hThread = CreateThread(NULL,0,(LPTHREAD_START_ROUTINE)DwnLdThrdProc,this, 0,&ThreadID);
if (hThread == NULL) 
{
   MessageBox( NULL, "Thread failed.", "Error", MB_OK | MB_SYSTEMMODAL );
}

// Thread procedure implementation
DWORD WINAPI DownLoadDataThrdProc(CDataStream* pDataStream)
{
   ...
   // Notify main thread this thread is ending
   pDataStream->TransEvent.SetEvent();
	return 1;
}
// // // // // // // // // // // // // // 
   
"***********************************************"
"**** CString_functions ******"   	
"***********************************************"
// Parse string with tab delimiters.
CString csTagData("3456\tFDriver_A\tLDriver_A\tEMP201234567\tGRP201234567\tBUID01234567");

int nNextTabLoc = csTagData.FindOneOf("\t");
int nPrevLoc = nNextTabLoc + 1;
csSecretNum = csTagData.Mid(0,nNextTabLoc);

nNextTabLoc = csTagData.Find("\t",nPrevLoc);   
int nNumChars = nNextTabLoc - nPrevLoc;
csFName = csTagData.Mid(nPrevLoc,nNumChars);
nPrevLoc = nNextTabLoc + 1;
// // // 
// Finds the last location(0 based start from begin) of the specified char
// Similar to the run-time function strrchr
int nStartEmpNumLoc = csSelDriver.ReverseFind('.');
// // // 
// Grab the right 13 chars of the string
CString csSub = csDrvFile.Right(13);
// Grab the first 3 chars and 2 chars at the 5th position
CString csMonthYr = csSub.Left(3) + csSub.Mid(5, 2);
// // // 
// Check for correct file type by looking at extension
CString csFileChk = csFilePath.Right(csFilePath.GetLength() - csFilePath.ReverseFind('.'));
if(csFileChk != ".rsf" && csFileChk != ".rsfdb")
// // // 
// Copy a CString to an array.
char szTagData[128];
strcpy(szTagData, csTagInfo.GetBuffer());
csTagInfo.ReleaseBuffer();
// Or copy an array to a CString
strcpy(csTagInfo.GetBuffer(20), szTagData);
csTagInfo.ReleaseBuffer();
// Or assign an array to a CString
CString csInputName = pDoc->SetUpData.szDigital1; // szDigital1[13]

// Convert CString to double and back again
double dOdom = atof(m_csOdometer);
m_csOdometer.Format("%0.1f", dOdom);

"***********************************************"
"**** File_functions ******"   	
"***********************************************"
// Create, open and write to a file
FILE *pTxtFile;
pTxtFile = fopen(m_csDataFilePath + "Devdata1.Txt", "w");
if(pTxtFile != NULL)
{
   nByteCnt = fwrite(rxRec, sizeof(char), strlen(rxRecord), pTxtFile);
   fclose(pTxtFile);
}

// Create and open a CFileDialog
char szFileNamesToOpen[1024] = ""; // Buffer to hold multiple file names
CFileDialog FlDlg(TRUE, "rsf", NULL, OFN_NOCHANGEDIR | OFN_FILEMUSTEXIST | OFN_PATHMUSTEXIST | OFN_ALLOWMULTISELECT | OFN_HIDEREADONLY,
         "Unit Download Files (*.rsf)|*.rsf|All Files (*.*)|*.*||", AfxGetApp()->m_pMainWnd);

FlDlg.m_ofn.lpstrInitialDir = "..\\RS-2000\\DataFiles\\";
FlDlg.m_ofn.lpstrFile = szFileNamesToOpen;
FlDlg.m_ofn.nMaxFile = 1024;
int nRet = FlDlg.DoModal(); 

switch(nRet)
{
	case -1: 
		AfxMessageBox("Dialog box could not be created!");
      break;
	case IDABORT:
   case IDCANCEL:
      return;
   break;
}

POSITION FilePos = FlDlg.GetStartPosition();
while(FilePos != NULL)
{
   csFilePath = FlDlg.GetNextPathName(FilePos);
   ...
}

// Get full path of current program.
char szCurrentDir[MAX_PATH + 1]; 
GetCurrentDirectory(MAX_PATH, szCurrentDir); 

// Use \r\n to append a line to a text file
csDataStr = "---------------------\r\n";

// Check if a Path Exists
if(PathFileExists(csCopyTo) != true){};
// Rename a file
nRet = rename(csTargetFilePath, csSourceFileName);
if(nRet != 0)
{
   pErrmsg = strerror(errno); // Char* pErrmsg; errno is a global system variable
   csMsg.Format("Unable to add 'db' ext to file. %s  Continue?", pErrmsg);
}

"***********************************************"
"**** Time_functions ******"   	
"***********************************************"
// Get current time.
time_t time_tCurrent;
time(&time_tCurrent);
 or
CTime ct_ReportDate = CTime::GetCurrentTime();
csReportDate = ct_ReportDate.Format("%m/%d/%y at %I:%M:%S %p");
// // // 
// Initialize a Ctime variable and a ptr
CTime CheckTm(nYear, nMonth, nDay, 0, 0, 0, -1);
CTime *pctCheckTm = new CTime(nYear, nMonth, nDay, 0, 0, 0, -1);
// Add 1 day, 1 hour to a Ctime variable
*pctCheckTm += CTimeSpan( 1, 1, 0, 0 );
csCheckTm = pctCheckTm->Format("%m/%d/%y  %H:%M:%S");
// Compare CTime objects
if(ctCurrentTm > ctExpirationTm)
// Convert CTime to time_t
time_tRFCard = ct_AdjBoxTm.GetTime();
// Get a tm string from a time_t variable
CTime ct_StrtTm = time_tStart; 
csStartTm = ct_StrtTm.Format("%H:%M:%S");

"**********************************************"
"**** Utility_functions ******"   	
"***********************************************"
// File open for read and again for write 
FILE *pTxtFile = NULL;
long nLen = 255;
char szIniPath[nLen];
pTxtFile = fopen("c:\\FMInstal\\FMpath.ini", "r");
if(pTxtFile == NULL)
   return 1;
   
// Read the path information
memset(szIniPath, 0, nLen);
int nRetNumRead = fread(szIniPath, sizeof(char), nLen, pTxtFile);
if(nRetNumRead < 1)
   return 2;

fflush(pTxtFile);
   
fclose(pTxtFile);
pTxtFile = NULL;   
         
// Write path to local ini file
// Open local ini file
pTxtFile = fopen("FMpath.ini", "w");
if(pTxtFile == NULL)
   return 3;
   
// Write path information to local ini file
nLen = strlen(szIniPath);
nRetNumRead = fwrite(szIniPath, sizeof(char), nLen, pTxtFile);
if(nRetNumRead < 1)
   return 4;

csIniFilePath.Format("%s", szIniPath);

fclose(pTxtFile);   
pTxtFile = NULL;   

// Copy file to target directory with new name
int nRet = CopyFile(csSourceFile, csNewTargetFile, FALSE);

// Function to get and display Latest Error Msg
int GetLatestError()
{
   LPVOID lpMsgBuf;
   TCHAR szBuf[200]; 
   
   DWORD dw = GetLastError(); 
   
   if(dw = 122)
      strcpy(szBuf, "Out of Disk Space");
   else
   {         
      FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER |  FORMAT_MESSAGE_FROM_SYSTEM, NULL, dw,
               MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),(LPTSTR) &lpMsgBuf, 0, NULL );

      wsprintf(szBuf, "Failed with error %d: %s", dw, lpMsgBuf); 
   }
   
   MessageBox(NULL, szBuf, "Error", MB_OK); 
   LocalFree(lpMsgBuf);
   return 0;
}

"**********************************************"
"**** Project_Specific ******"   	
"***********************************************"
char szTst[80];      

if(pMainFrame->bShowS2DATA)
{
   strcpy(szTst,"DownloadBoxDataRF() called\n");
   pTxtFile = fopen("DebugRS2100.Txt", "w");
   fwrite(szTst,  sizeof(char), strlen(szTst), pTxtFile);
   fclose(pTxtFile);
}

// ***********************************************
// Execute a program from a program
SHELLEXECUTEINFO info; 
::ZeroMemory(&info,sizeof(info)); 
info.cbSize = sizeof(info); 
info.fMask = SEE_MASK_NOCLOSEPROCESS; 
info.lpFile = "..\\RS-2000\\mysql\\bin\\MySqld.exe"; 
info.lpParameters = args; 
info.nShow = SW_HIDE; // Hide the console window

ShellExecuteEx(&info); 
if ((long)info.hInstApp <= 32) 
   MessageBox("Unable to start database server.", "Startup Error", MB_OK);
else 
   // Wait until the program is finished 
   ::WaitForSingleObject(info.hProcess,INFINITE); 
// *** OR
STARTUPINFO si;
PROCESS_INFORMATION ProcInfoStruct;
ZeroMemory( &si, sizeof(si) );
si.cb = sizeof(si);
ZeroMemory( &ProcInfoStruct, sizeof(ProcInfoStruct) );
// Start the DB Server. 
try{CreateProcess( "..\\RS-2000\\mysql\\bin\\MySqld.exe",NULL,NULL,NULL,FALSE,0,NULL,NULL,&si,&ProcInfoStruct);}
catch(...)
   MessageBox("Unable to start database server.", "Startup Error", MB_OK);

// Close process and thread handles. 
CloseHandle( ProcInfoStruct.hProcess );
CloseHandle( ProcInfoStruct.hThread );

// ***********************************************
// Get screen resolution and set window size from
// InitInstance() in App class. Could also use AfxGetApp()   
CDC *pDc = this->GetMainWnd()->GetDC();
int nXRes = GetDeviceCaps(*pDc,HORZRES);
if(nXRes < 1024)   
   m_pMainWnd->ShowWindow(SW_SHOWMAXIMIZED);
      
// ***********************************************
// A simple function to convert a HEX string to an integer:
long int FAR PASCAL hex2int(char far *s)
{
   return strtol(s,NULL,16);
}

// Parse a char array to a double value
fStartODM = strtod(VehSettings.szOdom, NULL);                 

// Round off the floating point result to within 2 digits to right of decimal. 
double Input = .17400190098;
double d_expo = Input * 100;
int nPercent = (int)(d_expo);
double fAdj = 10 * (d_expo - nPercent);
if(fAdj > 5.0) // Greater than 50%
  nPercent++;

double fRes1 = nPercent * 0.010000001; // The last one prevents close values like .169999999
                                       // from occuring
// Compare two floating point values
if((fLftRghtForceWarn - fLRFrcGrace) > fabs(0.001))
"***********************************************"
"**** C++ Language ******"   	
"***********************************************"
// Test for remainder
if((nLineCnt % 5) == 0)

// Get the 2's compliment of a number
int nTest = ~nTest + 1;

//**** Language constructs******   	
switch()
{
   case 1:
   {
    ;
   }   
   break;
}

// Debug statements
TRACE0("Failed to create DlgBar\n");
TRACE("pScreen.y = %d\n", g_nScrollYPos);   

CString cstestpos;
cstestpos.Format("%d",nMemDataPos);
CWnd* ptestpos = (CWnd*)GetDlgItem(IDC_STATICTEST);
ptestpos->SetWindowText(cstestpos);   

void CMyScrollView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
 CPoint p(GetScrollPosition());
 switch (nChar) {
 case VK_NEXT:
  p.y += PAGE_SIZE_YOU_DEFINED;
  break;
 case VK_PRIOR:
  p.y -= PAGE_SIZE_YOU_DEFINED;
  break;
 // Other cases, analogue to this (VK_HOME, VK_END...)
 }
 ScrollToPosition(p);
 CScrollView::OnKeyDown(nChar, nRepCnt, nFlags);
}
"***********************************************"
"**** Math_Code ******"   	
"***********************************************"
// Foating point
// Wrong: Result is zero with int numerator, cast numerator to float or double
float fPercResult = nInput1/4294967296;
// Divide and discard remainder
int nNumRecStructs = nGPSEvtCnt / 60;
// Get only the remainder
nNumRecStructs = nGPSEvtCnt % 60;
// Compare two floating point values for equality
if(fabs(fMaxLftRghtForce - fLeftRightForce) > 0.001){}

// Perform scientific notation on an int and return a double
double CDataStream::Powers(int nNum, int nPower)
{
   double dResult = nNum;
   
   for(int i = 0; i < nPower -1; i++)
      dResult *= nNum;
   
   return dResult;
}
"***********************************************"
"**** Managed_function_calls ******"
"***********************************************"
// Access the C# dll component from C++ application (C++/cli)
#using "C:/Program Files/Road Safety/RS-2100/CSDBControl.dll"
CSqlDBAccess^ hndlDB = gcnew CSqlDBAccess();
CVehSettings^ pcsVehClass = gcnew CVehSettings();
// Call function in dll
pcsVehClass->DllFunction(MyParameter);
delete pcsVehClass; // To call Dispose()

// Pass a CString argument to a managed function
pcsUtility->SetDataFileDir(gcnew String(csPath));
// Copy a CString instance to a managed string instance
csVehClass->VehSettings.szOdom = gcnew String(csConvert);
// Declare an instance of a managed string
System::String^ ClassNameDB;

// Create and display a managed form. Add a value to it
SettingsDifFrm^ pSetDifFrm = gcnew SettingsDifFrm();
pSetDifFrm->ClassName = gcnew String(csFileHdrClassName);
pSetDifFrm->SetBounds(400, 600, 408, 130);
Windows::Forms::DialogResult DlgRes = pSetDifFrm->ShowDialog();

// User does not want to change class settings in database
if(DlgRes == Windows::Forms::DialogResult::Cancel)

// http://www.codeproject.com/KB/mcpp/C___CLI_Primer.aspx
"***********************************************"
"**** Managed_Resources ********"
"***********************************************"
// Embedding a managed class in an unmanaged class
#include <msclr\auto_gcroot.h>              // In Header file
msclr::auto_gcroot<CDBReports^> pDBReports; // In unmanaged class declaration in header file
pDBReports = gcnew CDBReports;              // In implementation
pDBReports->GetDrvSumryDB();                // In use
// http://schemas.stylusstudio.com/msoffice2003/n20135ca/element_Cell.html
"***********************************************"
"**** Syntax ******"   	
"***********************************************"
// This statement
const BOOL bShortBlox = ProtType == R.P_CRC;
// can be rewritten as
if(ProtType == R.P_CRC)
   bShortBlox = true;
else
   bShortBlox = false;      
// This shorthand if/else statement 
BlockSizT = BlockSizR = bShortBlox ? SHRTBLOCKSIZE : LONGBLOCKSIZE;
// can be rewritten as
if(bShortBlox)
   BlockSizT = BlockSizR = SHRTBLOCKSIZE;
else
   BlockSizT = BlockSizR = LONGBLOCKSIZE;

// These are the same
shift>>=1;  shift = shift >> 1;


"***********************************************"
"**** Registry Functions ******"   	
"***********************************************"
// ********************************************************
// SetConnectType()   Example of setting a value in registry
// ********************************************************
void CMainFrame::SetConnectType()
{
   HKEY hTopKey = NULL, hKeyBSConfig = NULL;
   DWORD dwDispostion;
   DWORD dwBufLen = MY_BUFSIZE;
   char TopKeyName[] = "Software\\PRD3";   
      
   // Open top level sub key "Software\\PRD3"
   if(::RegOpenKeyEx(HKEY_CURRENT_USER, TopKeyName, 0, KEY_WRITE, &hTopKey) != ERROR_SUCCESS)
   {
      MessageBox("Unable to apply changes to registry. (Error MBSC04)", "Setup Error", MB_OK);
      return;
   }

   char BSConfigKeyName[] = "BSConfig"; 
   // Open next level sub key "BSConfig"
   if(::RegOpenKeyEx(hTopKey, BSConfigKeyName, 0, KEY_WRITE, &hKeyBSConfig) != ERROR_SUCCESS)
   {
      MessageBox("Unable to apply changes to registry. (Error MBSC05)", "Setup Error", MB_OK);
      return;
   }

   // Get the connection flag value if it exists.
   int nUSBConnectEnbled = 0;
   DWORD *pdwUSBFlag = new DWORD(1); // Default value for USB
   DWORD dwUSBType = REG_DWORD;

   if(nBSUSBFlag)
      pdwUSBFlag = new DWORD(1); // Value for USB
   else   
      pdwUSBFlag = new DWORD(0); // Value for RF
      
   if(::RegSetValueEx(hKeyBSConfig, "BoxConnect", 0, REG_DWORD, (LPBYTE)pdwUSBFlag, sizeof(int))
                  != ERROR_SUCCESS)
   {
      MessageBox("Unable to apply changes to registry. (Error BCUSB 01)", "Setup Error", MB_OK);
      delete pdwUSBFlag;
      return;
   }
   
   if(hKeyBSConfig)
      ::RegCloseKey(hKeyBSConfig);

   ::RegCloseKey(hTopKey);
	delete pdwUSBFlag;
}





HKEY hKeyPath;
DWORD dwDisposition; 
char szInstallPath[MAX_PATH];
DWORD dwBufLen = MAX_PATH;
LONG lRet;

// Open Vehicle sub key if present,otherwise create.
char szSubkey[] = "Software\\RS1000Path";
if(::RegCreateKeyEx(HKEY_LOCAL_MACHINE, szSubkey, 0, "", REG_OPTION_NON_VOLATILE,
            KEY_ALL_ACCESS, NULL, &hKeyPath, &dwDisposition) != ERROR_SUCCESS)
{
   MessageBox(NULL, "Unable to create RS1000Path subkey in registry.", "Setup Error", MB_OK);
}
else
{
   // Read value to see if exists
   lRet = RegQueryValueEx(hKeyPath,"InstallPath",NULL,NULL,(LPBYTE)szInstallPath,&dwBufLen);
   if(lRet != ERROR_SUCCESS)   
   {
      // Try creating the value that does not exist
      if(::RegSetValueEx(hKeyPath,"InstallPath",0,REG_SZ,(LPBYTE)szCurrentDir,strlen(szCurrentDir) + 1)
                  != ERROR_SUCCESS)
      {
         MessageBox(NULL, "Unable to set value in RS1000Path subkey. (RSP 1)", "Setup Error", MB_OK);
      }
      
      return  TRUE; // New value set 
   }
   
   // Compare cur dir with reg path
   if(strcmp(szInstallPath, szCurrentDir))
   {
      // Set new value since different than current
      if(::RegSetValueEx(hKeyPath,"InstallPath",0,REG_SZ,(LPBYTE)szCurrentDir,strlen(szCurrentDir) + 1)
                  != ERROR_SUCCESS)
      {
         MessageBox(NULL, "Unable to set value in RS1000Path subkey. (RSP 2)", "Setup Error", MB_OK);
         return  TRUE;
      }          
   }
}

::RegCloseKey(hKeyPath);
// ***********************************************
   //char szTopkey[] = "Software\\PRFX";
   //HKEY hTopKey;
   //DWORD dwDispostion;
   //CHAR     achKey[MAX_PATH]; 
   //FILETIME ftLastWriteTime;      // last write time 
   //
   //// pComboSelectName
   //if(::RegOpenKeyEx(HKEY_CURRENT_USER, szTopkey, 0, KEY_QUERY_VALUE, &hTopKey) != ERROR_SUCCESS)
   //{
   //   MessageBox("Unable to open user information keys", "Setup Error", MB_OK);
   //   return 0;
   //}
   //      
   //// Enumerate user keys, until RegEnumKeyEx fails.  
   //// Get the name of each key and copy it into list box. 
   //for (i = 0, retCode = ERROR_SUCCESS; retCode == ERROR_SUCCESS; i++) 
   //{ 
   //   retCode = RegEnumKeyEx(hTopKey, i, achKey, &ulSizeBuf, NULL, 
   //                  NULL, NULL, &ftLastWriteTime); 
   //   if (retCode == (DWORD)ERROR_SUCCESS) 
   //   {
   //      nNumKeys++;
   //      // Add to list box.
   //      csKeyName = achKey;
   //      
   //      
   //      // Get the most recent vehicle name.
   //      lRet = RegEnumValue(hKeyVehicle, 0, achValueName, &cchValueSize,NULL,NULL,(LPBYTE)szValue,&dwSize); 
   //      if (lRet == (DWORD) ERROR_SUCCESS && lRet != ERROR_INSUFFICIENT_BUFFER) 
   //      { 
   //         CString csValue = szValue;
   //         strcat(subkeyVeh, "\\");   
   //         strcat(subkeyVeh, csValue);         
   //      }
   //      
   //      // nIndex = pLB->AddString(csKeyName);
   //         
   //      if(nIndex == CB_ERR)
   //         break;
   //   }
   //
   //   // if(nNumKeys > 1)
   //      // pLB->ShowWindow(TRUE);
   //   
   //   ulSizeBuf = MY_BUFSIZE;
   // }  


// *******************************************************************
// ********* project notes and other useful information **************
// *******************************************************************

using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.IO;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Diagnostics; // For Processes
using System.IO.Ports;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.ServiceProcess;
using System.Data.SqlClient;   // Provider for connecting to SQL Database
using System.Net.Mail;
// For xml transformation to Excel
using System.Xml;
using System.Xml.Xsl;
using System.Linq;
using System.Text.RegularExpressions;

namespace FormSmp1
{
   public unsafe partial class Form1 : Form
   {
      public byte [] VehicleName = new byte[16];
      private string AdminPwdFileName = "Adpwd.ini";

      // Delegate with parameters practice
      delegate int delGetNewNum(int val);
      delegate int delMakeNum(int val);
      delegate bool delBiggerThan(int n, string s);

           
      public Form1()
      {
         InitializeComponent();
      }

      // Use this override to capture key presses
      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         // if(keyData.ToString() == "F5")
            // MessageBox.Show(keyData.ToString());
         return base.ProcessCmdKey(ref msg, keyData);
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         string name = System.Windows.Forms.SystemInformation.ComputerName;

         // ConvertTime();
         // ConvertNumericValues();
         // ReadS2Rec();
         // Miscpractise();

         // Writes and encrypts bytes
         // ConvertStringToBytes();
         // WriteStringToBytesToFile();  
         // BtyesToString();         
         // WriteTextToFile();
         // Reads and decrypts bytes
         // ReadBytesFromFileToString();
         // FilePrac();         
         // CheckIfAppRunning();
         
         // GetDirectoryFileNames();
         // GetDirInfo();
         // GetDriveInfo();
         
         
         // ParseString();
         // FormatStrings();
         // CompareStrings();
         // NullableExample();
         // ArrayTest();
         // ParamPassingTest();
         
         // ReadVehFile();
         // CopyProgToTempFile();
         // InterfaceTest();
         
         // XMLSerialization();         
         // SingletonExample();
         
         // ******* Configuration *******
         // ConfigAppSettings(); 
         // ConfigFileModify(@"C:\Program Files\Road Safety\RS-2100\RS2100.exe.Config");
         // DataViewPrac();

         // CSharp3();
         // LinqQuerys();
         // ExtensionMethods();
         // StartStopService();
         // AssignReferencesTest();
         // ManualSerialize();

         // ******* Database *******
         // ConnectToDB();         
         
         // Convert string to bytes
         Encoding encodingUTF8 = Encoding.UTF8;
         Byte[] arrOutData = encodingUTF8.GetBytes("103001M20391");
         Byte bt = arrOutData[0];
         
         int [] myarray = new Int32[3]{2,3,4};
         int[] myarray2 = new Int32[3] { 12, 13, 14 };
         List<int> mylist = new List<int>(myarray);
         mylist.AddRange(myarray2);
         
         // // // // 
         int n = 0;
         object ob = n;
         n = (int)ob;

         byte b = 73; // test value
         byte t = 1;
         byte chk = 0;

         for (t = 1; t != 0; t <<= 1)
         {
            chk = (byte)(b & t);
            if ((b & t) > 0) 
               break;
         }

         byte r = t;
         // // // 

         List<byte> ListOne = new List<byte>(){0x22, 0x23, 0x45, 0x55};
         List<byte> ListTwo = new List<byte>();

         ListTwo.AddRange(ListOne);
         return;
      }
      
      /// <summary>
      /// Demonstrate the conversion of numeric types
      /// </summary>
      private void ConvertNumericValues()
      {
         // Decimal to ushort(truncates the decimal portion)
         Decimal dec = 500.7M;
         ushort usht = 0;
         usht = (ushort)dec;

         dec = 3125.3M;
         usht = (ushort) dec;

         // This over flow value will cause an exception if caught otherwise function exits.
         dec = 83125.3M;

         // Can use either of these methods
         // usht = (ushort)dec;
         // usht = Convert.ToUInt16(dec);

         // Float to int(truncates the decimal portion)
         float flt = 458.9f;
         int int_result = (int) flt;

         return;
      }

      private void ManualSerialize()
      {
         UInt16 Version = 5000;
         UInt16 Size = 0;

         var settingsStream = new MemoryStream();
         BinaryWriter writer = new BinaryWriter(settingsStream);
         writer.Write(Version);
         //writer.Write(settingsHeaderSize);
         //writer.Write(Class_Name);
         //writer.Write(Vehicle_Name);

         //writer.Write();
         //writer.Write();
         //writer.Write();
         //writer.Write();
         //writer.Write();
         writer.Close();
         long count = settingsStream.Length;
         List<byte> test = new List<byte>(settingsStream.ToArray());
      }

// S2 24 34AEA0 C620068592CE040A0717168697CC4263068592CE040A0712168697CCE6530685 E3
      private void ReadS2Rec()
      {
         int S2RecLen = 0, DataVal = 0, nPageCnt = 0;
         List<byte> listData = new List<byte>(375);
         String LineIn = "";
         StringBuilder sbCharIn = new StringBuilder();

         // Read the contents of the S record file
         using (StreamReader srInput = File.OpenText("boxt34.s28"))
         {
            while ((LineIn = srInput.ReadLine()) != null)
            {
               // If not an S2 record, skip it
               if (LineIn[1] != '2')
                  continue;

               // Get the length of bytes in this S-Record
               // Convert two length chars to an int value
               sbCharIn.Append(LineIn[2]);
               // string strtest = sbCharIn.ToString();
               S2RecLen = AlphaToInt(sbCharIn.ToString()) * 0x10;
               sbCharIn.Length = 0;
               sbCharIn.Append(LineIn[3]);
               S2RecLen += AlphaToInt(sbCharIn.ToString());
               sbCharIn.Length = 0;

               // S2 24 348000 0680680690D20690EA8707FA811B27013D141016813CFDFFFE05401691193D7223

               // Read each byte of data(represented by 2chars). Do not incude address and chksum(4 bytes)
               for (int i = 0, RecIndx = 10; i < S2RecLen - 4; i++)
               {
                  sbCharIn.Append(LineIn[RecIndx++]);
                  DataVal = AlphaToInt(sbCharIn.ToString()) * 0x10;
                  sbCharIn.Length = 0;
                  sbCharIn.Append(LineIn[RecIndx++]);
                  DataVal += AlphaToInt(sbCharIn.ToString());
                  sbCharIn.Length = 0;

                  // Add each byte of data to list
                  listData.Add((byte)DataVal);
                  DataVal = 0;
               }
            }
         }

         // Copy data to a byte array
         // DataToSend = new byte[listData.Count];
         // listData.CopyTo(DataToSend);
         
         int SendIndex = 0;
         string strOut = "";
         
         // Number of data bytes that are not padding
         int nBytesToSend = listData.Count;

         // Create output file
         using (StreamWriter swOutPut = File.CreateText("boxt34Output.txt"))
         {
            swOutPut.WriteLine("Total Byte count: " + listData.Count.ToString());

            // Write 512 byte blocks to file until we have none left to send
            while (nBytesToSend > 0)
            {
               if (nBytesToSend >= 512)
               {
                  nBytesToSend -= 512;

                  // Send 16 rows of 32 bytes
                  for (int SentCnt = 0; SentCnt < 512; SentCnt += 0x20)
                  {
                     // Write a row of 32 bytes (32 * 16 = 512)
                     for (int i = 0; i < 0x20; i++)
                     {
                        // Format values for display then write them to file
                        strOut = (listData[SendIndex] & 0xF0).ToString("X");
                        swOutPut.Write(strOut[0]);

                        strOut = (listData[SendIndex++] & 0x0F).ToString("X");
                        swOutPut.Write(strOut[0]);
                        swOutPut.Write(' '); // space

                        if (SendIndex == listData.Count)
                           break;
                     }

                     // Display 32 bytes per line
                     swOutPut.Write("\r\n");
                  }   
               }
               else // Write remaining bytes with padding
               {
                  // Counter to determine how much padding will be needed
                  int nSendLast512Pkt = 0;
                  
                  // While still enough bytes to write whole rows 
                  while (nBytesToSend >= 32)
                  {
                     nBytesToSend -= 32;
                     nSendLast512Pkt += 32;

                     for (int i = 0; i < 32; i++)
                     {
                        // Format values for display then write them to file
                        strOut = (listData[SendIndex] & 0xF0).ToString("X");
                        swOutPut.Write(strOut[0]);

                        strOut = (listData[SendIndex++] & 0x0F).ToString("X");
                        swOutPut.Write(strOut[0]);
                        swOutPut.Write(' '); // space

                        if (SendIndex == listData.Count)
                           break;
                     }

                     // Display 32 bytes per line
                     swOutPut.Write("\r\n");
                  }

                  // If still some odd bytes to send(will be less than 32)
                  if (nBytesToSend > 0)
                  {
                     // We now have less than a row of data to send
                     // Send rows of 32 bytes till last 512 byte packet sent
                     for (; nSendLast512Pkt < 512; nSendLast512Pkt += 32)
                     {
                        // Write a row of 32 bytes
                        for (int i = 0; i < 32; i++)
                        {
                           if (nBytesToSend > 0)
                           {
                              // Format values for display then write them to file
                              strOut = (listData[SendIndex] & 0xF0).ToString("X");
                              swOutPut.Write(strOut[0]);

                              strOut = (listData[SendIndex++] & 0x0F).ToString("X");
                              swOutPut.Write(strOut[0]);
                              swOutPut.Write(' '); // space
                              nBytesToSend--;
                           }
                           else
                           {
                              swOutPut.Write("FF");
                              swOutPut.Write(' '); // space
                           }
                        }

                        // Display 32 bytes per line
                        swOutPut.Write("\r\n");
                     }
                  }  
               }
               swOutPut.WriteLine();
               swOutPut.Write("********* End of 512 byte block ************");
               swOutPut.WriteLine();
               nPageCnt++;
            }// End while (nBytesToSend > 0)
            
            swOutPut.WriteLine("Total page count: " + nPageCnt.ToString());
         }// End using()

         return;
      }
      
      //private void ReadS2Rec()
      //{
      //   int S2RecLen = 0, DataVal = 0, nPageCnt = 0;
      //   List<byte> listData = new List<byte>(375);
      //   byte [] DataToSend = null;
      //   String LineIn = "";
      //   StringBuilder sbCharIn = new StringBuilder();

      //   // Read the contents of the S record file
      //   using (StreamReader srInput = File.OpenText("boxt34.s28"))
      //   {
      //      while ((LineIn = srInput.ReadLine()) != null)
      //      {
      //         // If not an S2 record, skip it
      //         if (LineIn[1] != '2')
      //            continue;

      //         // Get the length of bytes in this S-Record
      //         // Convert two length chars to an int value
      //         sbCharIn.Append(LineIn[2]);
      //         // string strtest = sbCharIn.ToString();
      //         S2RecLen = AlphaToInt(sbCharIn.ToString()) * 0x10;
      //         sbCharIn.Length = 0;
      //         sbCharIn.Append(LineIn[3]);
      //         S2RecLen += AlphaToInt(sbCharIn.ToString());
      //         sbCharIn.Length = 0;

      //         // S2 24 348000 0680680690D20690EA8707FA811B27013D141016813CFDFFFE05401691193D7223
               
      //         // Read each byte of data(represented by 2chars). Do not incude address and chksum(4 bytes)
      //         for (int i = 0, RecIndx = 10; i < S2RecLen - 4; i++)
      //         {
      //            sbCharIn.Append(LineIn[RecIndx++]);
      //            DataVal = AlphaToInt(sbCharIn.ToString()) * 0x10;
      //            sbCharIn.Length = 0;
      //            sbCharIn.Append(LineIn[RecIndx++]);
      //            DataVal += AlphaToInt(sbCharIn.ToString());
      //            sbCharIn.Length = 0;

      //            // Add each byte of data to list
      //            listData.Add((byte)DataVal);
      //            DataVal = 0;
      //         }
      //      }
      //   }
         
      //   // Copy data to a byte array
      //   DataToSend = new byte[listData.Count];
      //   listData.CopyTo(DataToSend);
         
      //   int SendIndex = 0;
      //   string strOut = "";
      //   // Number of data bytes that are not padding
      //   int nBytesToSend = listData.Count;
         
      //   // Create output file
      //   using (StreamWriter swOutPut = File.CreateText("boxt34Output.txt"))
      //   {
      //      swOutPut.WriteLine("Total Byte count: " + DataToSend.Length.ToString());
            
      //      // Write 512 byte blocks to file until we have less than 512 bytes to send
      //      while (nBytesToSend >= 512)
      //      {
      //         nBytesToSend -= 512;

      //         // Send 16 rows of 32 bytes
      //         for (int SentCnt = 0; SentCnt < 512; SentCnt += 0x20)
      //         {
      //            // Write a row of 32 bytes (32 * 16 = 512)
      //            for (int i = 0; i < 0x20; i++)
      //            {
      //               // Format values for display then write them to file
      //               strOut = (DataToSend[SendIndex] & 0xF0).ToString("X");
      //               swOutPut.Write(strOut[0]);

      //               strOut = (DataToSend[SendIndex++] & 0x0F).ToString("X");
      //               swOutPut.Write(strOut[0]);
      //               swOutPut.Write(' '); // space
                     
      //               if(SendIndex == listData.Count)
      //                  break;
      //            }

      //            // Display 32 bytes per line
      //            swOutPut.Write("\r\n"); 
      //         }
               
      //         swOutPut.WriteLine();
      //         swOutPut.Write("********* End of 512 byte block ************");
      //         swOutPut.WriteLine();
      //         nPageCnt++;
      //      }

      //      // Counter to determine how much padding will be needed
      //      int nSendLast512Pkt = 0;
            
      //      // We now have less than a 512 block so write remaining whole rows
      //      while (nBytesToSend > 0)
      //      {
      //         // While still enough bytes to write whole rows 
      //         while (nBytesToSend >= 32)
      //         {
      //            nBytesToSend -= 32;
      //            nSendLast512Pkt += 32;
                  
      //            for (int i = 0; i < 32; i++)
      //            {
      //               // Format values for display then write them to file
      //               strOut = (DataToSend[SendIndex] & 0xF0).ToString("X");
      //               swOutPut.Write(strOut[0]);

      //               strOut = (DataToSend[SendIndex++] & 0x0F).ToString("X");
      //               swOutPut.Write(strOut[0]);
      //               swOutPut.Write(' '); // space

      //               if (SendIndex == listData.Count)
      //                  break;
      //            }

      //            // Display 32 bytes per line
      //            swOutPut.Write("\r\n");
      //         }

      //         // If still some odd bytes to send
      //         if (nBytesToSend > 0)
      //         {
      //            // We now have less than a row of data to send
      //            // Send rows of 32 bytes till last 512 byte packet sent
      //            for (; nSendLast512Pkt < 512; nSendLast512Pkt += 32)
      //            {
      //               // Write a row of 32 bytes
      //               for (int i = 0; i < 0x20; i++)
      //               {
      //                  if(nBytesToSend > 0)
      //                  {
      //                     // Format values for display then write them to file
      //                     strOut = (DataToSend[SendIndex] & 0xF0).ToString("X");
      //                     swOutPut.Write(strOut[0]);

      //                     strOut = (DataToSend[SendIndex++] & 0x0F).ToString("X");
      //                     swOutPut.Write(strOut[0]);
      //                     swOutPut.Write(' '); // space
      //                     nBytesToSend--;   
      //                  }   
      //                  else
      //                  {
      //                     swOutPut.Write("FF");
      //                     swOutPut.Write(' '); // space
      //                  }
      //               }

      //               // Display 32 bytes per line
      //               swOutPut.Write("\r\n");
      //            }   
      //         }
      //         swOutPut.WriteLine();
      //         swOutPut.Write("********* End of 512 byte block ************");
      //         swOutPut.WriteLine();
      //         nPageCnt++;
      //      }// End while(nBytesToSend > 0)
      //      swOutPut.WriteLine("Total page count: " + nPageCnt.ToString());            
      //   }// End using()
         
      //   return;
                 
      //}
      
      private void Miscpractise()
      {
         // int nComNum = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\PRD3\BSConfig", "ComPortNum", 1);
         // string PortName = "COM" + nComNum.ToString();

         int hdrPos = 0;
         // Header size
         int byteCnt = 744;
         byte[] arrHdrData = new byte[byteCnt];
         
         FileStream fsOut = File.Open("HdrFile", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
         
         // Length will equal 20
         byte [] VehicleName = new byte[20];

         string VehName = "Dog1";

         for (int i = 0; i < VehName.Length; i++)
         {
            VehicleName[i] = (byte)VehName[i];
         }

         VehicleName.CopyTo(arrHdrData, hdrPos);

         hdrPos += VehicleName.Length;

         byte [] IntBytes = new byte[4];
         
         Int32 nInput1 = 33825;

         // IntBytes = IntToBytes(nInput1);
         IntBytes = BitConverter.GetBytes(nInput1);
         // Array.Reverse(IntBytes);

         Int32 Output1 = IntBytes[0] << 24;
         Output1 += IntBytes[1] << 16;
         Output1 += IntBytes[2] << 8;
         Output1 += IntBytes[3];
         
         IntBytes.CopyTo(arrHdrData, hdrPos);
         hdrPos += IntBytes.Length;

         fsOut.Close();

         string strTcpipPortNumber = "55";
         Int32 PortNumber = 0;
         if(!int.TryParse(strTcpipPortNumber, out PortNumber))
            PortNumber = 10197;

         // Get the file name and version for the windows installer.
         string path = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\MSI.DLL";
         FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(path);

         // File: Windows Installer Version number: 3.1.4001.5512"
         textBox1.Text = "File: " + myFileVersionInfo.FileDescription + '\n' +
            "Version number: " + myFileVersionInfo.FileVersion;

         string Version = myFileVersionInfo.FileVersion.Substring(0,3);
         double dVersion = 0.0;
         bool bGotVersion = double.TryParse(Version, out dVersion);

         if (bGotVersion && dVersion < 3.1)
         {
         }

         int nStartValue = 66;
         // Truncates the number by removing the below the decimal value
         int nSpd = (int)(nStartValue * 1.609347);
         double dSpd = (double)(nStartValue * 1.609347);
         // Remove above decimal value so that only the fractional part remains
         double dFrac = dSpd - nSpd;
         
         if(dFrac > 0.5)
            nSpd++;
       
         double dVal = 14.3, dPow = 3.0;
         double dPwrRes = Math.Pow(dVal, dPow);
         
         return;
      }
      
      //********************************************  
      // Convert an integer to 4 bytes
      //********************************************
      //private byte[] IntToBytes(Int32 num)
      //{
      //   byte[] IntBytes = new byte[4];

      //   IntBytes[0] = (byte)(num >> 24); // msb
      //   IntBytes[1] = (byte)(num >> 16);
      //   IntBytes[2] = (byte)(num >> 8);
      //   IntBytes[3] = (byte)(num);
         
      //   return IntBytes;
      //}

      ////********************************************  
      //// Convert a float to 4 bytes
      ////********************************************
      //private byte[] FloatToBytes(float num)
      //{
      //   byte[] FloatBytes = new byte[4];

      //   //FloatBytes[0] = (byte)(num & (float)0xff000000) >> 24; // msb
      //   //FloatBytes[1] = (byte)(num & 0x00ff0000) >> 16;
      //   //FloatBytes[2] = (byte)(num & 0x0000ff00) >> 8;
      //   //FloatBytes[3] = (byte)(num & 0x000000ff);

      //   return FloatBytes;
      //}
      
      //private void ConvertStringToBytes()
      //{
      //   string Teststring = "modem=123456789ABCWE003040";
         
      //   // Convert string to bytes
      //   Encoding encodingUTF8 = Encoding.UTF8;
      //   Byte[] arrData = encodingUTF8.GetBytes(Teststring);
         
      //   StringBuilder sbTest = new StringBuilder(25);
         
      //   foreach (byte bt in arrData)
      //   {
      //      sbTest.AppendFormat("{0:x2}", bt);
      //      sbTest.Append(' ');
      //   }
         
      //   string DisplayBytesAsString = sbTest.ToString();
      //   return;      
      //}
      
      // Builds a text string, converts it to a byte array, writes it to file.
      private void WriteStringToBytesToFile()
      {
         // Record name and pwd for new user in admin pwd file
         FileStream fs = File.Open(AdminPwdFileName, FileMode.Create, FileAccess.Write);

         StringBuilder AdminEntry = new StringBuilder(50);
         AdminEntry.AppendFormat("{0}::{1}", "tomslick", "Driver");
      
         // Convert string to bytes
         Encoding encodingUTF8 = Encoding.UTF8;
         Byte[] arrOutData = encodingUTF8.GetBytes(AdminEntry.ToString());

         // Encrypt the data bytes
         EncryptData(arrOutData);
         
         // Write bytes to file.
         fs.Write(arrOutData, 0, arrOutData.Length);
         fs.Close();
      }

      // Reads bytes from array and converts into a 
      // string representation and then back again
      //private void BtyesToString()
      //{
      //   byte[] DataBindings = new byte[4]{0x0A, 0x0B, 0x0c, 0x0d};
      //   string result = string.Empty;
      //   StringBuilder sb = new StringBuilder();
         
         
      //   foreach (var bt in DataBindings)
      //    {
      //        sb.AppendFormat("{0:X2}", bt); 
      //    }

      //   result = sb.ToString();
      //   return;
      //}

      // Writes a text string to file
      private void WriteTextToFile()
      {
         FileStream fsTestOutput = File.Open("TestVehInfo.txt", FileMode.Append, FileAccess.Write);
         // FileStream fsTestOutput = new FileStream("TestVehInfo.txt", FileMode.OpenOrCreate, FileAccess.Write);
         StreamWriter swTestSetOut = new StreamWriter(fsTestOutput);
         swTestSetOut.WriteLine("test string");
         swTestSetOut.Flush();
         swTestSetOut.Close();
         fsTestOutput.Close();
      }
      
      // Read a text string, converts it to 
      private void ReadBytesFromFileToString()
      {
         string inputStr;
         
         // Get file size
         FileInfo fi = new FileInfo(AdminPwdFileName);

         Byte[] arrInData = new Byte[fi.Length];
         
         // Open file to read
         FileStream fs = File.Open(AdminPwdFileName, FileMode.Open, FileAccess.Read);
         int byteCnt = fs.Read(arrInData, 0, arrInData.Length);

         Encoding encodingUTF8 = Encoding.UTF8;
         
         if(byteCnt > 0)
         {
            // Decrypt the Data bytes
            DecryptData(arrInData);
            inputStr = encodingUTF8.GetString(arrInData);
            // string format is: "Name::Pwd
            textBox2.Text = inputStr;
         }
         
         fs.Close();
      }
      
      private void FilePrac()
      {
         // Appending file will create if it does not exist
         FileStream fsNotes = File.Open(@"C:\ProgramData\ZOLL Data Systems\EnterpriseServices\DwnLdTestNotes.txt", FileMode.Append, FileAccess.Write);
         Byte[] arrOutData = null;
         Encoding encodingUTF8 = Encoding.UTF8;
         int ExpCnt = 120;
         int DataCount = 125;
         
         // Write 70 lines to text file from byte array
         for(int i = 0; i < 70; i++)
         {
            arrOutData = encodingUTF8.GetBytes("// End transmit DS= " + DataCount.ToString() + "EXP= " + ExpCnt.ToString() + "\r\n");
            fsNotes.Write(arrOutData, 0, arrOutData.Length);
         }
         
         fsNotes.Close();
      }
      
      private void EncryptData(byte[] arrData)
      {
         int sum = 0;
         byte MasterKey = 0x2c;
         byte tempKey = 0;

         // Sum first 5 chars of string, then encode each one using MasterKey
         for(int i = 0; i < 5; i++)
         {
            sum += arrData[i];
            arrData[i] += MasterKey;
         }

         // Exclusive OR MasterKey with most significant byte of 5 char sum
         tempKey = (byte)(MasterKey ^ (sum >> 24));

         // Encode remaining chars with tempKey
         for (int j = 5; j < arrData.Length; j++)
            arrData[j] += tempKey;    
      }

      private void DecryptData(byte[] arrData)
      {
         int sum = 0;
         byte MasterKey = 0x2c;
         byte tempKey = 0;

         // Get sum of first 5 chars of string, then Decrypt each one using MasterKey
         for (int i = 0; i < 5; i++)
         {
            arrData[i] -= MasterKey;
            sum += arrData[i];
         }

         // Exclusive OR MasterKey with most significant byte of 5 char sum
         // to find the original tempkey used to encode
         tempKey = (byte)(MasterKey ^ (sum >> 24));

         // Encode remaining chars with tempKey
         for (int j = 5; j < arrData.Length; j++)
            arrData[j] -= tempKey;
      }



      // Copy the source bytes to the type
      public static object RawDeserialize(byte[] SourceBytes, Type anytype)
      {
         int TargetSize = Marshal.SizeOf(anytype);
         
         // If target bigger than source
         if (TargetSize > SourceBytes.Length)
            return null;

         // Allocate a block of unmanaged memory
         IntPtr buffer = Marshal.AllocHGlobal(TargetSize);

         // Copy source bytes to buffer
         Marshal.Copy(SourceBytes, 0, buffer, TargetSize);

         // Marshal data from unmanaged memory block to newly allocated managed object of the specified type
         object retobj = Marshal.PtrToStructure(buffer, anytype);
         
         Marshal.FreeHGlobal(buffer);
         
         return retobj;
      }

      private void CheckIfAppRunning()
      {
         // Get all processes running on the local computer.
         Process[] localAll = Process.GetProcesses();
         
         Process[] localByName = Process.GetProcessesByName("RS2100");
         if(localByName.Length > 0)
            MessageBox.Show("RS2100 is running", "CheckIfAppRunning()", MessageBoxButtons.OK, MessageBoxIcon.Information);           
         else
            MessageBox.Show("RS2100 is NOT running", "CheckIfAppRunning()", MessageBoxButtons.OK, MessageBoxIcon.Information);              
      }

      // Used to sort an array of structs
      struct Driver : IComparable
      {
         public string Name;
         public string SerNum;
         public int CompareTo(object obj)
         {
            if(obj is Driver)
            {
               Driver Temp = (Driver) obj;
               // Name also implements IComparable
               return Name.CompareTo(Temp.Name);
            }
            throw new ArgumentException("object is not a Driver");    
         } 
      }

      private void GetDirectoryFileNames()
      {
         string directoryName = @"C:\CurrentProjects\Battery-Management (ZOLL Circulation)\MainLine\Output";   

         // string[] directoryList = Directory. GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly);


         var directoryList = Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => s.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) || 
            s.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) || 
            s.EndsWith("config", StringComparison.OrdinalIgnoreCase) || 
            s.EndsWith("xml", StringComparison.OrdinalIgnoreCase));

         StreamWriter sw = new StreamWriter(@"C:\_AATestCmp\DirectoryList.txt");
         
         // Write each file name to a text file 
         foreach(string str in directoryList)
         {
            string fileName = Path.GetFileName(str);
            sw.WriteLine(fileName);
         }

         sw.Close();
      }

      private void GetDirInfo()
      {
         DirectoryInfo dirInfo = new DirectoryInfo("c:\\");
         string DirName = dirInfo.Name.ToString();
         
         string path = Directory.GetCurrentDirectory();
         path += @"\MapData.txt";
         DataSet ds1 = new DataSet();
         ds1.ReadXml(path);
         
         // This returns "C:\\"
         string root = Directory.GetDirectoryRoot(path);
         return;
      }

      private void GetDriveInfo()
      {
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
      }
      
      private void ConvertTime()
      {
         DateTime dtCurrentTm = new DateTime();
         dtCurrentTm = DateTime.Now;

         DateTime dtConvertedUTC = new DateTime();
         dtConvertedUTC = dtCurrentTm.ToUniversalTime();

         DateTime dtConvertedLocal = new DateTime();
         dtConvertedLocal = dtConvertedUTC.ToLocalTime();

         // Example 1. Convert a DateTime to a time_t value 
         DateTime dtBoxTime = DateTime.Now;
         DateTime unixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
         TimeSpan timeSpan = dtBoxTime - unixStartTime;
         TimeSpan timeSpanDST = new TimeSpan(1, 0, 0);

         if (dtBoxTime.IsDaylightSavingTime())
            timeSpan -= timeSpanDST;

         UInt32 time_tTM = Convert.ToUInt32(timeSpan.TotalSeconds);

         // Example 2. Convert a DateTime to an int(represents number of seconds since 1970) 
         DateTime boxTime = DateTime.Now;
         DateTime unixTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
         var timeValue = (int)(boxTime.Subtract(unixTime)).TotalSeconds;
         
         // Convert a time_t value to a DateTime  
         DateTime dtResult = unixStartTime.AddSeconds(Convert.ToDouble(time_tTM));
         
         DateTime unixSTm = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
         DateTime dtEmpty = new DateTime();
         TimeSpan ts1 = unixSTm - dtEmpty;

         DateTime dtTestMinTime = new DateTime();
         return;
      }
      
      private void ParseString()
      {
         string StrLat = "", StrLong = "", StrSpd = "";
         string StrLatRes = "", StrLongRes = "", StrSpdRes = "";
         string StrLatDir = "", StrLongDir = "", StrChk = "";
         char[] Seps = new char[] { ',' };
         int nSubStrCnt = 0;
         byte ChkSumVal = 0, ChkSumValFromStr = 0;

         string StrInput = "$GPRMC,205926.00,A,4300.1398,N,08346.2462,W,000.0,000.0,221007,05.9,W,A*0A:192.31.234";
         int nIPLoc = StrInput.IndexOf(':');
         string StrToParse = StrInput.Substring(0, nIPLoc);
         string StrIPAddr = StrInput.Substring(nIPLoc + 1);
         
         int nChkSumLoc = StrToParse.IndexOf('*');
         if (nChkSumLoc < 0)
            return;

         StrChk = StrToParse.Substring(1, nChkSumLoc - 1);
         foreach (char ch in StrChk)
         {
            ChkSumVal ^= (byte)ch;
         }

         StrChk = StrToParse.Substring(nChkSumLoc + 1);
         
         ChkSumValFromStr = (byte)(AlphaToInt(StrChk[0]) << 4);
         ChkSumValFromStr += (byte)(AlphaToInt(StrChk[1]));

        if (ChkSumVal != ChkSumValFromStr)
            return;
         
         // Parse out the Lat, Long and Speed
         foreach (string SearchStr in StrToParse.Split(Seps))
         {
            switch (nSubStrCnt)
            {
               case 3: // Lat 
                  StrLat = SearchStr;
                  break;
               case 4: // Lat direction 
                  StrLatDir = SearchStr;
                  break;
               case 5: // Long
                  StrLong = SearchStr;
                  break;
               case 6: // Long direction 
                  StrLongDir = SearchStr;
                  break;   
               case 7: // Speed
                  StrSpd = SearchStr;
                  break;
            }
            
            nSubStrCnt++;
         }
         
         // Latitude
         double dLat = double.Parse(StrLat.Substring(0,2));
         double dLatFrac = double.Parse(StrLat.Substring(2));
         
         dLat += dLatFrac/60;

         if (String.CompareOrdinal(StrLatDir, "N") == 0)
            StrLatRes = String.Format("{0:##.######}", dLat);
         else
            StrLatRes = String.Format("{0:-##.######}", dLat);   

         // Longitude
         double dLong = double.Parse(StrLong.Substring(0, 3));
         double dLongFrac = double.Parse(StrLong.Substring(3));

         dLong += dLongFrac / 60;

         if (String.CompareOrdinal(StrLongDir, "W") == 0)
            StrLongRes = String.Format("{0:-###.######}", dLong);
         else
            StrLongRes = String.Format("{0:###.######}", dLong);

         // Parse a Vehicle event notification
         //CVehException VehExcp = new CVehException();
         //string strEvent = "Radio_Flyer ,040000002FBE0A28 ,106.1 ,N*,  580*, 17 ,Y ,Y ";
         //string[] arrInput = strEvent.Split(',');
         //nSubStrCnt = 0;
         //string strTemp = "";
         
         //if (arrInput.Length != 8)
         //   return;
         
         //foreach (string strData in arrInput)
         //{
         //   switch(nSubStrCnt)
         //   {
         //      case 0:
         //         // 12 char string Vehicle Number
         //         VehExcp.m_VehName = strData.Substring(7, 4);
         //      break;
         //      case 1:
         //         // 16 char string Driver Number
         //         strTemp = strData.Substring(10, 4);
         //         VehExcp.m_DrvName = strTemp;
         //      break;
         //      case 2:
         //         // 5 digits Speed
         //         VehExcp.m_Speed = strData.Substring(0, 5);
         //         VehExcp.bSpeedTrig = (strData[5] == '*');
         //      break;
         //      case 3:
         //         // 1 digit SeatBelt
         //         VehExcp.m_bSeatBlt = (strData[0] == 'Y');
         //         VehExcp.bSeatBltTrig = (strData[1] == '*');
         //      break;
         //      // "Radio_Flyer ,040000002FBE0A28 ,106.1 ,N*,  580*, 17 ,Y ,Y "
         //      case 4:
         //         // 5 digit idle time
         //      VehExcp.m_IdleTm = strData.Substring(0, 5);
         //      VehExcp.bIdleTrig = (strData[5] == '*');
         //      break;
         //      case 5:
         //         // 3 digit centi-force
         //         VehExcp.m_Force = strData.Substring(0, 3);
         //         VehExcp.bForceTrig = (strData[3] == '*');
         //      break;
         //      case 6:
         //         // 1 digit EM Lights
         //         VehExcp.m_bEMLights = (strData[0] == 'Y');
         //      break;
         //      case 7:
         //         // 1 digit Siren
         //         VehExcp.m_bSiren = (strData[0] == 'Y');
         //      break;
         //   }
            
         //   nSubStrCnt++;
         //}
         
         return;
      }

      // ***********************************************
      // Convert Hexadecimal chars to ints.
      // ***********************************************
      byte AlphaToInt(Char csCAlpha)
      {
         byte nResult = 0;

         if (csCAlpha == '0')
            nResult = 0;
         else if (csCAlpha == '1')
            nResult = 1;
         else if (csCAlpha == '2')
            nResult = 2;
         else if (csCAlpha == '3')
            nResult = 3;
         else if (csCAlpha == '4')
            nResult = 4;
         else if (csCAlpha == '5')
            nResult = 5;
         else if (csCAlpha == '6')
            nResult = 6;
         else if (csCAlpha == '7')
            nResult = 7;
         else if (csCAlpha == '8')
            nResult = 8;
         else if (csCAlpha == '9')
            nResult = 9;
         else if (csCAlpha == 'A')
            nResult = 10;
         else if (csCAlpha == 'B')
            nResult = 11;
         else if (csCAlpha == 'C')
            nResult = 12;
         else if (csCAlpha == 'D')
            nResult = 13;
         else if (csCAlpha == 'E')
            nResult = 14;
         else if (csCAlpha == 'F')
            nResult = 15;
         else if (csCAlpha == 'a')
            nResult = 10;
         else if (csCAlpha == 'b')
            nResult = 11;
         else if (csCAlpha == 'c')
            nResult = 12;
         else if (csCAlpha == 'd')
            nResult = 13;
         else if (csCAlpha == 'e')
            nResult = 14;
         else if (csCAlpha == 'f')
            nResult = 15;
         else // Invalid char
            nResult = 16;

         return nResult;
      }
      
      public void FormatStrings()
      {
         double val1 = 14.38009, val2 = 0.0;
         bool Ret = false;
         string strSpd1 = "";
         string strSpd2 = "";

         strSpd1 = String.Format("{0:##.#}", val1);
         strSpd2 = String.Format("{0:#.#}", val2);

         // Convert number of seconds to string showing Hrs, Mins, Secs            
         TimeSpan tsRunTm = new TimeSpan(3, 0, 5);
         string szRunTm = string.Format("{0:##00}:{1:##00}:{2:##00}", tsRunTm.Hours, tsRunTm.Minutes, tsRunTm.Seconds);
         string szRunTm2 = string.Format("{0:00}:{1:00}:{2:00}", tsRunTm.Hours, tsRunTm.Minutes, tsRunTm.Seconds);

         // Format a double value. 0 is default
         double fDist = 14.7;
         string Distance2 = String.Format("{0:0.#}", fDist);

         string str1 = String.Format("{0:E}", 250000); // 2.500000E+005
         string str2 = String.Format("{0:F3}", 25);    // 25.000
         string str3 = String.Format("{0:N}", 25000);  // 25,000
         string str4 = String.Format("{0:X}", 25);     // 19    

         // Use a format string to create "Jan01080325PM"
         //                                       year-month-day
         string strCurTm = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
         return;
      }
      
      public void CompareStrings()
      {
         string addr1 = "Address 108971";
         string addr2 = "Address 108972";
         string addr3 = "Address 108973";
         
         // Case sensitive: requires boxing
         int cmpVal = addr1.CompareTo(addr2);
         if (cmpVal == 0) // the values are the same
            return;
         else if (cmpVal > 0) // the first value is greater than the second value
            return;

         // Case sensitive comparison, culture-sensitive(Word sort) 
         cmpVal = string.Compare(addr1, addr2);

         // Case insensitive comparison
         cmpVal = string.Compare(addr1, addr2, true);

         // Case insensitive comparison
         cmpVal = string.Compare(addr1, addr2, StringComparison.OrdinalIgnoreCase);

         // ( == )ordinal, case-sensitive and culture-insensitive comparison
         bool bEq = addr1.Equals(addr3);

         // ordinal, case-insensitive and culture-insensitive comparison
         bEq = addr1.Equals(addr3, StringComparison.OrdinalIgnoreCase);

         // Create a Unicode String with 5 Greek Alpha characters
         String szGreekAlpha = new String('a', 5);
         // Create a Unicode String with a Greek Omega character
         String szGreekOmega = new String(new char[] { 'b', 'c', 'd' }, 2, 1);

         String szGreekLetters = String.Concat(szGreekOmega, szGreekAlpha, szGreekOmega.Clone());
         
         // Locate ' and place an escape in front of it.
         string szFirstLastName = "0'Hara";
         string szResult = "";
         int index = 0;
         
         if(szFirstLastName.Contains("'"))
         {
            // szFirstLastName = szFirstLastName.Replace("'", "\\'");
            index = szFirstLastName.IndexOf("'");
            szFirstLastName.Insert(index, "\\");   
         }

         return;
      }
      
      public void NullableExample()
      {
         // Create types
         Nullable<int> n1 = new Nullable<int>();
         Nullable<int> n2 = 50;
         Nullable<int> n3 = null;
         Nullable<int> n4 = new Nullable<int>(125);
         int? n5 = new int?();
         int? n6 = 30;
         int? n7 = null;
         
         // Change their values
         n1 = 60;
         n2 = null;
         n3 = 22;
         n4 = 50;
         
         if(n1.HasValue && n3.HasValue)
            n2 = n1 + n3;
         
         n5 = 100;
         n7 = n6 + n5 + n4;

         // Get a list of serial port names.
         string[] ports = SerialPort.GetPortNames();
         
         foreach(string port in ports)
         {
            SerialPort sp = new SerialPort(port);
            
            try
            {
               sp.Open();
            }
            catch (InvalidOperationException ex)
            {
               MessageBox.Show(ex.ToString(), "INV Could not open port: " + port);
               continue;               
            }
            catch (UnauthorizedAccessException ex)
            {
               MessageBox.Show(ex.ToString(), "UA Could not open port: " + port);
               continue;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString(), "G Could not open port: " + port);
               continue;
            }
            finally
            {
               sp.Close();   
            }
            
            MessageBox.Show("Could open port: " + port, "Port open successfull!");
         }  
      }
   
      protected void ArrayTest()
      {
         Int32 [] ArrOrig = new Int32[]{10, 11, 12, 13, 14};
         // This array points to ArrOrig
         Int32 [] ArrRef = ArrOrig;

         // Values change in both arrays
         ArrRef[0] = 71;
         ArrRef[1] = 69;
         ArrOrig[0] = 500;

         // Creates a copy of the array
         Int32[] ArrCloned = (Int32 [])ArrOrig.Clone();
         // Value change does not change in original
         ArrCloned[0] = 1200;

         // Creates a copy of the array
         Int32[] ArrCopy = new Int32[ArrOrig.Length];
         ArrOrig.CopyTo(ArrCopy, 0);

         ArrCopy[0] = 888;

         // Attempt to Set the value of each element to zero
         Array.ForEach<Int32>(ArrOrig, delegate(Int32 bt) { bt = 0; });

         // Sorts an array of a custom object
         Driver[] Drvs = new Driver[6];
         Drvs[0].Name = "simpson"; Drvs[0].SerNum = "10000340";
         Drvs[1].Name = "cox"; Drvs[1].SerNum = "10000341";
         Drvs[2].Name = "zandar"; Drvs[2].SerNum = "10000342";
         Drvs[3].Name = "roberts"; Drvs[3].SerNum = "10000343";
         Drvs[4].Name = "database"; Drvs[4].SerNum = "10000344";
         Drvs[5].Name = "barosa"; Drvs[5].SerNum = "10000345";

         Array.Sort(Drvs);

         return;
      }

      
      [Serializable()]
      public sealed class CVehException
      {
         public bool m_bSeatBlt = true;
         public bool m_bSiren = false;
         public string m_DrvName = "tomslick";
         public string m_VehName = "Camry";
         public string m_Speed = "200";
         public string m_Force = "25";
         public string m_IdleTm = "100";
      }

      // Test method that serializes an object, then deserializes it
      protected void XMLSerialization()
      {
         FileStream fs = null;
         // BinaryFormatter xs = null;
         XmlSerializer xs = null;
         CVehException VehExcep = new CVehException();
         CVehException VehExcepRec = null;
         
         VehExcep.m_bSeatBlt = true;
         VehExcep.m_bSiren = false;
         VehExcep.m_DrvName = "tomslick";
         VehExcep.m_VehName = "Camry";
         VehExcep.m_Speed = "200";
         VehExcep.m_Force = "25";
         VehExcep.m_IdleTm = "100";

         try
         {
            // Serialize object to file 
            xs = new XmlSerializer(typeof(CVehException));
            fs = new FileStream("AA_SerVehExc2.xml", FileMode.Create);
            xs.Serialize(fs, VehExcep);
         }
         catch (Exception ex)
         {
            ex.ToString();
         }
         finally
         {
            if(fs != null)
               fs.Close();
         }

         try
         {
            // De serialize object from from File    
            fs = new FileStream("AA_SerVehExc2.xml", FileMode.Open);
            VehExcepRec = (CVehException)xs.Deserialize(fs);
            MessageBox.Show("File deserialized");
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString(),"Deserialize failed"); 
         }
         finally
         {         
            if(fs != null) fs.Close();
         }
         
         return;
      }
      
      protected void InterfaceTest()
      {
         
      }

      protected void SingletonExample()
      {
         int topSpeed = 0;
         string carName = "";
         MySinglton Single1 = MySinglton.GetMySingle();
         
         Single1.TopSpeed = 80;
         Single1.CarName = "Bufred Mobile";
         
         topSpeed = Single1.TopSpeed;
         carName = Single1.CarName;

         // Create a another ref to the singlton object
         MySinglton Single2 = MySinglton.GetMySingle();
         Single2.TopSpeed = 168;
         Single2.CarName = "Souped Mobile";
         
         // First ref should have been changed by second ref
         topSpeed = Single1.TopSpeed;
         carName = Single1.CarName;
         return;
      }

      private void ConfigAppSettings()
      {
         string strSetting = ConfigurationManager.AppSettings.Get("WatchPath");
         // Or - string strSetting = ConfigurationManager.AppSettings["WatchPath"];
         return;
      }

      protected void ConfigFileModify(string ConfigFilePath)
      {
         string StartStopServer = "false";
         string ClearCards = "true";
         string UseMPH = "true";
         string DataFilePath = @"C:\Program Files\Road Safety\RS-2100\DataFiles";
         string AutoUpdateCards = "true";
         // string ConnectStr = ""; Currently no reason to have to update the connection string
         
         // Open configuration when updating
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
               StartStopServer = keyValElem.Value;
            else if (keyValElem.Key == "ClearCards")
               ClearCards = keyValElem.Value;   
            else if (keyValElem.Key == "UseMPH")
               UseMPH = keyValElem.Value;   
            else if (keyValElem.Key == "DataFilePath")
               DataFilePath = keyValElem.Value;   
            else if (keyValElem.Key == "AutoUpdateCards")
               AutoUpdateCards = keyValElem.Value;                          
         }

         // Create or overwrite each of the key/values in the appSettings Section
         // with the values stored in the local variables
         appSection.Settings.Remove("StartStopServer");
         appSection.Settings.Add("StartStopServer", StartStopServer);
         
         appSection.Settings.Remove("ClearCards");
         appSection.Settings.Add("ClearCards", ClearCards);

         appSection.Settings.Remove("UseMPH");
         appSection.Settings.Add("UseMPH", UseMPH);
                  
         appSection.Settings.Remove("DataFilePath");
         appSection.Settings.Add("DataFilePath", DataFilePath);
         
         appSection.Settings.Remove("AutoUpdateCards");
         appSection.Settings.Add("AutoUpdateCards", AutoUpdateCards);

         // Remove the diagnostics section if it exists
         config.Sections.Remove("system.diagnostics");
         
         config.Save(ConfigurationSaveMode.Modified);
      }
      
      // Interface controls
      private void btnInstallSvc_Click(object sender, EventArgs e)
      {
         Process proc = new Process();
         proc.StartInfo.FileName = @"C:\Program Files\Road Safety\RS-2100\mysql\bin\RS2100Sqld.exe";
         proc.StartInfo.Arguments = "--install RS2100sqld --defaults-file=\"C:\\Program Files\\Road Safety\\RS-2100\\mysql\\my.ini\"";
         proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
         proc.Start();  
      }

      private void btnStartSvc_Click(object sender, EventArgs e)
      {
         Process proc = new Process();
         proc.StartInfo.FileName = "Net.exe";
         proc.StartInfo.Arguments = "START RS2100sqld";
         proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
         proc.Start();
      }

      private void btnStopSvc_Click(object sender, EventArgs e)
      {
         Process proc = new Process();
         proc.StartInfo.FileName = "Net.exe";
         proc.StartInfo.Arguments = "STOP RS2100sqld";
         proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
         proc.Start();
      }

      private void btnRemoveSvc_Click(object sender, EventArgs e)
      {
         Process proc = new Process();
         proc.StartInfo.FileName = "SC.exe";
         proc.StartInfo.Arguments = "delete RS2100sqld";
         proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
         proc.Start();
      }
      
      // Convert Hexadecimal chars to ints.
      int AlphaToInt(string csCAlpha)
      {
         int nResult = -1;

         bool bResult = Int32.TryParse(csCAlpha, out nResult);

         if (!bResult)
         {
            switch (csCAlpha)
            {
               case "A":
                  nResult = 10;
                  break;   
               case "B":
                  nResult = 11;
                  break;   
               case "C":
                  nResult = 12;
                  break;   
               case "D":
                  nResult = 13;
                  break;   
               case "E":
                  nResult = 14;
                  break;   
               case "F":
                  nResult = 15;
                  break;   
               default:
                  break;
            }
         }         
  
         return nResult;
      }

      private void btnLaunchFileFrm_Click(object sender, EventArgs e)
      {
         //FrmFilePrac frmFilePrac = new FrmFilePrac();
         //frmFilePrac.Show();
      }

      private void btnIsRunning_Click(object sender, EventArgs e)
      {
         int nRunning = 0;
         try
         {
            ServiceController sc = new ServiceController("RS2100sqld");

            if (sc.Status == ServiceControllerStatus.Running)
               nRunning = 1;

            sc.Close();
         }
         catch (Exception exz)
         {
            MessageBox.Show(exz.Message, "Error");
         }
         
         textBox5.Text = nRunning.ToString();
      }
      
      private void DataViewPrac()
      {
         string strPublicFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);// Environment.GetEnvironmentVariable(@"Public");
         textBox5.Text = "5 " + strPublicFolderPath;
         
         DataTable tbl = new DataTable("Customers");
         tbl.Columns.Add("CustomerID", typeof(string));
         tbl.Columns.Add("CompanyName", typeof(string));
         tbl.Columns.Add("ContactName", typeof(string));
         DataView vue = new DataView(tbl);
         //Add a new row when EndEdit() is called.
         DataRowView row = vue.AddNew();
         row["CustomerID"] = "ABCDE";
         row["CompanyName"] = "New Company";
         row["ContactName"] = "New Contact";
         row.EndEdit();
         //Modify a row when EndEdit() is called.
         row.BeginEdit();
         row["CompanyName"] = "Modified";
         row.EndEdit();
         //Delete a row. Do not need to call EndEdit()
         row.Delete();
      }
      
      //********************************************  
      // Practice conversion to Excel's XML format
      // 1) Write db data to an XML file
      // 2) Link the db data xml file to an xsl file
      // 3) Output is an xml file that is spreadsheet-xml
      //********************************************
      private void btnToExcel_Click(object sender, EventArgs e)
      {
         DataSet dsVehSettings = new DataSet("dsVehSettings");
         string szVehQuery = "SELECT VehName, SerialNum, Odom FROM tbl_veh_settings;";
                                             
         // Build connection string to open DB in server MySQL. 
         string MyConString = "DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.1.199;" +
            "DATABASE=DB_RS2100;USER=NotLogged;PASSWORD=NotLog4596;OPTION=3";

         OdbcConnection DBConn = new OdbcConnection(MyConString);
         OdbcDataAdapter daVehQuery = new OdbcDataAdapter(szVehQuery, DBConn);

         // Fill the dataset with 3 fields for the selected vehicle.
         try { daVehQuery.Fill(dsVehSettings, "TBL_VEH_SETTINGS"); }
         catch (Exception ex) { }
         
         // Create the FileStream for the xml-spreadsheet target file
         FileStream fsTarget = new System.IO.FileStream("Vehicles.xml", FileMode.Create);

         // Create an XmlTextWriter for the xml-spreadsheet target file.
         XmlTextWriter xtwTarget = new XmlTextWriter(fsTarget, Encoding.Unicode);

         // Load the dataset into an XML source document
         XmlDataDocument xmlSourceDoc = new XmlDataDocument(dsVehSettings);
         // for testing source output
         // xmlSourceDoc.WriteContentTo(xtwTarget);
         
         XslTransform xslTran = new XslTransform();

         // Load the xslt stylesheet into the XslTransform object
         xslTran.Load("Vehicles.xsl");         
         
         // Transform the source XML doc to the Taget xml doc
         xslTran.Transform(xmlSourceDoc, null, xtwTarget);

         // Get the current file path
         string TargFilePath = Directory.GetCurrentDirectory() + @"\Vehicles.xml";
         
         //Open the HTML file in Excel.
         /*Excel.Application oExcel = new Excel.Application();
         oExcel.Visible = true;
         oExcel.UserControl = true;
         Excel.Workbooks oBooks = oExcel.Workbooks;
         object oOpt = System.Reflection.Missing.Value; //for optional arguments
         oBooks.Open(TargFilePath, oOpt, oOpt, oOpt,
            oOpt, oOpt, oOpt, oOpt, oOpt, oOpt, oOpt, oOpt,
            oOpt, oOpt, oOpt);
         */

         //Add processing instructions to the beginning of the XML file, one 
         //of which indicates a style sheet.
         // xtw.WriteProcessingInstruction("xml", "version='1.0'");
         // xtw.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='Vehicles.xsl'");

         //Write the XML from the dataset to the file
         // dsVehSettings.WriteXml(xtw);
         xtwTarget.Close();
         return;
         /*         
         <xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
         <xsl:template match="/">
          <HTML>
            <HEAD>
              <STYLE>   
                .HDR { background-color:bisque;font-weight:bold }
              </STYLE>
            </HEAD>
            <BODY>
              <TABLE>
                <COLGROUP WIDTH="300" ALIGN="CENTER"></COLGROUP>
                <COLGROUP WIDTH="200" ALIGN="LEFT"></COLGROUP>
                <COLGROUP WIDTH="200" ALIGN="LEFT"></COLGROUP>
                <TD CLASS="HDR">VehName</TD>
                <TD CLASS="HDR">SerialNum</TD>
                <TD CLASS="HDR">Odom</TD>
                <xsl:for-each select="NewDataSet/Table">
                  <TR>
                    <TD><xsl:value-of select="VehName"/></TD>
                    <TD><xsl:value-of select="SerialNum"/></TD>
                    <TD><xsl:value-of select="Odom"/></TD>
                  </TR>
                </xsl:for-each>
              </TABLE>
            </BODY>
          </HTML>
         </xsl:template>
         </xsl:stylesheet> */
      }

      //********************************************  
      // Execute a query against the system sql database
      // Connect string: Data Source=CT2\SQLEXPRESS;Initial Catalog=PRACDB;User Id=Driver90;Password=Driver90;
      //********************************************
      private void btnExecute_Click(object sender, EventArgs e)
      {
         SqlConnection DBConnect = null;
         string strConnect = tbConnectString.Text;
         try
         {
            DBConnect = new SqlConnection(strConnect); // (@"Data Source=CT2\SQLEXPRESS;Initial Catalog=Northwind;User Id=tomslick;Password=tomslick;");
            DBConnect.Open();

            // SqlCommand cmd = new SqlCommand("select CustomerID, CompanyName, Address, City from Customers", DBConnect);
            SqlCommand cmd = new SqlCommand("select Password, Email from aspnet_Membership", DBConnect);
            DataSet dsMyData = new DataSet("MyData");           
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
               da.Fill(dsMyData);
               tbSqlResults.Text = dsMyData.Tables[0].Rows.Count.ToString();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString(), "Test query xls74");
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString(), "Database Error 3G-X45");
            return;
         }

         DBConnect.Close();
      }

      //********************************************  
      // Send an email
      //********************************************
      private void btnSendEmail_Click(object sender, EventArgs e)
      {
         MailMessage msg = new MailMessage(new MailAddress("ctaylor@roadsafety.com"), new MailAddress("ct_taylor@yahoo.com"));
         SmtpClient client = new SmtpClient("ctaylor.roadsafety.com");

         try
         {
            msg.Subject = "Alarm: Vehicle 76001";
            msg.Body = "Hurry! Vehicle on fire!";
            msg.Priority = MailPriority.High;
            client.Send(msg);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString(), "Mail Sending error");
         }
      }


      // 
      //private int TryGetNewNum(delGetNewNum gnn)
      //{
      //   int res = gnn(5);
      //   return res;
      //}

      // Calls extension method for the string class. Uses static class CMyExtensions
      private void ExtensionMethods()
      {
         string MyStr = "Thisxxx is my five string full string.";
         string MySub = MyStr.GetSubStr5char();         
         return;
      }

      public void ConnectToDB()
      {
         // @"Data Source=.;Initial Catalog=Northwind;User Id=tomslick;Password=tomslick;");
         // @"DataSource=localhost\SQLEXPRESS;Initial Catalog=Northwind; Integrated Security=False; User Id=tomslick; Password=tomslick; Connect Timeout=0");
         // @"data source=RoadSafety;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true");
         // From safeforce alert web app:
         // Data Source=CT2\SQLEXPRESS;Initial Catalog=PRACDB;User Id=Driver90;Password=Driver90;
         // @"data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\Northwind.mdf;User Instance=true");
        
        const string connectString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ZEDS;
                                            User Id=sa;Password=!Password1;";
          using (DbConnection connection = new SqlConnection(connectString))
          {
              try
              {
                  connection.Open();
              }
              catch (Exception ex)
              {
                  ;
              }

              ;
              connection.Close();
          }

          return;
      }

      private void StartStopService()
      {
         // using System.Diagnostics;   // To start the service
         ServiceController controller = new ServiceController("ZOLL Charger Client Data Retriever");

         try
         {
            controller.Start();
         }
         catch (Exception ex)
         {
            // String to record  in the event viewer
            String source = "ZOLL Charger Client Data Retriever Installer";
            String log = "Application";

            if (!EventLog.SourceExists(source))
            {
               EventLog.CreateEventSource(source, log);
            }

            EventLog eLog = new EventLog();
            eLog.Source = source;
            eLog.WriteEntry(@"The service could not be started. Please start the service manually. Error: " + ex.Message, EventLogEntryType.Error);
         }

         try
         {
            controller.Stop();
         }
         catch (Exception ex)
         {
            String source = "ZOLL Charger Client Data Retriever Installer";
            String log = "Application";

            if (!EventLog.SourceExists(source))
            {
               EventLog.CreateEventSource(source, log);
            }

            EventLog eLog = new EventLog();
            eLog.Source = source;
            eLog.WriteEntry(@"The service could not be stopped. Please start the service manually. Error: " + ex.Message, EventLogEntryType.Error);
         }
      }

      private void AssignReferencesTest()
      {
         //var dogs = new List<Dog>();
         //Dog dog1 = new Dog();   

         //dog1.feet = 4;
         //dogs.Add(dog1);
                  
         //Dog dog2 = dog1;
         //dogs.Add(dog2);

         //dog1.feet += 2;

         //foreach(Dog dg in dogs)
         //{
         //   int num = dg.feet;
         //}
      }
       
       //private void ParamPassingTest()
       //{
       //    int value1 = 0x200; // Initialization is optional. Only used as out param.
       //    int value2 = 0x300;

       //    PassInValueWithOutParam(out value1);
       //    PassInValueWithRefParam(ref value2);

       //    // If out or ref not used, called method will only make a local copy.
       //    Cat kitty1;
       //    PassInRefTypeWithOutParam(out kitty1); 
       //    var kitty2  = new Cat();
       //    PassInRefTypeWithRefParam(ref kitty2);
            
       //    return;
       //}

       //private void PassInValueWithOutParam(out int value)
       //{
       //    value = 0x600;
       //}
       //private void PassInValueWithRefParam(ref int value)
       //{
       //    value = 0x400;
       //}
       //private void PassInRefTypeWithOutParam(out Cat value)
       //{
       //    value = new Cat() { feet = "4" };
       //    // value = null; Can legally do this because an assignment is still being made.
       //}
       //private void PassInRefTypeWithRefParam(ref Cat kitty2)
       //{
       //    kitty2.feet = "4";
       //}

      
       private void button1_Click(object sender, EventArgs e)
      {

      }
   }// End class form1

   //// Interface sample isx5
   //public interface IAnimal
   //{
   //   void Feed();
   //}

   //class Cat : IAnimal
   //{
   //   public string feet { get; set; }
   //   public string tail { get; set; }

   //   public void Feed()
   //   {
   //      string str = "eatThis";
   //   }
   //}

   //class Dog : IAnimal
   //{
   //   public void Feed()
   //   {
   //      string str = "eatThis";
   //   }

   //   public int feet = 0;
   //}

   
   // Used in ExtensionMethods() and LambdaPrac()
   // Extension can only exist in static classes
   public static class CMyExtensions
   {
      // The this param determines the type that gets extended
      public static string GetSubStr5char(this string strVal)
      {
         string strSub = strVal.Substring(0, 5);
         return strSub;
      }

      // Delegate: Function signature
      public delegate bool delCriteria<T>(T value);

      // Takes a plug in type and a plug in filter(Criteria) See SampleD3
      public static IEnumerable<T> Where<T>(this IEnumerable<T> values, delCriteria<T> criteria)
      {
         foreach (T item in values)
            if (criteria(item))
               yield return item;
      }

      // Adds an extension 'Select' to IEnumerable  See SampleX4
      public static IEnumerable<TDest> Select<T, TDest>(this IEnumerable<T> values, Func<T, TDest> transformation)
      {
         foreach (T item in values)
            yield return transformation(item);
      } 
   }

   // Used in SingletonExample()
   public sealed class MySinglton
   {
      // This is the one instance of this type (static).
      private static readonly MySinglton MySingle = new MySinglton();
      
      private int topSpeed;
      private string carName;
      
      // Use a private constructor
      private MySinglton()
      {
         topSpeed = 190;
         carName = "Desparodo";
      }
      // Public Property
      public int TopSpeed
      {
         get{return topSpeed;}
         set{topSpeed = value;}
      }
      // Public Property
      public string CarName
      {
         get{return carName;}
         set{carName = value;}        
      }
      // Returns ref to this singlton object
      public static MySinglton GetMySingle()
      {
         return MySingle;
      }

      
   }

   public class structhdr
   {
      public char[] HdrName = new char[] {'H', 'd', 'r', 'n', 'a', 'm', 'e' };
   }
   // // // // 
   public class CA : structhdr
   {
      public char [] className = new char[]{'c', 'l', 'a', 's', 's', 'n', 'a', 'm', 'e'};
   }

   
}




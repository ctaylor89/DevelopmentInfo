
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentInfo.CodeSamples
{
    public class Conversions
    {
        public void StringToBytesAndBack()
        {
            Console.WriteLine("Starting method: StringToBytesAndBack()");
            const string teststring = "modem=123456789ABCWE003040";

            // Convert string to bytes
            var bytesFromString = Encoding.UTF8.GetBytes(teststring);

            // Convert bytes to string
            var displayOutput = Encoding.ASCII.GetString(bytesFromString);
            Console.WriteLine("displayOutput: {0}", displayOutput);
            
            // Another option
            byte[] bytesFromString2 = new System.Text.ASCIIEncoding().GetBytes(teststring);
            string stringFromBytes = new System.Text.ASCIIEncoding().GetString(bytesFromString2);
            Console.WriteLine("stringFromBytes: {0}", stringFromBytes);
        }

        public void IntToBytesAndBack()
        {
            Console.WriteLine("Starting method: IntToBytesAndBack()");
            const int input = 0x7FFFFFFF;  // 5098;
            var intBytesBigEndian = new byte[4];

            // To force the conversion to big endian
            unchecked
            { 
                intBytesBigEndian[0] = (byte)(input >> 24); // msb, Big Endian
                intBytesBigEndian[1] = (byte)(input >> 16);
                intBytesBigEndian[2] = (byte)(input >> 8);
                intBytesBigEndian[3] = (byte)(input);
            }

            // Can be big or little endian depending on the machine type
            var intBytes = BitConverter.GetBytes(input);
            var output = BitConverter.ToInt32(intBytes, 0);
            Console.WriteLine("Integer output is: {0}", output);
        }

        /// <summary>
        /// The order of bytes in the array returned by the GetBytes method depends on 
        /// whether the computer architecture is little-endian or big-endian.
        /// Little endian - used mostly in Intel machines. Big endian - used mostly in Motorola machines.
        /// </summary>
        public void FloatToBytesAndBack()
        {
            Console.WriteLine("Starting method: FloatToBytesAndBack()");
            const float input = 140.04f;
            var floatBytes = BitConverter.GetBytes(input);
            var output = BitConverter.ToSingle(floatBytes, 0);
            Console.WriteLine("Float output is: {0}", output);
        }

        
        // Console.WriteLine("Starting method: ()");
    }
}

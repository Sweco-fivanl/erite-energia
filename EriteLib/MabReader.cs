using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace EriteLib
{
    public class MabReader
    {
        public void TryDecode(byte[] binaryData)
        {
            // data 00 terminator
            int bytesRead = 0;
            var buffer = new byte[100]; //< todo: size
            for(int i=0; i<binaryData.Length; i++)
            {
                if (bytesRead == 0 || (bytesRead != 0 && binaryData[i] != 0x0))
                {
                    buffer[bytesRead] = binaryData[i];
                    bytesRead++;
                }
                else
                {
                    // terminator encountered
                    var output = BitConverter.ToInt32(buffer, 0);
                    Debug.WriteLine($"[ERITE] index-{i}: hex:{ByteArrayToString(buffer)}, {output}");
                    Array.Clear(buffer, 0, 100);
                    bytesRead = 0;
                }
            }
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            int zeros = 0;
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
                if (0x0 == b) zeros++;
                if (2 == zeros) break;
            }
            return hex.ToString();
        }
    }
}

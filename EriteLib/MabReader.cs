using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace EriteLib
{
    public class MabReader
    {
        public void TryDecode(byte[] binaryData)
        {
            byte marker = 0x00;
            Byte[][] result = SplitByteArray(binaryData, marker).ToArray();
            bool prevWasZero = false;
            int index = -1;
            var result2 = new List<Byte[]>();
            foreach (var innerArr in result)
            {
                index++;
                if (isZeroArr(innerArr, marker))
                {
                    if (prevWasZero)
                    {
                        prevWasZero = false;
                        //continue;
                    }
                    // peek
                    if (0 != index && !isZeroArr(result[index - 1], marker))
                    {
                        result[index - 1] = result[index - 1].ToList().Concat(result[index].ToList()).ToArray();
                    }
                    prevWasZero = true;
                }
            }
            foreach (var innerArr in result)
            {
                if (!isZeroArr(innerArr, marker))
                {
                    result2.Add(innerArr);
                }
            }
            // data splitted has been represented for testing
            String report = String.Join(Environment.NewLine,
              result2.Select(line => String.Join(" ", line.Select(x => x.ToString("X2")))));

            // 08 FF FF
            // 47 FF FF FF
            // 47 FF FF
            // 47 FF
            // 47 FF FF FF FF
            // 47 FF FF
            Debug.WriteLine("[ERITE] " + report);
        }

        IEnumerable<Byte> nonTerminated(List<Byte> source, byte marker3)
        {

            if (source.Count() > 1 && source.First() == marker3)
            {
                source.RemoveAt(0);
            }
            return source;
        }

        IEnumerable<Byte[]> SplitByteArray(IEnumerable<Byte> source, byte marker4)
        {
            if (null == source)
                throw new ArgumentNullException("source");

            List<byte> current = new List<byte>();

            var zerosRead = 0;
            int i = -1;
            foreach (byte b in source)
            {
                i++;
                //for(int i=0; i<source.Count(); i++) {
                //var b = source.[i];
                if (b == marker4)
                {
                    zerosRead++;
                    if (current.Count > 0)
                        yield return nonTerminated(current, marker4).ToArray();

                    current.Clear();
                }
                //else /*if (zerosRead >= 2 )*/ {
                //if (b != marker) {
                current.Add(b);
                //}
            }

            if (current.Count > 0)
                yield return nonTerminated(current, marker4).ToArray();
        }

        //var data = new byte[] { 0x05, 0x2B, 0x00, 0x00, 0x65, 0x00, 0x00, 0x00, 0xAC, 0x08, 0x00, 0x00, 0x25, 0x00, 0x07, 0x00, 0x42, 0x65, 0x74, 0x6F, 0x6E, 0x69, 0x00 };
        //var len = byteArray.Length;
        //Debug.WriteLine(len);
        //int count = 0;
        //for(int i=0; i<byteArray.Length; i++)
        //{
        //	count++;
        //}
        //Debug.WriteLine(count);
        //var splitted = byteArray.ToList().Split(

        bool isZeroArr(Byte[] innerArr, byte marker2)
        {
            return innerArr.Length == 1 && innerArr[0] == marker2;
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

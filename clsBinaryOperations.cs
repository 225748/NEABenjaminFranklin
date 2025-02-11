using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEABenjaminFranklin
{
    internal class clsBinaryOperations
    {
        protected ulong ConvertStrToBinary(string text)
        {
            ulong binary = 0;
            foreach (char character in text)
            {
               binary = binary + Convert.ToByte(character);
            }

            return binary;
        }

        protected string ConvertByteToHex(ulong bin)
        {
            string hex = "";
            for (int i = 0; i < bin.ToString().Length; i = i + 8)
            {
                string b = bin.ToString().Substring(i, 8);
                hex = hex + Convert.ToInt32(b, 2).ToString("X"); //the (b,2) tells it to convert from base 2
            }
            return hex;
        }
    }
}

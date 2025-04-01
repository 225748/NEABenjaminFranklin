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
    }
}

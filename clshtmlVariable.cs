using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEABenjaminFranklin
{
    public class clshtmlVariable
    {
        public string FileIdentifier { get ; set; }
        public string VariableValue { get; set; }

        public clshtmlVariable(string fileIdentifier, string variableValue)
        {
            FileIdentifier = fileIdentifier;
            VariableValue = variableValue;
        }
    }
}

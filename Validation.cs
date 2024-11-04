using System.Text.RegularExpressions;

namespace NEABenjaminFranklin
{
    public class Validation
    {
        public string plainTextValidation(string text)
        {
            const string regexExpression = @"^[a-zA-Z]$";
            Match tryToMatch = Regex.Match(text, regexExpression);
            if (tryToMatch.Success)
            {
                return "string";
            }
            else
            {
                return "invalid";
            }
            
        }
        public string emailValidation(string email)
        {
            const string regexExpression = @"  EXPRESSION GOES HERE $";
            Match tryToMatch = Regex.Match(email, regexExpression);
            if (tryToMatch.Success)
            {
                return "email";
            }
            else
            {
                return "invalid";
            }
        }
        //SEE ONENote for interger stuff
        //int validation should be able to test for int, real +ve int, -ve int, +ve real, -ve real all using one regex expression
        //it will then return int, real +ve int, +ve real etc.

    }
}

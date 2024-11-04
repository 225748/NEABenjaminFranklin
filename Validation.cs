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

    }
}

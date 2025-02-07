using System.Text.RegularExpressions;

namespace NEABenjaminFranklin
{
    public class Validation
    {
        public static bool presenceCheck(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string plainTextValidation(string text)
        {
            if (presenceCheck(text) == false)
            {
                return "nullString";
            }
            else
            {
                const string regexExpression = @"^[A-Za-z\s]*$";
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
            
        }
        public string emailValidation(string email)
        {
            if (presenceCheck(email) == false)
            {
                return "nullString";
            }
            else
            {
                const string regexExpression = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$$";
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
        }

        public string integerValidation(int number)
        {
            string strNum = number.ToString();
            const string regexExpression = @"[0-9]+$";
            Match tryToMatch = Regex.Match(strNum, regexExpression);
            if (tryToMatch.Success)
            {
                return "integer";
            }
            else
            {
                return "invalid";
            }
        }
    }
}

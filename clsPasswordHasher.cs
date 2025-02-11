using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEABenjaminFranklin
{
    internal class clsPasswordHasher : clsBinaryOperations
    {
        //create a random salt unique to each user and store in people table
        //append the salt to their raw password
        //conv to binary
        //ensure at a given size of bits - append 1 and then 0s to get to the size
        //perform bitwise operations and pads, shifts rotates etc
        //conv to hex and store in database
        private string GenerateSalt()
        {
            string salt = "";
            Random randValue = new Random();
            for (int i = 0; i < 512; i++)
            {
                int ascii = randValue.Next(65, 90);
                if (ascii % 2 == 1)
                {//add the lowercase version for variety
                    ascii = ascii + 32;
                }
                salt = salt + (Convert.ToChar(ascii));
            }
            return salt;
        }

        public string performHash(string rawPassword, string salt)
        {
            string combinedString = rawPassword + salt;

            System.Security.Cryptography.SHA256CryptoServiceProvider SHA256 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            byte[] byteArray = SHA256.ComputeHash(Encoding.UTF8.GetBytes(combinedString));

            string hexDigest = "";
            foreach (byte b in byteArray)//using b instead of 'byte' as a variable name as byte is reserved
            {
                hexDigest = hexDigest + b.ToString("X");
            }
            return hexDigest;
        }



    }
}

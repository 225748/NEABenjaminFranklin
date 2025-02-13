using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using Google.Apis.Gmail.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Net.Mail;
using System.Net;

namespace NEABenjaminFranklin
{
    internal class clsEmailManager
    {
        private string CredentialsFileLocation = (AppDomain.CurrentDomain.BaseDirectory + "/credentials.json");//directs itself to its own debug folder and then the file

        public string ReadAndPopulateEmailTemplate(string filePath, clshtmlVariable[] variableReplacement)
        {
            //Read the file in
            StreamReader htmlFile = new StreamReader(filePath);
            string htmlString = "";
            while (!htmlFile.EndOfStream)
            {
                htmlString = htmlString + htmlFile.ReadLine();
            }
            htmlFile.Close();

            //replace variable placeholders in the htmlString to contain their actual value
            foreach (clshtmlVariable htmlVariable in variableReplacement)
            {
                htmlString = htmlString.Replace(htmlVariable.FileIdentifier.ToString(), htmlVariable.VariableValue.ToString());
                //must assign it back to the variable, doesn't throw an error without but doesn't 'save' its change
            }

            return htmlString;
        }





        public void SendEmail(string addressTo, string body = "", string subject = "", string cc = "", string bcc = "")
        {
            string[] Scopes = {GmailService.Scope.GmailSend };
            string ApplicationName = "SendMail";

            string Base64UrlEncode(string input)
            {
                var data = Encoding.UTF8.GetBytes(input);
                return Convert.ToBase64String(data).Replace("+", "-").Replace("/", "_").Replace("=", "");
            }

            UserCredential credential;
            //read credentials file
            using (FileStream stream = new FileStream(CredentialsFileLocation, FileMode.Open, FileAccess.Read))
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                path = Path.Combine(path, ".credentials/gmail-dotnet-quickstart.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(path, true)).Result;
            }

            //compile the email
            string Message = $"To:{addressTo}" +
                $"\r\nCC:{cc}" +
                $"\r\nBcc:{bcc}" +
                $"\r\nSubject:{subject}" +
                $"\r\nFrom: RotaConnect <windowsformsmail@gmail.com>" +
                $"\r\nContent-Type: text/html;charset=utf-8\r\n" +
                $"\r\n<body>{body}</body>";

            //call gmail service, giving your credentials
            var service = new GmailService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = ApplicationName });
            var msg = new Google.Apis.Gmail.v1.Data.Message();
            msg.Raw = Base64UrlEncode(Message.ToString());

            try
            {
                service.Users.Messages.Send(msg, "me").Execute();
                //MessageBox.Show("Your email has been successfully sent !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                //MessageBox.Show("There was an error in sending your email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

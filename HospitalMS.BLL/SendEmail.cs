using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL
{
    internal class SendEmail
    {
        public static async Task SendNewUserEmail(string email, string password, string userType)
        {
            string to = email;
            string from = "my email";
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Hi, Your temporary password is " + password + ". Use this to login as " + userType + ".";
            message.Subject = "New " + userType + " registration at XYZ Hospital";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("my email", /*pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp*/"Password");
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                await client.SendMailAsync(message);
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
                throw ex;
            }

        }
    }
}

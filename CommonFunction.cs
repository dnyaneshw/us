using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Insurance
{
    public class CommonFunction
    {
        public static bool SendEmail(string EmailID, string MessageBody, string MessageSub)
        {
            string message = "success";
            bool sent = false;
            try
            {

                SmtpClient sclient;
                String userName, passWord, smtpHost;
                int portDetails;
                sclient = new SmtpClient();
                smtpHost = ConfigurationManager.AppSettings["smtpClient"].ToString();
                sclient.Host = smtpHost;
                portDetails = Convert.ToInt16(ConfigurationManager.AppSettings["portDetails"]);
                sclient.Port = portDetails;
                userName = ConfigurationManager.AppSettings["useremailId"].ToString();
                passWord = ConfigurationManager.AppSettings["userPassword"].ToString();
                sclient.Credentials = new System.Net.NetworkCredential(userName, passWord);
                MailMessage mmsg;
                MailAddress maddr;
                mmsg = new MailMessage();
                mmsg.IsBodyHtml = true;

                mmsg.From = new System.Net.Mail.MailAddress("donotreply@dscoverage.com", "dscoverage.com");
                maddr = new MailAddress(EmailID);
                mmsg.To.Add(maddr);
                mmsg.Subject = MessageSub;
                mmsg.Body = MessageBody;
                mmsg.Priority = MailPriority.High;
                bool ebablessl = Convert.ToBoolean(ConfigurationManager.AppSettings["ssl"].ToString());
                sclient.EnableSsl = ebablessl;

                sclient.Send(mmsg);
                sclient.Dispose();


                sent = true;
            }
            catch (Exception e)
            {
                string errmessage = LogWritter.CreateErrorMessage(e);
                LogWritter.LogFileWrite(errmessage);
                message = e.Message;
                sent = false;
            }
            return sent;
        }
    }
}
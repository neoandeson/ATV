using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Advertisment.Services
{
    public interface IEmailService
    {
        void SendMail(string fromMailAddress, string password, string toMailAddress, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void SendMail(string fromMailAddress, string password, string toMailAddress, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(fromMailAddress);
            mail.To.Add(toMailAddress);
            mail.Subject = subject;
            mail.Body = body;

            string exeFolder = Application.StartupPath;
            string reportPath = Path.Combine(exeFolder, @"OutputReports\LichPhatSong.xls");//TODO test
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(reportPath);
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(fromMailAddress, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}

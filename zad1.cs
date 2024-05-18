using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dz.cistKod
{
    //obrazac je builder
    public class Mail
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Recipient { get; set; }
        public string Attachments { get; set; }
    }

    public interface IMailConstructor
    {
        public IMailConstructor AddSubject(string subject);
        public IMailConstructor AddContent(string content);
        public IMailConstructor AddRecipient(string recipient);
        public IMailConstructor AddAttachments(string attachments);
        public IMailConstructor Reset();
        public Mail Construct();

    }
    public class MailConstructor: IMailConstructor
    {
        Mail mail;
        public MailConstructor()
        {
            mail = new Mail();
        }
        public IMailConstructor AddSubject(string recipient)
        {
            mail.Recipient = recipient;
            return this;
        }
        public IMailConstructor AddContent(string content)
        { 
            mail.Content = content;
            return this;
        }
        public IMailConstructor AddRecipient(string recipient)
        {
            mail.Recipient = recipient;
            return this;
        }
        public IMailConstructor AddAttachments(string attachments)
        { 
            mail.Attachments = attachments;
            return this;
        }
        public IMailConstructor Reset()
        {
            mail = new Mail();
            return this;
        }
        public Mail Construct()
        {
            return mail;
        }
    }

    public class SMTP
    {
        IMailConstructor mailConstructor;
        public SMTP(IMailConstructor mailConstructor)
        {
            this.mailConstructor = mailConstructor;
        }

        public void SendNoReplyMail()
        {
            IMailConstructor mailConstructor;

            mailConstructor.AddSubject("No reply");
            mailConstructor.AddContent("Hello world");
            mailConstructor.Construct();
            //Sending logic here
        }
    }
   
}

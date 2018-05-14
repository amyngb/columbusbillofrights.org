using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CCBOR.Core
{
    public class Emailer
    {
        string retMsg = string.Empty;

        private string m_toEmail;
        private string m_fromEmail;
        private string m_displayName;
        private string m_subject;
        private string m_body;
        private string m_bcc;
        private List<string> m_attachments;
        private string m_host;
        private int m_port;
        private string m_defaultCredentials;
        private string m_userName;
        private string m_password;

        public const string c_success = "success";
        public const string c_error = "error";

        public Emailer()
        { }

        public string ToEmail
        {
            get
            {
                return m_toEmail;
            }
            set
            {
                if (value != m_toEmail)
                {
                    m_toEmail = value;
                }
            }
        }
        public string FromEmail
        {
            get
            {
                return m_fromEmail;
            }
            set
            {
                if (value != m_fromEmail)
                {
                    m_fromEmail = value;
                }
            }
        }
        public string DisplayName
        {
            get
            {
                return m_displayName;
            }
            set
            {
                if (value != m_displayName)
                {
                    m_displayName = value;
                }
            }
        }
        public string Subject
        {
            get
            {
                return m_subject;
            }
            set
            {
                if (value != m_subject)
                {
                    m_subject = value;
                }
            }
        }
        public string Body
        {
            get
            {
                return m_body;
            }
            set
            {
                if (value != m_body)
                {
                    m_body = value;
                }
            }
        }
        public string Bcc
        {
            get
            {
                return m_bcc;
            }
            set
            {
                if (value != m_bcc)
                {
                    m_bcc = value;
                }
            }
        }
        public List<string> Attachments
        {
            get
            {
                return m_attachments;
            }
            set
            {
                if (value != m_attachments)
                {
                    m_attachments = value;
                }
            }
        }

        public string Host
        {
            get
            {
                return m_host;
            }
            set
            {
                if (value != m_host)
                {
                    m_host = value;
                }
            }
        }
        public int Port
        {
            get
            {
                return m_port;
            }
            set
            {
                if (value != m_port)
                {
                    m_port = value;
                }
            }
        }
        public string DefaultCredentials
        {
            get
            {
                return m_defaultCredentials;
            }
            set
            {
                if (value != m_defaultCredentials)
                {
                    m_defaultCredentials = value;
                }
            }
        }
        public string UserName
        {
            get
            {
                return m_userName;
            }
            set
            {
                if (value != m_userName)
                {
                    m_userName = value;
                }
            }
        }
        public string Password
        {
            get
            {
                return m_password;
            }
            set
            {
                if (value != m_password)
                {
                    m_password = value;
                }
            }
        }

        public string SendMail(Emailer emailer)
        {
            try
            {
                retMsg = String.Empty;

                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(emailer.Host, emailer.Port);

                emailer.DisplayName = emailer.DisplayName;
                MailAddress from = new MailAddress(emailer.FromEmail, emailer.DisplayName);
                message.From = from;

                if (m_toEmail.Contains(";"))
                {
                    string[] addrCollection = m_toEmail.Split(";".ToCharArray());
                    MailAddressCollection TO_addressList = new MailAddressCollection();

                    foreach (string addr in addrCollection)
                    {
                        if (addr != String.Empty)
                        {
                            MailAddress toAddress = new MailAddress(addr, addr);
                            TO_addressList.Add(toAddress);
                        }
                    }

                    message.To.Add(TO_addressList.ToString());
                }
                else
                {
                    MailAddress to = new MailAddress(m_toEmail);
                    message = new MailMessage(from, to);
                }

                if (m_bcc != null)
                {
                    MailAddress bcc = new MailAddress(m_bcc);
                    message.Bcc.Add(bcc);
                }

                message.IsBodyHtml = true;
                message.Subject = m_subject;
                message.Body = m_body;

                if (this.Attachments.Count > 0)
                {
                    foreach (string attachment in Attachments)
                    {
                        Attachment attach = new Attachment(attachment);
                        message.Attachments.Add(attach);
                    }
                }

                // If the UseDefaultCredentials property is set to false, then the value set in the Credentials property will be used for the credentials when connecting to the server. 
                Boolean isUseDefaultCredentials = false;
                Boolean isAnonymous = false;

                if (emailer.DefaultCredentials == "1")
                {
                    isUseDefaultCredentials = true;
                    smtpClient.UseDefaultCredentials = isUseDefaultCredentials;
                }

                // Credentials are necessary if the server requires the client to authenticate before it will send e-mail on the client's behalf.
                if (!isUseDefaultCredentials)
                {
                    if ((String.IsNullOrEmpty(emailer.UserName)) && (String.IsNullOrEmpty(emailer.Password)))
                    {
                        // no user credentials have been set in db
                        isAnonymous = true;
                    }
                    else
                    {
                        smtpClient.Credentials = new System.Net.NetworkCredential(
                            emailer.UserName.Trim(),
                            emailer.Password.Trim()
                            );
                    }
                }

                // If the UseDefaultCredentials property is set to false and the Credentials property has not been set, then mail is sent to the server anonymously.

                smtpClient.Send(message);
                retMsg = c_success;
                smtpClient.Dispose();
            }


            catch (Exception ex)
            {
                retMsg = String.Format("ex.Message-{0} ex.Inner-{1} ex.StackTrace{2}", ex.Message, ex.InnerException, ex.StackTrace);
                Core.Logger.AppendToErrors("ERROR - " + String.Format("ex.Message-{0} ex.Inner-{1} ex.StackTrace{2}", ex.Message, ex.InnerException, ex.StackTrace));
            }

            return retMsg;
        }

    }
}

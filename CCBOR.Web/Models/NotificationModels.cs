using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCBOR.Web.Models
{

    public class Notifications
    {}

    public class ContactForm
    {
        [Required]
        public String FullName { get; set; }

        [Required]
        [EmailAddress]
        public String EmailAddress { get; set; }

        public String PhoneNumber { get; set; }

        [Required]
        public String Subject { get; set; }

        [Required]
        public String Message { get; set; }

        public static ContactForm GetDefinition()
        {
            ContactForm contactForm = new ContactForm();
            contactForm.FullName = String.Empty;
            contactForm.EmailAddress = String.Empty;
            contactForm.PhoneNumber = String.Empty;
            contactForm.Subject = String.Empty;
            contactForm.Message = String.Empty;
            return contactForm;
        }

        public static Boolean Send(ContactForm contactForm)
        {
            Boolean isMailSent = false;
            String htmlEmailBody = String.Empty;

            Core.Emailer emailer = new Core.Emailer();
            emailer.FromEmail = Convert.ToString("Notify@jeffgildone.com");
            emailer.DisplayName = Convert.ToString("Columbus Community Bill of Rights");
            emailer.ToEmail = Convert.ToString("info@JMGSoftware.com").Trim();
            emailer.Subject = Convert.ToString("New Contact Form Message from Columbus Community Bill of Rights").Trim();

            emailer.Body = String.Format(@" Hello, <br /> You have received a new message from: <br /><br />
                            Name: {0} <br />
                            Email: {1} <br />
                            Phone: {2} <br />
                          Subject: {3} <br />
                          Message:<br /><pre><strong> {4} </strong></pre>",
                Convert.ToString(contactForm.FullName),
                Convert.ToString(contactForm.EmailAddress),
                Convert.ToString(contactForm.PhoneNumber),
                Convert.ToString(contactForm.Subject),
                Convert.ToString(contactForm.Message)
                );

            emailer.Host = Convert.ToString("mail.jeffgildone.com");
            //emailer.Port = Convert.ToInt32(25);
            //emailer.Port = Convert.ToInt32(465);
            emailer.Port = Convert.ToInt32(587);
            emailer.DefaultCredentials = Convert.ToString("0").Trim();
            emailer.UserName = Convert.ToString("Notify@jeffgildone.com");
            emailer.Password = Convert.ToString("P@ssword2017");
            emailer.Attachments = new List<String>();

            string result = emailer.SendMail(emailer);
            if (result == "success")
            {
                isMailSent = true;
                Core.Logger.AppendToActivity("INFO - Email Sent To: " + Convert.ToString("info@JMGSoftware.com").Trim());
            }
            else
            { Core.Logger.AppendToActivity("ERROR - Sending Email: " + result); }

            return isMailSent;
        }

    }

}
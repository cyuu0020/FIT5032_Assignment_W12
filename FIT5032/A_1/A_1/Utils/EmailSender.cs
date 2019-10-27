﻿using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace A_1.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, String path, HttpPostedFileBase postedFile)
        {

            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            List<EmailAddress> emails = new List<EmailAddress>();
            String[] toEmails = toEmail.Split(';');
            for (int i =0; i < toEmails.Length; i++)
            {
                emails.Add(new EmailAddress(toEmails[i], ""));
            }  
            //create the mail message
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>"; 
            var msgs = MailHelper.CreateSingleEmailToMultipleRecipients(from, emails, subject, plainTextContent, htmlContent);

            if (postedFile != null && postedFile.ContentLength > 0)
            {
                var bytes = File.ReadAllBytes(path);
                var file = Convert.ToBase64String(bytes);
                msgs.AddAttachment(postedFile.FileName, file);
            }
            var response = client.SendEmailAsync(msgs);
        }
        public void SendEmails(List<String> toEmail, String subject, String contents, String path, HttpPostedFileBase postedFile)
        {

            var client = new SendGridClient(API_KEY);

            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            List<EmailAddress> emails = new List<EmailAddress>();
            emails.Add(new EmailAddress("1073049705@qq.com", ""));
            emails.Add(new EmailAddress("179022655@qq.com", ""));
            //create the mail message
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";

            var msgs = MailHelper.CreateSingleEmailToMultipleRecipients(from, emails, subject, plainTextContent, htmlContent);


            if (postedFile != null && postedFile.ContentLength > 0)
            {
                var bytes = File.ReadAllBytes(path);
                var file = Convert.ToBase64String(bytes);
                msgs.AddAttachment(postedFile.FileName, file);
            }
            var response = client.SendEmailAsync(msgs);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ALifeNews.Admin
{
    public partial class MailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                txtUrl.Text = baseUrl + Page.ResolveUrl("~/Home/Preview.aspx") + "?IssueNum=" +Request["IssueNum"];
            }

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string passPhrase = WebConfigurationManager.AppSettings["passphrase"].ToString();
            string inputPhrase = txtPass.Text;
            if(inputPhrase.Equals(passPhrase))
            {
                //ltrFeedback.Text = "Equal";
                string url = txtUrl.Text.Trim();
                string recipient = txtRecipient.Text.Trim();
                SendMail(url, recipient);
            }
            else
            {
                ltrFeedback.Text = "Pass phrase does not match!";
            }
            btnSend.Enabled = false;
        }

        protected void SendMail(string url, string recipient)
        {
            string mailServer = WebConfigurationManager.AppSettings["mailserver"].ToString();
            string mailPort = WebConfigurationManager.AppSettings["mailport"].ToString();
            string senderId= WebConfigurationManager.AppSettings["mailid"].ToString();
            string senderAddress = WebConfigurationManager.AppSettings["mailaddress"].ToString();
            string senderPassword = WebConfigurationManager.AppSettings["mailpassword"].ToString();

            WebClient myClient = new WebClient();
            byte[] htmlData;
            UTF8Encoding utf8 = new UTF8Encoding();
            htmlData = myClient.DownloadData(url);
            string htmlString = utf8.GetString(htmlData);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderAddress);
            message.To.Add(recipient);
            message.Subject = "Newsletter " + DateTime.Now.ToString();
            message.IsBodyHtml = true;
            message.Body = htmlString;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = true;

            smtpClient.Host = mailServer;
            smtpClient.Port = Convert.ToInt32(mailPort);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Send(message);
        }
    }
}
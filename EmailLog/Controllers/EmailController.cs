using EmailLog.Messaging;
using EmailLog.Models;
using System.Configuration;
using System.Web.Mvc;

namespace EmailLog.Controllers.api
{
    public class EmailController : Controller
    {

        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(SendEmail sm)
        {
            string key = ConfigurationManager.AppSettings["Sendgrid.Key"];
            SendGridEmailService messageSvc = new SendGridEmailService(key);

            string htmlBody = $@"<ul>
                                <li>Name: {sm.Name}</li>    
                                <li>Email: {sm.Email}</li>
                                <li>Message Details: {sm.Message}</li>
                            </ul>";

            var msg = new EmailMsg()
            {
                Body = htmlBody,
                Subject = sm.Subject,
                From = sm.Name,
                Recipient = sm.Email
            };

            return RedirectToAction("Success", "Home");

            //messageSvc.SendMail(msg, true, fileName, fileData);
            //var fileName = FileConverter.GetFilePath("Logs\\2018-05-21.log");
            //var fileData = FileConverter.Convert(fileName);
            //attaches file
            //string envPath = HttpRuntime.AppDomainAppPath;
            //string fileName = $"{envPath}\\Content\\assets\\images\\logo_dark.png";
            //byte[] imageData = null;
            //FileInfo fileInfo = new FileInfo(fileName);
            //long imageFileLength = fileInfo.Length;
            //FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //imageData = br.ReadBytes((int)imageFileLength);

            //messageSvc.SendMail(msg, true, fileName, imageData);


        }
    }
}
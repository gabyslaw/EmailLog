using EmailLog.Helpers;
using EmailLog.Messaging;
using EmailLog.Models;
using NLog;
using System;
using System.Configuration;
using System.Web.Mvc;



[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace EmailLog.Controllers
{
    public class LogErrorController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Log4net()
        {
            log.Error("This is our error message");
            try
            {
                int i = 5;
                var s = i / 0;
            }
            catch (DivideByZeroException ex)
            {
                log.Fatal("This was a terrible error");
                log.Debug("Here again", ex);
            }

            return View();
        }


        [HttpPost]
        public ActionResult Log4net(SendEmail sm)
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

            var fileName = FileConverter.GetFilePath("Log4net\\Log-file.txt");
            var fileData = FileConverter.Convert(fileName);



            messageSvc.SendMail(msg, true, fileName, fileData);



            return RedirectToAction("Success", "Home");

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




        // GET: LogError
        public ActionResult NLog()
        {
            try
            {
                int i = 5;
                var s = i / 0;
            }
            catch (DivideByZeroException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();

                logger.Error(ex, "this too");

            }

            return View();
        }

        [HttpPost]
        public ActionResult NLog(SendEmail sm)
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

            var fileName = FileConverter.GetFilePath("logs\\2018-05-21.log");
            var fileData = FileConverter.Convert(fileName);



            messageSvc.SendMail(msg, true, fileName, fileData);



            return RedirectToAction("Success", "Home");

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

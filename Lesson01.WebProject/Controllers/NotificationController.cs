using Lesson01.WebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Lesson01.WebProject.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SentEmail(string Title, string To, string Body)
        {
            SmtpClient client = new SmtpClient();

            MailMessage msg = new MailMessage();
            msg.To.Add(To);
            msg.Body = Body;
            msg.Subject = Title;

            ResultSendingEmail result = new ResultSendingEmail();

            try
            {
                client.Send(msg);
                result.Message = "Сообщение успешно отправлено";
                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Message = "При отправке возникла ошибка "+ex.Message;
                result.Result = false;
            }

            ViewBag.ResultSending = result;

            return View();
        }
    }
}
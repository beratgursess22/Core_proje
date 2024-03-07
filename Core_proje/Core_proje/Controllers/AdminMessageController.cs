using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace Core_proje.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminMessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "test@gmail.com";
            var values = messageManager.GetListReceiverMessages(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "test@gmail.com";
            var values = messageManager.GetListSenderMessages(p);
            return View(values);
        }
        public IActionResult AdminMessageDetail(int id)
        {
            var values = messageManager.TGetByID(id);
            return View(values);

        }
        public IActionResult AdminDelete(int id)
        {
            var values = messageManager.TGetByID(id);
            messageManager.TDelete(values);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageAdd(WriterMessage p)
        {
            p.Sender = "test@gmail.com";
            p.SenderName = "berat gürses";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            messageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}

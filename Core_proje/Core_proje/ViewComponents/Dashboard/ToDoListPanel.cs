using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;


namespace Core_proje.ViewComponents.Dashboard
{
    public class ToDoListPanel:ViewComponent
    {
        ToDolistManager todolistManager= new ToDolistManager(new EfToDoListDal());

        public IViewComponentResult Invoke()
        {
            var values=todolistManager.TGetList();
            return View(values);
        }
    }
}

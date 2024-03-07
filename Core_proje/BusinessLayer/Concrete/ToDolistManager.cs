using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDolistManager : IToDoListService
    {
        IToDoListDal _todolistDal;

        public ToDolistManager(IToDoListDal todolistManager)
        {
            _todolistDal = todolistManager;
        }

        public void TAdd(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public ToDoList TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ToDoList> TGetList()
        {
            return _todolistDal.Getlist();
        }

        public List<ToDoList> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDoList t)
        {
            throw new NotImplementedException();
        }
    }
}

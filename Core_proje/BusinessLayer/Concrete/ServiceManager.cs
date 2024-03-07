using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager: IServiceDal
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Delete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public List<Service> GetByFilter(Expression<Func<Service, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetById(id); 
        }

        public List<Service> Getlist()
        {
            return _serviceDal.Getlist();

        }

        public void Insert(Service t)
        {
            _serviceDal.Insert(t);
        }

        public void Update(Service t)
        {
            _serviceDal.Update(t);
        }
    }
}

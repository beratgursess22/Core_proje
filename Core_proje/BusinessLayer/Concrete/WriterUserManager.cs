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
	public class WriterUserManager : IWriterUserDal
	{
		IWriterUserDal _writerUserDal;

		public WriterUserManager(IWriterUserDal writerUserDal)
		{
			_writerUserDal = writerUserDal;
		}

		public void Delete(WriterUser t)
		{
			throw new NotImplementedException();
		}

		public List<WriterUser> GetByFilter(Expression<Func<WriterUser, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public WriterUser GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<WriterUser> Getlist()
		{
			return _writerUserDal.Getlist();
		}

		public void Insert(WriterUser t)
		{
			_writerUserDal.Insert(t);
		}

		public void Insert(WriterUserManager p)
		{
			throw new NotImplementedException();
		}

		public void Update(WriterUser t)
		{
			throw new NotImplementedException();
		}
	}
}

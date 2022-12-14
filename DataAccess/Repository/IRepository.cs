using System;
using System.Linq.Expressions;

namespace ITS_TechnicalAssignment.DataAccess.Repository
{
    public interface IRepository<T,TDto> where T : class
    {
        IEnumerable<TDto> GetAll(int pageSize, int pageNumber);
        TDto Get(Expression<Func<T, bool>> exp);
        T Add(TDto entityDto);
        void Update(int id, TDto entityDto);
        bool Delete(int id);
        void SaveChanges();
    }
}

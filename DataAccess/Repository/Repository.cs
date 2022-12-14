using AutoMapper;
using ITS_TechnicalAssignment.DataAccess.Data;
using ITS_TechnicalAssignment.DataAccess.Models;
using System.Linq.Expressions;

namespace ITS_TechnicalAssignment.DataAccess.Repository
{
    public class Repository<T, TDto> : IRepository<T, TDto> where T : class
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext _Context;

        public Repository(ApplicationDbContext _Context, IMapper mapper)
        {
            this._Context = _Context;
            this.mapper = mapper;
        }

        public IEnumerable<TDto> GetAll(int pageSize = 0,int pageNumber = 0)
        {
            if(pageSize != 0)
            {
                IEnumerable<T> entity = _Context.Set<T>().Skip(pageNumber*pageSize).Take(pageSize).ToList();
                return mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(entity);
            }
            else
            {
                IEnumerable<T> entity = _Context.Set<T>().ToList();
                return mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(entity);
            }
        }

        public TDto Get(Expression<Func<T, bool>> exp)
        {
            IQueryable<T> query = _Context.Set<T>();

            T entity = query.FirstOrDefault(exp);
            return mapper.Map<T, TDto>(entity);
        }

        public T Add(TDto entityDto)
        {
            T entity = mapper.Map<TDto, T>(entityDto);
            _Context.Set<T>().Add(entity);
            return entity;
        }

        public void Update(int id, TDto entityDto)
        {
            T entity = _Context.Set<T>().Find(id);
            mapper.Map(entityDto, entity);
        }

        public bool Delete(int id)
        {
            T entity = _Context.Set<T>().Find(id);

            if (entity == null)
                return false;

            _Context.Set<T>().Remove(entity);
            return true;
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }
    }
}

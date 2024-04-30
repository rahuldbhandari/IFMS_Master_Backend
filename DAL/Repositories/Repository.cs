using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using IFMS_Master_Backend.DAL.IRepositories;

namespace IFMS_Master_Backend.DAL.Repositories
{
    public abstract class Repository<T, Tcontext> : IRepository<T> where T : class where Tcontext : DbContext
    {
        protected readonly Tcontext ifmsContext = null;

        public Repository(Tcontext context)
        {
            ifmsContext = context;
        }


        public bool IsTransactionRunning()
        {
            return ifmsContext.Database.CurrentTransaction == null ? false : true;
        }
        private IDbContextTransaction BeginTran()
        {
            return ifmsContext.Database.BeginTransaction();
        }



        public IExecutionStrategy GetExecutionStrategy()
        {
            return ifmsContext.Database.CreateExecutionStrategy();
        }


        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = ifmsContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return result;
        }

        public async Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = ifmsContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return await result.ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> result = ifmsContext.Set<T>();
            return result;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            IQueryable<T> result = ifmsContext.Set<T>();
            return await result.ToListAsync();
        }



        public IQueryable<T> GetSingle(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = ifmsContext.Set<T>();
            return result;
        }
        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition)
        {
            var retValue = await ifmsContext.Set<T>().Where(condition).SingleOrDefaultAsync();

            return retValue;
        }


        public List<T> GetMultiple(Expression<Func<T, bool>> condition)
        {
            return ifmsContext.Set<T>().Where(condition).ToList();
        }
        public async Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>> condition)
        {
            var result = await ifmsContext.Set<T>().Where(condition).ToListAsync();
            return result;
        }

        public IQueryable<T> GetAllByLikeCondition(Expression<Func<T, string>> propertySelector, string value)
        {
            return ifmsContext.Set<T>()
                .Where(entity => EF.Functions.Like(EF.Property<string>(entity, GetPropertyName(propertySelector)), $"%{value}%"));
        }

        public async Task<ICollection<T>> GetAllByLikeConditionAsync(Expression<Func<T, string>> propertySelector, string value)
        {
            return await ifmsContext.Set<T>()
                .Where(entity => EF.Functions.Like(EF.Property<string>(entity, GetPropertyName(propertySelector)), $"%{value}%"))
                .ToListAsync();
        }

        private string GetPropertyName(Expression<Func<T, string>> propertySelector)
        {
            if (propertySelector.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }
            else if (propertySelector.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
            {
                return operand.Member.Name;
            }

            throw new ArgumentException("Invalid property selector");
        }


        public bool Add(T entity)
        {
            ifmsContext.Set<T>().Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            ifmsContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            ifmsContext.Set<T>().Remove(entity);
            return true;
        }


        public void SaveChangesManaged()
        {
            ifmsContext.SaveChanges();
        }

    }
}

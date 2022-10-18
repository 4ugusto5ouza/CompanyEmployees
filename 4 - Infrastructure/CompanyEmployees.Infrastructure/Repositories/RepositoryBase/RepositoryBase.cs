using CompanyEmployees.Domain.Interfaces;
using CompanyEmployees.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyEmployees.Infrastructure.RepositoryBase
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected CompanyEmployeesContext CompanyEmployeesContext;

        public RepositoryBase(CompanyEmployeesContext companyEmployeesContext)
        {
            CompanyEmployeesContext = companyEmployeesContext;
        }

        public IQueryable<TEntity> FindAll(bool trackChanges)
        {
            return !trackChanges ? CompanyEmployeesContext.Set<TEntity>().AsNoTracking()
                                 : CompanyEmployeesContext.Set<TEntity>();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? CompanyEmployeesContext.Set<TEntity>().Where(expression).AsNoTracking()
                                 : CompanyEmployeesContext.Set<TEntity>().Where(expression);
        }

        public void Create(TEntity entity) => CompanyEmployeesContext.Set<TEntity>().Add(entity); 

        public void Update(TEntity entity) => CompanyEmployeesContext.Set<TEntity>().Update(entity); 

        public void Delete(TEntity entity) => CompanyEmployeesContext.Set<TEntity>().Remove(entity);
    }
}

﻿using Data.Models;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<RepositoryResult<TEntity>> AddAsync(TEntity entity);
    Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync(bool orderDescending = false, Expression<Func<TEntity, object>>? sortBy = null, Expression<Func<TEntity, bool>>? where = null, params Expression<Func<TEntity, object>>[] includes);
    Task<RepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
    Task<RepositoryResult> UpdateAsync(TEntity entity);
    Task<RepositoryResult> DeleteAsync(TEntity entity);
    Task<RepositoryResult> AnyAsync(Expression<Func<TEntity, bool>> expression);
}
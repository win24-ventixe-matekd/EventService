using Data.Entities;
using Data.Models;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IEventRepository : IBaseRepository<EventEntity>
{
    Task<RepositoryResult<EventEntity>> GetAsync(Expression<Func<EventEntity, bool>> where, params Expression<Func<EventEntity, object>>[] includes);
}

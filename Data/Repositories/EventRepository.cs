using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository
{
    public async override Task<RepositoryResult<EventEntity>> GetAsync(Expression<Func<EventEntity, bool>> where, params Expression<Func<EventEntity, object>>[] includes)
    {
        // something wrong with base repo not including
        var entity = await _dbSet.Include(x => x.Packages).FirstOrDefaultAsync(where);
        return new RepositoryResult<EventEntity> { Success = true, Result = entity, StatusCode = 200 };
    }
}

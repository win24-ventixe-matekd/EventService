using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class PackageRepository(DataContext context) : BaseRepository<PackageEntity>(context), IPackageRepository
{
    public async override Task<RepositoryResult<PackageEntity>> AddAsync(PackageEntity entity)
    {
        if (entity == null)
            return new RepositoryResult<PackageEntity> { Success = false, StatusCode = 400, Error = "Entity can't be null." };

        var currentEvent = await _context.Events.Include(x => x.Packages).FirstOrDefaultAsync(x => x.Id == entity.EventId);
        if (currentEvent == null)
            return new RepositoryResult<PackageEntity> { Success = false, StatusCode = 404, Error = "Event not found." };

        try
        {
            var result = await _dbSet.AddAsync(entity);

            currentEvent.Packages.Add(entity);

            await _context.SaveChangesAsync();
            return new RepositoryResult<PackageEntity> { Success = true, StatusCode = 201, Result = result.Entity };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new RepositoryResult<PackageEntity> { Success = false, StatusCode = 500, Error = "An error occurred." };
        }
    }

    public async override Task<RepositoryResult<PackageEntity>> GetAsync(Expression<Func<PackageEntity, bool>> where, params Expression<Func<PackageEntity, object>>[] includes)
    {
        // something wrong with base repo not including
        var entity = await _dbSet.Include(x => x.Event).FirstOrDefaultAsync(where);
        return new RepositoryResult<PackageEntity> { Success = true, Result = entity, StatusCode = 200 };
    }
}

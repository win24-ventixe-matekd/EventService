using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
}

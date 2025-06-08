using Data.Entities;
using Data.Models;

namespace Data.Interfaces;

public interface IPackageRepository : IBaseRepository<PackageEntity>
{
    Task<RepositoryResult<PackageEntity>> AddAsync(PackageEntity entity);
}

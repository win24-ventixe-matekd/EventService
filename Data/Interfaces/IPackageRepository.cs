using Data.Entities;
using Data.Models;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IPackageRepository : IBaseRepository<PackageEntity>
{
    Task<RepositoryResult<PackageEntity>> AddAsync(PackageEntity entity);
    Task<RepositoryResult<PackageEntity>> GetAsync(Expression<Func<PackageEntity, bool>> where, params Expression<Func<PackageEntity, object>>[] includes);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IMongoDbRepository<T> where T : MongoDbEntity,new()
{
    IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<string> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(string id, T entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> DeleteAsync(string id, CancellationToken cancellationToken = default);
    Task<T> DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    bool SetCollection(string collectionName);
    bool CreateCollection(string collectionName);

}

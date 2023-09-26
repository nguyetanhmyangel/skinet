using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Specifications;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreDbContext _context;
    public GenericRepository(StoreDbContext context)
    {
        _context = context;
    }

    void IGenericRepository<T>.Add(T entity)
    {
        throw new NotImplementedException();
    }

    Task<int> IGenericRepository<T>.CountAsync(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }

    void IGenericRepository<T>.Delete(T entity)
    {
        throw new NotImplementedException();
    }

    Task<T> IGenericRepository<T>.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<T> IGenericRepository<T>.GetEntityWithSpec(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }

    Task<IReadOnlyList<T>> IGenericRepository<T>.ListAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<IReadOnlyList<T>> IGenericRepository<T>.ListAsync(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }

    void IGenericRepository<T>.Update(T entity)
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Catalog.Service.Entities;

namespace Product.Catalog.Service.Repositories
{
    public interface IRepository<T> where T:IEntity
    {
        // Retrieve all items asynchronously
        Task<IReadOnlyCollection<T>> GetAllAsync();

        // Retrieve a specific item by its ID asynchronously
        Task<Item> GetAsync(Guid id);

        // Create a new item asynchronously
        Task CreateAsync(T entity);

        // Update an existing item asynchronously
        Task UpdateAsync(T entity);

        // Remove an item by its ID asynchronously
        Task RemoveAsync(Guid id);
    }
}

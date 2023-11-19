using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Catalog.Service.Entities;

namespace Product.Catalog.Service.Repositories
{
    public interface IItemsRepository
    {
        // Retrieve all items asynchronously
        Task<IReadOnlyCollection<Item>> GetAllAsync();

        // Retrieve a specific item by its ID asynchronously
        Task<Item> GetAsync(Guid id);

        // Create a new item asynchronously
        Task CreateAsync(Item entity);

        // Update an existing item asynchronously
        Task UpdateAsync(Item entity);

        // Remove an item by its ID asynchronously
        Task RemoveAsync(Guid id);
    }
}

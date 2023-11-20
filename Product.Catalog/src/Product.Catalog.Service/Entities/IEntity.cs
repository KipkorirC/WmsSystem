using System;

namespace Product.Catalog.Service.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}

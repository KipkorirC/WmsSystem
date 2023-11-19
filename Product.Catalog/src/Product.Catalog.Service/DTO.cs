using System;
using System.ComponentModel.DataAnnotations;

// DTO (Data Transfer Object) representing an Item
namespace Product.Catalog.Service.DTO
{
    // Represents an Item's details
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    // DTO for creating a new Item
    public record CreateItemDto(
        [Required] string Name,
        string Description,
        [Range(0, 1000)] decimal Price
    );

    // DTO for updating an existing Item
    public record UpdateItemDto(
        [Required] string Name,
        string Description,
        [Range(0, 1000)] decimal Price
    );
}

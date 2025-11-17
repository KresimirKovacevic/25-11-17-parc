using Ispit.API.Entities;

namespace Ispit.API.Abstractions
{
    public interface IShoppingItemRepository
    {
        Task<List<ShoppingItem>> GetShoppingItemsAsync();

        Task<ShoppingItem?> GetShoppingItemByIdAsync(int id);
        Task<int> AddShoppingItemAsync(ShoppingItem shoppingitem);
        Task UpdateShoppingItemAsync(ShoppingItem shoppingitem);
        Task DeleteShoppingItemAsync(int id);
        bool ShoppingItemExists(int id);
    }
}

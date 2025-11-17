using Ispit.API.Abstractions;
using Ispit.API.Data;
using Ispit.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ispit.API.Repositories
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly AppDbContext _context;

        public ShoppingItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddShoppingItemAsync(ShoppingItem shoppingitem)
        {
            _context.ShoppingItems.Add(shoppingitem);
            await _context.SaveChangesAsync();

            return shoppingitem.Id;
        }

        public async Task DeleteShoppingItemAsync(int id)
        {
            var shoppingitem = await _context.ShoppingItems.FindAsync(id);
            if (shoppingitem != null)
            {
                _context.ShoppingItems.Remove(shoppingitem);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("ShoppingItem not found");
            }
        }

        public async Task<ShoppingItem?> GetShoppingItemByIdAsync(int id)
        {
            return await _context.ShoppingItems.FindAsync(id);
        }

        public async Task<List<ShoppingItem>> GetShoppingItemsAsync()
        {
            return await _context.ShoppingItems.ToListAsync();
        }

        public bool ShoppingItemExists(int id)
        {
            return _context.ShoppingItems.Any(x => x.Id == id);
        }

        public async Task UpdateShoppingItemAsync(ShoppingItem shoppingitem)
        {
            _context.Entry(shoppingitem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

using Ispit.API;
using Ispit.API.Abstractions;
using Ispit.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingItemsController (IShoppingItemRepository repository) : ControllerBase
    {
        // GET: api/ShoppingItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingItem>>> GetShoppingItems()
        {
            var shoppingitems = await repository.GetShoppingItemsAsync();
            return shoppingitems.Count == 0 ? NotFound() : Ok(shoppingitems);
        }

        // GET: api/ShoppingItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingItem>> GetShoppingItem(int id)
        {
            var shoppingitem = await repository.GetShoppingItemByIdAsync(id);

            if (shoppingitem == null)
            {
                return NotFound();
            }

            return shoppingitem;
        }

        // PUT: api/ShoppingItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingItem(int id, ShoppingItem shoppingitem)
        {
            if (id != shoppingitem.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.UpdateShoppingItemAsync(shoppingitem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (repository.ShoppingItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingItem>> PostShoppingItem(ShoppingItem shoppingitem)
        {
            await repository.AddShoppingItemAsync(shoppingitem);

            return CreatedAtAction("GetShoppingItem", new { id = shoppingitem.Id }, shoppingitem);
        }

        // DELETE: api/ShoppingItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingItem(int id)
        {
            if (!repository.ShoppingItemExists(id))
            {
                return NotFound();
            }

            await repository.DeleteShoppingItemAsync(id);

            return NoContent();
        }
    }
}

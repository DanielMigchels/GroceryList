using GroceryList.API.Data;
using GroceryList.API.Services.GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.API.Services.GroceryList;

public class GroceryListService(ILogger<GroceryListService> logger, DatabaseContext db) : IGroceryListService
{
    public async Task AddGroceryList(GroceryListModel requestModel)
    {
        var groceryItem = new Data.Models.GroceryItem
        {
            Name = requestModel.Name
        };
        db.GroceryItems.Add(groceryItem);
        await db.SaveChangesAsync();
    }

    public async Task DeleteGroceryList(GroceryListModel requestModel)
    {
        var groceryItem = db.GroceryItems.FirstOrDefault(x => x.Id == requestModel.Id);

        if (groceryItem == null)
        {
            return;
        }

        groceryItem.Name = requestModel.Name;
        db.GroceryItems.Remove(groceryItem);
        await db.SaveChangesAsync();
    }

    public async Task EditGroceryList(GroceryListModel requestModel)
    {
        var groceryItem = db.GroceryItems.FirstOrDefault(x => x.Id == requestModel.Id);

        if (groceryItem == null)
        {
            return;
        }

        groceryItem.Name = requestModel.Name;
        db.GroceryItems.Update(groceryItem);
        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<GroceryListModel>> GetGroceryList()
    {
        logger.LogInformation("Getting grocery list from Database");

        return await db.GroceryItems.Select(x => new GroceryListModel
        {
            Id = x.Id,
            Name = x.Name
        }).ToListAsync();
    }
}

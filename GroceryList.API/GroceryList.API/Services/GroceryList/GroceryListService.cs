using GroceryList.API.Data;
using GroceryList.API.Services.GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.API.Services.GroceryList;

public class GroceryListService(ILogger<GroceryListService> logger, DatabaseContext db) : IGroceryListService
{
    public async Task AddGroceryList(GroceryListRequestModel requestModel)
    {
        var groceryItem = new Data.Models.GroceryItem();
        groceryItem.Name = requestModel.Name;
        db.GroceryItems.Add(groceryItem);
        await db.SaveChangesAsync();
    }

    public async Task DeleteGroceryList(GroceryListRequestModel requestModel)
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

    public async Task EditGroceryList(GroceryListRequestModel requestModel)
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

    public async Task<IEnumerable<GroceryListResponseModel>> GetGroceryList()
    {
        logger.LogInformation("Getting grocery list from Database");

        return await db.GroceryItems.Select(x => new GroceryListResponseModel
        {
            Id = x.Id,
            Name = x.Name
        }).ToListAsync();
    }
}

using GroceryList.API.Services.GroceryList.Models;

namespace GroceryList.API.Services.GroceryList;

public interface IGroceryListService
{
    public Task AddGroceryList(GroceryListModel requestModel);
    public Task DeleteGroceryList(GroceryListModel requestModel);
    public Task EditGroceryList(GroceryListModel requestModel);
    public Task<IEnumerable<GroceryListModel>> GetGroceryList();
}

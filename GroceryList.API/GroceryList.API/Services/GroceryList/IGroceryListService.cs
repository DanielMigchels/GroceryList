using GroceryList.API.Services.GroceryList.Models;

namespace GroceryList.API.Services.GroceryList;

public interface IGroceryListService
{
    public Task AddGroceryList(GroceryListRequestModel requestModel);
    public Task DeleteGroceryList(GroceryListRequestModel requestModel);
    public Task EditGroceryList(GroceryListRequestModel requestModel);
    public Task<IEnumerable<GroceryListResponseModel>> GetGroceryList();
}

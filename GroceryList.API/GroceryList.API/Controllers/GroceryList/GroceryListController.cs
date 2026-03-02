using GroceryList.API.Services.GroceryList;
using GroceryList.API.Services.GroceryList.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryList.API.Controllers.GroceryList
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryListController(IGroceryListService groceryListService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groceryList = await groceryListService.GetGroceryList();
            return Ok(groceryList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroceryListModel requestModel)
        {
            await groceryListService.AddGroceryList(requestModel);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GroceryListModel requestModel)
        {
            await groceryListService.EditGroceryList(requestModel);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] GroceryListModel requestModel)
        {
            await groceryListService.DeleteGroceryList(requestModel);
            return Ok();
        }
    }
}

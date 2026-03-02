namespace GroceryList.API.Services.GroceryList.Models
{
    public class GroceryListResponseModel
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
    }
}

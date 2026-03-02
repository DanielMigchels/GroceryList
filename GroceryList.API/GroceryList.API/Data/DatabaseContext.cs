using GroceryList.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.API.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<GroceryItem> GroceryItems { get; set; }
}

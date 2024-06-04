using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Filamentous.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GroceryController : ODataController
{
    private List<Grocery> products = new List<Grocery>()
    { 
        new() { Id = 0, Name="Milk" },
        new() { Id = 1, Name="Bread" },
        new() { Id = 2, Name="Eggs" },
        new() { Id = 3, Name="Butter" },
        new() { Id = 4, Name="Spaghetti" },
        new() { Id = 5, Name="Ketchup" },
    };

    [HttpGet]
    public IEnumerable<Grocery> Get()
    {
        return products;
    }
}

public class Grocery { public int Id { get; set; } public string Name { get; set; } }

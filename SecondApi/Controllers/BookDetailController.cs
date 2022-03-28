using Microsoft.AspNetCore.Mvc;

namespace SecondApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BookDetailController : ControllerBase
{
    private readonly ILogger<BookDetailController> _logger;

    public BookDetailController(ILogger<BookDetailController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<BookDetail> Get()
    {
        var books = new List<BookDetail>
        {
            new()
            {
                Title = "Blazor Server .NET 6 Fundamentals",
                Author = "Huy Tran",
                Publisher = "Blazor School"
            },
            new()
            {
                Title = "Blazor WebAssembly .NET 6 Fundamentals",
                Author = "Huy Tran",
                Publisher = "Blazor School"
            },
            new()
            {
                Title = "Blazor Server .NET 6 Advanced",
                Author = "Huy Tran",
                Publisher = "Blazor School"
            },
            new()
            {
                Title = "Blazor WebAssembly .NET 6 Advanced",
                Author = "Huy Tran",
                Publisher = "Blazor School"
            }
        };

        return books;
    }
}

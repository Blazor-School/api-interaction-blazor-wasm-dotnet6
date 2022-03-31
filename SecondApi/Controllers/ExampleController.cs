using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SecondApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    [HttpPost("[action]")]
    public void ProcessComplexData([FromBody] ExampleClass data) => Console.WriteLine($"Data received: {JsonConvert.SerializeObject(data)}.");

    [HttpPost("[action]")]
    public void ProcessPrimitiveData([FromBody] string data) => Console.WriteLine($"Data received: {data}.");

    [HttpPost("[action]")]
    public void ProcessStreamdata([FromForm] ExampleStreamClass streamModel) => Console.WriteLine($"Stream received with length: {streamModel.FileStream.Length}");

    [HttpGet("[action]")]
    public IActionResult ReturnPrimitiveData() => Ok("Blazor School");

    [HttpGet("[action]")]
    public IActionResult ReturnComplexData() => Ok(new ExampleClass { ExampleString = "Blazor School" });
}
using Microsoft.AspNetCore.Components.Forms;

namespace ApiInteractionMultipleApis.Models;

public class ExampleFormModel
{
    public IBrowserFile ExampleFile { get; set; } = default!;
}
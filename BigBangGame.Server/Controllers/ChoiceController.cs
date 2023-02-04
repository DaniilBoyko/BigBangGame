using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BigBangGame.Server.Controllers;

[ApiController]
public class ChoiceController : ControllerBase
{
	private readonly IChoiceService _choiceService;

	public ChoiceController(IChoiceService choiceService)
	{
		_choiceService= choiceService;
	}

	[HttpGet("/choices")]
	public IEnumerable<Choice> GetChoices()
	{
		return _choiceService.GetAvailableChoices();
	}

    [HttpGet("/choice")]
    public Choice GetRandomChoice()
    {
        return _choiceService.GetRandomChoice();
    }
}

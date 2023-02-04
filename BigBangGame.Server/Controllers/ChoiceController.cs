using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BigBangGame.Server.Controllers;

[ApiController]
public class ChoiceController : ControllerBase
{
	private readonly IChoiceServices _choiceServices;

	public ChoiceController(IChoiceServices choiceService)
	{
		_choiceServices= choiceService;
	}

	[HttpGet("/choices")]
	public IEnumerable<Choice> GetChoices()
	{
		return _choiceServices.GetAvailableChoices();
	}

    [HttpGet("/choice")]
    public Choice GetRandomChoice()
    {
        return _choiceServices.GetRandomChoice();
    }
}

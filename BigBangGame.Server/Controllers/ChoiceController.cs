using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BigBangGame.Server.Controllers;

[ApiController]
public class ChoiceController : ControllerBase
{
	private readonly IChoiceStorage _choiceStorage;
    private readonly IChoiceSelector _choiceSelector;

    public ChoiceController(IChoiceStorage choiceStorage,
        IChoiceSelector choiceSelector)
    {
        _choiceStorage= choiceStorage;
        _choiceSelector = choiceSelector;
    }

	[HttpGet("/choices")]
	public IEnumerable<Choice> GetChoices()
	{
		return _choiceStorage.GetChoices();
	}

    [HttpGet("/choice")]
    public Choice GetRandomChoice()
    {
        return _choiceSelector.GetRandomChoice();
    }
}

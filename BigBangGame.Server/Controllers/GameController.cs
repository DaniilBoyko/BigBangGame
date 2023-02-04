using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Models.Input;
using BigBangGame.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BigBangGame.Server.Controllers;

[ApiController]
public class GameController : ControllerBase
{
	private readonly IPlayService _playService;

	public GameController(IPlayService playService)
	{
		_playService= playService;
	}

    [HttpPost("/play")]
    public ComputerGameResult PlayGame([FromBody] PlayerTurn playerTurn)
    {
        return _playService.PlayWithComputer(playerTurn.ChoiceId!.Value);
    }
}

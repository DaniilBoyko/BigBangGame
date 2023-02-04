using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BigBangGame.Server.Controllers;

[ApiController]
public class ScoreboardController : ControllerBase
{
    private readonly IScoreboardService _scoreboardService;

    public ScoreboardController(IScoreboardService scoreboardService)
    {
        _scoreboardService = scoreboardService;
    }

    [HttpGet("scoreboard")]
    public IEnumerable<ScoreboardItem> GetScoreboardItems()
    {
        return _scoreboardService.GetScoreboardItems();
    }

    [HttpDelete("scoreboard/clear")]
    public IActionResult ClearScoreboard()
    {
        _scoreboardService.ClearScoreboard();
        return Ok();
    }
}
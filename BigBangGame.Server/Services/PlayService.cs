using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Services.Interfaces;

namespace BigBangGame.Server.Services;

public class PlayService : IPlayService
{
    private readonly IChoiceService _choiceService;
    private readonly IScoreboardService _scoreboardService;

    public PlayService(IChoiceService choiceService,
        IScoreboardService scoreboardService)
    {
        _choiceService = choiceService;
        _scoreboardService = scoreboardService;
    }

    public ComputerGameResult PlayWithComputer(int playerChoiceId)
    {
        var computerChoice = _choiceService.GetRandomGameChoice();
        var playerChoice = _choiceService.GetGameChoiceById(playerChoiceId);

        if (playerChoice == null)
        {
            throw new Exception($"Unknown player choice Id: {playerChoiceId}");
        }

        var result = CalculateResult(playerChoice, computerChoice);

        AddScoreboardItem(playerChoice, computerChoice, result);

        return new ComputerGameResult(result, playerChoice.Id, computerChoice.Id);
    }

    private void AddScoreboardItem(GameChoice playerChoice, GameChoice computerChoice, string gameResult)
    {
        var scoreboardItem = new ScoreboardItem(
            FirstPlayerName: "Unknown",
            FirstPlayerChoice: playerChoice.Name,
            SecondPlayerName: "Computer",
            SecondPlayerChoice: computerChoice.Name,
            GameResult: gameResult,
            Date: DateTime.UtcNow
            );

        _scoreboardService.AddScoreboardItem(scoreboardItem);
    }

    private string CalculateResult(GameChoice firstChoice, GameChoice secondChoice)
    {
        if (firstChoice.Id == secondChoice.Id)
        {
            return "tie";
        }

        return firstChoice.BeatsChoiceIds.Contains(secondChoice.Id) ? "win" : "lose";
    }
}

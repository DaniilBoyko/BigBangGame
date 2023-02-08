using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Models.Enums;
using BigBangGame.Server.Services.Interfaces;

namespace BigBangGame.Server.Services;

public class PlayService : IPlayService
{
    private readonly IChoiceStorage _choiceStorage;
    private readonly IScoreboardService _scoreboardService;
    private readonly IChoiceSelector _choiceSelector;

    public PlayService(IChoiceStorage choiceStorage,
        IScoreboardService scoreboardService,
        IChoiceSelector choiceSelector)
    {
        _choiceStorage = choiceStorage;
        _scoreboardService = scoreboardService;
        _choiceSelector = choiceSelector;
    }

    public ComputerGameResult PlayWithComputer(int playerChoiceId)
    {
        var computerChoice = _choiceSelector.GetRandomGameChoice();
        var playerChoice = _choiceStorage.GetGameChoiceById(playerChoiceId);

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
            return GameResult.Tie.ToString();
        }

        return firstChoice.BeatsChoiceIds.Contains(secondChoice.Id)
            ? GameResult.Win.ToString()
            : GameResult.Lose.ToString();
    }
}

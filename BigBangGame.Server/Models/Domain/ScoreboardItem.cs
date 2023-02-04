namespace BigBangGame.Server.Models.Domain;

public record class ScoreboardItem(
    string FirstPlayerName,
    string FirstPlayerChoice,
    string SecondPlayerName,
    string SecondPlayerChoice,
    string GameResult,
    DateTime Date);
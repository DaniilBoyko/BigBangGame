using BigBangGame.Server.Models.Domain;

namespace BigBangGame.Server.Services.Interfaces;

public interface IScoreboardService
{
    void AddScoreboardItem(ScoreboardItem scoreboardItem);
    IEnumerable<ScoreboardItem> GetScoreboardItems();
    void ClearScoreboard();
}
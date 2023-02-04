using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Services.Interfaces;

namespace BigBangGame.Server.Services;

public class ScoreboardService : IScoreboardService
{
    private readonly LinkedList<ScoreboardItem> _scoreItems = new();

    private const int MaxScoreItemsCount = 10;

    public void AddScoreboardItem(ScoreboardItem scoreboardItem)
    {
        lock (_scoreItems)
        {
            _scoreItems.AddFirst(scoreboardItem);

            if (_scoreItems.Count > MaxScoreItemsCount)
            {
                _scoreItems.RemoveLast();
            }
        }
    }

    public IEnumerable<ScoreboardItem> GetScoreboardItems()
    {
        LinkedList<ScoreboardItem> scoreboardCopy;
        lock (_scoreItems)
        {
            scoreboardCopy = new LinkedList<ScoreboardItem>(_scoreItems);
        }

        return scoreboardCopy;
    }

    public void ClearScoreboard()
    {
        lock (_scoreItems)
        {
            _scoreItems.Clear();
        }
    }
}
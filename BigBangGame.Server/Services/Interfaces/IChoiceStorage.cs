using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Models.Enums;

namespace BigBangGame.Server.Services.Interfaces;

public interface IChoiceStorage
{
    IList<Choice> GetChoices();
    IList<GameChoice> GetGameChoices();
    GameChoice? GetGameChoiceById(int choiceId);
    GameChoice? GetGameChoiceByName(ChoiceName choiceName);
}

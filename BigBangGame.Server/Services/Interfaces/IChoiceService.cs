using BigBangGame.Server.Models.Domain;

namespace BigBangGame.Server.Services.Interfaces;

public interface IChoiceService
{
    IEnumerable<Choice> GetAvailableChoices();
    Choice GetRandomChoice();
    GameChoice GetRandomGameChoice();
    GameChoice? GetGameChoiceById(int choiceId);
}

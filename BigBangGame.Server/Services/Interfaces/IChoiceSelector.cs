using BigBangGame.Server.Models.Domain;

namespace BigBangGame.Server.Services.Interfaces;

public interface IChoiceSelector
{
    Choice GetRandomChoice();
    GameChoice GetRandomGameChoice();
}
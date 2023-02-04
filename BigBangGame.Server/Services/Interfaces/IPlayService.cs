using BigBangGame.Server.Models.Domain;

namespace BigBangGame.Server.Services.Interfaces;

public interface IPlayService
{
    ComputerGameResult PlayWithComputer(int playerChoiceId);
}

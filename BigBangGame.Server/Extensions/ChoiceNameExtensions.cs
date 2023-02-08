using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Models.Enums;

namespace BigBangGame.Server.Extensions;

public static class ChoiceNameExtensions
{
    public static GameChoice ToGameChoice(this ChoiceName choiceName, params int[] beatsChoiceIds)
    {
        var id = (int)choiceName;
        var name = choiceName.ToString().ToLower();
        return new GameChoice
        {
            Id = id,
            Name = name,
            BeatsChoiceIds = beatsChoiceIds
        };
    }
}
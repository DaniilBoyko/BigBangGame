using System.Collections.Concurrent;
using AutoMapper;
using BigBangGame.Server.Extensions;
using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Models.Enums;
using BigBangGame.Server.Services.Interfaces;

namespace BigBangGame.Server.Services;

public class ChoiceStorage : IChoiceStorage
{
    private readonly IMapper _mapper;
    private readonly ConcurrentDictionary<int, GameChoice> _choices = new();

    public ChoiceStorage(IMapper mapper)
    {
        _mapper = mapper;
        _choices.GetOrAdd((int)ChoiceName.Rock, ChoiceName.Rock.ToGameChoice(5, 3));
        _choices.GetOrAdd((int)ChoiceName.Paper, ChoiceName.Paper.ToGameChoice(1, 4));
        _choices.GetOrAdd((int)ChoiceName.Scissors, ChoiceName.Scissors.ToGameChoice(2, 5));
        _choices.GetOrAdd((int)ChoiceName.Spock, ChoiceName.Spock.ToGameChoice(3, 1));
        _choices.GetOrAdd((int)ChoiceName.Lizard, ChoiceName.Lizard.ToGameChoice(4, 2));
    }

    public IList<Choice> GetChoices()
    {
        return _choices.Select(x => _mapper.Map<Choice>(x.Value)).ToArray();
    }

    public IList<GameChoice> GetGameChoices()
    {
        return _choices.Select(x => x.Value).ToArray();
    }

    public GameChoice? GetGameChoiceById(int choiceId)
    {
        _choices.TryGetValue(choiceId, out var choice);
        return choice;
    }

    public GameChoice? GetGameChoiceByName(ChoiceName choiceName)
    {
        return GetGameChoiceById((int)choiceName);
    }
}

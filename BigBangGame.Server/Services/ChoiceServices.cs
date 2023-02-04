using System.Collections.Concurrent;
using AutoMapper;
using BigBangGame.Server.Extensions;
using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Services.Interfaces;

namespace BigBangGame.Server.Services;

public class ChoiceServices : IChoiceServices
{
    private readonly IMapper _mapper;
    private readonly ConcurrentDictionary<int, GameChoice> _choices = new();

    public ChoiceServices(IMapper mapper)
    {
        _mapper = mapper;
        _choices.GetOrAdd(1, new GameChoice(Id: 1, Name: "rock", BeatsChoiceIds: new[] {5, 3}));
        _choices.GetOrAdd(2, new GameChoice(Id: 2, Name: "paper", BeatsChoiceIds: new[] {1, 4}));
        _choices.GetOrAdd(3, new GameChoice(Id: 3, Name: "scissors", BeatsChoiceIds: new[] {2, 5}));
        _choices.GetOrAdd(4, new GameChoice(Id: 4, Name: "spock", BeatsChoiceIds: new[] {3, 1}));
        _choices.GetOrAdd(5, new GameChoice(Id: 5, Name: "lizard", BeatsChoiceIds: new[] {4, 2}));
    }

    public IEnumerable<Choice> GetAvailableChoices()
    {
        return _choices.Select(x => _mapper.Map<Choice>(x.Value)).ToArray();
    }

    public Choice GetRandomChoice()
    {
        var randomChoice = _choices.Select(x => x.Value).ToArray().GetRandom();
        return _mapper.Map<Choice>(randomChoice);
    }

    public GameChoice GetRandomGameChoice()
    {
        return _choices.Select(x => x.Value).ToArray().GetRandom();
    }

    public GameChoice? GetGameChoiceById(int choiceId)
    {
        _choices.TryGetValue(choiceId, out var choice);
        return choice;
    }
}

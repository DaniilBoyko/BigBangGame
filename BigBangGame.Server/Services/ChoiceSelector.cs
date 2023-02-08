using AutoMapper;
using BigBangGame.Server.Extensions;
using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Services.Interfaces;

namespace BigBangGame.Server.Services;

public class ChoiceSelector : IChoiceSelector
{
    private readonly IChoiceStorage _choiceStorage;
    private readonly IMapper _mapper;

    public ChoiceSelector(IChoiceStorage choiceStorage,
        IMapper mapper)
    {
        _choiceStorage = choiceStorage;
        _mapper = mapper;
    }

    public Choice GetRandomChoice()
    {
        var choices = _choiceStorage.GetChoices();
        var randomChoice = choices.GetRandom();
        return _mapper.Map<Choice>(randomChoice);
    }

    public GameChoice GetRandomGameChoice()
    {
        var choices = _choiceStorage.GetGameChoices();
        return choices.GetRandom();
    }
}
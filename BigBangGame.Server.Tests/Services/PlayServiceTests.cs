using AutoMapper;
using BigBangGame.Server.Mapping;
using BigBangGame.Server.Models.Domain;
using BigBangGame.Server.Models.Enums;
using BigBangGame.Server.Services;
using BigBangGame.Server.Services.Interfaces;
using FluentAssertions;
using Moq;

namespace BigBangGame.Server.Tests.Services;

internal class PlayServiceTests
{
    private readonly IPlayService _sut;
    private readonly IChoiceStorage _choiceStorage;

    private GameChoice _computerGameChoice;

    public PlayServiceTests()
    {
        var mapper = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        }).CreateMapper();

        _computerGameChoice = new GameChoice();
        _choiceStorage = new ChoiceStorage(mapper);
        var choiceSelectorMock = new Mock<IChoiceSelector>();
        choiceSelectorMock.Setup(x => x.GetRandomGameChoice()).Returns(() => _computerGameChoice);
        
        var scoreboardService = new Mock<IScoreboardService>().Object;

        _sut = new PlayService(_choiceStorage, scoreboardService, choiceSelectorMock.Object);
    }

    [Test]
    [TestCase(ChoiceName.Rock, ChoiceName.Lizard)]
    [TestCase(ChoiceName.Rock, ChoiceName.Scissors)]
    [TestCase(ChoiceName.Lizard, ChoiceName.Spock)]
    [TestCase(ChoiceName.Lizard, ChoiceName.Paper)]
    [TestCase(ChoiceName.Spock, ChoiceName.Scissors)]
    [TestCase(ChoiceName.Spock, ChoiceName.Rock)]
    [TestCase(ChoiceName.Scissors, ChoiceName.Paper)]
    [TestCase(ChoiceName.Scissors, ChoiceName.Lizard)]
    [TestCase(ChoiceName.Paper, ChoiceName.Rock)]
    [TestCase(ChoiceName.Paper, ChoiceName.Spock)]
    public void PlayWithComputer_CheckThatUserWinInAppropriateCases(ChoiceName userChoice, ChoiceName computerChoice)
    {
        _computerGameChoice = _choiceStorage.GetGameChoiceByName(computerChoice)!;
        ReplaceComputerGameChoice(_computerGameChoice);

        var gameResult = _sut.PlayWithComputer((int)userChoice);

        gameResult.Result.Should().Be(GameResult.Win.ToString());
    }

    [Test]
    [TestCase(ChoiceName.Rock, ChoiceName.Rock)]
    [TestCase(ChoiceName.Lizard, ChoiceName.Lizard)]
    [TestCase(ChoiceName.Spock, ChoiceName.Spock)]
    [TestCase(ChoiceName.Scissors, ChoiceName.Scissors)]
    [TestCase(ChoiceName.Paper, ChoiceName.Paper)]
    public void PlayWithComputer_CheckThatUserTieInAppropriateCases(ChoiceName userChoice, ChoiceName computerChoice)
    {
        _computerGameChoice = _choiceStorage.GetGameChoiceByName(computerChoice)!;
        ReplaceComputerGameChoice(_computerGameChoice);

        var gameResult = _sut.PlayWithComputer((int)userChoice);

        gameResult.Result.Should().Be(GameResult.Tie.ToString());
    }

    [Test]
    [TestCase(ChoiceName.Rock, ChoiceName.Paper)]
    [TestCase(ChoiceName.Rock, ChoiceName.Spock)]
    [TestCase(ChoiceName.Lizard, ChoiceName.Rock)]
    [TestCase(ChoiceName.Lizard, ChoiceName.Scissors)]
    [TestCase(ChoiceName.Spock, ChoiceName.Lizard)]
    [TestCase(ChoiceName.Spock, ChoiceName.Paper)]
    [TestCase(ChoiceName.Scissors, ChoiceName.Spock)]
    [TestCase(ChoiceName.Scissors, ChoiceName.Rock)]
    [TestCase(ChoiceName.Paper, ChoiceName.Scissors)]
    [TestCase(ChoiceName.Paper, ChoiceName.Lizard)]
    public void PlayWithComputer_CheckThatUserLoseInAppropriateCases(ChoiceName userChoice, ChoiceName computerChoice)
    {
        _computerGameChoice = _choiceStorage.GetGameChoiceByName(computerChoice)!;
        ReplaceComputerGameChoice(_computerGameChoice);

        var gameResult = _sut.PlayWithComputer((int)userChoice);

        gameResult.Result.Should().Be(GameResult.Lose.ToString());
    }

    private void ReplaceComputerGameChoice(GameChoice gameChoice)
    {
        _computerGameChoice.Id = gameChoice.Id;
        _computerGameChoice.Name = gameChoice.Name;
        _computerGameChoice.BeatsChoiceIds = gameChoice.BeatsChoiceIds;
    }
}
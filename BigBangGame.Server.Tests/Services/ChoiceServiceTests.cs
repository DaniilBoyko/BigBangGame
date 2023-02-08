using AutoMapper;
using BigBangGame.Server.Mapping;
using BigBangGame.Server.Services;
using BigBangGame.Server.Services.Interfaces;
using FluentAssertions;

namespace BigBangGame.Server.Tests.Services;

internal class ChoiceServiceTests
{
    private readonly IChoiceStorage _sut;

    public ChoiceServiceTests()
    {
        var mapper = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        }).CreateMapper();

        _sut = new ChoiceStorage(mapper);
    }

    [Test]
    public void GetAvailableChoices_Rerun5Choices()
    {
        var choices = _sut.GetChoices().ToList();

        choices.Should().HaveCount(5);
    }

    [Test]
    [TestCase(1, "rock")]
    [TestCase(2, "paper")]
    [TestCase(3, "scissors")]
    [TestCase(4, "spock")]
    [TestCase(5, "lizard")]
    public void GetAvailableChoices_ShouldHaveCorrectNames(int choiceId, string name)
    {
        var choices = _sut.GetChoices().ToList();
        var choice = choices.FirstOrDefault(x => x.Id == choiceId);

        choice.Should().NotBeNull();
        choice!.Name.Should().Be(name);
    }
}

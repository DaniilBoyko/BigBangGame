namespace BigBangGame.Server.Models.Domain;

public class GameChoice
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int[] BeatsChoiceIds { get; set; }
}

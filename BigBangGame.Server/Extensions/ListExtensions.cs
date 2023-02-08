namespace BigBangGame.Server.Extensions;

public static class ListExtensions
{
    public static T GetRandom<T>(this IList<T> collection)
    {
        return collection[Random.Shared.Next(0, collection.Count)];
    }
}

namespace Business.Helpers;

public static class IdGenerator
{
    public static string Generate() => Guid.NewGuid().ToString();
}
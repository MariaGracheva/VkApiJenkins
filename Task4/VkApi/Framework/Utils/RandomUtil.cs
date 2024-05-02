namespace Framework.Utils
{
    public class RandomUtil
    {
        private static readonly Random Random = new();

        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateRandomString(int lengthOfString) => new(Enumerable.Repeat(Letters, lengthOfString).Select(str => str[Random.Next(str.Length)]).ToArray());
    }
}
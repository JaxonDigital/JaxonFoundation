using System.Security.Cryptography;

namespace JaxonFoundation.Logic.Extensions
{
    public static class CalculateMD5
    {
        public static string CreateHash(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}

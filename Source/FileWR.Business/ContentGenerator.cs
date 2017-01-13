using System;
using System.Linq;
using System.Text;

namespace FileWR.Business
{
    public static class ContentGenerator
    {
        public static byte[] GenerateFileContents()
        {
            var _randomNumberGenerator = new Random();
            var _unicodeEncoding= new UnicodeEncoding();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            var randomString = new string(Enumerable.Repeat(chars, 1000000)
              .Select(p => p[_randomNumberGenerator.Next(p.Length)]).ToArray());

            return _unicodeEncoding.GetBytes(randomString);
        }
    }
}

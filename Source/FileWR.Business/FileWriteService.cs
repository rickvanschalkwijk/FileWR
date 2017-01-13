using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace FileWR.Business
{
    public class FileWriteService : IFileWriteService
    {
        private readonly ILogger<IFileWriteService> _logger;
        private readonly Random _randomNumberGenerator = new Random();
        private readonly UnicodeEncoding _unicodeEncoding = new UnicodeEncoding();

        public FileWriteService(ILogger<IFileWriteService> logger)
        {
            _logger = logger;
        }

        public byte[] GenerateFileContents()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            var randomString = new string(Enumerable.Repeat(chars, 1000000)
              .Select(p => p[_randomNumberGenerator.Next(p.Length)]).ToArray());

            return _unicodeEncoding.GetBytes(randomString);
        }
    }

    public interface IFileWriteService
    {
        byte[] GenerateFileContents();
    }
}

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FileWR.Business
{
    public class FileHelper : IFileHelper
    {
        private readonly ILogger<FileHelper> _logger;

        public FileHelper(ILogger<FileHelper> logger)
        {
            _logger = logger;
        }
        public async Task<string> Bar()
        {
            _logger.LogInformation("Begin write to file");

            return "lol";
        }
    }

    public interface IFileHelper
    {
        Task<string> Bar();
    }
}

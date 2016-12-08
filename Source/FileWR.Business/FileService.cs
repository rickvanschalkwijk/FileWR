using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FileWR.Business
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }
        public async Task<bool> CreateFileAsync(string path)
        {
            try
            {
                File.Create(path);
                _logger.LogInformation($"File created at path: {path}");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to create file: {ex}");
                return false;
            }
        }
    }

    public interface IFileService
    {
        Task<bool> CreateFileAsync(string path);
    }
}

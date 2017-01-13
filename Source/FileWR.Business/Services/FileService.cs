using System;
using System.IO;
using System.Threading.Tasks;
using FileWR.Business.Services;
using Microsoft.Extensions.Logging;

namespace FileWR.Business.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly IDirectoryService _directoryService;

        public FileService(ILogger<FileService> logger, IDirectoryService directoryService)
        {
            _logger = logger;
            _directoryService = directoryService;
        }
        public async Task<string> CreateFileAsync(string path)
        {
            var combinedPath = string.Empty;

            try
            {
                var dirPath = await _directoryService.CreateDirectoryAsync("input");
                combinedPath = Path.Combine(dirPath, path);

                using (File.Create(combinedPath))

                _logger.LogInformation($"File created at path: {combinedPath}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to create file: {ex}");
            }

            return combinedPath;
        }    
    }

    public interface IFileService
    {
        Task<string> CreateFileAsync(string path);
    }
}

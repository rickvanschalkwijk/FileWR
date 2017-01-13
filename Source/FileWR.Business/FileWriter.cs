using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWR.Business.Services;
using Microsoft.Extensions.Logging;

namespace FileWR.Business
{
    public class FileWriter : IFileWriter
    {
        private readonly ILogger<FileWriter> _logger;
        private readonly IDirectoryService _directoryService;

        public FileWriter(ILogger<FileWriter> logger, IDirectoryService directoryService)
        {
            _logger = logger;
            _directoryService = directoryService;
        }
        public async Task<string> CreateFileAsync(string path, string content)
        {
            var combinedPath = string.Empty;

            try
            {
                var dirPath = await _directoryService.CreateDirectoryAsync("input");
                combinedPath = Path.Combine(dirPath, path);

                using (StreamWriter writer = File.CreateText(combinedPath))
                {
                    await writer.WriteAsync(content);
                }

                _logger.LogInformation($"File created at path: {combinedPath}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to create file: {ex}");
            }

            return combinedPath;
        }
    }

    public interface IFileWriter
    {
        Task<string> CreateFileAsync(string path, string content);
    }
}

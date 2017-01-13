using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FileWR.Business
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly IDirectoryService _directoryService;
        private readonly IFileWriteService _fileWriteService;

        public FileService(ILogger<FileService> logger, IDirectoryService directoryService, IFileWriteService fileWriteService)
        {
            _logger = logger;
            _directoryService = directoryService;
            _fileWriteService = fileWriteService;
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

        public async Task WriteToFileAsync(string path)
        {         
            await WriteToFileAsync(path, _fileWriteService.GenerateFileContents());
        }

        public async Task WriteToFileAsync(string path, byte[] bytesToWrite)
        {
            try
            {
                using (FileStream stream = File.Open(path, FileMode.Open))
                {
                    stream.Seek(0, SeekOrigin.End);
                    await stream.WriteAsync(bytesToWrite, 0, bytesToWrite.Length);
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError($"Can not file source file: {ex}");
            }
        }
    }

    public interface IFileService
    {
        Task<string> CreateFileAsync(string path);

        Task WriteToFileAsync(string path);

        Task WriteToFileAsync(string path, byte[] bytesToWrite);
    }
}

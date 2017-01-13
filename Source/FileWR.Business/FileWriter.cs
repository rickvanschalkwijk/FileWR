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
        private readonly ILogger<FileService> _logger;

        public FileWriter(ILogger<FileService> logger)
        {
            _logger = logger;
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

    public interface IFileWriter
    {
        Task WriteToFileAsync(string path, byte[] bytesToWrite);
    }
}

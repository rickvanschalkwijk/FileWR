using System.Threading.Tasks;
using FileWR.Business;
using FileWR.Business.Services;

namespace FileWR
{
    public class FileWR
    {
        private readonly IFileService _fileService;
        private readonly IFileWriter _fileWriter;

        public FileWR(IFileService fileService, IFileWriter fileWriter)
        {
            _fileService = fileService;
            _fileWriter = fileWriter;
        }

        public async Task Run()
        {
            var filePath = await _fileService.CreateFileAsync("random-input-file.txt");
            await _fileWriter.WriteToFileAsync(filePath, ContentGenerator.GenerateFileContents());
        }
    }
}


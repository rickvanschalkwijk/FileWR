using System.Threading.Tasks;
using FileWR.Business;

namespace FileWR
{
    public class FileWR
    {
        private readonly IFileService _fileService;

        public FileWR(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task Run()
        {
            var filePath = await _fileService.CreateFileAsync("random-input-file.txt");
            await _fileService.WriteToFileAsync(filePath);
        }
    }
}


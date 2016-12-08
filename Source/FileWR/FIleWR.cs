using System.Threading.Tasks;
using FileWR.Business;

namespace FileWR
{
    /*
     * TODO
     * Create timer to see excution time
     * 
     */
    public class FileWR
    {
        private readonly IFileService _fileService;
        private readonly IDirectoryService _directoryService;

        public FileWR(IFileService fileService, IDirectoryService directoryService)
        {
            _fileService = fileService;
            _directoryService = directoryService;
        }

        public async Task Run()
        {
            var createdDir = await _directoryService.CreateDirectoryAsync("input");

            await _fileService.CreateFileAsync("file.txt");
        }
    }
}


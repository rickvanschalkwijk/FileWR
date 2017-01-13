using System.Threading.Tasks;
using FileWR.Business;
using FileWR.Business.Services;

namespace FileWR
{
    public class FileWR
    {
        private readonly IFileWriter _fileWriter;
        private readonly IFileReader _fileReader;

        public FileWR(IFileWriter fileWriter, IFileReader fileReader)
        {
            _fileWriter = fileWriter;
            _fileReader = fileReader;
        }

        public async Task Run()
        {
            var filePath = await _fileWriter.CreateFileAsync("random-input-file.txt", ContentHelper.GenerateFileContents());
            var content = await _fileReader.ReadAsync(filePath);
            var splitFileContent = ContentHelper.SplitFileContent(content);
            await _fileWriter.CreateFileAsync("char-output-file.txt", splitFileContent["chars"]);
            await _fileWriter.CreateFileAsync("digits-output-file.txt", splitFileContent["digits"]);
        }
    }
}


using System;
using System.Threading.Tasks;
using FileWR.Business;

namespace FileWR
{
    public class FileWR
    {
        private readonly IFileHelper _fileHelper;

        public FileWR(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        public async Task Run()
        {
            var response = await _fileHelper.Bar();

            Console.WriteLine(response);
        }
    }
}


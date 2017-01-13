using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileWR.Business
{
    public class FileReader : IFileReader
    {
        public async Task<string> ReadAsync(string path)
        {
            using (StreamReader stream = File.OpenText(path))
            {
                try
                {
                    var fileText = await stream.ReadToEndAsync();

                    return fileText;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }
    }

    public interface IFileReader
    {
        Task<string> ReadAsync(string path);
    }
}

using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Ecom.Services
{
    public interface IArchiveService
    {
        public Task ExportJSON<T>(IEnumerable<T> list);
    }
    public class ArchiveService : IArchiveService
    {
        private readonly Random random = new();
        public Task ExportJSON<T>(IEnumerable<T> list)
        {
            if (list.Any())
            {
                var filename = $@"Archive\{list.First().GetType().Name}";
                bool append = true;
                if(random.NextDouble() < 0.0000001)
                {
                    ArchieveFile(filename);
                    append = false;
                }
                using var f = new StreamWriter(filename, append);
                foreach (var item in list)
                {
                    string jsonString = JsonSerializer.Serialize(item);
                    _ = f.WriteLineAsync(jsonString);
                }

            }

            return Task.CompletedTask;
        }

        private  void ArchieveFile(string filename)
        {
            string newName = filename + DateTime.UtcNow.ToShortDateString();
            // PS: notification JSON is roughly about 1KB 
            using FileStream sourceFile = File.OpenRead(filename);
            using FileStream destinationFile = File.Create(newName);
            using GZipStream output = new(destinationFile, CompressionMode.Compress);
            sourceFile.CopyTo(output);
            File.Delete(filename);
        }
    }
}

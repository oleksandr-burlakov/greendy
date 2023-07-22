
namespace Greendy.Application.Helpers {
    public class FileHelper {
        public async Task<string> SaveFile(string filePath, byte[] file) {
            var directoryName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryName) && directoryName != null) {
                Directory.CreateDirectory(directoryName);
            }
            await File.WriteAllBytesAsync(filePath, file);
            return filePath;
        }
    }
}
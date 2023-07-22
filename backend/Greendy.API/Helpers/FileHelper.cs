namespace Greendy.API.Helpers {
    public class FileHelper 
    {
        public async Task<byte[]?> GetByteArray(IFormFile file) 
        {
            if (file.Length == 0) {
                return null;
            }
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
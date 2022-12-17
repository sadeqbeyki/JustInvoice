using Microsoft.AspNetCore.Http;

namespace AppFramework;

public interface IFileUploader
{
    string Upload(IFormFile file, string path);
    string GetUploadFileName(IFormFile file);
}

using Microsoft.AspNetCore.Http;

namespace InvoiceFramework;

public interface IFileUploader
{
    string Upload(IFormFile file, string path);
    string GetUploadFileName(IFormFile file);
}

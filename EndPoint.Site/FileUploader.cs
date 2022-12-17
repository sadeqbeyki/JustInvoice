using AppFramework;

namespace EndPoint.Site;
public class FileUploader : IFileUploader
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUploader(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


    public string Upload(IFormFile file, string path)
    {
        if (file == null) return " ";

        var uploadFolder = $"{_webHostEnvironment.WebRootPath}/Images/{path}";

        if (!Directory.Exists(uploadFolder))
            Directory.CreateDirectory(uploadFolder);

        var uniqueFileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
        var filePath = $"{uploadFolder}/{uniqueFileName}";
        using var output = File.Create(filePath);
        file.CopyTo(output);
        return $"{path}/{uniqueFileName}";
    }

    //string uniqueFileName = GetUploadFileName(Factor);
    //Factor.PhotoUrl = uniqueFileName;



    public string GetUploadFileName(IFormFile file)
    {
        string uniqueFileName = string.Empty;
        if (file != null)
        {
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadFolder, uniqueFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
        }
        return uniqueFileName;
    }
}

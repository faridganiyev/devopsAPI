using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;

namespace DevopsAPI.Helpers
{
    public class MediaService : IMedia
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public MediaService(IWebHostEnvironment hostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _hostEnvironment = hostEnvironment;
            _contextAccessor = contextAccessor;
        }

       
        public async Task<(string[] pathList, string[] thumbPathList, string[] fileNameList)> UploadImageList(List<IFormFile> fileList, string folder, int thumbWidth = 120, int thumbHeight = 120)
        {
            var pathList = new string[fileList.Count];
            var thumbPathList = new string[fileList.Count];
            var fileNameList = new string[fileList.Count];

            //schema+base url
            var requestContext = _contextAccessor.HttpContext.Request;
            var baseUrl = $"{requestContext.Scheme}://{requestContext.Host}";

            for (int i = 0; i < fileList.Count; i++)
            {
                var extension = $".{fileList[i].FileName.Split('.')[^1]}";
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(_hostEnvironment.WebRootPath, $"photos/{folder}", $"{fileName}{extension}");
                var pathThumb = Path.Combine(_hostEnvironment.WebRootPath, "photos/thumbs", $"{fileName}{extension}");

                //original sekli upload edir
                using var stream = new FileStream(path, FileMode.Create);
                await fileList[i].CopyToAsync(stream);

                //thumbnail upload etmek
                CreateAndSaveThumbnail(fileList[i], pathThumb);

                //result hazirlamaq
                pathList[i] = $"{baseUrl}/photos/{folder}/{fileName}{extension}";
                thumbPathList[i] = $"{baseUrl}/photos/thumbs/{fileName}{extension}";
                fileNameList[i] = $"{fileName}{extension}";
            }
            return (pathList, thumbPathList, fileNameList);
        }

        public async Task<(string fullPath, string thumbPath, string fileName)> UploadImage(IFormFile file, string folder, int thumbWidth = 120, int thumbHeight = 120)
        {
            var extentions = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString();

            var path = Path.Combine(_hostEnvironment.WebRootPath, $"photos/{folder}");

            var fullPath = Path.Combine(path, $"{fileName}{extentions}");
            var pathThumb = Path.Combine(_hostEnvironment.WebRootPath, "photos/thumbs", $"{fileName}{extentions}");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //original sekli upload edir
            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            var requestContext = _contextAccessor?.HttpContext?.Request;
            var baseUrl = $"{requestContext?.Scheme}://{requestContext?.Host}";

            //thumbnail upload etmek
            CreateAndSaveThumbnail(file, pathThumb);
            return ($"{baseUrl}/photos/{folder}/{fileName}{extentions}", $"{baseUrl}/photos/thumbs/{fileName}{extentions}", fileName);
        }

        private static void CreateAndSaveThumbnail(IFormFile file, string outputPath)
        {
            using var input = file.OpenReadStream();
            using Image image = Image.Load(input);
            int width = image.Width / 2;
            int height = image.Height / 2;
            image.Mutate(x => x.Resize(
                width >= 360 
                    ? 360 
                    : width, 
                height >= 360 
                    ? 360 
                    : height, 
                KnownResamplers.Lanczos3));
            image.Save(outputPath);
        }

        public bool DeleteFile(string fileName, string folder)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, $"photos/{folder}", fileName);
            var pathThumb = Path.Combine(_hostEnvironment.WebRootPath, $"photos/{folder}_thumbnails", fileName);
            if (File.Exists(path) && File.Exists(pathThumb))
            {
                File.Delete(path);
                File.Delete(pathThumb);
            }
            return true;
        }
    }
}

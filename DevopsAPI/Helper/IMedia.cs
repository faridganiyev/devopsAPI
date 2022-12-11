namespace DevopsAPI.Helpers
{
    public interface IMedia
    {
        /// <summary>
        /// Upload list of image with thumbnails
        /// </summary>
        /// <param name="fileList"></param>
        /// <param name="folder"></param>
        /// <param name="thumbWidth"></param>
        /// <param name="thumbHeight"></param>
        /// <returns></returns>
        Task<(string[] pathList, string[] thumbPathList, string[] fileNameList)> UploadImageList(List<IFormFile> fileList, string folder, int thumbWidth = 120, int thumbHeight = 120);

        /// <summary>
        /// Upload image with thumbnail
        /// </summary>
        /// <param name="file"></param>
        /// <param name="folder"></param>
        /// <param name="thumbWidth"></param>
        /// <param name="thumbHeight"></param>
        /// <returns></returns>
        Task<(string fullPath, string thumbPath, string fileName)> UploadImage(IFormFile file, string folder, int thumbWidth = 120, int thumbHeight = 120);

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        bool DeleteFile(string fileName, string folder);
    }
}

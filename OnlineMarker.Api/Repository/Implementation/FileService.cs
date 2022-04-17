using OnlineMarker.Api.Repository.Interfaces;

namespace OnlineMarker.Api.Repository.Implementation
{
    public class FileService : IFileService
    {
        public FileInfo CopyTo(FileInfo file, string path, bool overwrite = false)
        {
            return file.CopyTo(path, overwrite);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public DirectoryInfo GetDirectoryInfo(string path)
        {
          return  new DirectoryInfo(path);
        }

        public FileInfo GetFileInfo(string path)
        {
           return  new FileInfo(path);
        }

        public FileInfo[] GetFiles(string rootpath, string path, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return new DirectoryInfo(rootpath).GetFiles(path, searchOption);
        }

        public FileInfo[] GetFiles(DirectoryInfo folder, string path, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return folder.GetFiles(path, searchOption);
        }

        public void WriteAllBytes(string path, byte[] byteData)
        {
            File.WriteAllBytes(path, byteData);
        }
    }
}

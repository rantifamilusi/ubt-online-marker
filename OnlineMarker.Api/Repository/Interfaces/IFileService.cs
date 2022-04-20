using System.IO;

namespace OnlineMarker.Api.Repository.Interfaces
{
    public interface IFileService
    {
        DirectoryInfo GetDirectoryInfo(string path);

        void WriteAllBytes(string path, byte[] byteData);

        FileInfo GetFileInfo(string path);
        FileInfo[] GetFiles(string rootpath, string path, SearchOption searchOption = SearchOption.TopDirectoryOnly);

        FileInfo[] GetFiles(DirectoryInfo folder, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly);

        bool FileExists(string path);

        FileInfo CopyTo (FileInfo file, string path, bool overwrite = false);
    }
}

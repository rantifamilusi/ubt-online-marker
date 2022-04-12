using OnlineMarker.Api.Repository.Implementation;
using OnlineMarker.Api.Repository.Interfaces;
using OnlineMarker.Shared;

namespace OnlineMarker.Api.Repository.Generic
{
    public static class Utility
    {
        private static IFileService _fileService;

      

        public static void InitFileService(IFileService fileService)
        {
            if (_fileService == null)
            _fileService = fileService;
        }

        public static List<SFilesInfo> GetNoScriptInfo(int errorid)
        {
            List<SFilesInfo> Sfiles = new List<SFilesInfo>();
            SFilesInfo Sfile = new SFilesInfo();
            Sfile.Markid = errorid;

            Sfiles.Add(Sfile);
            return Sfiles;
        }

        public static bool GetSeedScriptFiles(string papercode, string scriptno, DirectoryInfo seededfolder, DirectoryInfo SFilesfolder, string examyear)
        {
            InitFileService(new FileService());

            string varscriptno = $"??{papercode}{examyear.Substring(2, 2)}.jpg";

            DirectoryInfo backupfolder = _fileService.GetDirectoryInfo (SFilesfolder.FullName + "_BAK");

            if (_fileService.GetFiles(seededfolder,scriptno + varscriptno, SearchOption.TopDirectoryOnly).Count() == 0)
            {
                FileInfo[] scriptfiles = _fileService.GetFiles(backupfolder,scriptno + varscriptno, SearchOption.TopDirectoryOnly);
                if ((scriptfiles.Count() == 0))
                    scriptfiles = _fileService.GetFiles(SFilesfolder,scriptno + varscriptno, SearchOption.TopDirectoryOnly);

                foreach (var file in scriptfiles)
                {
                    string temppath = Path.Combine(seededfolder.FullName, file.Name);
                    _fileService.CopyTo(file, temppath, false);
                }
            }
            return true;
        }

        public static bool BackupScriptFiles(string papercode, string scriptno, DirectoryInfo SFilesfolder, string examyear)
        {
            InitFileService(new FileService());

            string varscriptno = $"??{papercode}{examyear.Substring(2, 2)}.jpg";
            
            DirectoryInfo backupfolder = _fileService.GetDirectoryInfo(SFilesfolder.FullName + "_BAK");

            FileInfo[] scriptfiles = _fileService.GetFiles(SFilesfolder, scriptno + varscriptno, SearchOption.TopDirectoryOnly);
            foreach (var file in scriptfiles)
            {
                string temppath = Path.Combine(backupfolder.FullName, file.Name);
                if (!(_fileService.FileExists(temppath)))
                    _fileService.CopyTo( file, temppath, false);
            }

            return true;
        }


        public static int GetNextSeedValue(int seedinterval, int totalmarked)
        {
      
            Random random = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);
            if ((seedinterval == 0))
                return -1;
            else
            {
                seedinterval -= 1;
                return random.Next(1, seedinterval) + totalmarked;// (seedinterval * random.Next()) + 1 + totalmarked;
            }
        }

    }
}

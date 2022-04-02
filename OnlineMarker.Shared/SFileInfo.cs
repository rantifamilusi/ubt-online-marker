namespace OnlineMarker.Shared
{
    public class SFilesInfo
    {
        public int Markid {get; set;}
        public string? Indexno { get; set; }
        public string? Scriptno { get; set; }
        public string? SFileName { get; set; }
        public string? OSFile { get; set; }
        public bool Seeded { get; set; }
        public string? Seededscriptid { get; set; }
        public int Totalsmarked { get; set; }
        public bool Newmessage { get; set; }
        public byte[]? SFilebyte { get; set; }
    }
}

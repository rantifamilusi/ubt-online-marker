using OnlineMarker.Shared;

namespace OnlineMarker.Api.Repository.Interfaces
{
    public interface IOnlineMarkerService
    {
        Task<List<PaperQuesInfo>> GetPaperQuesInfos(string examptype, string papercode);
    }
}

using OnlineMarker.Api.Repository.Interfaces;
using OnlineMarker.Domain.Models;
using OnlineMarker.Shared;
using Snickler.EFCore;

namespace OnlineMarker.Api.Repository.Implementation
{
    public class OnlineMarkerService : IOnlineMarkerService
    {
        private readonly NGOnlineMarkerContext _dbContext;

        public OnlineMarkerService(NGOnlineMarkerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<PaperQuesInfo>> GetPaperQuesInfos(string examptype, string papercode)
        {
            List<PaperQuesInfo> paperQuesInfos = new List<PaperQuesInfo>();
          
            await _dbContext.LoadStoredProc("WS_sp_PaperQues_LoadbyCode")
                 .WithSqlParam("examtype", examptype)
                 .WithSqlParam("papercode", papercode)
                 .ExecuteStoredProcAsync(x =>
                 {
                     var result = x.ReadToList<PaperQuesInfo>();
                     paperQuesInfos = result.ToList();
                 });
            return await Task.FromResult(paperQuesInfos);
        }
    }
}

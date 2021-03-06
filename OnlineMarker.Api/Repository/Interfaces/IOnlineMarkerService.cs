using OnlineMarker.Shared;

namespace OnlineMarker.Api.Repository.Interfaces
{
    public interface IOnlineMarkerService
    {
        bool Seed_DeleteScores(int markid, string scriptfileid);
        bool SeedScriptMark_byQues(int markid, string scriptno, int quesno, bool seeded);
        bool ScriptMark_Update(int markid, string scriptno, decimal totalscore, bool vetted);
        bool DeleteScores(int markid);
        int GetScriptsMarked_Examiner(string examtype, string papercode, string examinercode);

        bool CandScores_Insert(int markid, string scriptno);
        bool CandScores_Delete(int markid);
        bool CandScores_InsertReview(int markid, string scriptno);
        bool VetScriptType_Update(string papercode, string examinercode, int vetscripttype);
        bool VetCandScores_InsertAudit(int markid, string markerid);
        bool SeedScriptMark_Update(int markid, string scriptno, bool seeded);
        bool DepletedSeed_Update(string papercode);
        Task<List<PaperQuesInfo>> GetPaperQuesInfos(string examptype, string papercode);

        bool QScore_UpdateMarkedPages(int markid, int quesno, string markedpages);

        bool SeedQScore_Insert(QScoreInfo oinfo);
        bool QScore_Insert(QScoreInfo oinfo);
        bool QueryCandScript_MAL(int markid, string scriptno, int malpractice);
        bool CandScoresVet_InsertTemp(int markid, string markerid);
        bool CandScoresReview_InsertTemp(int markid, string markerid);

        Task<List<QScoreInfo>> GetCandScores_Temp(int markid, string markerid, string scriptno);

        Task<List<QScoreInfo>> GetCandScores_Vet(int markid, string examinercode, string scriptno);

        Task<List<QScoreInfo>> GetCandScores(int markid, string examinercode, string scriptno);
       
        int CandScores_CheckVet(int markid);

        Task<List<QScoreInfo>> Seed_GetCandScores(int markid, string markerid, string scriptno);
        int DepletedSeed_Insert(string examtype, string papercode, string examinercode);

        ScriptInfo GetNewScript(string examtype, string papercode, string examinercode, int totalscriptsmarked, int minvet, SeedInfo seededinfo);


        ScriptInfo GetVetScriptInfo_ExaminerNo(string examtype, string papercode, string markerid, string examinercode, int scripttype);
        bool GetSeededScript(string examtype, string papercode, string examinercode);
        int GetSeedScript(string examtype, string papercode, string examinercode);
        int GetDepletedSeed(string examtype, string papercode);
        ScriptInfo GetScriptsInfo_Seed(string examtype, string papercode, string examinercode);

        int GetSeedsMarked_Examiner(string examtype, string papercode, string examinercode);
        int GetSeededMarked_ByExaminer(string examtype, string papercode, string examinercode);
        ScriptInfo GetSeededScriptsInfo(string examtype, string papercode, string examinercode);
        ScriptInfo GetScriptInfo_Review(string examtype, string papercode, string examinercode, int scripttype, int markedid);
        bool UpdateScript_Review(int markid, int review);

        SeedInfo GetSeededInfo_ByExaminer(string examtype, string papercode, string examinercode);

        SeedInfo GetBulkAllocValues(string examtype, string papercode, string markingstatus);
        bool SeededScriptMark_Update(int markid, string scriptno);

        bool NextSeedVal_Update(string papercode, string examinercode, int nextseedval);

        ScriptInfo  GetScriptsInfo_ByExaminerNo(string examtype, string papercode, string examinercode);

        int GetExaminerUnmarkedscript(string examtype, string papercode, string examinercode);
        int Alloccentre_Insert(string examtype, string papercode, string examinercode, int totalalloc, int nextseedval);

        bool Alloccentre_Update(int logid, string centreno);

        bool AvailScript_Update(int logid);
        int GetNewAllocCentre(string examtype, string papercode, string examinercode, SeedInfo seededinfo);

        ScriptInfo ScriptsInfo_GetNew(int markid);
        string GetExaminers_ToVet(string papercode, string venuecode, string team);

        bool MaxAllocation_Update(int logid, int totalalloc, int totalscriptmarked, int scriptstovet);
        int ScriptInfoAvailable_Insert(string examtype, string papercode, string venuecode, string examinercode);

        string AllocCentre_GetNew(string examtype, string papercode, string allocid);

        int ScriptInfoByCentre_Insert(string examtype, string papercode, string venuecode, string examinercode, string centreno);


    }
}

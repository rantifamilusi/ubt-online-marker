using Microsoft.Extensions.Options;
using OnlineMarker.Api.Repository.Interfaces;
using OnlineMarker.Api.Settings;
using OnlineMarker.Domain.Models;
using OnlineMarker.Shared;
using Snickler.EFCore;

namespace OnlineMarker.Api.Repository.Implementation
{
    public class OnlineMarkerService : IOnlineMarkerService
    {
        private readonly NGOnlineMarkerContext _dbContext;
        private readonly AppSettings _appSettings;
        public OnlineMarkerService(NGOnlineMarkerContext dbContext, IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
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

    

        public int GetSeedScript(string examtype, string papercode, string examinercode)
        {
            try
            {
                int? data = 0 ;
                _dbContext.LoadStoredProc("WS_sp_GetSeedScript")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("examinercode", examinercode)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        data = x.ReadToValue<int>();
                                       
                                    });
                return data ?? 0;
            }
            catch
            {
                
                return -99;
            }
        }

        public int GetDepletedSeed(string examtype, string papercode)
        {
            try
            {
                int? data = 0;
                _dbContext.LoadStoredProc("WS_sp_GetDepletedSeed")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        data = x.ReadToValue<int>();

                                    });
                return data ?? 0;
            }
            catch
            {

                return 0;
            }
        }

        public ScriptInfo GetScriptsInfo_Seed(string examtype, string papercode, string markerid)
        {
           ScriptInfo   data = new();
            try
            {
               
                _dbContext.LoadStoredProc("WS_sp_GetScriptInfo_Seed")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("markerid", markerid)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                       var  d = x.ReadToList<ScriptInfo>();
                                        data = d.ToList().FirstOrDefault();

                                    });
                if (data == null)
                    return new ScriptInfo();
                else
                    return new ScriptInfo
                    {
                        Indexnumber = data.indexno,
                        Markid = data.Markid,
                        Examtype = data.Examtype,
                        Papercode = data.Papercode,
                        makerid = data.makerid,
                        Scriptno = data.Seedmaster

                    };
            }
            catch
            {
                return new ScriptInfo();

            }
        }

        public int GetSeedsMarked_Examiner(string examtype, string papercode, string examinercode)
        {
            try
            {
                int? data = 0;
                _dbContext.LoadStoredProc("BOL_sp_GetSeedsMarked_Examiner")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("markerid", examinercode)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        data = x.ReadToValue<int>();

                                    });
                return data ?? 0;
            }
            catch
            {

                return 0;
            }
        }

        public int GetSeededMarked_ByExaminer(string examtype, string papercode, string examinercode)
        {
            try
            {
                int? data = 0;
                _dbContext.LoadStoredProc("WS_sp_GetSeededMarked_ByExaminer")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("markerid", examinercode)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        data = x.ReadToValue<int>();

                                    });
                return data ?? 0;
            }
            catch
            {

                return 0;
            }
        }

        public ScriptInfo GetSeededScriptsInfo(string examtype, string papercode, string examinercode)
        {
            ScriptInfo data = new();
            try
            {

                _dbContext.LoadStoredProc("WS_sp_GetSeededScriptInfo")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("examinercode", examinercode)
                                    .ExecuteStoredProc(x =>
                                    {
                                        var d = x.ReadToList<ScriptInfo>();
                                        data = d.ToList().FirstOrDefault();

                                    });
                if (data == null)
                    return new ScriptInfo();
                else
                    return new ScriptInfo
                    {
                        Indexnumber = data.indexno,
                        Markid = data.Markid,
                        Examtype = data.Examtype,
                        Papercode = data.Papercode,
                        Seeded = data.Seeded,
                        Scriptno = data.seededscript

                    };
            }
            catch
            {
                return new ScriptInfo();

            }
        }

        public ScriptInfo GetScriptInfo_Review(string examtype, string papercode, string examinercode, int scripttype, int markedid)
        {
            ScriptInfo data = new();
            try
            {

                _dbContext.LoadStoredProc("WS_sp_GetScriptInfo_Review")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("examinercode", examinercode)
                                    .WithSqlParam("scripttype", scripttype)
                                    .WithSqlParam("markedid", markedid)
                                    .ExecuteStoredProc(x =>
                                    {
                                        var d = x.ReadToList<ScriptInfo>();
                                        data = d.ToList().FirstOrDefault();

                                    });
                if (data == null)
                    return new ScriptInfo();
                else
                    return new ScriptInfo
                    {
                        Indexnumber = data.indexno,
                        Markid = data.Markid,
                        Examtype = data.Examtype,
                        Papercode = data.Papercode,
                        Examinercode = data.Examinercode,
                        Scriptno = data.Scriptno

                    };
            }
            catch
            {
                return new ScriptInfo();

            }
        }

        public bool UpdateScript_Review(int markid, int review)
        {

            try
            {
                _dbContext.LoadStoredProc("WS_sp_ScriptReview_update")
                                    .WithSqlParam("markid", markid)
                                    .WithSqlParam("review", review)
                                    .ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;

        }

        public SeedInfo GetSeededInfo_ByExaminer(string examtype, string papercode, string examinercode)
        {
            SeedInfo data = new();
            try
            {

                _dbContext.LoadStoredProc("WS_sp_GetSeededInfo_ByExaminer")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("examinercode", examinercode)
                                   
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        var d = x.ReadToList<SeedInfo>();
                                        data = d.ToList().FirstOrDefault();

                                    });
                if (data == null)
                    return new SeedInfo();
                else
                    return data;
            }
            catch
            {
                return new SeedInfo();

            }
        }

        public SeedInfo GetBulkAllocValues(string examtype, string papercode, string markingstatus)
        {
            SeedInfo data = new();
            try
            {

                _dbContext.LoadStoredProc("BOL_sp_GetBulkAllocValues")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("markingstatus", markingstatus)

                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        var d = x.ReadToList<SeedInfo>();
                                        data = d.ToList().FirstOrDefault();

                                    });
                if (data == null)
                    return new SeedInfo();
                else
                    return data;
            }
            catch
            {
                return new SeedInfo();

            }
        }

        public bool SeededScriptMark_Update(int markid, string scriptno)
        {
            try
            {
                _dbContext.LoadStoredProc("WS_sp_SeededScriptMark_update")
                                    .WithSqlParam("markid", markid)
                                    .WithSqlParam("scriptno", scriptno)
                                    .ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;

        }

        public bool NextSeedVal_Update(string papercode, string examinercode, int nextseedval)
        {
            try
            {
                _dbContext.LoadStoredProc("WS_sp_NextSeedVal_Update")
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("examinercode", examinercode)
                                    .WithSqlParam("nextseedval", nextseedval)
                                    .ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public  ScriptInfo GetScriptsInfo_ByExaminerNo(string examtype, string papercode, string examinercode)
        {
            ScriptInfo data = new();
            try
            {

                 _dbContext.LoadStoredProc("WS_sp_GetScriptInfo_Review")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("examinercode", examinercode)
                                
                                    .ExecuteStoredProc(x =>
                                    {
                                        var d = x.ReadToList<ScriptInfo>();
                                        data = d.ToList().FirstOrDefault();

                                    });
                if (data == null)
                    return new ScriptInfo();
                else
                    return data;
            }
            catch
            {
                return new ScriptInfo();

            }
        }

        public int GetExaminerUnmarkedscript(string examtype, string papercode, string examinercode)
        {
            try
            {
                int? data = 0;
                _dbContext.LoadStoredProc("BOL_sp_GetUnMarkedScript")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("markerid", examinercode)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        data = x.ReadToValue<int>();

                                    });
                return data ?? 0;
            }
            catch
            {

                return 0;
            }
        }

        public int Alloccentre_Insert(string examtype, string papercode, string examinercode, int totalalloc, int nextseedval)
        { 
            try
            {
                int? data = 0;
               data = (int?)  _dbContext.LoadStoredProc("WS_sp_Alloccentre_Insert")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("examinercode", examinercode)
                                    .WithSqlParam("totalalloc", totalalloc)
                                    .WithSqlParam("nextseedval", nextseedval)
                                    .ExecuteScalar();
                return  data ?? 0;
            }
            catch
            {

                return 0;
            }
        }

        public bool Alloccentre_Update(int logid, string centreno)
        {
            try
            {
                _dbContext.LoadStoredProc("WS_sp_Alloccentre_Update")
                                    .WithSqlParam("logid", logid)
                                    .WithSqlParam("centreno", centreno)
                                    .ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool AvailScript_Update(int logid)
        {
            try
            {
                _dbContext.LoadStoredProc("WS_sp_AvailScript_Update")
                                    .WithSqlParam("logid", logid)
                                    .ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int GetNewAllocCentre(string examtype, string papercode, string examinercode, SeedInfo seededinfo)
        {
            int markid;
            string allocid = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + examinercode;
            string centreno = AllocCentre_GetNew(examtype, papercode, allocid);

            if ((centreno != ""))
            {
                Alloccentre_Update(seededinfo.Logid, centreno);
                markid = ScriptInfoByCentre_Insert(examtype, papercode, seededinfo.Venuecode, examinercode, centreno);
                if ((markid == 0))
                    return -99;
            }
            else
            {
                AvailScript_Update(seededinfo.Logid);
                markid = ScriptInfoAvailable_Insert(examtype, papercode, seededinfo.Venuecode, examinercode);
            }

            return markid;

        }

        public ScriptInfo ScriptsInfo_GetNew(int markid)
        {
            ScriptInfo data = new();
            try
            {

                _dbContext.LoadStoredProc("WS_sp_ScriptInfo_GetNew")
                                   .WithSqlParam("markid", markid)

                                   .ExecuteStoredProc(x =>
                                   {
                                       var d = x.ReadToList<ScriptInfo>();
                                       data = d.ToList().FirstOrDefault();

                                   });
                if (data == null)
                    return new ScriptInfo();
                else
                    return data;
            }
            catch
            {
                return new ScriptInfo();

            }
        }

        public string GetExaminers_ToVet(string papercode, string venuecode, string team)
        {
            try
            {
                string data = string.Empty;
                _dbContext.LoadStoredProc("WS_sp_GetExaminers_ToVet")
                                    
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("venuecode", venuecode)
                                    .WithSqlParam("team", team)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        var result = x.ReadToList<dynamic>();
                                        data = result[0];

                                    });
                return data;
            }
            catch
            {

                return string.Empty;
            }
        }

        public bool MaxAllocation_Update(int logid, int totalalloc, int totalscriptmarked, int scriptstovet)
        {
            try
            {
                _dbContext.LoadStoredProc("WS_sp_MaxAllocation_Update")
                                    .WithSqlParam("logid", logid)
                                    .WithSqlParam("totalalloc", totalalloc)
                                    .WithSqlParam("markedallocs", totalscriptmarked)
                                    .WithSqlParam("scriptstovet", scriptstovet)
                                    .ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int ScriptInfoAvailable_Insert(string examtype, string papercode, string venuecode, string examinercode)
        {
            try
            {
                int? data = 0;
                data = (int?)_dbContext.LoadStoredProc("WS_sp_AvailableScriptInfo_Insert")
                                     .WithSqlParam("examtype", examtype)
                                     .WithSqlParam("papercode", papercode)
                                     .WithSqlParam("examinercode", examinercode)
                                     .WithSqlParam("venuecode", venuecode)
                                     .WithSqlParam("examinercode", examinercode)
                                     .ExecuteScalar();
                return data ?? 0;
            }
            catch
            {

                return 0;
            }
        
    }

        public int ScriptInfoByCentre_Insert(string examtype, string papercode, string venuecode, string examinercode, string centreno)
        {
            try
            {
                int? data = 0;
                data = (int?)_dbContext.LoadStoredProc("WS_sp_ScriptInfoByCentre_Insert")
                                     .WithSqlParam("examtype", examtype)
                                     .WithSqlParam("papercode", papercode)
                                     .WithSqlParam("examinercode", examinercode)
                                     .WithSqlParam("venuecode", venuecode)
                                     .WithSqlParam("examinercode", examinercode)
                                     .WithSqlParam("centreno", centreno)
                                     .ExecuteScalar();
                return data ?? 0;
            }
            catch
            {

                return 0;
            }
        }

        public string AllocCentre_GetNew(string examtype, string papercode, string allocid)
        {
            try
            {
                string data = string.Empty;
                 _dbContext.LoadStoredProc("WS_sp_GetNewAllocCentre")
                                     .WithSqlParam("examtype", examtype)
                                     .WithSqlParam("papercode", papercode)
                                     .WithSqlParam("examinercode", allocid)
                                     .ExecuteStoredProcAsync( x =>
                                     {
                                        var result = x.ReadToList<dynamic>();
                                         data = result[0];

                                     });
                return data;
            }
            catch
            {

                return string.Empty;
            }
        }

        public bool GetSeededScript(string examtype, string papercode, string examinercode)
        {
            try
            {
                int? data = 0;
                _dbContext.LoadStoredProc("WS_sp_GetSeededScript")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("examinercode", examinercode)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        data = x.ReadToValue<int>();

                                    });

                if (data.HasValue && data > 0)
                    return true;
                return false;
            }
            catch
            {

                return false;
            }
        }

        public ScriptInfo GetVetScriptInfo_ExaminerNo(string examtype, string papercode, string markerid, string examinercode, int scripttype)
        {
            ScriptInfo data = new();
            try
            {

                _dbContext.LoadStoredProc("WS_sp_GetScriptInfo_Vet")
                                    .WithSqlParam("examtype", examtype)
                                    .WithSqlParam("papercode", papercode)
                                    .WithSqlParam("markerid", markerid)
                                    .WithSqlParam("examinercode", examinercode)
                                    .WithSqlParam("scripttype", scripttype)
                                    .ExecuteStoredProcAsync(x =>
                                    {
                                        var d = x.ReadToList<ScriptInfo>();
                                        data = d.ToList().FirstOrDefault();

                                    });
                if (data == null)
                    return new ScriptInfo();
                else
                    return data;
            }
            catch
            {
                return new ScriptInfo();

            }
        }

        public int DepletedSeed_Insert(string examtype, string papercode, string examinercode)
        {
            try
            {
                int? data = 0;
                data = (int?)_dbContext.LoadStoredProc("WS_sp_DepletedSeed_Insert")
                                     .WithSqlParam("examtype", examtype)
                                     .WithSqlParam("papercode", papercode)
                                     .WithSqlParam("examinercode", examinercode)
                                     .ExecuteScalar();
                return data ?? 0;
            }
            catch
            {

                return 0;
            }
        }

        public ScriptInfo GetNewScript(string examtype, string papercode, string examinercode, int totalscriptsmarked, int minvet, SeedInfo seededinfo)
        {
            ScriptInfo newscript = new ScriptInfo();
            int markid = 0;
            int minalloc = 0;

            if ((seededinfo.Alloccentre == null & seededinfo.Availscript == false))
            {
                markid = GetNewAllocCentre(examtype, papercode, examinercode, seededinfo);
                if ((markid > 0))
                    newscript = ScriptsInfo_GetNew(markid);
                else
                    newscript.Markid = markid;
            }
            else
            {
                int addscriptsmarked = totalscriptsmarked - seededinfo.Markedallocs;
                if ((addscriptsmarked >= seededinfo.Totalalloc))
                {
                    if ((seededinfo.Markingstatus == "SE"))
                    {
                        string examinerno = GetExaminers_ToVet(papercode, seededinfo.Venuecode, seededinfo.Team);
                        if ((examinerno != ""))
                        {
                            newscript.Markid = -4;
                            newscript.Examinercode = examinerno;
                            return newscript;
                        }
                    }

                    minalloc = GetBulkAllocValues(examtype, papercode, seededinfo.Markingstatus).Addallocation;
                    int scriptstovet;
                    if ((seededinfo.Scriptstovet > 0))
                        scriptstovet = seededinfo.Scriptstovet;
                    else
                        scriptstovet = (int)Math.Ceiling((minvet / (double)100) * addscriptsmarked);

                    MaxAllocation_Update(seededinfo.Logid, minalloc, totalscriptsmarked, scriptstovet);

                    if ((minalloc == 0))
                    {
                        newscript.Markid = -3;
                        return newscript;
                    }
                }

                if ((seededinfo.Availscript == true))
                {
                    markid = ScriptInfoAvailable_Insert(examtype, papercode, seededinfo.Venuecode, examinercode);
                    if ((markid > 0))
                        newscript = ScriptsInfo_GetNew(markid);
                }
                else
                {
                    markid = ScriptInfoByCentre_Insert(examtype, papercode, seededinfo.Venuecode, examinercode, seededinfo.Alloccentre);
                    if ((markid > 0))
                        newscript = ScriptsInfo_GetNew(markid);
                    else
                    {
                        markid = GetNewAllocCentre(examtype, papercode, examinercode, seededinfo);
                        if ((markid > 0))
                            newscript = ScriptsInfo_GetNew(markid);
                        else
                            newscript.Markid = markid;
                    }
                }
            }

            return newscript;
        }

       

        public async Task<List<QScoreInfo>> Seed_GetCandScores(int markid, string markerid, string scriptno)
        {
            List<QScoreInfo> qScoreInfos = new List<QScoreInfo>();

            await _dbContext.LoadStoredProc("WS_sp_LoadCandScores_Seed")
                 .WithSqlParam("markid", markid)
                 .WithSqlParam("markerid", markerid)
                 .WithSqlParam("scriptno", scriptno)
                 .ExecuteStoredProcAsync(x =>
                 {
                     var result = x.ReadToList<QScoreInfo>();
                     qScoreInfos = result.ToList();
                 });
            return await Task.FromResult(qScoreInfos);
        }

        public bool CandScoresVet_InsertTemp(int markid, string markerid)
        {
            try
            {
                
                _dbContext.LoadStoredProc("WS_sp_VetCandScores_InsertTemp")
                                    .WithSqlParam("markid", markid)
                                    .WithSqlParam("markerid", markerid)
                                                         .ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool CandScoresReview_InsertTemp(int markid, string markerid)
        {
            try
            {

                _dbContext.LoadStoredProc("WS_sp_ReviewCandScores_InsertTemp")
                                    .WithSqlParam("markid", markid)
                                    .WithSqlParam("markerid", markerid)
                                                         .ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public int CandScores_CheckVet (int markid)
        {
            try
            {
                int? data = 0;
                data = (int?)_dbContext.LoadStoredProc("WS_sp_CandScores_CheckVet")
                                     .WithSqlParam("markid", markid)
                                     .ExecuteScalar();
                return data ?? 0;
            }
            catch
            {

                return 0;
            }
        }

        public async Task<List<QScoreInfo>> GetCandScores_Vet(int markid, string examinercode, string scriptno)
        {
            List<QScoreInfo> qScoreInfos = new List<QScoreInfo>();

            await _dbContext.LoadStoredProc("WS_sp_LoadCandScores_Vet")
                 .WithSqlParam("markid", markid)
                 .WithSqlParam("examinercode", examinercode)
                 .WithSqlParam("scriptno", scriptno)
                 .ExecuteStoredProcAsync(x =>
                 {
                     var result = x.ReadToList<QScoreInfo>();
                     qScoreInfos = result.ToList();
                 });
            return await Task.FromResult(qScoreInfos);
        }

        public async Task<List<QScoreInfo>> GetCandScores(int markid, string examinercode, string scriptno)
        {
            List<QScoreInfo> qScoreInfos = new List<QScoreInfo>();

            await _dbContext.LoadStoredProc("WS_sp_LoadCandScores")
                 .WithSqlParam("markid", markid)
                 .WithSqlParam("examinercode", examinercode)
                 .WithSqlParam("scriptno", scriptno)
                 .ExecuteStoredProcAsync(x =>
                 {
                     var result = x.ReadToList<QScoreInfo>();
                     qScoreInfos = result.ToList();
                 });
            return await Task.FromResult(qScoreInfos);
        }

        public async  Task<List<QScoreInfo>> GetCandScores_Temp(int markid, string markerid, string scriptno)
        {
            List<QScoreInfo> qScoreInfos = new List<QScoreInfo>();

            await _dbContext.LoadStoredProc("WS_sp_LoadCandScores_Temp")
                 .WithSqlParam("markid", markid)
                 .WithSqlParam("markerid", markerid)
                 .WithSqlParam("scriptno", scriptno)
                 .ExecuteStoredProcAsync(x =>
                 {
                     var result = x.ReadToList<QScoreInfo>();
                     qScoreInfos = result.ToList();
                 });
            return await Task.FromResult(qScoreInfos);
        }

        public bool SeedQScore_Insert(QScoreInfo oinfo)
        {
            try
            {
                int? data = 0;
               data = (int?)_dbContext.LoadStoredProc("WS_sp_SaveQScores_Seed")
                                    .WithSqlParam("examtype", oinfo.examtype)
                                    .WithSqlParam("markid", oinfo.markid)
                                     .WithSqlParam("papercode", oinfo.papercode)
                                    .WithSqlParam("quesno", oinfo.quesno)
                                     .WithSqlParam("score", oinfo.score)
                                    .WithSqlParam("numticks", oinfo.numticks)
                                     .WithSqlParam("examinercode", oinfo.examinercode)
                                    .WithSqlParam("indexnumber", oinfo.indexnumber)
                                     .WithSqlParam("scriptno", oinfo.scriptno)
                                    .WithSqlParam("mqa", oinfo.mqa)
                                     .WithSqlParam("mecherror", oinfo.mecherror)
                                    .WithSqlParam("wordscount", oinfo.wordscount)
                                 .WithSqlParam("seedmaster", oinfo.seedmaster)
                                    .WithSqlParam("markedpages", oinfo.markedpages)
                                    .WithSqlParam("seeded", oinfo.seeded)
                                    .WithSqlParam("marksposition", oinfo.marksposition)
                                                         .ExecuteScalar();
                return data == null || data == 0 ? false: true;
            }
            catch
            {

                return false;
            }
        }

        public bool QScore_Insert(QScoreInfo oinfo)
        {
            try
            {
                int? data = 0;
                data = (int?)_dbContext.LoadStoredProc("WS_sp_SaveQScores")
                                     .WithSqlParam("examtype", oinfo.examtype)
                                     .WithSqlParam("markid", oinfo.markid)
                                      .WithSqlParam("papercode", oinfo.papercode)
                                     .WithSqlParam("quesno", oinfo.quesno)
                                      .WithSqlParam("score", oinfo.score)
                                     .WithSqlParam("numticks", oinfo.numticks)
                                      .WithSqlParam("examinercode", oinfo.examinercode)
                                     .WithSqlParam("indexnumber", oinfo.indexnumber)
                                      .WithSqlParam("scriptno", oinfo.scriptno)
                                     .WithSqlParam("mqa", oinfo.mqa)
                                      .WithSqlParam("mecherror", oinfo.mecherror)
                                     .WithSqlParam("wordscount", oinfo.wordscount)
                                     .WithSqlParam("markedpages", oinfo.markedpages)
                                  .WithSqlParam("marksposition", oinfo.marksposition)
                                     .WithSqlParam("review", oinfo.review)
                                     .WithSqlParam("vetted", oinfo.vetted)
                                     .WithSqlParam("vetterid", oinfo.vetterid)
                                                          .ExecuteScalar();
                return data == null || data == 0 ? false : true;
            }
            catch
            {

                return false;
            }
        }

        public bool QueryCandScript_MAL(int markid, string scriptno, int malpractice)
        {
            try
            {

                _dbContext.LoadStoredProc("WS_sp_QueryScript_MAL")
                                    .WithSqlParam("markid", markid)
                                    .WithSqlParam("scriptno", scriptno)
                                    .WithSqlParam("malpractice", malpractice)
                                                         .ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool QScore_UpdateMarkedPages(int markid, int quesno, string markedpages)
        {
            try
            {

                _dbContext.LoadStoredProc("WS_sp_UpdateQScores_Pages")
                                    .WithSqlParam("markid", markid)
                                    .WithSqlParam("quesno", quesno)
                                    .WithSqlParam("markedpages", markedpages)
                                                         .ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
    
}
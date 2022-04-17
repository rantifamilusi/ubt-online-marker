using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using OnlineMarker.Api.Repository.Generic;
using OnlineMarker.Api.Repository.Implementation;
using OnlineMarker.Api.Repository.Interfaces;
using OnlineMarker.Api.Settings;
using OnlineMarker.Shared;
using OnlineMarker.Shared.Request;

namespace OnlineMarker.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly IOnlineMarkerService _onlineMarkerService;
        private  IFileService _fileService;
        private readonly AppSettings _appSettings;
        private readonly IValidator<GetCandidateScriptsRequest> _validatorCandidateRequest;
        private readonly IValidator<SaveMarkedScriptsRequest> _validatorSavedMarkScriptRequest;
        public ServicesController(IOnlineMarkerService onlineMarkerService, 
            IFileService fileService, 
            IOptions<AppSettings> appSettings,
            IValidator<GetCandidateScriptsRequest> validator, IValidator<SaveMarkedScriptsRequest> validatorS)
        {
            _onlineMarkerService = onlineMarkerService;
            _validatorCandidateRequest = validator;
            _validatorSavedMarkScriptRequest = validatorS;
            _fileService = fileService;
            _appSettings = appSettings.Value;
        }


         void InitFileService(IFileService fileService)
        {
            if (_fileService == null)
                _fileService = fileService;
        }
        [HttpGet]
        [Route("GetPaperQuestionInfo")]
        public async  Task<IActionResult> GetPaperQuestionInfo(string examtype, string papercode)
        {
            
                if (string.IsNullOrEmpty(examtype) || string.IsNullOrEmpty(papercode)) return BadRequest("Parameters are missing");
                return new OkObjectResult( await _onlineMarkerService.GetPaperQuesInfos(examtype, papercode));
            
        }

        [HttpGet]
        [Route("GetCandidateScores")]
        public async Task<IActionResult> GetCandidateScores(int markid, string markerid, string scriptno, bool vetobj, bool seedmasterobj, bool seeded, bool reviewobj, bool reviewteam, int scripttype)
        {
            if (string.IsNullOrEmpty(scriptno) || string.IsNullOrEmpty(markerid)) return BadRequest("Parameters are missing");

            if (seedmasterobj == true | seeded == true)
                return new OkObjectResult(await _onlineMarkerService.Seed_GetCandScores(markid, markerid, scriptno));
            if (vetobj == true)
                _onlineMarkerService.CandScoresVet_InsertTemp(markid, markerid);
            if (reviewobj == true)
            {
                if (scripttype == 1)
                    _onlineMarkerService.CandScoresReview_InsertTemp(markid, markerid);
                else if (_onlineMarkerService.CandScores_CheckVet(markid) > 0)
                    return new OkObjectResult(await _onlineMarkerService.GetCandScores_Vet(markid, markerid, scriptno));
                else
                    return new OkObjectResult(await _onlineMarkerService.GetCandScores(markid, markerid, scriptno));
            }
            if ((reviewteam == true))
            {
                if ((_onlineMarkerService.CandScores_CheckVet(markid) > 0))

                    return new OkObjectResult(await _onlineMarkerService.GetCandScores_Vet(markid, markerid, scriptno));
                else

                    return new OkObjectResult(await _onlineMarkerService.GetCandScores(markid, markerid, scriptno));
            }
            return new OkObjectResult(await _onlineMarkerService.GetCandScores_Temp(markid, markerid, scriptno));
        }


        [HttpPost]
        [Route("GetCandidateScripts")]
        public async Task<IActionResult> GetCandidateScripts(GetCandidateScriptsRequest request)
        {
            var result = _validatorCandidateRequest.Validate(request);
            if (!result.IsValid)
                return BadRequest(result.Errors);
            
                InitFileService(new FileService());

            ScriptInfo candscript = new ScriptInfo();
            string scriptid = "";

            DirectoryInfo SFilesLocation = _fileService.GetDirectoryInfo (_appSettings.DataPath + @"\" + request.papercode);
            DirectoryInfo seededfolder = _fileService.GetDirectoryInfo(SFilesLocation.FullName + @"\SeededScripts");
            DirectoryInfo mseededfolder = _fileService.GetDirectoryInfo(SFilesLocation.FullName + @"\MarkedSeededScripts");
            if ((!seededfolder.Exists))
                seededfolder.Create();

            List<SFilesInfo> Sfiles = new List<SFilesInfo>();

            try
            {
                if (request.seedmasterobj == true)
                {
                    int iret = _onlineMarkerService.GetSeedScript(request.examtype, request.papercode, request.markerid);
                    candscript = _onlineMarkerService.GetScriptsInfo_Seed(request.examtype, request.papercode, request.markerid);
                    if ((iret > 0))
                        Utility.GetSeedScriptFiles(request.papercode, candscript.Scriptno, seededfolder, SFilesLocation, _appSettings.ExamYear);
                }
                else
                {
                    // check seed availability in bank for seed masters----
                    if ((request.seedmaster == true))
                    {
                        if (_onlineMarkerService.GetDepletedSeed(request.examtype, request.papercode) > 0)
                            return new OkObjectResult(Utility.GetNoScriptInfo(-5));
                    }

                    // check if examiner marked/set practice scripts before loading raw scripts
                    int seedsmarked=0;
                    if ((request.totalscriptsmarked == 0))
                    {
                        if ((request.seedmaster == true))
                            seedsmarked = _onlineMarkerService.GetSeedsMarked_Examiner(request.examtype, request.papercode, request.markerid);
                        else
                            seedsmarked = _onlineMarkerService.GetSeededMarked_ByExaminer(request.examtype, request.papercode, request.markerid);
                    }
                    else
                        request.practicescript = 0;

                    if ((seedsmarked < request.practicescript))
                    {
                        if ((request.seedmaster == true))
                            return new OkObjectResult(Utility.GetNoScriptInfo(-5));
                        else if (_onlineMarkerService.GetSeededScript(request.examtype, request.papercode, request.markerid) == true)
                            candscript = _onlineMarkerService.GetSeededScriptsInfo(request.examtype, request.papercode, request.markerid);
                        else if (candscript.Markid == 0)
                            return new OkObjectResult(Utility.GetNoScriptInfo(-6));
                    }
                    else if ((request.reloadscript != ""))
                    {
                        candscript.Markid = request.markedid;
                        candscript.Indexnumber = request.indexnumber;
                        candscript.Scriptno = request.reloadscript;
                        if ((request.seeded == true))
                            candscript.Seeded = true;
                        else
                            candscript.Seeded = false;
                    }
                    else if ((request.vetobj == true))
                    {
                        candscript = _onlineMarkerService.GetVetScriptInfo_ExaminerNo(request.examtype, request.papercode, request.markerid, request.vetteeid, request.vetscripttype);
                        if ((candscript.Markid > 0))
                            _onlineMarkerService.UpdateScript_Review(candscript.Markid, 1);
                    }
                    else if ((request.reviewobj == true))
                    {
                        candscript = _onlineMarkerService.GetScriptInfo_Review(request.examtype, request.papercode, request.markerid, request.scripttype, request.markedid);
                        if ((request.scripttype == 1))
                        {
                            if ((candscript.Markid > 0))
                                _onlineMarkerService.UpdateScript_Review(candscript.Markid, 2);
                        }
                    }
                    else if ((request.reviewteam == true))
                        candscript = _onlineMarkerService.GetScriptInfo_Review(request.examtype, request.papercode, request.vetteeid, request.scripttype, request.markedid);
                    else
                    {
                        // check if examiner is still active to mark before fetching raw script for examiner----
                        SeedInfo seededinfo = new SeedInfo();
                        seededinfo = _onlineMarkerService.GetSeededInfo_ByExaminer(request.examtype, request.papercode, request.markerid);
                        if ((seededinfo.Accessstatus == false))
                            return new OkObjectResult(Utility.GetNoScriptInfo(-1));
                        
                        if ((seededinfo.Logid == 0))
                        {
                            int minalloc = _onlineMarkerService.GetBulkAllocValues(request.examtype, request.papercode, seededinfo.Markingstatus).Minallocation;
                            if ((minalloc == 0))
                                return new OkObjectResult(Utility.GetNoScriptInfo(-2));
                         

                            int nextseedval = Utility.GetNextSeedValue(request.seedinterval, request.totalscriptsmarked);
                            if ((nextseedval <= 0))
                                return new OkObjectResult(Utility.GetNoScriptInfo(-99));


                            _onlineMarkerService.Alloccentre_Insert(request.examtype, request.papercode, request.markerid, minalloc, nextseedval);
                            seededinfo = _onlineMarkerService.GetSeededInfo_ByExaminer(request.examtype, request.papercode, request.markerid);
                        }

                        // if no script to seed, stop examiner from continuing
                        bool nextseed = false;
                        if ((request.totalscriptsmarked > 0 & request.totalscriptsmarked == seededinfo.Nextseedval))
                        {
                            nextseed = true;
                            if ((_onlineMarkerService.GetSeededScript(request.examtype, request.papercode, request.markerid) == true))
                                candscript = _onlineMarkerService.GetSeededScriptsInfo(request.examtype, request.papercode, request.markerid);
                            else if (candscript.Markid == 0)
                            {
                                _onlineMarkerService.DepletedSeed_Insert(request.examtype, request.papercode, request.markerid);
                                
                                return new OkObjectResult(Utility.GetNoScriptInfo(-6));
                               
                            }

                            if ((seededinfo.Seedmaster == true))
                            {
                                if ((candscript.Examinercode == request.markerid))
                                {
                                    if (_onlineMarkerService.SeededScriptMark_Update(candscript.Markid, (request.markerid + candscript.Scriptno)) == true)
                                    {
                                        _onlineMarkerService.NextSeedVal_Update(request.papercode, request.markerid, 0);
                                        nextseed = false;
                                    }
                                }
                            }
                        }

                        if ((nextseed == false))
                        {
                            if ((seededinfo.Bulkalloc == true))
                            {
                                candscript = _onlineMarkerService.GetScriptsInfo_ByExaminerNo(request.examtype, request.papercode, request.markerid);
                                Utility.BackupScriptFiles(request.papercode, candscript.Scriptno, SFilesLocation, _appSettings.ExamYear);
                            }
                            else
                            {
                                int scriptret = _onlineMarkerService.GetExaminerUnmarkedscript(request.examtype, request.papercode, request.markerid);
                                if ((scriptret > 0))
                                    candscript = _onlineMarkerService.GetScriptsInfo_ByExaminerNo(request.examtype, request.papercode, request.markerid);
                                else
                                {
                                    candscript = _onlineMarkerService.GetNewScript(request.examtype, request.papercode, request.markerid, request.totalscriptsmarked, request.minvet, seededinfo);
                                    if (candscript.Markid <= 0)
                                        return new OkObjectResult(Utility.GetNoScriptInfo(candscript.Markid));
                                    Utility.BackupScriptFiles(request.papercode, candscript.Scriptno, SFilesLocation, _appSettings.ExamYear);
                                   
                                }
                            }
                        }
                    }
                }

                string SfileURL = "/";
                int lindex = 0;
                bool seededscripts = false;

                if (candscript.Markid == 0)
                    return new OkObjectResult(Utility.GetNoScriptInfo(0));
                

                scriptid = candscript.Scriptno;
                string scriptfileid = scriptid;
                string varscriptno = "??" + request.papercode + _appSettings.ExamYear.Substring(2, 2) + ".jpg";
                int scriptnamelen = (scriptid + varscriptno).Length;

                if ((request.seedmasterobj == true))
                {
                    scriptfileid = request.markerid + scriptid;
                    if ((!mseededfolder.Exists))
                        mseededfolder.Create();
                    if ((mseededfolder.GetFiles(scriptfileid + varscriptno, SearchOption.TopDirectoryOnly).Count() == 0))
                    {
                        FileInfo[] scriptfiles = seededfolder.GetFiles(scriptid + varscriptno, SearchOption.TopDirectoryOnly);
                        foreach (var file in scriptfiles)
                        {
                            string mtemppath = Path.Combine(mseededfolder.FullName, request.markerid + file.Name);
                            file.CopyTo(mtemppath, false);
                        }
                    }
                }

                if ((candscript.Seeded == true))
                {
                    scriptfileid = request.markerid + scriptid;
                    if ((mseededfolder.GetFiles(scriptfileid + varscriptno, SearchOption.TopDirectoryOnly).Count() == 0))
                    {
                        FileInfo[] scriptfiles = seededfolder.GetFiles(scriptid + varscriptno, SearchOption.TopDirectoryOnly);
                        foreach (var file in scriptfiles)
                        {
                            string mtemppath = Path.Combine(mseededfolder.FullName, request.markerid + file.Name);
                            file.CopyTo(mtemppath, false);
                        }
                    }
                }

                if ((request.seedmasterobj == true | candscript.Seeded == true))
                {
                    seededscripts = true;
                    SFilesLocation = mseededfolder;
                    SfileURL = SfileURL + "MarkedSeededScripts/";
                }

                VBMath.Randomize();

                List<string> responsepageslist = new List<string>();
                responsepageslist.AddRange(request.responsepages.Split(","));

                foreach (var ScriptFile in _fileService.GetFiles( SFilesLocation, scriptfileid + varscriptno, SearchOption.TopDirectoryOnly).OrderBy(f => f.Name))
                {
                    if ((seededscripts == true | (seededscripts == false & ScriptFile.Name.Length == scriptnamelen)))
                    {
                        SFilesInfo Sfile = new SFilesInfo();
                        string pageno = ScriptFile.Name.Substring(ScriptFile.Name.Length - 14, 2);
                        Sfile.Totalsmarked = request.totalscriptsmarked;
                        Sfile.Indexno = candscript.Indexnumber;
                        Sfile.Scriptno = scriptid;
                        Sfile.Seededscriptid = scriptfileid;
                        Sfile.Markid = candscript.Markid;
                        Sfile.Seeded = candscript.Seeded;
                        Sfile.SFileName = ScriptFile.Name;
                        Sfile.OSFile = SfileURL + ScriptFile.Name + "?" + (Conversion.Int((1000000 * VBMath.Rnd()) + 1)).ToString();
                        foreach (var rpage in responsepageslist)
                        {
                            if ((rpage.PadLeft(2, '0') == pageno))
                                Sfiles.Add(Sfile);
                        }
                        lindex = lindex + 1;
                    }
                }

                return new OkObjectResult(Sfiles); ;
            }
            catch (Exception ex)
            {
                
                return new OkObjectResult(Utility.GetNoScriptInfo(-99));
                
            }
        }


        [HttpPost]
        [Route("SaveMarkedScripts")]
        public async Task<IActionResult> SaveMarkedScripts(SaveMarkedScriptsRequest request)
        {
            var result = _validatorSavedMarkScriptRequest.Validate(request);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            InitFileService(new FileService());

            try
            {
                bool iret = false;

                string filepath = Path.Combine(_appSettings.DataPath, request.papercode);

                // save score for question
                if (request.nullquesno == false)
                {
                    QScoreInfo qscore = new QScoreInfo
                    {
                        examtype = request.examtype,
                        markid = request.markid,
                        papercode = request.papercode,
                        quesno = int.Parse(request.quesno),
                        score = request.score,
                        numticks = request.tickno,
                        mqa = request.mqaobj,
                        indexnumber = request.indexno,
                        scriptno = request.scriptno,
                        mecherror = request.mecherror,
                        wordscount = request.wordscount,
                        markedpages = request.markedpages,
                        seeded = request.seededques,
                        marksposition = request.marksposition
                    };

                    if (request.seedmasterobj == true)
                        qscore.seedmaster = request.scriptno;

                    if (request.seedmasterobj == true || request.seeded == true)
                    {
                        qscore.scriptno = request.seededscriptid;
                        qscore.examinercode = request.markerid;
                        iret = _onlineMarkerService.SeedQScore_Insert(qscore);
                    }
                    else
                    {
                        if (request.vetobj == true)
                        {
                            qscore.vetted = 1;
                            qscore.vetterid = request.markerid;
                            qscore.examinercode = request.vetteeid;
                        }
                        else if (request.reviewobj == true)
                        {
                            qscore.review = 1;
                            qscore.examinercode = request.markerid;
                        }
                        else
                            qscore.examinercode = request.markerid;

                        iret = _onlineMarkerService.QScore_Insert(qscore);
                    }

                    if (iret == false)
                        return new OkObjectResult(Utility.GetResponse("03"));
                  
                }
                else
                    _onlineMarkerService.QScore_UpdateMarkedPages(request.markid, int.Parse(request.quesno), request.markedpages);

                if (request.seedmasterobj == false && request.seeded == false)
                {
                    if (request.malpractice > 0)
                        _onlineMarkerService.QueryCandScript_MAL(request.markid, request.scriptno, request.malpractice);
                }
                else
                    filepath = Path.Combine(filepath, "MarkedSeededScripts");

                foreach (SFilesInfo sfile in request.sfiles)
                {
                    FileInfo fileinfo = _fileService.GetFileInfo(Convert.ToString(filepath + @"\" + @"\" + sfile.SFileName));
                    _fileService.WriteAllBytes(fileinfo.FullName, sfile.SFilebyte);
                }
            }
            catch (Exception ex)
            {
                
              
                return new OkObjectResult(Utility.GetResponse("02"));
            }
          
            return new OkObjectResult(Utility.GetResponse("01"));
        }
    }
}

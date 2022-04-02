using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineMarker.Domain.Models
{
    public partial class NGOnlineMarkerContext : DbContext
    {
        public NGOnlineMarkerContext()
        {
        }

        public NGOnlineMarkerContext(DbContextOptions<NGOnlineMarkerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adminuser> Adminusers { get; set; } = null!;
        public virtual DbSet<AdminuserAudit> AdminuserAudits { get; set; } = null!;
        public virtual DbSet<Allocadmin> Allocadmins { get; set; } = null!;
        public virtual DbSet<AllocadminAudit> AllocadminAudits { get; set; } = null!;
        public virtual DbSet<CandMasterTemp> CandMasterTemps { get; set; } = null!;
        public virtual DbSet<CandScoresSeededAudit> CandScoresSeededAudits { get; set; } = null!;
        public virtual DbSet<Canddelete> Canddeletes { get; set; } = null!;
        public virtual DbSet<CandidateMarksDataVet> CandidateMarksDataVets { get; set; } = null!;
        public virtual DbSet<CandidateMarksDatum> CandidateMarksData { get; set; } = null!;
        public virtual DbSet<CandidateScore> CandidateScores { get; set; } = null!;
        public virtual DbSet<CandidateScoresAudit> CandidateScoresAudits { get; set; } = null!;
        public virtual DbSet<CandidateScoresSeeded> CandidateScoresSeededs { get; set; } = null!;
        public virtual DbSet<CandidateScoresTemp> CandidateScoresTemps { get; set; } = null!;
        public virtual DbSet<CandidatesMaster> CandidatesMasters { get; set; } = null!;
        public virtual DbSet<DepletedseedAudit> DepletedseedAudits { get; set; } = null!;
        public virtual DbSet<ErraticMarkingAudit> ErraticMarkingAudits { get; set; } = null!;
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; } = null!;
        public virtual DbSet<ExStatusType> ExStatusTypes { get; set; } = null!;
        public virtual DbSet<ExamType> ExamTypes { get; set; } = null!;
        public virtual DbSet<Examinerfile> Examinerfiles { get; set; } = null!;
        public virtual DbSet<ExaminerfileAudit> ExaminerfileAudits { get; set; } = null!;
        public virtual DbSet<Examinerslist> Examinerslists { get; set; } = null!;
        public virtual DbSet<ExaminerslistAudit> ExaminerslistAudits { get; set; } = null!;
        public virtual DbSet<FilesUploadAudit> FilesUploadAudits { get; set; } = null!;
        public virtual DbSet<MarkingVenue> MarkingVenues { get; set; } = null!;
        public virtual DbSet<MarksAudit> MarksAudits { get; set; } = null!;
        public virtual DbSet<MessageBoard> MessageBoards { get; set; } = null!;
        public virtual DbSet<OperatorsInfo> OperatorsInfos { get; set; } = null!;
        public virtual DbSet<PaperQuesControl> PaperQuesControls { get; set; } = null!;
        public virtual DbSet<Schdelete> Schdeletes { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<ScriptsMaster> ScriptsMasters { get; set; } = null!;
        public virtual DbSet<ScriptsMasterTemp> ScriptsMasterTemps { get; set; } = null!;
        public virtual DbSet<ScriptsUploadAudit> ScriptsUploadAudits { get; set; } = null!;
        public virtual DbSet<SeededScriptsScore> SeededScriptsScores { get; set; } = null!;
        public virtual DbSet<Subjectspaper> Subjectspapers { get; set; } = null!;
        public virtual DbSet<TblAbsentCand> TblAbsentCands { get; set; } = null!;
        public virtual DbSet<TblAbsentCandsTemp> TblAbsentCandsTemps { get; set; } = null!;
        public virtual DbSet<TblAlloccentre> TblAlloccentres { get; set; } = null!;
        public virtual DbSet<TblBookletsInfo> TblBookletsInfos { get; set; } = null!;
        public virtual DbSet<TblCentrestoAlloc> TblCentrestoAllocs { get; set; } = null!;
        public virtual DbSet<TblImageFile> TblImageFiles { get; set; } = null!;
        public virtual DbSet<TblMacAddress> TblMacAddresses { get; set; } = null!;
        public virtual DbSet<TblScriptRptTemp> TblScriptRptTemps { get; set; } = null!;
        public virtual DbSet<TblTeam> TblTeams { get; set; } = null!;
        public virtual DbSet<UploadSchedule> UploadSchedules { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersInfoAudit> UsersInfoAudits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=(local);Database=NGOnlineMarker;Trusted_Connection=True;Integrated Security=false;User Id=sa;Password=Passw0rd1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adminuser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adminuser");

                entity.Property(e => e.Errormargin).HasColumnName("errormargin");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Examyear)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examyear");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Maxerraticcount).HasColumnName("maxerraticcount");

                entity.Property(e => e.Minvet).HasColumnName("minvet");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Practicescript).HasColumnName("practicescript");

                entity.Property(e => e.Responsepages)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("responsepages");

                entity.Property(e => e.Seedid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("seedid");

                entity.Property(e => e.Seedinterval).HasColumnName("seedinterval");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<AdminuserAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adminuser_audit");

                entity.Property(e => e.Errormargin).HasColumnName("errormargin");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Examyear)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examyear");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("logid");

                entity.Property(e => e.Maxerraticcount).HasColumnName("maxerraticcount");

                entity.Property(e => e.Minvet).HasColumnName("minvet");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Practicescript).HasColumnName("practicescript");

                entity.Property(e => e.Responsepages)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("responsepages");

                entity.Property(e => e.Seedinterval).HasColumnName("seedinterval");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<Allocadmin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("allocadmin");

                entity.Property(e => e.Addallocation).HasColumnName("addallocation");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Logid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("logid");

                entity.Property(e => e.Markingstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("markingstatus");

                entity.Property(e => e.Minallocation).HasColumnName("minallocation");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<AllocadminAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("allocadmin_audit");

                entity.Property(e => e.Addallocation).HasColumnName("addallocation");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("logid");

                entity.Property(e => e.Markingstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("markingstatus");

                entity.Property(e => e.Minallocation).HasColumnName("minallocation");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<CandMasterTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CandMaster_Temp");

                entity.Property(e => e.Blind)
                    .HasMaxLength(1)
                    .HasColumnName("blind");

                entity.Property(e => e.Candname)
                    .HasMaxLength(40)
                    .HasColumnName("candname");

                entity.Property(e => e.Centre)
                    .HasMaxLength(7)
                    .HasColumnName("centre");

                entity.Property(e => e.Deaf)
                    .HasMaxLength(1)
                    .HasColumnName("deaf");

                entity.Property(e => e.Dob)
                    .HasMaxLength(8)
                    .HasColumnName("dob");

                entity.Property(e => e.Dumb)
                    .HasMaxLength(1)
                    .HasColumnName("dumb");

                entity.Property(e => e.Exammonyear)
                    .HasMaxLength(50)
                    .HasColumnName("exammonyear");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Grpawd)
                    .HasMaxLength(50)
                    .HasColumnName("grpawd");

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(10)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Indexrefno)
                    .HasMaxLength(50)
                    .HasColumnName("indexrefno");

                entity.Property(e => e.Phychall)
                    .HasMaxLength(1)
                    .HasColumnName("phychall");

                entity.Property(e => e.Recordtype)
                    .HasMaxLength(3)
                    .HasColumnName("recordtype");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex");

                entity.Property(e => e.StudentId).ValueGeneratedOnAdd();

                entity.Property(e => e.Subjcode1)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode1");

                entity.Property(e => e.Subjcode10)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode10");

                entity.Property(e => e.Subjcode2)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode2");

                entity.Property(e => e.Subjcode3)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode3");

                entity.Property(e => e.Subjcode4)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode4");

                entity.Property(e => e.Subjcode5)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode5");

                entity.Property(e => e.Subjcode6)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode6");

                entity.Property(e => e.Subjcode7)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode7");

                entity.Property(e => e.Subjcode8)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode8");

                entity.Property(e => e.Subjcode9)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode9");

                entity.Property(e => e.Totalsubjects)
                    .HasMaxLength(2)
                    .HasColumnName("totalsubjects");
            });

            modelBuilder.Entity<CandScoresSeededAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CandScores_seeded_Audit");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Markerid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("markerid");

                entity.Property(e => e.Markid).HasColumnName("markid");

                entity.Property(e => e.Marksposition)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("marksposition");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Quesno).HasColumnName("quesno");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("score");

                entity.Property(e => e.ScoreId).ValueGeneratedOnAdd();

                entity.Property(e => e.Seedmaster)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("seedmaster");

                entity.Property(e => e.Seedstatus).HasColumnName("seedstatus");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<Canddelete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("canddelete");
            });

            modelBuilder.Entity<CandidateMarksDataVet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Candidate_Marks_Data_Vet");

                entity.HasIndex(e => new { e.Papercode, e.Indexnumber, e.Quesno }, "IX_CandVetScores_duplicate_Ques")
                    .IsUnique();

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Markedpages)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("markedpages");

                entity.Property(e => e.Marksposition)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("marksposition");

                entity.Property(e => e.Mecherror)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("mecherror");

                entity.Property(e => e.Mqa).HasColumnName("mqa");

                entity.Property(e => e.Numticks).HasColumnName("numticks");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(50)
                    .HasColumnName("papercode");

                entity.Property(e => e.Quesno).HasColumnName("quesno");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("score");

                entity.Property(e => e.Scoreid).HasColumnName("scoreid");

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.VetId).ValueGeneratedOnAdd();

                entity.Property(e => e.VetterId)
                    .HasMaxLength(50)
                    .HasColumnName("vetterId");

                entity.Property(e => e.Wordscount).HasColumnName("wordscount");
            });

            modelBuilder.Entity<CandidateMarksDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Candidate_Marks_Data");

                entity.HasIndex(e => new { e.Papercode, e.Indexnumber }, "IX_CandMarks_PaperCode_Indexno")
                    .IsUnique();

                entity.Property(e => e.Candname)
                    .HasMaxLength(40)
                    .HasColumnName("candname");

                entity.Property(e => e.Centreno)
                    .HasMaxLength(7)
                    .HasColumnName("centreno");

                entity.Property(e => e.Cleared).HasColumnName("cleared");

                entity.Property(e => e.Cleareddate)
                    .HasColumnType("datetime")
                    .HasColumnName("cleareddate");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("entrydate");

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(10)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LoginId)
                    .HasMaxLength(50)
                    .HasColumnName("loginId");

                entity.Property(e => e.Malpractice).HasColumnName("malpractice");

                entity.Property(e => e.Mark)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MarkId).ValueGeneratedOnAdd();

                entity.Property(e => e.Markerid)
                    .HasMaxLength(20)
                    .HasColumnName("markerid");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(50)
                    .HasColumnName("papercode");

                entity.Property(e => e.Processed).HasColumnName("processed");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Reviewed).HasColumnName("reviewed");

                entity.Property(e => e.Schno)
                    .HasMaxLength(10)
                    .HasColumnName("schno");

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Venuecode)
                    .HasMaxLength(10)
                    .HasColumnName("venuecode");

                entity.Property(e => e.Vetscore)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("vetscore")
                    .IsFixedLength();

                entity.Property(e => e.Vetted).HasColumnName("vetted");

                entity.Property(e => e.Vetteddate)
                    .HasColumnType("datetime")
                    .HasColumnName("vetteddate");
            });

            modelBuilder.Entity<CandidateScore>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Candidate_Scores");

                entity.HasIndex(e => new { e.Papercode, e.Indexno, e.Quesno }, "IX_CandScores_duplicate_Ques")
                    .IsUnique();

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("indexno");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Markedpages)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("markedpages");

                entity.Property(e => e.Markid).HasColumnName("markid");

                entity.Property(e => e.Marksposition)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("marksposition");

                entity.Property(e => e.Mecherror)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("mecherror");

                entity.Property(e => e.Mqa).HasColumnName("mqa");

                entity.Property(e => e.Numticks).HasColumnName("numticks");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Quesno).HasColumnName("quesno");

                entity.Property(e => e.Reviewed).HasColumnName("reviewed");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("score");

                entity.Property(e => e.ScoreId).ValueGeneratedOnAdd();

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Vetted).HasColumnName("vetted");

                entity.Property(e => e.Vetterid)
                    .HasMaxLength(50)
                    .HasColumnName("vetterid");

                entity.Property(e => e.Wordscount).HasColumnName("wordscount");
            });

            modelBuilder.Entity<CandidateScoresAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Candidate_Scores_Audit");

                entity.Property(e => e.Auditlogdate)
                    .HasColumnType("datetime")
                    .HasColumnName("auditlogdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("indexno");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate");

                entity.Property(e => e.Markedpages)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("markedpages");

                entity.Property(e => e.Markid).HasColumnName("markid");

                entity.Property(e => e.Marksposition)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("marksposition");

                entity.Property(e => e.Mqa).HasColumnName("mqa");

                entity.Property(e => e.Numticks).HasColumnName("numticks");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Quesno).HasColumnName("quesno");

                entity.Property(e => e.Reallocate).HasColumnName("reallocate");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("score");

                entity.Property(e => e.ScoreId).ValueGeneratedOnAdd();

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<CandidateScoresSeeded>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Candidate_Scores_seeded");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("indexno");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Markerid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("markerid");

                entity.Property(e => e.Markid).HasColumnName("markid");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.ScoreId).ValueGeneratedOnAdd();

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Seededscript)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("seededscript");

                entity.Property(e => e.Seedmaster)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("seedmaster");

                entity.Property(e => e.Seedstatus).HasColumnName("seedstatus");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<CandidateScoresTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Candidate_Scores_Temp");

                entity.HasIndex(e => new { e.Papercode, e.Indexno, e.Quesno }, "IX_CandScoresTemp_duplicate_Ques")
                    .IsUnique();

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("indexno");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Markedpages)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("markedpages");

                entity.Property(e => e.Markid).HasColumnName("markid");

                entity.Property(e => e.Marksposition)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("marksposition");

                entity.Property(e => e.Mecherror)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("mecherror");

                entity.Property(e => e.Mqa).HasColumnName("mqa");

                entity.Property(e => e.Numticks).HasColumnName("numticks");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Quesno).HasColumnName("quesno");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("score");

                entity.Property(e => e.ScoreId).ValueGeneratedOnAdd();

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Vetterid)
                    .HasMaxLength(50)
                    .HasColumnName("vetterid");

                entity.Property(e => e.Vetting).HasColumnName("vetting");

                entity.Property(e => e.Wordscount).HasColumnName("wordscount");
            });

            modelBuilder.Entity<CandidatesMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Candidates_Master");

                entity.Property(e => e.Blind)
                    .HasMaxLength(1)
                    .HasColumnName("blind");

                entity.Property(e => e.Candname)
                    .HasMaxLength(40)
                    .HasColumnName("candname");

                entity.Property(e => e.Centre)
                    .HasMaxLength(7)
                    .HasColumnName("centre");

                entity.Property(e => e.Dateloaded)
                    .HasColumnType("datetime")
                    .HasColumnName("dateloaded")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deaf)
                    .HasMaxLength(1)
                    .HasColumnName("deaf");

                entity.Property(e => e.Dob)
                    .HasMaxLength(8)
                    .HasColumnName("dob");

                entity.Property(e => e.Dumb)
                    .HasMaxLength(1)
                    .HasColumnName("dumb");

                entity.Property(e => e.Exammonyear)
                    .HasMaxLength(50)
                    .HasColumnName("exammonyear");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Grpawd)
                    .HasMaxLength(50)
                    .HasColumnName("grpawd");

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(10)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Indexrefno)
                    .HasMaxLength(50)
                    .HasColumnName("indexrefno");

                entity.Property(e => e.Phychall)
                    .HasMaxLength(1)
                    .HasColumnName("phychall");

                entity.Property(e => e.Recordtype)
                    .HasMaxLength(3)
                    .HasColumnName("recordtype");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex");

                entity.Property(e => e.StudentId).ValueGeneratedOnAdd();

                entity.Property(e => e.Subjcode1)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode1");

                entity.Property(e => e.Subjcode10)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode10");

                entity.Property(e => e.Subjcode2)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode2");

                entity.Property(e => e.Subjcode3)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode3");

                entity.Property(e => e.Subjcode4)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode4");

                entity.Property(e => e.Subjcode5)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode5");

                entity.Property(e => e.Subjcode6)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode6");

                entity.Property(e => e.Subjcode7)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode7");

                entity.Property(e => e.Subjcode8)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode8");

                entity.Property(e => e.Subjcode9)
                    .HasMaxLength(6)
                    .HasColumnName("subjcode9");

                entity.Property(e => e.Totalsubjects)
                    .HasMaxLength(2)
                    .HasColumnName("totalsubjects");
            });

            modelBuilder.Entity<DepletedseedAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Depletedseed_audit");

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("logid");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Resolved).HasColumnName("resolved");
            });

            modelBuilder.Entity<ErraticMarkingAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ErraticMarking_Audit");

                entity.Property(e => e.AuditId).ValueGeneratedOnAdd();

                entity.Property(e => e.Blockeddate)
                    .HasColumnType("datetime")
                    .HasColumnName("blockeddate");

                entity.Property(e => e.Blockedno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("blockedno");

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Quesno).HasColumnName("quesno");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("score");

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Seeded).HasColumnName("seeded");

                entity.Property(e => e.Vetted).HasColumnName("vetted");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("ErrorLog");

                entity.Property(e => e.DateLogged).HasColumnType("datetime");

                entity.Property(e => e.ErrorLog1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ErrorLog");
            });

            modelBuilder.Entity<ExStatusType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExStatusType");

                entity.Property(e => e.Statuscode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("statuscode")
                    .IsFixedLength();

                entity.Property(e => e.Statusname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("statusname");
            });

            modelBuilder.Entity<ExamType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExamType");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Examyear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("examyear");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Examinerfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Examinerfile");

                entity.Property(e => e.CandserialEnd)
                    .HasMaxLength(3)
                    .HasColumnName("candserial_end");

                entity.Property(e => e.CandserialStart)
                    .HasMaxLength(3)
                    .HasColumnName("candserial_start");

                entity.Property(e => e.Clearedstatus).HasColumnName("clearedstatus");

                entity.Property(e => e.Datelogged)
                    .HasColumnType("datetime")
                    .HasColumnName("datelogged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examinername)
                    .HasMaxLength(50)
                    .HasColumnName("examinername");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.LogId).ValueGeneratedOnAdd();

                entity.Property(e => e.LoginId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LoginID");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(10)
                    .HasColumnName("papercode");

                entity.Property(e => e.Papername)
                    .HasMaxLength(50)
                    .HasColumnName("papername");

                entity.Property(e => e.Schname)
                    .HasMaxLength(255)
                    .HasColumnName("schname");

                entity.Property(e => e.Schno)
                    .HasMaxLength(20)
                    .HasColumnName("schno");

                entity.Property(e => e.Subject)
                    .HasMaxLength(3)
                    .HasColumnName("subject");

                entity.Property(e => e.Tdduser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TDDuser");

                entity.Property(e => e.Totalscripts).HasColumnName("totalscripts");

                entity.Property(e => e.Venuecode)
                    .HasMaxLength(10)
                    .HasColumnName("venuecode");
            });

            modelBuilder.Entity<ExaminerfileAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Examinerfile_audit");

                entity.Property(e => e.CandserialEnd)
                    .HasMaxLength(3)
                    .HasColumnName("candserial_end");

                entity.Property(e => e.CandserialStart)
                    .HasMaxLength(3)
                    .HasColumnName("candserial_start");

                entity.Property(e => e.Datelogged)
                    .HasColumnType("datetime")
                    .HasColumnName("datelogged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examinername)
                    .HasMaxLength(50)
                    .HasColumnName("examinername");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.LogId).ValueGeneratedOnAdd();

                entity.Property(e => e.LoginId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LoginID");

                entity.Property(e => e.Logtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("logtype");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(10)
                    .HasColumnName("papercode");

                entity.Property(e => e.Papername)
                    .HasMaxLength(50)
                    .HasColumnName("papername");

                entity.Property(e => e.Schname)
                    .HasMaxLength(255)
                    .HasColumnName("schname");

                entity.Property(e => e.Schno)
                    .HasMaxLength(20)
                    .HasColumnName("schno");

                entity.Property(e => e.Subject)
                    .HasMaxLength(3)
                    .HasColumnName("subject");

                entity.Property(e => e.Tdduser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TDDuser");

                entity.Property(e => e.Totalscripts).HasColumnName("totalscripts");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");

                entity.Property(e => e.Venuecode)
                    .HasMaxLength(10)
                    .HasColumnName("venuecode");
            });

            modelBuilder.Entity<Examinerslist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Examinerslist");

                entity.Property(e => e.AccessStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Addedexaminer).HasColumnName("addedexaminer");

                entity.Property(e => e.Allocstatus).HasColumnName("allocstatus");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.Clearedby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("clearedby");

                entity.Property(e => e.Cleareddate)
                    .HasColumnType("datetime")
                    .HasColumnName("cleareddate");

                entity.Property(e => e.Cpassword).HasColumnName("cpassword");

                entity.Property(e => e.Dateloaded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddr)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExaminerId).ValueGeneratedOnAdd();

                entity.Property(e => e.Examinername)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Examinernum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gatecrasher).HasColumnName("gatecrasher");

                entity.Property(e => e.Gsmnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gsmnumber");

                entity.Property(e => e.Markingstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Queried).HasColumnName("queried");

                entity.Property(e => e.Seedmaster).HasColumnName("seedmaster");

                entity.Property(e => e.Team)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("team");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userid");

                entity.Property(e => e.Venuecode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExaminerslistAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Examinerslist_audit");

                entity.Property(e => e.AccessStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Addedexaminer).HasColumnName("addedexaminer");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.EmailAddr)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExaminerId).ValueGeneratedOnAdd();

                entity.Property(e => e.Examinername)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Examinernum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gatecrasher).HasColumnName("gatecrasher");

                entity.Property(e => e.Gsmnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gsmnumber");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Markingstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Seedmaster).HasColumnName("seedmaster");

                entity.Property(e => e.Updatetype)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userid");

                entity.Property(e => e.Venuecode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FilesUploadAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FilesUpload_Audit");

                entity.Property(e => e.Filename)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("filename");

                entity.Property(e => e.Filetype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("filetype");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logid).ValueGeneratedOnAdd();

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<MarkingVenue>(entity =>
            {
                entity.HasKey(e => e.Venueid)
                    .HasName("PK_Marking_Centres");

                entity.ToTable("Marking_Venues");

                entity.Property(e => e.Venueid).HasColumnName("venueid");

                entity.Property(e => e.VenueCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Venuename)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarksAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Marks_Audit");

                entity.Property(e => e.AuditId).ValueGeneratedOnAdd();

                entity.Property(e => e.Candname)
                    .HasMaxLength(40)
                    .HasColumnName("candname");

                entity.Property(e => e.Centreno)
                    .HasMaxLength(7)
                    .HasColumnName("centreno");

                entity.Property(e => e.Cleared).HasColumnName("cleared");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("entrydate");

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(10)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LoginId)
                    .HasMaxLength(50)
                    .HasColumnName("loginId");

                entity.Property(e => e.Mark)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Papercode)
                    .HasMaxLength(50)
                    .HasColumnName("papercode");

                entity.Property(e => e.Printflag).HasColumnName("printflag");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Schno)
                    .HasMaxLength(10)
                    .HasColumnName("schno");

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Scriptnotfound).HasColumnName("scriptnotfound");

                entity.Property(e => e.Scriptstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("scriptstatus")
                    .IsFixedLength();

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");

                entity.Property(e => e.Venuecode)
                    .HasMaxLength(10)
                    .HasColumnName("venuecode");

                entity.Property(e => e.Vetscore)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("vetscore")
                    .IsFixedLength();

                entity.Property(e => e.Vetted).HasColumnName("vetted");
            });

            modelBuilder.Entity<MessageBoard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MessageBoard");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Loginid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loginid");

                entity.Property(e => e.Message)
                    .HasMaxLength(500)
                    .HasColumnName("message");

                entity.Property(e => e.Messageid).HasColumnName("messageid");

                entity.Property(e => e.Messagestatus).HasColumnName("messagestatus");

                entity.Property(e => e.Mid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MId");

                entity.Property(e => e.Receiver)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("receiver");

                entity.Property(e => e.Replyflag).HasColumnName("replyflag");

                entity.Property(e => e.Sender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sender");

                entity.Property(e => e.Sendername)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("sendername");

                entity.Property(e => e.Subject)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("subject");

                entity.Property(e => e.Typeid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("typeid")
                    .IsFixedLength();

                entity.Property(e => e.Userrole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userrole");

                entity.Property(e => e.Usertype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("usertype")
                    .IsFixedLength();
            });

            modelBuilder.Entity<OperatorsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OperatorsInfo");

                entity.Property(e => e.Accessstatus).HasColumnName("accessstatus");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.Emailaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailaddress");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Lastupload)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupload");

                entity.Property(e => e.Oid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("oid");

                entity.Property(e => e.Operatorid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("operatorid");

                entity.Property(e => e.Postaladdress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("postaladdress");

                entity.Property(e => e.Servername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servername");

                entity.Property(e => e.Uploading).HasColumnName("uploading");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<PaperQuesControl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PaperQues_Control");

                entity.Property(e => e.Constscore).HasColumnName("constscore");

                entity.Property(e => e.Endpage).HasColumnName("endpage");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Qmaxscore).HasColumnName("qmaxscore");

                entity.Property(e => e.Qminscore).HasColumnName("qminscore");

                entity.Property(e => e.Qsection)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("qsection");

                entity.Property(e => e.Quesno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("quesno");

                entity.Property(e => e.Questype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("questype");

                entity.Property(e => e.Sectionmax).HasColumnName("sectionmax");

                entity.Property(e => e.Sectionmin).HasColumnName("sectionmin");

                entity.Property(e => e.Startpage).HasColumnName("startpage");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Submaxscore).HasColumnName("submaxscore");
            });

            modelBuilder.Entity<Schdelete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("schdelete");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Centre)
                    .HasMaxLength(10)
                    .HasColumnName("centre");

                entity.Property(e => e.CentreId).ValueGeneratedOnAdd();

                entity.Property(e => e.Centrename)
                    .HasMaxLength(255)
                    .HasColumnName("centrename");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Recordtype)
                    .HasMaxLength(2)
                    .HasColumnName("recordtype");

                entity.Property(e => e.Schname)
                    .HasMaxLength(255)
                    .HasColumnName("schname");

                entity.Property(e => e.Schno)
                    .HasMaxLength(10)
                    .HasColumnName("schno");
            });

            modelBuilder.Entity<ScriptsMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ScriptsMaster");

                entity.Property(e => e.Candname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("candname");

                entity.Property(e => e.Centre)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("centre");

                entity.Property(e => e.Dateloaded)
                    .HasColumnType("datetime")
                    .HasColumnName("dateloaded")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Operatorid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("operatorid");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Processed).HasColumnName("processed");

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Sid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sid");

                entity.Property(e => e.Sstatus).HasColumnName("sstatus");

                entity.Property(e => e.Userlogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userlogin");
            });

            modelBuilder.Entity<ScriptsMasterTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ScriptsMaster_Temp");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Operatorid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("operatorid");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Sid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sid");

                entity.Property(e => e.Uploadid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("uploadid");
            });

            modelBuilder.Entity<ScriptsUploadAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ScriptsUpload_Audit");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.Endtime)
                    .HasColumnType("datetime")
                    .HasColumnName("endtime");

                entity.Property(e => e.Operatorid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("operatorid");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Ready).HasColumnName("ready");

                entity.Property(e => e.Sessionid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sessionid");

                entity.Property(e => e.Starttime)
                    .HasColumnType("datetime")
                    .HasColumnName("starttime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Totalimages).HasColumnName("totalimages");

                entity.Property(e => e.Totalscripts).HasColumnName("totalscripts");

                entity.Property(e => e.Uid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("uid");
            });

            modelBuilder.Entity<SeededScriptsScore>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SeededScripts_Scores");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("indexno");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Markedpages)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("markedpages");

                entity.Property(e => e.Markerid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("markerid");

                entity.Property(e => e.Markid).HasColumnName("markid");

                entity.Property(e => e.Marksposition)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("marksposition");

                entity.Property(e => e.Mecherror)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("mecherror");

                entity.Property(e => e.Mqa).HasColumnName("mqa");

                entity.Property(e => e.Numticks).HasColumnName("numticks");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Quesno).HasColumnName("quesno");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("score");

                entity.Property(e => e.ScoreId).ValueGeneratedOnAdd();

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Seedmaster)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("seedmaster");

                entity.Property(e => e.Seedstatus).HasColumnName("seedstatus");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Wordscount).HasColumnName("wordscount");
            });

            modelBuilder.Entity<Subjectspaper>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Errorpenalty1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("errorpenalty1");

                entity.Property(e => e.Errorpenalty2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("errorpenalty2");

                entity.Property(e => e.Errorpenalty3)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("errorpenalty3");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Maxscore).HasColumnName("maxscore");

                entity.Property(e => e.Minscore).HasColumnName("minscore");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(6)
                    .HasColumnName("papercode");

                entity.Property(e => e.Papertype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("papertype");

                entity.Property(e => e.Recordtype)
                    .HasMaxLength(2)
                    .HasColumnName("recordtype");

                entity.Property(e => e.Sscoremax).HasColumnName("sscoremax");

                entity.Property(e => e.SubjectId).ValueGeneratedOnAdd();

                entity.Property(e => e.Subjname)
                    .HasMaxLength(255)
                    .HasColumnName("subjname");

                entity.Property(e => e.Totalanswers).HasColumnName("totalanswers");

                entity.Property(e => e.Totalquestions).HasColumnName("totalquestions");
            });

            modelBuilder.Entity<TblAbsentCand>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblAbsentCands");

                entity.Property(e => e.Absent).HasColumnName("absent");

                entity.Property(e => e.Dateuploaded)
                    .HasColumnType("datetime")
                    .HasColumnName("dateuploaded")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Operatorid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("operatorid");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Sid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sid");
            });

            modelBuilder.Entity<TblAbsentCandsTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblAbsentCands_Temp");

                entity.Property(e => e.Absent).HasColumnName("absent");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Operatorid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("operatorid");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Sid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sid");

                entity.Property(e => e.Uploadid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("uploadid");
            });

            modelBuilder.Entity<TblAlloccentre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblAlloccentre");

                entity.HasIndex(e => e.Examinercode, "IX_Alloccentre_Examinercode")
                    .IsUnique();

                entity.HasIndex(e => new { e.Papercode, e.Examinercode }, "IX_Alloccentre_PaperCode_Examinercode")
                    .IsUnique();

                entity.Property(e => e.Availscript).HasColumnName("availscript");

                entity.Property(e => e.Centreno)
                    .HasMaxLength(20)
                    .HasColumnName("centreno");

                entity.Property(e => e.Datelogged)
                    .HasColumnType("datetime")
                    .HasColumnName("datelogged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Examinercode)
                    .HasMaxLength(20)
                    .HasColumnName("examinercode");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.LogId).ValueGeneratedOnAdd();

                entity.Property(e => e.Markedallocs).HasColumnName("markedallocs");

                entity.Property(e => e.Nextseedval).HasColumnName("nextseedval");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(10)
                    .HasColumnName("papercode");

                entity.Property(e => e.Scriptstovet).HasColumnName("scriptstovet");

                entity.Property(e => e.Totalalloc).HasColumnName("totalalloc");

                entity.Property(e => e.Vetscripttype).HasColumnName("vetscripttype");

                entity.Property(e => e.Vettedscripts).HasColumnName("vettedscripts");
            });

            modelBuilder.Entity<TblBookletsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblBookletsInfo");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Indexnumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("indexnumber");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Scriptid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("scriptid");
            });

            modelBuilder.Entity<TblCentrestoAlloc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCentrestoAlloc");

                entity.Property(e => e.Allocid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("allocid");

                entity.Property(e => e.CentreId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("centreId");

                entity.Property(e => e.Centreno)
                    .HasMaxLength(10)
                    .HasColumnName("centreno");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Numofcand).HasColumnName("numofcand");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(10)
                    .HasColumnName("papercode");
            });

            modelBuilder.Entity<TblImageFile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblImageFiles");

                entity.Property(e => e.Fid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fid");

                entity.Property(e => e.Filename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("filename");

                entity.Property(e => e.Imagebyte).HasColumnName("imagebyte");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("papercode");
            });

            modelBuilder.Entity<TblMacAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblMacAddress");

                entity.Property(e => e.Macaddress)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("macaddress")
                    .IsFixedLength();

                entity.Property(e => e.Mid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("mid");

                entity.Property(e => e.Operatorid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("operatorid");
            });

            modelBuilder.Entity<TblScriptRptTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblScriptRpt_Temp");

                entity.Property(e => e.Pageno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pageno");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("papercode");

                entity.Property(e => e.Scriptno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptno");

                entity.Property(e => e.Scriptpageid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scriptpageid");

                entity.Property(e => e.Scriptpath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("scriptpath");

                entity.Property(e => e.Sid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sid");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<TblTeam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblTeams");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");
            });

            modelBuilder.Entity<UploadSchedule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UploadSchedule");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examtype");

                entity.Property(e => e.Examyear)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("examyear");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AccessStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cpassword).HasColumnName("cpassword");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Emailaddr)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VenueCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersInfoAudit>(entity =>
            {
                entity.HasKey(e => e.Auditid)
                    .HasName("PK_Users_Audit");

                entity.ToTable("UsersInfo_Audit");

                entity.Property(e => e.AccessStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emailaddr)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Updatetype)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userid");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.VenueCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

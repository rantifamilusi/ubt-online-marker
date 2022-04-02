ALTER TABLE adminuser
   ADD CONSTRAINT PK_adminuser_seedid PRIMARY KEY CLUSTERED (seedid);

ALTER TABLE adminuser_audit
   ADD CONSTRAINT PK_adminuser_audit_logid PRIMARY KEY CLUSTERED (logid);

ALTER TABLE allocadmin
   ADD CONSTRAINT PK_allocadmin_logid PRIMARY KEY CLUSTERED (logid);

ALTER TABLE allocadmin_audit
   ADD CONSTRAINT PK_allocadmin_audit_logid PRIMARY KEY CLUSTERED (logid);

ALTER TABLE Candidate_Marks_Data_Vet
   ADD CONSTRAINT PK_Candidate_Marks_Data_Vet_VetId PRIMARY KEY CLUSTERED (VetId);

ALTER TABLE Candidate_Scores
   ADD CONSTRAINT PK_Candidate_Scores_ScoreId PRIMARY KEY CLUSTERED (ScoreId);

ALTER TABLE Candidate_Scores_seeded
   ADD CONSTRAINT PK_Candidate_Scores_seeded_ScoreId PRIMARY KEY CLUSTERED (ScoreId);

ALTER TABLE Candidate_Scores_Temp
   ADD CONSTRAINT PK_Candidate_Scores_Temp_ScoreId PRIMARY KEY CLUSTERED (ScoreId);

ALTER TABLE Candidates_Master
   ADD CONSTRAINT PK_Candidates_Master_StudentId PRIMARY KEY CLUSTERED (StudentId);

ALTER TABLE CandMaster_Temp
   ADD CONSTRAINT PK_CandMaster_Temp_StudentId PRIMARY KEY CLUSTERED (StudentId);

ALTER TABLE CandScores_seeded_Audit
   ADD CONSTRAINT PK_CandScores_seeded_Audit_ScoreId PRIMARY KEY CLUSTERED (ScoreId);

ALTER TABLE Depletedseed_audit
   ADD CONSTRAINT PK_Depletedseed_audit_logid PRIMARY KEY CLUSTERED (logid);

ALTER TABLE ErraticMarking_Audit
   ADD CONSTRAINT PK_Depletedseed_audit_AuditId PRIMARY KEY CLUSTERED (AuditId);



ALTER TABLE Examinerfile
   ADD CONSTRAINT PK_Examinerfile_LogId PRIMARY KEY CLUSTERED (LogId);

ALTER TABLE Examinerfile_audit
   ADD CONSTRAINT PK_Examinerfile_audit_LogId PRIMARY KEY CLUSTERED (LogId);

ALTER TABLE Examinerslist
   ADD CONSTRAINT PK_Examinerslist_ExaminerId PRIMARY KEY CLUSTERED (ExaminerId);

ALTER TABLE Examinerslist_audit
   ADD CONSTRAINT PK_Examinerslist_audit_ExaminerId PRIMARY KEY CLUSTERED (ExaminerId);

ALTER TABLE FilesUpload_Audit
   ADD CONSTRAINT PK_FilesUpload_Audit_Logid PRIMARY KEY CLUSTERED (Logid);

ALTER TABLE Marks_Audit
   ADD CONSTRAINT PK_Marks_Audit_AuditId PRIMARY KEY CLUSTERED (AuditId);

ALTER TABLE MessageBoard
   ADD CONSTRAINT PK_MessageBoard_Mid PRIMARY KEY CLUSTERED (Mid);

ALTER TABLE OperatorsInfo
   ADD CONSTRAINT PK_OperatorsInfo_oid PRIMARY KEY CLUSTERED (oid);

ALTER TABLE Schools
   ADD CONSTRAINT PK_Schools_CentreId PRIMARY KEY CLUSTERED (CentreId);

ALTER TABLE ScriptsMaster
   ADD CONSTRAINT PK_ScriptsMaster_sid PRIMARY KEY CLUSTERED (sid);

ALTER TABLE ScriptsMaster_Temp
   ADD CONSTRAINT PK_ScriptsMaster_Temp_sid PRIMARY KEY CLUSTERED (sid);

ALTER TABLE ScriptsUpload_Audit
   ADD CONSTRAINT PK_ScriptsUpload_Audit_uid PRIMARY KEY CLUSTERED (uid);


ALTER TABLE SeededScripts_Scores
   ADD CONSTRAINT PK_SeededScripts_Scores_ScoreId PRIMARY KEY CLUSTERED (ScoreId);



   ALTER TABLE Subjectspapers
   ADD CONSTRAINT PK_Subjectspapers_SubjectId PRIMARY KEY CLUSTERED (SubjectId);

ALTER TABLE tblAbsentCands
   ADD CONSTRAINT PK_tblAbsentCands_sid PRIMARY KEY CLUSTERED (sid);

ALTER TABLE tblAbsentCands_Temp
   ADD CONSTRAINT PK_tblAbsentCands_Temp_sid PRIMARY KEY CLUSTERED (sid);

ALTER TABLE tblAlloccentre
   ADD CONSTRAINT PK_tblAlloccentre_LogId PRIMARY KEY CLUSTERED (LogId);

ALTER TABLE tblCentrestoAlloc
   ADD CONSTRAINT PK_tblCentrestoAlloc_centreid PRIMARY KEY CLUSTERED (centreid);

ALTER TABLE tblImageFiles
   ADD CONSTRAINT PK_tblImageFiles_fid PRIMARY KEY CLUSTERED (fid);

ALTER TABLE tblMacAddress
   ADD CONSTRAINT PK_tblMacAddress_mid PRIMARY KEY CLUSTERED (mid);

ALTER TABLE tblScriptRpt_Temp
   ADD CONSTRAINT PK_tblScriptRpt_Temp_sid PRIMARY KEY CLUSTERED (sid);


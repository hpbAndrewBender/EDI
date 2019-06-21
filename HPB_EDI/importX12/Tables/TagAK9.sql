CREATE TABLE [importX12].[TagAK9] (
    [AK9Id]                             BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileID]                         INT          NOT NULL,
    [LineNumber]                        INT          NOT NULL,
    [ControlNumberGroup]                VARCHAR (25) NULL,
    [ControlNumberTransaction]          VARCHAR (25) NULL,
    [FunctionalGroupAcknowledgeCode]    VARCHAR (1)  NULL,
    [NumberOfTransactionSetsIncluded]   VARCHAR (6)  NULL,
    [NumberOfReceivedTransactionSets]   VARCHAR (6)  NULL,
    [NumberOfAcceptedTransactionSets]   VARCHAR (6)  NULL,
    [FunctionalGroupSyntaxErrorCode_01] VARCHAR (3)  NULL,
    [FunctionalGroupSyntaxErrorCode_02] VARCHAR (3)  NULL,
    [FunctionalGroupSyntaxErrorCode_03] VARCHAR (3)  NULL,
    [FunctionalGroupSyntaxErrorCode_04] VARCHAR (3)  NULL,
    [FunctionalGroupSyntaxErrorCode_05] VARCHAR (3)  NULL,
    CONSTRAINT [PK_importEDI_AK9] PRIMARY KEY CLUSTERED ([AK9Id] ASC),
    CONSTRAINT [FK_importEDI_AK9~importEDIFiles] FOREIGN KEY ([EDIFileID]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


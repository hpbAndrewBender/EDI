CREATE TABLE [importX12].[TagAK5] (
    [AK5Id]                            BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileID]                        INT          NOT NULL,
    [LineNumber]                       INT          NOT NULL,
    [ControlNumberGroup]               VARCHAR (25) NULL,
    [ControlNumberTransaction]         VARCHAR (25) NULL,
    [TransactionSetAcknowledgmentCode] VARCHAR (2)  NULL,
    [TransactionSetSyntaxErrorCode_01] VARCHAR (3)  NULL,
    [TransactionSetSyntaxErrorCode_02] VARCHAR (3)  NULL,
    [TransactionSetSyntaxErrorCode_03] VARCHAR (3)  NULL,
    [TransactionSetSyntaxErrorCode_04] VARCHAR (3)  NULL,
    [TransactionSetSyntaxErrorCode_05] VARCHAR (3)  NULL,
    CONSTRAINT [PK_importEDI_AK5] PRIMARY KEY CLUSTERED ([AK5Id] ASC),
    CONSTRAINT [FK_importEDI_AK5~importEDIFiles] FOREIGN KEY ([EDIFileID]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


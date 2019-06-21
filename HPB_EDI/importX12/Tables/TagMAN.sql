CREATE TABLE [importX12].[TagMAN] (
    [MANId]                       BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                   INT          NOT NULL,
    [LineNumber]                  INT          NOT NULL,
    [ControlNumberGroup]          VARCHAR (25) NULL,
    [ControlNumberTransaction]    VARCHAR (25) NULL,
    [MarksAndNumbersQualifier_01] VARCHAR (2)  NULL,
    [MarksAndNumbers_01]          VARCHAR (48) NULL,
    [MarksAndNumbersQualifier_02] VARCHAR (2)  NULL,
    [MarksAndNumbers_02]          VARCHAR (48) NULL,
    CONSTRAINT [PK_importEDI_MAN] PRIMARY KEY CLUSTERED ([MANId] ASC),
    CONSTRAINT [FK_importEDI_MAN~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


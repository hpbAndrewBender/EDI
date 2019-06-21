CREATE TABLE [importX12].[TagIT8] (
    [IT8Id]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [SalesRequirementCode]     VARCHAR (2)  NULL,
    [Do_Not_ExceedActionCode]  VARCHAR (1)  NULL,
    [Amount]                   VARCHAR (15) NULL,
    CONSTRAINT [PK_importEDI_IT8] PRIMARY KEY CLUSTERED ([IT8Id] ASC),
    CONSTRAINT [FK_importEDI_IT8~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


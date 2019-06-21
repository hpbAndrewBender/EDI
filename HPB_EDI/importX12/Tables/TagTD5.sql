CREATE TABLE [importX12].[TagTD5] (
    [TD5Id]                       BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                   INT          NOT NULL,
    [LineNumber]                  INT          NOT NULL,
    [ControlNumberGroup]          VARCHAR (25) NULL,
    [ControlNumberTransaction]    VARCHAR (25) NULL,
    [RoutingSequenceCode]         VARCHAR (2)  NULL,
    [IdentificationCodeQualifier] VARCHAR (2)  NULL,
    [IdentificationCode]          VARCHAR (20) NULL,
    [Routing]                     VARCHAR (35) NULL,
    [ServiceLevelCode]            VARCHAR (2)  NULL,
    CONSTRAINT [PK_importEDI_TD5] PRIMARY KEY CLUSTERED ([TD5Id] ASC),
    CONSTRAINT [FK_importEDI_TD5~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


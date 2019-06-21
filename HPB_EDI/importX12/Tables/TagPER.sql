CREATE TABLE [importX12].[TagPER] (
    [PERId]                            BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                        INT          NOT NULL,
    [LineNumber]                       INT          NOT NULL,
    [ControlNumberGroup]               VARCHAR (25) NULL,
    [ControlNumberTransaction]         VARCHAR (25) NULL,
    [ContactFunctionCode]              VARCHAR (2)  NULL,
    [Name]                             VARCHAR (35) NULL,
    [CommunicationNumberQualifier_01]  VARCHAR (2)  NULL,
    [CommunicationNumber_01]           VARCHAR (80) NULL,
    [CommunicationNumberQualifier_02]  VARCHAR (2)  NULL,
    [CommunicationNumber_02]           VARCHAR (80) NULL,
    [CommunicationNumberQualifier_027] VARCHAR (2)  NULL,
    [CommunicationNumber_03]           VARCHAR (80) NULL,
    CONSTRAINT [PK_importEDI_PER] PRIMARY KEY CLUSTERED ([PERId] ASC),
    CONSTRAINT [FK_importEDI_PER~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


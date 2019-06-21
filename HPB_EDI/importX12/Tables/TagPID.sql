CREATE TABLE [importX12].[TagPID] (
    [PIDId]                            BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                        INT          NOT NULL,
    [LineNumber]                       INT          NOT NULL,
    [ControlNumberGroup]               VARCHAR (25) NULL,
    [ControlNumberTransaction]         VARCHAR (25) NULL,
    [ItemDescriptionType]              VARCHAR (1)  NULL,
    [ProductProcessCharacteristicCode] VARCHAR (3)  NULL,
    [AgencyQualifierCode]              VARCHAR (2)  NULL,
    [ProductDescriptionCode]           VARCHAR (12) NULL,
    [Description]                      VARCHAR (80) NULL,
    CONSTRAINT [PK_importEDI_PID] PRIMARY KEY CLUSTERED ([PIDId] ASC),
    CONSTRAINT [FK_importEDI_PID~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


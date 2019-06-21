CREATE TABLE [importX12].[TagREF] (
    [REFId]                            BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                        INT          NOT NULL,
    [LineNumber]                       INT          NOT NULL,
    [ControlNumberGroup]               VARCHAR (25) NULL,
    [ControlNumberTransaction]         VARCHAR (25) NULL,
    [ReferenceIdentificationQualifier] VARCHAR (3)  NULL,
    [ReferenceIdentification]          VARCHAR (30) NULL,
    CONSTRAINT [PK_importEDI_REF] PRIMARY KEY CLUSTERED ([REFId] ASC),
    CONSTRAINT [FK_importEDI_REF~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


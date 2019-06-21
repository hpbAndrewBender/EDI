CREATE TABLE [importX12].[TagCSH] (
    [CSHId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [SalesRequirementCode]     VARCHAR (2)  NULL,
    [AgencyQualifierCode]      VARCHAR (2)  NULL,
    [SpecialServicesCode]      VARCHAR (10) NULL,
    CONSTRAINT [PK_importEDI_CSH] PRIMARY KEY CLUSTERED ([CSHId] ASC),
    CONSTRAINT [FK_importEDI_CSH~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


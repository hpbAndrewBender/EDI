CREATE TABLE [importX12].[TagSCH] (
    [SCHId]                         BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                     INT          NOT NULL,
    [LineNumber]                    INT          NOT NULL,
    [ControlNumberGroup]            VARCHAR (25) NULL,
    [ControlNumberTransaction]      VARCHAR (25) NULL,
    [Quantity]                      VARCHAR (15) NULL,
    [UnitOrBasisForMeasurementCode] VARCHAR (2)  NULL,
    [EntityIdentifierCode]          VARCHAR (2)  NULL,
    [Name]                          VARCHAR (35) NULL,
    [DateTimeQualifier]             VARCHAR (3)  NULL,
    [Date]                          VARCHAR (8)  NULL,
    [RequestReferenceNumber]        VARCHAR (45) NULL,
    CONSTRAINT [PK_importEDI_SCH] PRIMARY KEY CLUSTERED ([SCHId] ASC),
    CONSTRAINT [FK_importEDI_SCH~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


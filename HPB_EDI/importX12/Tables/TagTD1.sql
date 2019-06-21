CREATE TABLE [importX12].[TagTD1] (
    [TD1Id]                         BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                     INT          NOT NULL,
    [LineNumber]                    INT          NOT NULL,
    [ControlNumberGroup]            VARCHAR (25) NULL,
    [ControlNumberTransaction]      VARCHAR (25) NULL,
    [PackagingCode]                 VARCHAR (5)  NULL,
    [LadingQuantity]                VARCHAR (7)  NULL,
    [CommodityCodeQualifier]        VARCHAR (1)  NULL,
    [CommodityCode]                 VARCHAR (30) NULL,
    [LadingDescription]             VARCHAR (50) NULL,
    [WeightQualifier]               VARCHAR (2)  NULL,
    [Weight]                        VARCHAR (10) NULL,
    [UnitOrBasisForMeasurementCode] VARCHAR (2)  NULL,
    CONSTRAINT [PK_importEDI_TD1] PRIMARY KEY CLUSTERED ([TD1Id] ASC),
    CONSTRAINT [FK_importEDI_TD1~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


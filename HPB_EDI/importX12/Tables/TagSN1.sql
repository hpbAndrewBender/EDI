CREATE TABLE [importX12].[TagSN1] (
    [SN1Id]                            BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                        INT          NOT NULL,
    [LineNumber]                       INT          NOT NULL,
    [ControlNumberGroup]               VARCHAR (25) NULL,
    [ControlNumberTransaction]         VARCHAR (25) NULL,
    [AssignedIdentification]           VARCHAR (20) NULL,
    [NumberOfUnitsShipped]             VARCHAR (10) NULL,
    [UnitOrBasisForMeasurementCode_01] VARCHAR (2)  NULL,
    [QuantityShippedToDate]            VARCHAR (9)  NULL,
    [QuantityOrdered]                  VARCHAR (9)  NULL,
    [UnitOrBasisForMeasurementCode_02] VARCHAR (2)  NULL,
    CONSTRAINT [PK_importEDI_SN1] PRIMARY KEY CLUSTERED ([SN1Id] ASC),
    CONSTRAINT [FK_importEDI_SN1~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


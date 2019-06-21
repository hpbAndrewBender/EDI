CREATE TABLE [importX12].[TagIT1] (
    [IT1Id]                         BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                     INT          NOT NULL,
    [LineNumber]                    INT          NOT NULL,
    [ControlNumberGroup]            VARCHAR (25) NULL,
    [ControlNumberTransaction]      VARCHAR (25) NULL,
    [AssignedIdentification]        VARCHAR (20) NULL,
    [QuantityInvoiced]              VARCHAR (10) NULL,
    [UnitOrBasisForMeasurementCode] VARCHAR (2)  NULL,
    [UnitPrice]                     VARCHAR (17) NULL,
    [BasisOfUnitPriceCode]          VARCHAR (2)  NULL,
    [ProductServiceIDQualifier_01]  VARCHAR (2)  NULL,
    [ProductServiceID_01]           VARCHAR (40) NULL,
    [ProductServiceIDQualifier_02]  VARCHAR (2)  NULL,
    [ProductServiceID_02]           VARCHAR (40) NULL,
    [ProductServiceIDQualifier_03]  VARCHAR (2)  NULL,
    [ProductServiceID_03]           VARCHAR (40) NULL,
    CONSTRAINT [PK_importEDI_IT1] PRIMARY KEY CLUSTERED ([IT1Id] ASC),
    CONSTRAINT [FK_importEDI_IT1~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


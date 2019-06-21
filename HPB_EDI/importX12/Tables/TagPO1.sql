CREATE TABLE [importX12].[TagPO1] (
    [PO1Id]                         BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                     INT          NOT NULL,
    [LineNumber]                    INT          NOT NULL,
    [ControlNumberGroup]            VARCHAR (25) NULL,
    [ControlNumberTransaction]      VARCHAR (25) NULL,
    [AssignedIdentification]        VARCHAR (20) NULL,
    [QuantityOrdered]               VARCHAR (9)  NULL,
    [UnitOrBasisForMeasurementCode] VARCHAR (2)  NULL,
    [UnitPrice]                     VARCHAR (17) NULL,
    [BasisOfUnitPriceCode]          VARCHAR (2)  NULL,
    [ProductServiceIDQualifier_01]  VARCHAR (2)  NULL,
    [ProductServiceID_01]           VARCHAR (40) NULL,
    [ProductServiceIDQualifier_02]  VARCHAR (2)  NULL,
    [ProductServiceID_02]           VARCHAR (40) NULL,
    [ProductServiceIDQualifier_03]  VARCHAR (2)  NULL,
    [ProductServiceID_03]           VARCHAR (40) NULL,
    [ProductServiceIDQualifier_04]  VARCHAR (2)  NULL,
    [ProductServiceID_04]           VARCHAR (40) NULL,
    CONSTRAINT [PK_importEDI_PO1] PRIMARY KEY CLUSTERED ([PO1Id] ASC),
    CONSTRAINT [FK_importEDI_PO1~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


GO
CREATE NONCLUSTERED INDEX [IX_impoortedEDI_PO1]
    ON [importX12].[TagPO1]([EDIFileId] ASC, [ControlNumberGroup] ASC, [ControlNumberTransaction] ASC, [LineNumber] ASC);


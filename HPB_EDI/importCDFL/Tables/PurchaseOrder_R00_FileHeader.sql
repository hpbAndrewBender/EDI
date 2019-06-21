CREATE TABLE [importCDFL].[PurchaseOrder_R00_FileHeader] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [BatchID]            INT          NOT NULL,
    [RecordCode]         TINYINT      NOT NULL,
    [SequenceNumber]     INT          NOT NULL,
    [FileSourceSAN]      VARCHAR (7)  NOT NULL,
    [FileSourceName]     VARCHAR (13) NOT NULL,
    [CreationDate]       DATE         NOT NULL,
    [FIleName]           VARCHAR (22) NOT NULL,
    [FormatVersion]      VARCHAR (3)  NOT NULL,
    [IngramSAN]          VARCHAR (7)  NOT NULL,
    [VendorNameFlag]     CHAR (1)     NOT NULL,
    [ProductDescription] VARCHAR (4)  NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R00_FileHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R00_FileHeader.RecodeSequence]
    ON [importCDFL].[PurchaseOrder_R00_FileHeader]([RecordCode] ASC, [SequenceNumber] ASC);


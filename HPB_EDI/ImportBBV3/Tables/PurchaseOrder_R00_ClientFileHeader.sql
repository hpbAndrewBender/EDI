CREATE TABLE [ImportBBV3].[PurchaseOrder_R00_ClientFileHeader] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]         VARCHAR (2)  NOT NULL,
    [SequenceNumber]     SMALLINT     NOT NULL,
    [FileSourceSAN]      VARCHAR (7)  NOT NULL,
    [FileSourceName]     VARCHAR (13) NOT NULL,
    [CreationDate]       DATE         NOT NULL,
    [Filename]           VARCHAR (22) NOT NULL,
    [FormatVersion]      VARCHAR (3)  NOT NULL,
    [IngramSAN]          VARCHAR (7)  NOT NULL,
    [VendorNameFlag]     CHAR (1)     NOT NULL,
    [ProductDescription] VARCHAR (4)  NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R00_ClientFileHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);


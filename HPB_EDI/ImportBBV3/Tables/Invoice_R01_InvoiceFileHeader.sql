CREATE TABLE [ImportBBV3].[Invoice_R01_InvoiceFileHeader] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT          NULL,
    [InvoiceFileHeader]    VARCHAR (2)  NULL,
    [RecordSequenceNumber] SMALLINT     NULL,
    [IngramSAN]            VARCHAR (12) NULL,
    [FileSource]           VARCHAR (13) NULL,
    [CreationDate]         DATE         NULL,
    [FileName]             VARCHAR (22) NULL,
    CONSTRAINT [PK_Invoice_R01_InvoiceFileHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);




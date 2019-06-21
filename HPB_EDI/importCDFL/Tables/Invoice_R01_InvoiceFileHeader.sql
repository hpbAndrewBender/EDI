CREATE TABLE [importCDFL].[Invoice_R01_InvoiceFileHeader] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [BatchID]        INT          NOT NULL,
    [FileHeader]     VARCHAR (2)  NOT NULL,
    [RecordSequence] SMALLINT     NOT NULL,
    [IngramSAN]      VARCHAR (12) NOT NULL,
    [FileSource]     VARCHAR (13) NOT NULL,
    [CreationDate]   DATE         NOT NULL,
    [FileName]       VARCHAR (22) NOT NULL,
    CONSTRAINT [PK_Invoice_R01_InvoiceFileHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R01_InvoiceFileHeader.RecordSequence]
    ON [importCDFL].[Invoice_R01_InvoiceFileHeader]([RecordSequence] ASC);


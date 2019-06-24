CREATE TABLE [importCDFL].[Invoice_R48_DetailTotal] (
    [Id]                  INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]             INT          NULL,
    [DetailTotalRecord#1] VARCHAR (2)  NOT NULL,
    [RecordSequence]      SMALLINT     NOT NULL,
    [InvoiceNumber]       VARCHAR (8)  NOT NULL,
    [Title]               VARCHAR (16) NOT NULL,
    [ClientOrderID]       VARCHAR (22) NOT NULL,
    [LineItemIDNumber]    VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_Invoice_R48_DetailTotal] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R48_DetailTotal.RecordSequence]
    ON [importCDFL].[Invoice_R48_DetailTotal]([RecordSequence] ASC);


CREATE TABLE [ImportBBV3].[Invoice_R46_DetailISBN13EAN] (
    [Id]                      INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                 INT          NULL,
    [DetailISBN13OrEANRecord] VARCHAR (2)  NULL,
    [RecordSequenceNumber]    SMALLINT     NULL,
    [InvoiceNumber]           INT          NULL,
    [LineItemIDNumber]        VARCHAR (22) NULL,
    [ISBN13OrEANShipped]      VARCHAR (13) NULL,
    CONSTRAINT [PK_Invoice_R46_DetailISBN13EAN] PRIMARY KEY CLUSTERED ([Id] ASC)
);




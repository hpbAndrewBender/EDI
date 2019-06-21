CREATE TABLE [importCDFL].[Invoice_R49_DetailTotalOrFreightAndFees] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [DetailTotalRecord] VARCHAR (2)    NOT NULL,
    [RecordSequence]    SMALLINT       NOT NULL,
    [InvoiceNumber]     VARCHAR (8)    NOT NULL,
    [TrackingNumber]    VARCHAR (25)   NOT NULL,
    [NetPrice]          DECIMAL (8, 2) NOT NULL,
    [Shipping]          DECIMAL (6, 2) NOT NULL,
    [Handling]          DECIMAL (7, 2) NOT NULL,
    [GiftWrap]          DECIMAL (6, 2) NOT NULL,
    [AmountDue]         DECIMAL (7, 2) NOT NULL,
    CONSTRAINT [PK_Invoice_R49_DetailTotalOrFreightAndFees] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R49_DetailTotalOrFreightAndFees.RecordSequence]
    ON [importCDFL].[Invoice_R49_DetailTotalOrFreightAndFees]([RecordSequence] ASC);


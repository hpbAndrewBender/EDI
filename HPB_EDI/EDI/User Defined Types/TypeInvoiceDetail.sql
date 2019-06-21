CREATE TYPE [EDI].[TypeInvoiceDetail] AS TABLE (
    [LineNo]          VARCHAR (10)   NULL,
    [ItemIdCode]      VARCHAR (5)    NULL,
    [ItemIdentifier]  VARCHAR (20)   NULL,
    [ItemDesc]        VARCHAR (250)  NULL,
    [InvoiceQty]      INT            NULL,
    [UnitPrice]       MONEY          NULL,
    [DiscountPrice]   MONEY          NULL,
    [DiscountCode]    VARCHAR (10)   NULL,
    [DiscountPct]     DECIMAL (4, 2) NULL,
    [RetailPrice]     MONEY          NULL,
    [ReferenceNumber] VARCHAR (50)   NULL,
    [ponumber]        VARCHAR (22)   NULL);




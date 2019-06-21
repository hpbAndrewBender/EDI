CREATE TYPE [EDI].[TypePurchaseOrderDetail] AS TABLE (
    [LineNo]         VARCHAR (10) NULL,
    [Quantity]       INT          NULL,
    [UnitOfMeasure]  CHAR (3)     NULL,
    [UnitPrice]      MONEY        NULL,
    [PriceCode]      VARCHAR (10) NULL,
    [ItemIdCode]     VARCHAR (5)  NULL,
    [ItemIdentifier] VARCHAR (20) NULL,
    [ItemFillTerms]  VARCHAR (30) NULL,
    [XActionCode]    VARCHAR (10) NULL,
    [FillAmount]     VARCHAR (10) NULL,
    [ponumber]       VARCHAR (10) NULL);


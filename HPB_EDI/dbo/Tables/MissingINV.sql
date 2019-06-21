CREATE TABLE [dbo].[MissingINV] (
    [Trans]      VARCHAR (10)   NOT NULL,
    [RemAmt]     MONEY          NOT NULL,
    [OrigAmt]    MONEY          NOT NULL,
    [TransDate]  SMALLDATETIME  NOT NULL,
    [PO]         VARCHAR (10)   NOT NULL,
    [SalesOrder] VARCHAR (10)   NOT NULL,
    [LocationNo] VARCHAR (10)   NOT NULL,
    [DiscPct]    DECIMAL (8, 2) NOT NULL,
    [OrigPrice]  MONEY          NOT NULL,
    CONSTRAINT [PK_MissingINV] PRIMARY KEY CLUSTERED ([Trans] ASC, [PO] ASC)
);


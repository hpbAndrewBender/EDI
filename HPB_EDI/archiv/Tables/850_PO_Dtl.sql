CREATE TABLE [archiv].[850_PO_Dtl] (
    [ItemOrdID]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [OrdID]          INT           NOT NULL,
    [LineNo]         NVARCHAR (10) NOT NULL,
    [Qty]            INT           NOT NULL,
    [UOM]            NCHAR (3)     NULL,
    [UnitPrice]      NVARCHAR (10) NULL,
    [PriceCode]      NVARCHAR (10) NULL,
    [ItemIDCode]     NVARCHAR (5)  NULL,
    [ItemIdentifier] NVARCHAR (20) NOT NULL,
    [ItemFillTerms]  NVARCHAR (30) NULL,
    [XActionCode]    NVARCHAR (10) NULL,
    [FillAmount]     NVARCHAR (10) NULL,
    CONSTRAINT [PK_850_PO_Dtl] PRIMARY KEY CLUSTERED ([ItemOrdID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_OrdID]
    ON [archiv].[850_PO_Dtl]([OrdID] ASC);


CREATE TABLE [dbo].[temp_810_Inv_Dtl] (
    [ItemInvoiceID]  INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceID]      INT            NOT NULL,
    [LineNo]         NVARCHAR (10)  NOT NULL,
    [ItemIDCode]     NVARCHAR (5)   NULL,
    [ItemIdentifier] NVARCHAR (20)  NOT NULL,
    [ItemDesc]       NVARCHAR (250) NULL,
    [InvoiceQty]     INT            NOT NULL,
    [UnitPrice]      NVARCHAR (10)  NULL,
    [DiscountPrice]  NVARCHAR (10)  NULL,
    [DiscountCode]   NVARCHAR (10)  NULL,
    [DiscountPct]    NVARCHAR (10)  NULL,
    [RetailPrice]    NVARCHAR (10)  NULL,
    CONSTRAINT [PK_810_Inv_Dtl_temp] PRIMARY KEY CLUSTERED ([ItemInvoiceID] ASC)
);


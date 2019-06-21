CREATE TABLE [dbo].[810_Inv_Charges] (
    [PONumber]   NCHAR (6)     NOT NULL,
    [InvoiceNo]  NVARCHAR (20) NOT NULL,
    [ChargeCode] NVARCHAR (10) NOT NULL,
    [ChargeAmt]  MONEY         NOT NULL,
    CONSTRAINT [PK_810_Inv_Charges] PRIMARY KEY CLUSTERED ([PONumber] ASC, [InvoiceNo] ASC, [ChargeCode] ASC)
);


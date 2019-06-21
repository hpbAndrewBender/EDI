CREATE TABLE [EDI].[PurchaseOrderHeader] (
    [OrderId]           INT           IDENTITY (1, 1) NOT NULL,
    [PONumber]          VARCHAR (22)  NOT NULL,
    [IssueDate]         DATETIME      NULL,
    [VendorID]          VARCHAR (20)  NOT NULL,
    [ShipToLoc]         VARCHAR (5)   NULL,
    [ShipToSAN]         VARCHAR (12)  NULL,
    [BillToLoc]         VARCHAR (5)   NULL,
    [BillToSAN]         VARCHAR (12)  NULL,
    [ShipFromLoc]       VARCHAR (5)   NULL,
    [ShipFromSAN]       VARCHAR (12)  NULL,
    [TotalLines]        INT           NULL,
    [TotalQuantity]     INT           NULL,
    [InsertDateTime]    DATETIME      CONSTRAINT [DF_PurchaseOrderHeader_InsertDateTime] DEFAULT (getutcdate()) NULL,
    [Processed]         BIT           CONSTRAINT [DF_PurchaseOrderHeader_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME2 (7) NULL,
    CONSTRAINT [PK_PurchaseOrderHeader] PRIMARY KEY CLUSTERED ([OrderId] ASC)
);






GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrderHeader_PONumber]
    ON [EDI].[PurchaseOrderHeader]([PONumber] ASC);


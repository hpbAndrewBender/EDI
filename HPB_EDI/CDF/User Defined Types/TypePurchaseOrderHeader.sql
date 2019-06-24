CREATE TYPE [CDF].[TypePurchaseOrderHeader] AS TABLE (
    [PONumber]          VARCHAR (10) NULL,
    [IssueDate]         DATETIME     NULL,
    [VendorID]          VARCHAR (20) NULL,
    [ShipToLoc]         VARCHAR (5)  NULL,
    [ShipToSAN]         VARCHAR (12) NULL,
    [BillToLoc]         VARCHAR (5)  NULL,
    [BillToSAN]         VARCHAR (12) NULL,
    [ShipFromLoc]       VARCHAR (5)  NULL,
    [ShipFromSAN]       VARCHAR (12) NULL,
    [TotalLines]        INT          NULL,
    [TotalQuantity]     INT          NULL,
    [InsertDateTime]    DATETIME     NULL,
    [Processed]         BIT          NULL,
    [ProcessedDateTime] DATETIME     NULL);


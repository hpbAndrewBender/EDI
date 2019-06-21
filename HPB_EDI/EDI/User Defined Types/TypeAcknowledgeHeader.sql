﻿CREATE TYPE [EDI].[TypeAcknowledgeHeader] AS TABLE (
    [PONumber]          VARCHAR (22)  NULL,
    [IssueDate]         DATETIME      NULL,
    [VendorId]          VARCHAR (20)  NULL,
    [ReferenceNo]       VARCHAR (20)  NULL,
    [ShipToLoc]         VARCHAR (5)   NULL,
    [ShipToSAN]         VARCHAR (12)  NULL,
    [BillToLoc]         VARCHAR (5)   NULL,
    [BillToSAN]         VARCHAR (12)  NULL,
    [ShipFromLoc]       VARCHAR (5)   NULL,
    [ShipFromSAN]       VARCHAR (12)  NULL,
    [TotalLines]        INT           NULL,
    [TotalQuantity]     INT           NULL,
    [CurrencyCode]      VARCHAR (5)   NULL,
    [InsertDateTime]    DATETIME      NULL,
    [Processed]         BIT           NULL,
    [ProcessedDateTime] DATETIME2 (7) NULL,
    [ResponseACKSent]   BIT           NULL,
    [ResponseAckNo]     VARCHAR (10)  NULL,
    [GSNo]              VARCHAR (10)  NULL);




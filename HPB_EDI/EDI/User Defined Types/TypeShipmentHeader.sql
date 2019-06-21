﻿CREATE TYPE [EDI].[TypeShipmentHeader] AS TABLE (
    [PONumber]          VARCHAR (22)  NULL,
    [ASNNo]             VARCHAR (20)  NULL,
    [IssueDate]         DATETIME      NULL,
    [VendorID]          VARCHAR (20)  NULL,
    [ReferenceNo]       VARCHAR (20)  NULL,
    [ShipToLoc]         VARCHAR (5)   NULL,
    [ShipToSAN]         VARCHAR (12)  NULL,
    [BillToLoc]         VARCHAR (5)   NULL,
    [BillToSAN]         VARCHAR (12)  NULL,
    [ShipFromLoc]       VARCHAR (5)   NULL,
    [ShipFromSAN]       VARCHAR (12)  NULL,
    [Carrier]           VARCHAR (20)  NULL,
    [TotalLines]        INT           NULL,
    [TotalQuantity]     INT           NULL,
    [CurrencyCode]      CHAR (3)      NULL,
    [InsertDateTime]    DATETIME      NULL,
    [Processed]         BIT           NULL,
    [ProcessedDateTime] DATETIME2 (7) NULL,
    [ASNACKSent]        BIT           NULL,
    [ASNAckNo]          VARCHAR (10)  NULL,
    [GSNo]              VARCHAR (10)  NULL);




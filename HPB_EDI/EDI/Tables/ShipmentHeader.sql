﻿CREATE TABLE [EDI].[ShipmentHeader] (
    [ShipmentID]        INT           IDENTITY (1, 1) NOT NULL,
    [PONumber]          VARCHAR (22)  NOT NULL,
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
    [InsertDateTime]    DATETIME      CONSTRAINT [DF_ShipmentHeader_InsertDateTime] DEFAULT (getutcdate()) NULL,
    [Processed]         BIT           CONSTRAINT [DF_ShipmentHeader_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME2 (7) NULL,
    [ASNACKSent]        BIT           NULL,
    [ASNAckNo]          VARCHAR (10)  NULL,
    [GSNo]              VARCHAR (10)  NULL,
    [EDISourceTypeId]   TINYINT       NULL,
    CONSTRAINT [PK_ShipmentHeader] PRIMARY KEY CLUSTERED ([ShipmentID] ASC)
);






GO
CREATE NONCLUSTERED INDEX [IX_ShipmentHeader_PONUmber]
    ON [EDI].[ShipmentHeader]([PONumber] ASC);


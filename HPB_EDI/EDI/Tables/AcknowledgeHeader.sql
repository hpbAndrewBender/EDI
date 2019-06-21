﻿CREATE TABLE [EDI].[AcknowledgeHeader] (
    [AckId]             INT           IDENTITY (1, 1) NOT NULL,
    [PONumber]          VARCHAR (22)  NULL,
    [IssueDate]         DATETIME      NULL,
    [VendorId]          VARCHAR (20)  NOT NULL,
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
    [InsertDateTime]    DATETIME      CONSTRAINT [DF_AcknowledgeHeader_InsertDateTime] DEFAULT (getutcdate()) NULL,
    [Processed]         BIT           CONSTRAINT [DF_AcknowledgeHeader_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME2 (7) NULL,
    [ResponseACKSent]   BIT           NULL,
    [ResponseAckNo]     VARCHAR (10)  NULL,
    [GSNo]              VARCHAR (10)  NULL,
    [EDISourceTypeId]   TINYINT       NULL,
    [VendorMessage]     VARCHAR (500) NULL,
    CONSTRAINT [PK_AcknowledgeHeader] PRIMARY KEY CLUSTERED ([AckId] ASC)
);








GO
CREATE NONCLUSTERED INDEX [IX_AcknowledgeHeader_PONumber]
    ON [EDI].[AcknowledgeHeader]([PONumber] ASC);


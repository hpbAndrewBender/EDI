﻿CREATE TABLE [archiv].[810_Inv_Hdr] (
    [InvoiceID]         INT           IDENTITY (1, 1) NOT NULL,
    [InvoiceNo]         NVARCHAR (20) NOT NULL,
    [IssueDate]         DATETIME      NOT NULL,
    [VendorID]          NVARCHAR (20) NOT NULL,
    [PONumber]          NCHAR (6)     NOT NULL,
    [ReferenceNo]       NVARCHAR (20) NULL,
    [ShipToLoc]         NCHAR (5)     NOT NULL,
    [ShipToSAN]         NVARCHAR (12) NOT NULL,
    [BillToLoc]         NCHAR (5)     NOT NULL,
    [BillToSAN]         NVARCHAR (12) NOT NULL,
    [ShipFromLoc]       NCHAR (5)     NOT NULL,
    [ShipFromSAN]       NVARCHAR (12) NOT NULL,
    [TotalLines]        INT           NOT NULL,
    [TotalQty]          INT           NOT NULL,
    [TotalPayable]      MONEY         NOT NULL,
    [CurrencyCode]      NVARCHAR (5)  NULL,
    [InsertDateTime]    DATETIME      CONSTRAINT [DF_810_Inv_Hdr_InsertDateTime] DEFAULT (getdate()) NOT NULL,
    [Processed]         BIT           CONSTRAINT [DF_810_Inv_Hdr_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME      NULL,
    [InvoiceACKSent]    BIT           CONSTRAINT [DF_810_Inv_Hdr_InvoiceACKSent] DEFAULT ((0)) NULL,
    [InvoiceAckNo]      NVARCHAR (10) NULL,
    [GSNo]              NVARCHAR (10) NULL,
    CONSTRAINT [PK_810_Inv_Hdr] PRIMARY KEY CLUSTERED ([InvoiceID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_PO_Num]
    ON [archiv].[810_Inv_Hdr]([PONumber] ASC);


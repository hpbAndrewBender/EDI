﻿CREATE TABLE [IngramContent].[PurchaseAck_Purchase] (
    [Id]                          INT           IDENTITY (1, 1) NOT NULL,
    [FileId]                      INT           NULL,
    [TerminalOrderControl]        VARCHAR (13)  NULL,
    [PONumber]                    VARCHAR (22)  NULL,
    [IGCShipToAccount]            VARCHAR (7)   NULL,
    [IGCSAN]                      VARCHAR (7)   NULL,
    [POStatus]                    SMALLINT      NULL,
    [AckDate]                     DATE          NULL,
    [PODate]                      DATE          NULL,
    [POCancellationDate]          DATE          NULL,
    [VendorMessage]               VARCHAR (250) NULL,
    [ShipTo_RecipientName]        VARCHAR (35)  NULL,
    [ShipTo_RecipientAddress]     VARCHAR (35)  NULL,
    [ShipTo_City]                 VARCHAR (25)  NULL,
    [ShipTo_StateOrProvince]      VARCHAR (3)   NULL,
    [ShipTo_PostCode]             VARCHAR (11)  NULL,
    [ShipTo_Country]              VARCHAR (3)   NULL,
    [OrderControl_RecordCount]    SMALLINT      NULL,
    [OrderControl_TotalLineItems] SMALLINT      NULL,
    [OrderControl_TotalUnitsAck]  SMALLINT      NULL,
    CONSTRAINT [PK_PurchaseAck_Purchase] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MetaData.Codes~IngramContent.PurchaseAck_Purchase-POStatus] FOREIGN KEY ([POStatus]) REFERENCES [MetaData].[Codes] ([Id]),
    CONSTRAINT [FK_PurchaseAck_File~PurchaseAck_Purchase] FOREIGN KEY ([FileId]) REFERENCES [IngramContent].[PurchaseAck_File] ([Id])
);

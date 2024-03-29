﻿CREATE TABLE [EDI].[Transactions] (
    [Id]                     BIGINT         IDENTITY (1, 1) NOT NULL,
    [ProcessLogId]           INT            NOT NULL,
    [SourceLocationId]       TINYINT        NOT NULL,
    [LineNumer]              VARCHAR (10)   NULL,
    [OrderLogId]             INT            NOT NULL,
    [AcknowledgementLogId]   INT            NOT NULL,
    [ShipLogId]              INT            NOT NULL,
    [InvoiceLogId]           INT            NOT NULL,
    [DateIssued]             DATETIME2 (7)  NULL,
    [PurposeCode]            VARCHAR (20)   NULL,
    [CountryCode]            VARCHAR (3)    NULL,
    [FillTermsCode]          VARCHAR (50)   NULL,
    [TotalPayable]           MONEY          NULL,
    [OrderStatus]            VARCHAR (30)   NULL,
    [BuyerIdType]            CHAR (3)       NULL,
    [BuyerId]                VARCHAR (12)   NULL,
    [SourceIdType]           CHAR (3)       NULL,
    [SourceId]               VARCHAR (12)   NULL,
    [SellerIdType]           CHAR (3)       NULL,
    [SellerId]               VARCHAR (12)   NULL,
    [ShipToName]             VARCHAR (30)   NULL,
    [ShipToAddress1]         VARCHAR (30)   NULL,
    [ShipToAddress2]         VARCHAR (30)   NULL,
    [ShipToCity]             VARCHAR (23)   NULL,
    [ShipToState]            VARCHAR (3)    NULL,
    [ShipToZip]              VARCHAR (10)   NULL,
    [ShipToCountryCode]      VARCHAR (2)    NULL,
    [BillToName]             VARCHAR (30)   NULL,
    [BillToAddress1]         VARCHAR (30)   NULL,
    [BillToAddress2]         VARCHAR (30)   NULL,
    [BillToCity]             VARCHAR (23)   NULL,
    [BillToState]            VARCHAR (3)    NULL,
    [BillToZip]              VARCHAR (10)   NULL,
    [BillToCountryCode]      VARCHAR (2)    NULL,
    [TransportIdType]        CHAR (4)       NULL,
    [TransportId]            CHAR (3)       NULL,
    [TextMessage]            VARCHAR (160)  NULL,
    [ProductIdType]          VARCHAR (10)   NULL,
    [ProductId]              VARCHAR (14)   NULL,
    [ItemDescription]        NVARCHAR (100) NULL,
    [UnitPrice]              VARCHAR (20)   NULL,
    [QuantityOrdered]        INT            NULL,
    [QuantityConfirmed]      INT            NULL,
    [QuantityBackOrdered]    INT            NULL,
    [QuantityCancelled]      INT            NULL,
    [QuantityShipped]        INT            NULL,
    [QuantityInvoiced]       INT            NULL,
    [OrderLineStatus]        VARCHAR (30)   NULL,
    [LineStatusDescription]  VARCHAR (50)   NULL,
    [DateShipStatus]         DATETIME2 (7)  NULL,
    [DateShipNotice]         DATETIME2 (7)  NULL,
    [CarrierNameCodeType]    VARCHAR (30)   NULL,
    [CarrierNameCode]        VARCHAR (50)   NULL,
    [CustomerOrderReference] VARCHAR (20)   NULL,
    [PackageNumber]          VARCHAR (22)   NULL,
    [PackageMarkTypeCode]    VARCHAR (50)   NULL,
    [PackageMarkValue]       MONEY          NULL,
    [ChargeTypeCode]         VARCHAR (20)   NULL,
    [ChargeTypeDescripton]   VARCHAR (50)   NULL,
    [ChargeAmount]           MONEY          NULL,
    [DateTimeInsertedUTC]    DATETIME2 (7)  CONSTRAINT [DF_Transactions_DateTimeInsertedUTC] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions.AcknowledgeLogID-ProcessLog] FOREIGN KEY ([AcknowledgementLogId]) REFERENCES [EDI].[ProcessLog] ([Id]),
    CONSTRAINT [FK_Transactions.InvoiceLogID-ProcessLog] FOREIGN KEY ([InvoiceLogId]) REFERENCES [EDI].[ProcessLog] ([Id]),
    CONSTRAINT [FK_Transactions.OrderLogID-ProcessLog] FOREIGN KEY ([OrderLogId]) REFERENCES [EDI].[ProcessLog] ([Id]),
    CONSTRAINT [FK_Transactions.ShipLogID-ProcessLog] FOREIGN KEY ([ShipLogId]) REFERENCES [EDI].[ProcessLog] ([Id]),
    CONSTRAINT [FK_Transactions_ProcessLog] FOREIGN KEY ([ProcessLogId]) REFERENCES [EDI].[ProcessLog] ([Id]),
    CONSTRAINT [FK_Transactions_SourceLocation] FOREIGN KEY ([SourceLocationId]) REFERENCES [EDI].[SourceLocation] ([Id])
);


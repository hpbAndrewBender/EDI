﻿CREATE TYPE [EDI].[TypeAcknowledgeDetail] AS TABLE (
    [LineNo]              VARCHAR (10)  NULL,
    [LineStatusCode]      VARCHAR (10)  NULL,
    [ItemStatusCode]      VARCHAR (10)  NULL,
    [UnitOfMeasure]       VARCHAR (10)  NULL,
    [QuantityOrdered]     INT           NULL,
    [QuantityShipped]     INT           NULL,
    [QuantityCancelled]   INT           NULL,
    [QuantityBackordered] INT           NULL,
    [UnitPrice]           MONEY         NULL,
    [PriceCode]           VARCHAR (10)  NULL,
    [CurrencyCode]        VARCHAR (5)   NULL,
    [ItemIdCode]          VARCHAR (5)   NULL,
    [ItemIdentifier]      VARCHAR (20)  NULL,
    [ItemDesc]            VARCHAR (250) NULL,
    [EDIFileID]           INT           NULL,
    [EDILineNumber]       INT           NULL,
    [referencenumber]     VARCHAR (20)  NULL,
    [ponumber]            VARCHAR (22)  NULL);




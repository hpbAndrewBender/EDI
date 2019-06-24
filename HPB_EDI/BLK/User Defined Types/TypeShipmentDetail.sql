CREATE TYPE [BLK].[TypeShipmentDetail] AS TABLE (
    [LineNo]          VARCHAR (10)  NULL,
    [ItemIdCode]      VARCHAR (5)   NULL,
    [ItemIdentifier]  VARCHAR (20)  NULL,
    [ItemDesc]        VARCHAR (250) NULL,
    [QuantityShipped] INT           NULL,
    [PackageNo]       VARCHAR (30)  NULL,
    [TrackingNo]      VARCHAR (30)  NULL,
    [ReferenceNumber] VARCHAR (50)  NULL,
    [ponumber]        VARCHAR (22)  NULL);


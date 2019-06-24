CREATE TABLE [BLK].[ShipmentDetail] (
    [ShipmentItemID]  BIGINT        IDENTITY (1, 1) NOT NULL,
    [ShipmentID]      INT           NOT NULL,
    [LineNo]          VARCHAR (10)  NULL,
    [ItemIdCode]      VARCHAR (5)   NULL,
    [ItemIdentifier]  VARCHAR (20)  NULL,
    [ItemDesc]        VARCHAR (250) NULL,
    [QuantityShipped] INT           NULL,
    [PackageNo]       VARCHAR (30)  NULL,
    [TrackingNo]      VARCHAR (30)  NULL,
    [ReferenceNumber] VARCHAR (20)  NULL,
    CONSTRAINT [PK_ShipmentDetail] PRIMARY KEY CLUSTERED ([ShipmentItemID] ASC),
    CONSTRAINT [FK_ShipmentDetail~AcknowledgeHeader] FOREIGN KEY ([ShipmentID]) REFERENCES [BLK].[ShipmentHeader] ([ShipmentID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ShipmentDetail_ItemIdentifier]
    ON [BLK].[ShipmentDetail]([ItemIdentifier] ASC);


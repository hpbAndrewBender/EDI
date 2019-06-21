CREATE TABLE [dbo].[temp_856_ASN_Dtl] (
    [ItemShipID]     INT            IDENTITY (1, 1) NOT NULL,
    [ShipID]         INT            NOT NULL,
    [LineNo]         NVARCHAR (10)  NOT NULL,
    [ItemIDCode]     NVARCHAR (5)   NULL,
    [ItemIdentifier] NVARCHAR (20)  NOT NULL,
    [ItemDesc]       NVARCHAR (250) NULL,
    [ShipQty]        INT            NOT NULL,
    [PackageNo]      NVARCHAR (30)  NULL,
    [TrackingNo]     NVARCHAR (30)  NULL,
    CONSTRAINT [PK_856_ASN_Dtl_temp] PRIMARY KEY CLUSTERED ([ItemShipID] ASC)
);


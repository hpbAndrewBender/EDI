CREATE TABLE [ImportBBV3].[ShipNotice_OR_ASNShipment] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [ShipmentRecordIdentifier] VARCHAR (2)  NULL,
    [PONumber]                 VARCHAR (22) NULL,
    [IngramOrderEntryNumber]   VARCHAR (5)  NULL,
    CONSTRAINT [PK_ShipNotice_OR_ASNShipment] PRIMARY KEY CLUSTERED ([Id] ASC)
);


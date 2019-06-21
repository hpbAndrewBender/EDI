CREATE TABLE [ImportBBV3].[ShipNotice_OP_ASNPack] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [PackRecordIdentifier] VARCHAR (2)    NULL,
    [ShippingDCCode]       VARCHAR (2)    NULL,
    [SSL]                  VARCHAR (20)   NULL,
    [TrackingNumber]       VARCHAR (25)   NULL,
    [SCAC]                 VARCHAR (5)    NULL,
    [CarrierActualNumber]  VARCHAR (5)    NULL,
    [Weight]               NUMERIC (9, 4) NULL,
    [NumberofUnitsinBox]   SMALLINT       NULL,
    [ShipmentDate]         DATE           NOT NULL,
    CONSTRAINT [PK_ShipNotice_OP_ASNPack] PRIMARY KEY CLUSTERED ([Id] ASC)
);


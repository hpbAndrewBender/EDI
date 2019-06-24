CREATE TABLE [MetaData].[VendorLocations] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [VendorId]            VARCHAR (20)  NULL,
    [LocationId]          VARCHAR (10)  NULL,
    [LocationNumber]      VARCHAR (5)   NULL,
    [VendorBillTo]        VARCHAR (12)  NULL,
    [VendorShipTo]        VARCHAR (12)  NULL,
    [SanAccount]          VARCHAR (12)  NULL,
    [LocationDescription] VARCHAR (250) NULL,
    [Active]              BIT           CONSTRAINT [DF_VendorLocationCodes_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_VendorLocationCodes] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [ImportBBV3].[ShipNotice_CR_ASNCompany] (
    [Id]                        INT         IDENTITY (1, 1) NOT NULL,
    [CompanyRecordIdentifier]   VARCHAR (2) NULL,
    [IngramShipToAccountNumber] VARCHAR (7) NULL,
    CONSTRAINT [PK_ShipNotice_CR_ASNCompany] PRIMARY KEY CLUSTERED ([Id] ASC)
);


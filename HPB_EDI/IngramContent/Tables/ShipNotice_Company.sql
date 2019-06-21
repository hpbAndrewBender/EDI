CREATE TABLE [IngramContent].[ShipNotice_Company] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [CDF]               BIT          NULL,
    [CompanyAccountID]  VARCHAR (10) NULL,
    [TotalOrderCount]   SMALLINT     NULL,
    [FileVersionNumber] VARCHAR (10) NULL,
    [FileName]          VARCHAR (23) NULL,
    CONSTRAINT [PK_ShipNotice_Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);


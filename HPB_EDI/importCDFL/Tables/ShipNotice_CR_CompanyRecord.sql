CREATE TABLE [importCDFL].[ShipNotice_CR_CompanyRecord] (
    [Id]                      INT          IDENTITY (1, 1) NOT NULL,
    [BatchID]                 INT          NOT NULL,
    [CompanyRecordIdentifier] VARCHAR (2)  NOT NULL,
    [CompanyAccountIDNumber]  VARCHAR (10) NOT NULL,
    [TotalOrderCount]         SMALLINT     NOT NULL,
    [FileVersionNumber]       VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_ShipNotice_CR_CompanyRecord] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ShipNotice_CR_CompanyRecord.CompanyRecIDAcctID]
    ON [importCDFL].[ShipNotice_CR_CompanyRecord]([CompanyRecordIdentifier] ASC, [CompanyAccountIDNumber] ASC);


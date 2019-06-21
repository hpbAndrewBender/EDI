CREATE TABLE [importX12].[TagBSN] (
    [BSNId]                     BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                 INT          NOT NULL,
    [LineNumber]                INT          NOT NULL,
    [ControlNumberGroup]        VARCHAR (25) NULL,
    [ControlNumberTransaction]  VARCHAR (25) NULL,
    [TransactionSetPurposeCode] VARCHAR (2)  NULL,
    [ShipmentIdentification]    VARCHAR (30) NULL,
    [Date]                      VARCHAR (8)  NULL,
    [Time]                      VARCHAR (8)  NULL,
    [HierarchicalStructureCode] VARCHAR (4)  NULL,
    CONSTRAINT [PK_importEDI_BSN] PRIMARY KEY CLUSTERED ([BSNId] ASC),
    CONSTRAINT [FK_importEDI_BSN~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


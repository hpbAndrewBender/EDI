CREATE TABLE [importX12].[TagTXI] (
    [TXIId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [TaxTypeCode]              VARCHAR (2)  NULL,
    [MonetaryAmount]           VARCHAR (15) NULL,
    [Percent]                  VARCHAR (10) NULL,
    CONSTRAINT [PK_importEDI_TXI] PRIMARY KEY CLUSTERED ([TXIId] ASC),
    CONSTRAINT [FK_importEDI_TXI~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


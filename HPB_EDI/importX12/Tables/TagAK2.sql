CREATE TABLE [importX12].[TagAK2] (
    [AK2Id]                        BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileID]                    INT          NOT NULL,
    [LineNumber]                   INT          NOT NULL,
    [ControlNumberGroup]           VARCHAR (25) NULL,
    [ControlNumberTransaction]     VARCHAR (25) NULL,
    [TransactionSetIdentifierCode] VARCHAR (3)  NULL,
    [TransactionSetControlNumber]  VARCHAR (9)  NULL,
    CONSTRAINT [PK_importEDI_AK2] PRIMARY KEY CLUSTERED ([AK2Id] ASC),
    CONSTRAINT [FK_importEDI_AK2~importEDIFiles] FOREIGN KEY ([EDIFileID]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


CREATE TABLE [importX12].[TagST] (
    [STId]                         BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                    INT          NOT NULL,
    [LineNumber]                   INT          NOT NULL,
    [ControlNumberGroup]           VARCHAR (25) NULL,
    [ControlNumberTransaction]     VARCHAR (25) NULL,
    [TransactionSetIdentifierCode] VARCHAR (3)  NULL,
    [TransactionSetControlNumber]  VARCHAR (9)  NULL,
    CONSTRAINT [PK_importEDI_ST] PRIMARY KEY CLUSTERED ([STId] ASC),
    CONSTRAINT [FK_importEDI_ST~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


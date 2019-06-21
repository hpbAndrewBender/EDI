CREATE TABLE [importX12].[TagN1] (
    [N1Id]                        BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                   INT          NOT NULL,
    [LineNumber]                  INT          NOT NULL,
    [ControlNumberGroup]          VARCHAR (25) NULL,
    [ControlNumberTransaction]    VARCHAR (25) NULL,
    [EntityIdentifierCode]        VARCHAR (2)  NULL,
    [Name]                        VARCHAR (35) NULL,
    [IdentificationCodeQualifier] VARCHAR (2)  NULL,
    [IdentificationCode]          VARCHAR (20) NULL,
    CONSTRAINT [PK_importEDI_N1] PRIMARY KEY CLUSTERED ([N1Id] ASC),
    CONSTRAINT [FK_importEDI_N1~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


GO
CREATE NONCLUSTERED INDEX [IX_importEDI_FileID-ControlNumberGorup-ControlNumberTransaction,LIneNumber]
    ON [importX12].[TagN1]([EDIFileId] ASC, [ControlNumberGroup] ASC, [ControlNumberTransaction] ASC, [LineNumber] ASC);


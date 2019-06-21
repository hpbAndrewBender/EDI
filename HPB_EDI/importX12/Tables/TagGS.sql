CREATE TABLE [importX12].[TagGS] (
    [GSId]                     BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [FunctionalIdentifierCode] VARCHAR (99) NULL,
    [ApplicationSenderCode]    VARCHAR (99) NULL,
    [ApplicationReceiverCode]  VARCHAR (99) NULL,
    [Date]                     VARCHAR (8)  NULL,
    [Time]                     VARCHAR (99) NULL,
    [GroupControlNumber]       VARCHAR (99) NULL,
    [ResponsibleAgencyCode]    VARCHAR (99) NULL,
    [VersionRelIndIDCode]      VARCHAR (99) NULL,
    [ControlNumberGroup]       VARCHAR (99) NULL,
    [ControlNumberTransaction] VARCHAR (99) NULL,
    CONSTRAINT [PK_importEDI_GS] PRIMARY KEY CLUSTERED ([GSId] ASC),
    CONSTRAINT [FK_importEDI_GS~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


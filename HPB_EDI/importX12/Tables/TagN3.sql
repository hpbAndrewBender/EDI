CREATE TABLE [importX12].[TagN3] (
    [N3Id]                     BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [AddressInformation_01]    VARCHAR (35) NULL,
    [AddressInformation_02]    VARCHAR (35) NULL,
    CONSTRAINT [PK_importEDI_N3] PRIMARY KEY CLUSTERED ([N3Id] ASC),
    CONSTRAINT [FK_importEDI_N3~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


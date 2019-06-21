CREATE TABLE [importX12].[TagN4] (
    [N4Id]                     BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [CityName]                 VARCHAR (30) NULL,
    [StateOrProvinceCode]      VARCHAR (2)  NULL,
    [PostalCode]               VARCHAR (15) NULL,
    [CountryCode]              VARCHAR (3)  NULL,
    CONSTRAINT [PK_importEDI_N4] PRIMARY KEY CLUSTERED ([N4Id] ASC),
    CONSTRAINT [FK_importEDI_N4~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


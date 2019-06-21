CREATE TABLE [importX12].[TagCTP] (
    [CTPId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [PriceIdentifierCode]      VARCHAR (3)  NULL,
    [UnitPrice]                VARCHAR (17) NULL,
    [Quantity]                 VARCHAR (15) NULL,
    [CompositeUnitOfMeasure]   VARCHAR (2)  NULL,
    [PriceMultiplierQualifier] VARCHAR (10) NULL,
    [Multiplier]               VARCHAR (10) NULL,
    CONSTRAINT [PK_importEDI_CTP] PRIMARY KEY CLUSTERED ([CTPId] ASC),
    CONSTRAINT [FK_importEDI_CTP~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


GO
CREATE NONCLUSTERED INDEX [IX_ImportedEDI_CTP]
    ON [importX12].[TagCTP]([EDIFileId] ASC, [ControlNumberGroup] ASC, [ControlNumberTransaction] ASC, [LineNumber] ASC)
    INCLUDE([CTPId], [PriceIdentifierCode], [UnitPrice], [Quantity], [CompositeUnitOfMeasure], [PriceMultiplierQualifier], [Multiplier]);


GO
CREATE NONCLUSTERED INDEX [importEDI_CTP-ControlNumberGroup-ControlNumberTransaction-LineNumber]
    ON [importX12].[TagCTP]([ControlNumberGroup] ASC, [ControlNumberTransaction] ASC, [LineNumber] ASC)
    INCLUDE([UnitPrice], [PriceMultiplierQualifier], [Multiplier]);


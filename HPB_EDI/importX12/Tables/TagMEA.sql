CREATE TABLE [importX12].[TagMEA] (
    [MEAId]                      BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                  INT          NOT NULL,
    [LineNumber]                 INT          NOT NULL,
    [ControlNumberGroup]         VARCHAR (25) NULL,
    [ControlNumberTransaction]   VARCHAR (25) NULL,
    [MeasurementReferenceIDCode] VARCHAR (2)  NULL,
    [MeasurementQualifier]       VARCHAR (3)  NULL,
    [MeasurementValue]           VARCHAR (20) NULL,
    [CompositeUnitOfMeasure]     VARCHAR (99) NULL,
    CONSTRAINT [PK_importEDI_MEA] PRIMARY KEY CLUSTERED ([MEAId] ASC),
    CONSTRAINT [FK_importEDI_MEA~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


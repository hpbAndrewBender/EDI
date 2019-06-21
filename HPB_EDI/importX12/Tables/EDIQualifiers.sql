CREATE TABLE [importX12].[EDIQualifiers] (
    [QualifierID]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [QualifierTypeID]      SMALLINT       NOT NULL,
    [QualifierCode]        VARCHAR (5)    NULL,
    [QualifierDescription] VARCHAR (1024) NULL,
    CONSTRAINT [PK_importEDIQualifiers] PRIMARY KEY CLUSTERED ([QualifierID] ASC),
    CONSTRAINT [FK_importEDIQualiifers~importEDIQualifierTypes] FOREIGN KEY ([QualifierTypeID]) REFERENCES [importX12].[EDIQualifierTypes] ([QualifierTypeID]),
    CONSTRAINT [UQ_ImportEDIQualifiers] UNIQUE NONCLUSTERED ([QualifierTypeID] ASC, [QualifierCode] ASC)
);


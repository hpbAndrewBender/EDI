CREATE TABLE [importX12].[EDIQualifierTypes] (
    [QualifierTypeID]      SMALLINT      IDENTITY (1, 1) NOT NULL,
    [EDITransactionCodeId] SMALLINT      NOT NULL,
    [QualifierType]        VARCHAR (500) NULL,
    CONSTRAINT [PK_importEDIQualifierTypes] PRIMARY KEY CLUSTERED ([QualifierTypeID] ASC),
    CONSTRAINT [FK_importEDIQualifierTypes~ImportEDITransactionCodes] FOREIGN KEY ([EDITransactionCodeId]) REFERENCES [importX12].[EDITransactionCodes] ([EDITransactionCodeId])
);


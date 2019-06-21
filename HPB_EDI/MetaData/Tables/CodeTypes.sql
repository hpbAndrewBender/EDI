CREATE TABLE [MetaData].[CodeTypes] (
    [Id]               SMALLINT      IDENTITY (1, 1) NOT NULL,
    [VendorID]         VARCHAR (10)  NULL,
    [FileFormatID]     TINYINT       NULL,
    [CodeType]         VARCHAR (500) NULL,
    [AssociatedColumn] VARCHAR (100) NULL,
    [MaxChars]         TINYINT       NULL
);


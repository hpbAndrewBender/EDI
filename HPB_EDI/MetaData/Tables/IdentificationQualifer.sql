CREATE TABLE [MetaData].[IdentificationQualifer] (
    [IqId]       INT            IDENTITY (1, 1) NOT NULL,
    [EDIId]      CHAR (4)       NOT NULL,
    [EDIVersion] CHAR (4)       NULL,
    [IDName]     VARCHAR (5)    NULL,
    [IDDescript] VARCHAR (4000) NULL,
    CONSTRAINT [PK_MetaData.IdentificationQualifer] PRIMARY KEY CLUSTERED ([IqId] ASC),
    CONSTRAINT [UQ_MetaData.IdentificationQualifier_EDIId] UNIQUE NONCLUSTERED ([EDIId] ASC, [EDIVersion] ASC, [IDName] ASC)
);


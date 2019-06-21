CREATE TABLE [importX12].[EDITransactionCodes] (
    [EDITransactionCodeId]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [EDITypeId]                     SMALLINT       NOT NULL,
    [EDITransactionCode]            VARCHAR (3)    NOT NULL,
    [EDITransactionCodeDescription] VARCHAR (1024) NOT NULL,
    [EDITransactionActive]          BIT            CONSTRAINT [DF_EDITransactionActive] DEFAULT ((1)) NOT NULL,
    [EDIPosition]                   SMALLINT       NULL,
    [EDIMax]                        SMALLINT       NULL,
    [EDILocation]                   VARCHAR (10)   NULL,
    [EDIMandatory]                  VARCHAR (50)   NULL,
    [EDILooping]                    VARCHAR (50)   NULL,
    [EDIElements]                   TINYINT        NULL,
    CONSTRAINT [PK_importEDITransactionCodes] PRIMARY KEY CLUSTERED ([EDITransactionCodeId] ASC),
    CONSTRAINT [FK_importEDITransactionCodes~importEDITypes] FOREIGN KEY ([EDITypeId]) REFERENCES [importX12].[EDITypes] ([EDITypeId])
);


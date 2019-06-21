CREATE TABLE [importCDFL].[BatchItem] (
    [Id]        TINYINT      IDENTITY (1, 1) NOT NULL,
    [BatchItem] VARCHAR (50) NULL,
    [Active]    BIT          CONSTRAINT [DF_BatchItem.Active] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_BatchItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_BatchItem.BatchItem] UNIQUE NONCLUSTERED ([BatchItem] ASC)
);


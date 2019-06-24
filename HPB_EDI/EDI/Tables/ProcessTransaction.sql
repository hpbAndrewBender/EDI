CREATE TABLE [EDI].[ProcessTransaction] (
    [Id]                     TINYINT      IDENTITY (1, 1) NOT NULL,
    [TransactionName]        VARCHAR (10) NOT NULL,
    [TransactionDescription] VARCHAR (50) NULL,
    [Active]                 BIT          CONSTRAINT [DF_Processtype_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ProcessTransaction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_ProcessTransaction_TransactionName] UNIQUE NONCLUSTERED ([TransactionName] ASC)
);


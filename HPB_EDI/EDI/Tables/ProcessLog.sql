CREATE TABLE [EDI].[ProcessLog] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [VendorId]          VARCHAR (20)  NULL,
    [SourceTypeId]      TINYINT       NOT NULL,
    [TransactionId]     TINYINT       NOT NULL,
    [OrderNumber]       VARCHAR (20)  NOT NULL,
    [Processed]         BIT           CONSTRAINT [DF_ProcessLog_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME2 (7) NULL,
    CONSTRAINT [PK_ProcessLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProcessLog_ProcessTransaction] FOREIGN KEY ([TransactionId]) REFERENCES [EDI].[ProcessTransaction] ([Id]),
    CONSTRAINT [FK_ProcessLog_SourceType] FOREIGN KEY ([SourceTypeId]) REFERENCES [EDI].[SourceType] ([SourceTypeID])
);


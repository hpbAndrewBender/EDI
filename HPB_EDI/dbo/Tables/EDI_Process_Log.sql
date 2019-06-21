CREATE TABLE [dbo].[EDI_Process_Log] (
    [LogID]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [TransType]         NCHAR (3)     NOT NULL,
    [OrderNumber]       NVARCHAR (20) NOT NULL,
    [Processed]         BIT           CONSTRAINT [DF_EDI_Process_Log_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME      NULL,
    CONSTRAINT [PK_EDI_Process_Log] PRIMARY KEY CLUSTERED ([LogID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_Order_Type]
    ON [dbo].[EDI_Process_Log]([TransType] ASC, [OrderNumber] ASC);


CREATE TABLE [dbo].[Email_Audit_Log] (
    [EmailType]         VARCHAR (20) NOT NULL,
    [LogID]             BIGINT       NOT NULL,
    [Processed]         BIT          CONSTRAINT [DF_Email_Audit_Log_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME     NULL,
    CONSTRAINT [FK_Email_Audit_Log_EDI_Process_Log] FOREIGN KEY ([LogID]) REFERENCES [dbo].[EDI_Process_Log] ([LogID])
);


CREATE TABLE [dbo].[WEB_Invoice_Audit_log] (
    [InvoiceNo]         VARCHAR (10) NOT NULL,
    [OrderNo]           VARCHAR (20) NOT NULL,
    [Processed]         INT          CONSTRAINT [DF_WEB_Invoice_Audit_log_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME     NULL,
    CONSTRAINT [PK_WEB_Invoice_Audit_log] PRIMARY KEY CLUSTERED ([InvoiceNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_Processed]
    ON [dbo].[WEB_Invoice_Audit_log]([Processed] ASC);


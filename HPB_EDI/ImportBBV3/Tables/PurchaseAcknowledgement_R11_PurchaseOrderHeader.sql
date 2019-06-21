CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R11_PurchaseOrderHeader] (
    [Id]                         INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                    INT          NULL,
    [RecordCode]                 VARCHAR (2)  NULL,
    [SequenceNumber]             SMALLINT     NULL,
    [TerminalOrderControlNumber] VARCHAR (13) NULL,
    [PONumber]                   VARCHAR (22) NULL,
    [IngramShipToAccountNumber]  VARCHAR (7)  NULL,
    [IngramSAN]                  VARCHAR (7)  NULL,
    [POStatus]                   CHAR (1)     NULL,
    [AcknowledgmentDate]         DATE         NULL,
    [PODate]                     DATE         NULL,
    [POCancellationDate]         DATE         NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R11_PurchaseOrderHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);




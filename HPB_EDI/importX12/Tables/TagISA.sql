CREATE TABLE [importX12].[TagISA] (
    [ISAId]                             BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                         INT          NOT NULL,
    [LineNumber]                        INT          NOT NULL,
    [AuthorizationInformationQualifier] VARCHAR (99) NULL,
    [AuthorizationInformation]          VARCHAR (99) NULL,
    [SecurityInformationQualifier]      VARCHAR (99) NULL,
    [SecurityInformation]               VARCHAR (99) NULL,
    [SenderQualifierID]                 VARCHAR (99) NULL,
    [InterchangeSenderID]               VARCHAR (99) NULL,
    [ReceiverQualifierID]               VARCHAR (99) NULL,
    [InterchangeReceiverID]             VARCHAR (99) NULL,
    [InterchangeDate]                   VARCHAR (99) NULL,
    [InterchangeTime]                   VARCHAR (99) NULL,
    [InterchangeControlStandardsID]     VARCHAR (99) NULL,
    [InterchangeControlVersionNumber]   VARCHAR (99) NULL,
    [InterchangeControlNumber]          VARCHAR (99) NULL,
    [AcknowledgmentRequested]           VARCHAR (99) NULL,
    [UsageIndicator]                    VARCHAR (99) NULL,
    [SubelementSeparator]               VARCHAR (99) NULL,
    CONSTRAINT [PK_importEDI_ISA] PRIMARY KEY CLUSTERED ([ISAId] ASC),
    CONSTRAINT [FK_importEDI_ISA~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


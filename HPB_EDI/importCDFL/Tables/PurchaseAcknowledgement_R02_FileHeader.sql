CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R02_FileHeader] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [BatchID]               INT          NOT NULL,
    [RecordCode]            TINYINT      NOT NULL,
    [SequenceNumber]        SMALLINT     NOT NULL,
    [FileSourceSAN]         VARCHAR (7)  NOT NULL,
    [FileSourceName]        VARCHAR (13) NOT NULL,
    [POACreationDate]       DATE         NOT NULL,
    [ElectronicControlUnit] VARCHAR (5)  NOT NULL,
    [Filename]              VARCHAR (17) NOT NULL,
    [FormatVersion]         VARCHAR (3)  NOT NULL,
    [DestinationSAN]        VARCHAR (7)  NOT NULL,
    [POAType]               CHAR (1)     NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R02_FileHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R02_FileHeader.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R02_FileHeader]([RecordCode] ASC, [SequenceNumber] ASC);


CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R02_FileHeader] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]               INT          NULL,
    [RecordCode]            VARCHAR (2)  NULL,
    [SequenceNumber]        SMALLINT     NULL,
    [FileSourceSAN]         VARCHAR (7)  NULL,
    [FileSourceName]        VARCHAR (13) NULL,
    [POACreationDate]       DATE         NULL,
    [ElectronicControlUnit] VARCHAR (5)  NULL,
    [Filename]              VARCHAR (17) NULL,
    [FormatVersion]         VARCHAR (3)  NULL,
    [DestinationSAN]        VARCHAR (7)  NULL,
    [POATypeCode]           CHAR (1)     NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R02_FileHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);




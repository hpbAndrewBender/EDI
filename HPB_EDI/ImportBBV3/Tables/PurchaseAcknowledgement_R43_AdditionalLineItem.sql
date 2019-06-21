CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R43_AdditionalLineItem] (
    [Id]                                    INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                               INT          NULL,
    [RecordCode]                            VARCHAR (2)  NULL,
    [SequenceNumber]                        SMALLINT     NULL,
    [PONumber]                              VARCHAR (22) NULL,
    [PublisherAlphaCode]                    VARCHAR (20) NULL,
    [PublicationOrReleaseDate]              VARCHAR (10) NULL,
    [OriginalSequenceNumber]                SMALLINT     NULL,
    [TotalQuantityPredictedtoShipPrimary]   VARCHAR (7)  NULL,
    [TotalQuantityPredictedtoShipSecondary] VARCHAR (7)  NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R43_AdditionalLineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);




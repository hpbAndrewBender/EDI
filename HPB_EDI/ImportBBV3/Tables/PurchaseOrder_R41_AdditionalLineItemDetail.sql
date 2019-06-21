CREATE TABLE [ImportBBV3].[PurchaseOrder_R41_AdditionalLineItemDetail] (
    [Id]                                  INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]                          VARCHAR (2)  NOT NULL,
    [SequenceNumber]                      SMALLINT     NOT NULL,
    [PONumber]                            VARCHAR (22) NOT NULL,
    [BackorderCancellationDate_LineLevel] DATE         NULL,
    [OrderQuantity]                       SMALLINT     NOT NULL,
    [ClientItemNumber]                    VARCHAR (20) NULL,
    CONSTRAINT [PK_PurchaseOrder_R41_AdditionalLineItemDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);


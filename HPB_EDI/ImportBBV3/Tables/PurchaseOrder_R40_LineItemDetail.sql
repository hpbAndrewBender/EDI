CREATE TABLE [ImportBBV3].[PurchaseOrder_R40_LineItemDetail] (
    [Id]                                         INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]                                 VARCHAR (2)  NOT NULL,
    [SequenceNumber]                             SMALLINT     NOT NULL,
    [PONumber]                                   VARCHAR (22) NOT NULL,
    [LineItemPONumber]                           VARCHAR (22) NULL,
    [ItemNumber]                                 VARCHAR (20) NOT NULL,
    [BackorderCodeLinelevel]                     CHAR (1)     NOT NULL,
    [SpecialActionCode]                          VARCHAR (2)  NULL,
    [DDCFulfillmentorSplitLineOrderingLinelevel] CHAR (1)     NOT NULL,
    [ItemNumberType]                             VARCHAR (2)  NULL,
    CONSTRAINT [PK_PurchaseOrder_R40_LineItemDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);


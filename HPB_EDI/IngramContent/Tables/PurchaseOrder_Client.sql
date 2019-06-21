CREATE TABLE [IngramContent].[PurchaseOrder_Client] (
    [Id]                             INT          IDENTITY (1, 1) NOT NULL,
    [FileId]                         INT          NULL,
    [Head_SequenceNumber]            SMALLINT     NULL,
    [Head_PONumber]                  VARCHAR (22) NULL,
    [Head_IngramBillToAccount]       VARCHAR (7)  NULL,
    [Head_VendorSAN]                 VARCHAR (7)  NULL,
    [Head_OrderDate]                 DATE         NULL,
    [Head_BackorderCancelDate]       DATE         NULL,
    [Head_BackOrderCode]             CHAR (1)     NULL,
    [Head_DCCFullfillment]           BIT          NULL,
    [Head_ShipToIndicator]           BIT          NULL,
    [Foot_TotalPurchaseOrderRecords] SMALLINT     NULL,
    [Foot_TotalUnitsOrdered]         SMALLINT     NULL,
    CONSTRAINT [PK_PurchaseOrder_Client] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PurchaesOrder_File~PurchaseOrder_Client] FOREIGN KEY ([FileId]) REFERENCES [IngramContent].[PurchaseOrder_File] ([Id])
);


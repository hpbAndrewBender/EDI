CREATE TABLE [IngramContent].[Invoice_Detail] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [HeaderID]                   INT            NOT NULL,
    [Detail_ISBN10Shipped]       VARCHAR (10)   NULL,
    [Detail_QuantityShipped]     SMALLINT       NULL,
    [Detail_IngramItemListPrice] NUMERIC (7, 2) NULL,
    [Detail_Discount]            NUMERIC (4, 2) NULL,
    [Detail_NetPriceOrCost]      NUMERIC (8, 2) NULL,
    [Detail_MeteredDate]         DATE           NULL,
    [EAN_ISBN13EANShipped]       VARCHAR (14)   NULL,
    [Total_Title]                VARCHAR (16)   NULL,
    [Total_ClientOrderID]        VARCHAR (22)   NULL,
    [Total_LineItemID]           VARCHAR (10)   NULL,
    [Fees_TrackingNumber]        VARCHAR (25)   NULL,
    [Fees_NetPrice]              NUMERIC (8, 2) NULL,
    [Fees_Shipping]              NUMERIC (6, 2) NULL,
    [Fees_Handling]              NUMERIC (7, 2) NULL,
    [Fees_GiftWrap]              NUMERIC (6, 2) NULL,
    [Fees_AmountDue]             NUMERIC (7, 2) NULL,
    CONSTRAINT [PK_Invoice_Detail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Invoice_Header~Invoice_Detail] FOREIGN KEY ([HeaderID]) REFERENCES [IngramContent].[Invoice_Header] ([Id])
);


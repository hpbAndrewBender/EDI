CREATE TABLE [archiv].[855_Ack_Dtl] (
    [ItemAckID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [AckID]          INT            NOT NULL,
    [LineNo]         NVARCHAR (10)  NOT NULL,
    [LineStatusCode] NVARCHAR (10)  NULL,
    [ItemStatusCode] NVARCHAR (10)  NULL,
    [UOM]            NCHAR (3)      NULL,
    [OrdQty]         INT            NOT NULL,
    [ShipQty]        INT            NOT NULL,
    [CanceledQty]    INT            NOT NULL,
    [BackOrdQty]     INT            NOT NULL,
    [UnitPrice]      NVARCHAR (10)  NULL,
    [PriceCode]      NVARCHAR (10)  NULL,
    [CurrencyCode]   NVARCHAR (5)   NULL,
    [ItemIDCode]     NVARCHAR (5)   NULL,
    [ItemIdentifier] NVARCHAR (20)  NOT NULL,
    [ItemDesc]       NVARCHAR (250) NULL,
    [EDIFileID]      INT            NULL,
    [EDILineNumber]  INT            NULL,
    CONSTRAINT [PK_855_Ack_Dtl] PRIMARY KEY CLUSTERED ([ItemAckID] ASC)
);


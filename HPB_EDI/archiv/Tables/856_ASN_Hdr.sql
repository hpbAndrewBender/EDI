CREATE TABLE [archiv].[856_ASN_Hdr] (
    [ShipID]            INT           IDENTITY (1, 1) NOT NULL,
    [PONumber]          CHAR (6)      NOT NULL,
    [ASNNo]             NVARCHAR (20) NULL,
    [IssueDate]         DATETIME      NOT NULL,
    [VendorID]          NVARCHAR (20) NOT NULL,
    [ReferenceNo]       NVARCHAR (20) NULL,
    [ShipToLoc]         NCHAR (5)     NOT NULL,
    [ShipToSAN]         NVARCHAR (12) NOT NULL,
    [BillToLoc]         NCHAR (5)     NOT NULL,
    [BillToSAN]         NVARCHAR (12) NOT NULL,
    [ShipFromLoc]       NCHAR (5)     NOT NULL,
    [ShipFromSAN]       NVARCHAR (12) NOT NULL,
    [Carrier]           NVARCHAR (20) NULL,
    [TotalLines]        INT           NOT NULL,
    [TotalQty]          INT           NOT NULL,
    [CurrencyCode]      NVARCHAR (5)  NULL,
    [InsertDateTime]    DATETIME      CONSTRAINT [DF_856_ASN_Hdr_InsertDateTime] DEFAULT (getdate()) NOT NULL,
    [Processed]         BIT           CONSTRAINT [DF_856_ASN_Hdr_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME      NULL,
    [ASNACKSent]        BIT           CONSTRAINT [DF_856_ASN_Hdr_ASNACKSent] DEFAULT ((0)) NULL,
    [ASNAckNo]          NVARCHAR (10) NULL,
    [GSNo]              NVARCHAR (10) NULL,
    CONSTRAINT [PK_856_ASN_Hdr] PRIMARY KEY CLUSTERED ([ShipID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_PO_Num]
    ON [archiv].[856_ASN_Hdr]([PONumber] ASC);


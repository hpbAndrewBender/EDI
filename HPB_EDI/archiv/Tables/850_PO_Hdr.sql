CREATE TABLE [archiv].[850_PO_Hdr] (
    [OrdID]             INT           IDENTITY (1, 1) NOT NULL,
    [PONumber]          CHAR (6)      NOT NULL,
    [IssueDate]         DATETIME      NOT NULL,
    [VendorID]          NVARCHAR (20) NOT NULL,
    [ShipToLoc]         NCHAR (5)     NOT NULL,
    [ShipToSAN]         NVARCHAR (12) NOT NULL,
    [BillToLoc]         NCHAR (5)     NOT NULL,
    [BillToSAN]         NVARCHAR (12) NOT NULL,
    [ShipFromLoc]       NCHAR (5)     NOT NULL,
    [ShipFromSAN]       NVARCHAR (12) NOT NULL,
    [TotalLines]        INT           NOT NULL,
    [TotalQty]          INT           NOT NULL,
    [InsertDateTime]    DATETIME      CONSTRAINT [DF_850_PO_Hdr_InsertDateTime] DEFAULT (getdate()) NOT NULL,
    [Processed]         BIT           CONSTRAINT [DF_850_PO_Hdr_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME      NULL,
    CONSTRAINT [PK_850_PO_Hdr] PRIMARY KEY CLUSTERED ([OrdID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_PO_Num]
    ON [archiv].[850_PO_Hdr]([PONumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IDX_VendID]
    ON [archiv].[850_PO_Hdr]([VendorID] ASC);


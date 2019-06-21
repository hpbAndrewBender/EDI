CREATE TABLE [dbo].[temp_850_PO_Hdr] (
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
    [InsertDateTime]    DATETIME      NOT NULL,
    [Processed]         BIT           NOT NULL,
    [ProcessedDateTime] DATETIME      NULL
);


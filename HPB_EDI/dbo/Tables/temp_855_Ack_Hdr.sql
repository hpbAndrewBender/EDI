CREATE TABLE [dbo].[temp_855_Ack_Hdr] (
    [AckID]             INT           IDENTITY (1, 1) NOT NULL,
    [PONumber]          CHAR (6)      NOT NULL,
    [IssueDate]         DATETIME      NOT NULL,
    [VendorID]          NVARCHAR (20) NOT NULL,
    [ReferenceNo]       NVARCHAR (20) NULL,
    [ShipToLoc]         NCHAR (5)     NOT NULL,
    [ShipToSAN]         NVARCHAR (12) NOT NULL,
    [BillToLoc]         NCHAR (5)     NOT NULL,
    [BillToSAN]         NVARCHAR (12) NOT NULL,
    [ShipFromLoc]       NCHAR (5)     NOT NULL,
    [ShipFromSAN]       NVARCHAR (12) NOT NULL,
    [TotalLines]        INT           NOT NULL,
    [TotalQty]          INT           NOT NULL,
    [CurrencyCode]      NVARCHAR (5)  NULL,
    [InsertDateTime]    DATETIME      CONSTRAINT [DF_855_Ack_Hdr_InsertDateTime_temp] DEFAULT (getdate()) NOT NULL,
    [Processed]         BIT           CONSTRAINT [DF_855_Ack_Hdr_Processed_temp] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME      NULL,
    [ResponseACKSent]   BIT           CONSTRAINT [DF_855_Ack_Hdr_ResponseACKSent_temp] DEFAULT ((0)) NULL,
    [ResponseAckNo]     NVARCHAR (10) NULL,
    [GSNo]              NVARCHAR (10) NULL,
    CONSTRAINT [PK_855_Ack_Hdr_temp] PRIMARY KEY CLUSTERED ([AckID] ASC)
);


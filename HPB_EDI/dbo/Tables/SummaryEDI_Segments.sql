CREATE TABLE [dbo].[SummaryEDI_Segments] (
    [SegmentID]                   INT          IDENTITY (1, 1) NOT NULL,
    [EDIFileID]                   INT          NULL,
    [TransactionSetControlNumber] VARCHAR (25) NULL,
    [SegStart]                    INT          NULL,
    [SegEnd]                      INT          NULL,
    [NumberOfSegments]            INT          NULL,
    CONSTRAINT [PK_SummaryEDI_Segments] PRIMARY KEY CLUSTERED ([SegmentID] ASC)
);


CREATE TABLE [IngramContent].[Invoice_File] (
    [Id]                  INT          IDENTITY (1, 1) NOT NULL,
    [FileName]            VARCHAR (23) NULL,
    [CDF]                 BIT          NULL,
    [Head_SequenceNumber] SMALLINT     NULL,
    [Head_IngramSAN]      VARCHAR (7)  NULL,
    [Head_FileSource]     VARCHAR (13) NULL,
    [Head_CreationDate]   DATE         NULL,
    [Head_Filename]       VARCHAR (22) NULL,
    [Foot_TotalTitles]    SMALLINT     NULL,
    [Foot_TotalInvoices]  SMALLINT     NULL,
    [Foot_TotalUnits]     SMALLINT     NULL,
    CONSTRAINT [PK_Invoice_File] PRIMARY KEY CLUSTERED ([Id] ASC)
);


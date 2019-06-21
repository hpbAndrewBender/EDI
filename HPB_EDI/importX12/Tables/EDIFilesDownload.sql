CREATE TABLE [importX12].[EDIFilesDownload] (
    [EDIDownloadFileID] INT          IDENTITY (1, 1) NOT NULL,
    [ServiceRef]        VARCHAR (50) NULL,
    [Stat]              VARCHAR (50) NULL,
    [APRF]              VARCHAR (10) NULL,
    [APRFType]          VARCHAR (10) NULL,
    [SNRF]              VARCHAR (50) NULL,
    [SenderID]          VARCHAR (50) NULL,
    [InsertDateTime]    DATETIME     CONSTRAINT [DF_importEDIFilesDownload_InsertDateTime] DEFAULT (getdate()) NOT NULL,
    [ProcessedDateTime] DATETIME     NULL,
    CONSTRAINT [PK_importEdiFilesDownload] PRIMARY KEY CLUSTERED ([EDIDownloadFileID] ASC)
);


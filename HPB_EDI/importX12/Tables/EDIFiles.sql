CREATE TABLE [importX12].[EDIFiles] (
    [EDIFileId]    INT            IDENTITY (1, 1) NOT NULL,
    [EDITypeId]    SMALLINT       NULL,
    [FullFileName] VARCHAR (1024) NOT NULL,
    [ImportDate]   DATETIME       CONSTRAINT [DF_ImportDate] DEFAULT (getutcdate()) NULL,
    [Processed]    BIT            CONSTRAINT [DF_Processed] DEFAULT ((0)) NULL,
    [ServiceRef]   VARCHAR (50)   NULL,
    CONSTRAINT [PK_importEDIFile] PRIMARY KEY CLUSTERED ([EDIFileId] ASC),
    CONSTRAINT [FK_importEDIFile~importEDIFileTypes] FOREIGN KEY ([EDITypeId]) REFERENCES [importX12].[EDITypes] ([EDITypeId])
);


CREATE TABLE [MetaData].[FileFormats] (
    [Id]         TINYINT      IDENTITY (1, 1) NOT NULL,
    [FileFormat] VARCHAR (50) NOT NULL,
    [Vers]       VARCHAR (10) NULL,
    [Active]     BIT          CONSTRAINT [DF_FileFormat_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_FIleFormat] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_FileFormat_FileFormat] UNIQUE NONCLUSTERED ([FileFormat] ASC, [Vers] ASC)
);


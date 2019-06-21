CREATE TABLE [MetaData].[FileFormat] (
    [Id]         TINYINT      IDENTITY (1, 1) NOT NULL,
    [FileFormat] VARCHAR (50) NOT NULL,
    [Active]     BIT          CONSTRAINT [DF_FileFormat_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_FIleFormat] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_FileFormat_FileFormat] UNIQUE NONCLUSTERED ([FileFormat] ASC)
);


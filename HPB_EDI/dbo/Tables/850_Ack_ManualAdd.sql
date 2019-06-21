CREATE TABLE [dbo].[850_Ack_ManualAdd] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [AckID]         INT           NOT NULL,
    [CreateDateUTC] DATETIME      CONSTRAINT [DF_850_Ack_ManualAdd_CreateDateUTC] DEFAULT (getutcdate()) NOT NULL,
    [PONumber]      VARCHAR (6)   NULL,
    [Descript]      VARCHAR (512) NULL,
    CONSTRAINT [PK_850_Ack_ManualAdd] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_850_Ack_Hdr_850_Ack_ManualAdd] FOREIGN KEY ([AckID]) REFERENCES [archiv].[855_Ack_Hdr] ([AckID])
);


CREATE TABLE [importX12].[TagFOB] (
    [FOBId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [ShipmentMethodOfPayment]  VARCHAR (2)  NULL,
    CONSTRAINT [PK_importEDI_FOB] PRIMARY KEY CLUSTERED ([FOBId] ASC),
    CONSTRAINT [FK_importEDI_FOB~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


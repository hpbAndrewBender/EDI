CREATE TABLE [importX12].[TagSAC] (
    [SACId]                                 BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                             INT          NOT NULL,
    [LineNumber]                            INT          NOT NULL,
    [ControlNumberGroup]                    VARCHAR (25) NULL,
    [ControlNumberTransaction]              VARCHAR (25) NULL,
    [AllowanceOrChargeIndicator]            VARCHAR (1)  NULL,
    [ServicePromotionAllowanceOrChargeCode] VARCHAR (4)  NULL,
    [Amount]                                VARCHAR (15) NULL,
    [Rate]                                  VARCHAR (9)  NULL,
    [UnitOrBasisForMeasurementCode]         VARCHAR (2)  NULL,
    [Quantity]                              VARCHAR (15) NULL,
    CONSTRAINT [PK_importEDI_SAC] PRIMARY KEY CLUSTERED ([SACId] ASC),
    CONSTRAINT [FK_importEDI_SAC~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


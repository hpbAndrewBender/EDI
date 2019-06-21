CREATE TABLE [importX12].[TagACK] (
    [ACKId]                         BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                     INT          NOT NULL,
    [LineNumber]                    INT          NOT NULL,
    [ControlNumberGroup]            VARCHAR (25) NULL,
    [ControlNumberTransaction]      VARCHAR (25) NULL,
    [LineItemStatusCode]            VARCHAR (2)  NULL,
    [Quantity]                      VARCHAR (15) NULL,
    [UnitOrBasisForMeasurementCode] VARCHAR (2)  NULL,
    [DateTimeQualifier]             VARCHAR (3)  NULL,
    [Date]                          VARCHAR (8)  NULL,
    [ProductServiceIDQualifier_01]  VARCHAR (2)  NULL,
    [ProductServiceID_01]           VARCHAR (40) NULL,
    [ProductServiceIDQualifier_02]  VARCHAR (2)  NULL,
    [ProductServiceID_02]           VARCHAR (40) NULL,
    [ProductServiceIDQualifier_03]  VARCHAR (2)  NULL,
    [ProductServiceID_03]           VARCHAR (40) NULL,
    [IndustryCode]                  VARCHAR (30) NULL,
    CONSTRAINT [PK_importEDI_ACK] PRIMARY KEY CLUSTERED ([ACKId] ASC),
    CONSTRAINT [FK_importEDI_ACK~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


GO
CREATE NONCLUSTERED INDEX [IX_ImportedEDI_ACK]
    ON [importX12].[TagACK]([EDIFileId] ASC, [ControlNumberGroup] ASC, [ControlNumberTransaction] ASC, [LineNumber] ASC)
    INCLUDE([ACKId], [LineItemStatusCode], [Quantity], [UnitOrBasisForMeasurementCode], [DateTimeQualifier], [Date], [ProductServiceIDQualifier_01], [ProductServiceID_01], [ProductServiceIDQualifier_02], [ProductServiceID_02], [ProductServiceIDQualifier_03], [ProductServiceID_03], [IndustryCode]);


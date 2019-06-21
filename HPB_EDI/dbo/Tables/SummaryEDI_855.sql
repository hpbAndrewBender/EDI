CREATE TABLE [dbo].[SummaryEDI_855] (
    [CombinedID]                        INT             IDENTITY (1, 1) NOT NULL,
    [BAKId]                             BIGINT          NULL,
    [EDIFileID]                         INT             NULL,
    [BAK_LineNumber]                    INT             NULL,
    [BAK_ControlNumberGroup]            VARCHAR (25)    NULL,
    [BAK_ControlNumberTransaction]      VARCHAR (25)    NULL,
    [BAK_TransactionSetPurposeCode]     VARCHAR (2)     NULL,
    [BAK_AcknowledgmentType]            VARCHAR (2)     NULL,
    [BAK_PurchaseOrderNumber]           VARCHAR (22)    NULL,
    [BAK_Date_01]                       VARCHAR (8)     NULL,
    [BAK_ReleaseNumber]                 VARCHAR (30)    NULL,
    [BAK_RequestReferenceNumber]        VARCHAR (45)    NULL,
    [BAK_ContractNumber]                VARCHAR (30)    NULL,
    [BAK_Date_02]                       VARCHAR (8)     NULL,
    [PO1Id]                             BIGINT          NULL,
    [PO1_LineNumber]                    INT             NULL,
    [PO1_ControlNumberGroup]            VARCHAR (25)    NULL,
    [PO1_ControlNumberTransaction]      VARCHAR (25)    NULL,
    [PO1_AssignedIdentification]        VARCHAR (20)    NULL,
    [PO1_QuantityOrdered]               VARCHAR (9)     NULL,
    [PO1_UnitOrBasisForMeasurementCode] VARCHAR (2)     NULL,
    [PO1_UnitPrice]                     DECIMAL (12, 4) NULL,
    [PO1_BasisOfUnitPriceCode]          VARCHAR (2)     NULL,
    [PO1_ProductServiceIDQualifier_01]  VARCHAR (2)     NULL,
    [PO1_ProductServiceID_01]           VARCHAR (40)    NULL,
    [PO1_ProductServiceIDQualifier_02]  VARCHAR (2)     NULL,
    [PO1_ProductServiceID_02]           VARCHAR (40)    NULL,
    [PO1_ProductServiceIDQualifier_03]  VARCHAR (2)     NULL,
    [PO1_ProductServiceID_03]           VARCHAR (40)    NULL,
    [CTPID]                             BIGINT          NULL,
    [CTP_LineNumber]                    INT             NULL,
    [CTP_ControlNumberGroup]            VARCHAR (25)    NULL,
    [CTP_ControlNumberTransaction]      VARCHAR (25)    NULL,
    [CTP_PriceIdentifierCode]           CHAR (3)        NULL,
    [CTP_UnitPrice]                     DECIMAL (12, 4) NULL,
    [CTP_Quantity]                      DECIMAL (12, 4) NULL,
    [CTP_CompositeUnitOfMeasure]        CHAR (2)        NULL,
    [CTP_PriceMultiplerQualifier]       VARCHAR (10)    NULL,
    [CTP_Multiplier]                    DECIMAL (12, 4) NULL,
    [ACKId]                             BIGINT          NULL,
    [ACK_LineNumber]                    INT             NULL,
    [ACK_ControlNumberGroup]            VARCHAR (25)    NULL,
    [ACK_ControlNumberTransaction]      VARCHAR (25)    NULL,
    [ACK_LineItemStatusCode]            VARCHAR (2)     NULL,
    [ACK_Quantity]                      DECIMAL (12, 4) NULL,
    [ACK_UnitOrBasisForMeasurementCode] VARCHAR (2)     NULL,
    [ACK_DateTimeQualifier]             CHAR (3)        NULL,
    [ACK_Date]                          VARCHAR (8)     NULL,
    [ACK_ProductServiceIDQualifier_01]  VARCHAR (2)     NULL,
    [ACK_ProductServiceID_01]           VARCHAR (40)    NULL,
    [ACK_ProductServiceIDQualifier_02]  VARCHAR (2)     NULL,
    [ACK_ProductServiceID_02]           VARCHAR (40)    NULL,
    [ACK_ProductServiceIDQualifier_03]  VARCHAR (2)     NULL,
    [ACK_ProductServiceID_03]           VARCHAR (40)    NULL,
    [ACK_IndustryCode]                  VARCHAR (30)    NULL,
    [PO1_ProductServiceIDQualifier_04]  VARCHAR (2)     NULL,
    [PO1_ProductServiceID_04]           VARCHAR (40)    NULL,
    CONSTRAINT [PK_ImportEDI_BAK_PO1_CTP_ACK] PRIMARY KEY CLUSTERED ([CombinedID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_IMportEDI_BAK_PO1_CTP_ACK-FileID]
    ON [dbo].[SummaryEDI_855]([EDIFileID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ImportEDI_BAK_PO1_CTP_ACK-PO]
    ON [dbo].[SummaryEDI_855]([BAK_PurchaseOrderNumber] ASC);


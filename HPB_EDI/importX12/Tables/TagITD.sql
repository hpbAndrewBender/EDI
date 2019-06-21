CREATE TABLE [importX12].[TagITD] (
    [ITDId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [TermsTypeCode]            VARCHAR (2)  NULL,
    [TermsBasisDateCode]       VARCHAR (2)  NULL,
    [TermsDiscountPercent]     VARCHAR (6)  NULL,
    [TermsDiscountDueDate]     VARCHAR (8)  NULL,
    [TermsDiscountDaysDue]     VARCHAR (3)  NULL,
    [TermsNetDueDate]          VARCHAR (8)  NULL,
    [TermsNetDays]             VARCHAR (3)  NULL,
    [TermsDiscountAmount]      VARCHAR (10) NULL,
    [PaymentMethodCode]        VARCHAR (1)  NULL,
    CONSTRAINT [PK_importEDI_ITD] PRIMARY KEY CLUSTERED ([ITDId] ASC),
    CONSTRAINT [FK_importEDI_ITD~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);


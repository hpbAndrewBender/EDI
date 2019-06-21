CREATE TABLE [importX12].[EDIQualifierShippingStatusTypes] (
    [QualifierShippingStatusTypeID] TINYINT       IDENTITY (0, 1) NOT NULL,
    [QualifierStatusType]           VARCHAR (250) NULL,
    [QualifierStatusActive]         BIT           CONSTRAINT [DF_QualifierStatusActive] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_importEDIQualiiferShippingStatusTypes] PRIMARY KEY CLUSTERED ([QualifierShippingStatusTypeID] ASC),
    CONSTRAINT [UQ_QualifierStatusType] UNIQUE NONCLUSTERED ([QualifierStatusType] ASC)
);


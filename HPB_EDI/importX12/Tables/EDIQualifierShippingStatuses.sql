CREATE TABLE [importX12].[EDIQualifierShippingStatuses] (
    [QualifierShippingStatusID]      SMALLINT IDENTITY (1, 1) NOT NULL,
    [QualifierShippingStatusTypesID] TINYINT  NOT NULL,
    [QualifierID]                    SMALLINT NOT NULL,
    CONSTRAINT [PK_importEDIQualiferShippingStatuses] PRIMARY KEY CLUSTERED ([QualifierShippingStatusID] ASC),
    CONSTRAINT [FK_importEDIQualifierShippingStatues~importEDIQualifierShipingStatusTypes] FOREIGN KEY ([QualifierShippingStatusTypesID]) REFERENCES [importX12].[EDIQualifierShippingStatusTypes] ([QualifierShippingStatusTypeID]),
    CONSTRAINT [FK_importEDIQualifierShippingStatuses~importEDIQualifiers] FOREIGN KEY ([QualifierID]) REFERENCES [importX12].[EDIQualifiers] ([QualifierID])
);


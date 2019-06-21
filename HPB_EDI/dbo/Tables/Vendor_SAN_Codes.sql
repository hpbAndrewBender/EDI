CREATE TABLE [dbo].[Vendor_SAN_Codes] (
    [VendorID]     VARCHAR (10)  NOT NULL,
    [VendorName]   VARCHAR (70)  NULL,
    [SANCode]      VARCHAR (12)  NOT NULL,
    [850Enabled]   BIT           NOT NULL,
    [855Enabled]   BIT           NOT NULL,
    [810Enabled]   BIT           NOT NULL,
    [856Enabled]   BIT           NOT NULL,
    [997Enabled]   BIT           NOT NULL,
    [Notes]        NVARCHAR (80) NULL,
    [Community]    NVARCHAR (50) NULL,
    [Processor]    NVARCHAR (20) NULL,
    [ParentFolder] NVARCHAR (10) NULL,
    [EDIVersion]   NVARCHAR (10) NULL,
    [Invoice997]   BIT           NULL,
    [DftBackOrd]   BIT           NULL,
    [InHouseOnly]  BIT           NULL,
    [ACK997]       BIT           NULL,
    [ASN997]       BIT           NULL,
    [Binary]       BIT           NULL,
    [ISAControlNo] BIGINT        NULL,
    CONSTRAINT [PK_Vendor_SAN_Codes] PRIMARY KEY CLUSTERED ([VendorID] ASC, [SANCode] ASC)
);


CREATE TABLE [dbo].[Vendor_Status_Codes] (
    [VendorID]   VARCHAR (30)  NOT NULL,
    [StatusCode] VARCHAR (10)  NOT NULL,
    [StatusDesc] VARCHAR (150) NOT NULL,
    [Action]     VARCHAR (20)  CONSTRAINT [DF_Vendor_Status_Codes_Action] DEFAULT ('Accept') NOT NULL,
    [Active]     BIT           CONSTRAINT [DF_Vendor_Status_Codes_Active] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Vendor_Status_Codes] PRIMARY KEY CLUSTERED ([VendorID] ASC, [StatusCode] ASC)
);


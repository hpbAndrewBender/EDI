CREATE TABLE [dbo].[HPB_SAN_Codes] (
    [LocationNo]         CHAR (5)     NOT NULL,
    [LocationID]         CHAR (10)    NOT NULL,
    [SANCode]            VARCHAR (12) NOT NULL,
    [Active]             BIT          CONSTRAINT [DF_HPB_SAN_Codes_Active] DEFAULT ((0)) NOT NULL,
    [ActiveInactiveDate] DATETIME     NULL,
    CONSTRAINT [PK_HPB_SAN_Codes] PRIMARY KEY CLUSTERED ([LocationID] ASC, [SANCode] ASC)
);


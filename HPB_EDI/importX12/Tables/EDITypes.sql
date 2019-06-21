CREATE TABLE [importX12].[EDITypes] (
    [EDITypeId]          SMALLINT       IDENTITY (0, 1) NOT NULL,
    [EDIType]            VARCHAR (15)   NOT NULL,
    [EDIVersion]         VARCHAR (5)    NOT NULL,
    [EDITypeDescription] VARCHAR (1024) NOT NULL,
    [EDIActive]          BIT            CONSTRAINT [DF_EDIActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_importEDITypes] PRIMARY KEY CLUSTERED ([EDITypeId] ASC),
    CONSTRAINT [UQ_EdiCode_EDIVersion] UNIQUE NONCLUSTERED ([EDIType] ASC, [EDIVersion] ASC)
);


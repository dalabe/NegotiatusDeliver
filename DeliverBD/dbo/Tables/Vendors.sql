CREATE TABLE [dbo].[Vendors] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [vendorName] VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([id] ASC)
);


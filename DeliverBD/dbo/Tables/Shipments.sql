CREATE TABLE [dbo].[Shipments] (
    [id]                   INT               IDENTITY (1, 1) NOT NULL,
    [orderedDate]          DATE              NULL,
    [shipedDate]           DATE              NULL,
    [deliveredDate]        DATE              NULL,
    [trackingNumber]       VARCHAR (50)      NULL,
    [originAddress]        VARCHAR (150)     NULL,
    [originPoint]          [sys].[geography] NULL,
    [destinationAddress]   VARCHAR (150)     NULL,
    [destinationPoint]     [sys].[geography] NULL,
    [vendorId]             INT               NULL,
    [lastPointReported]    [sys].[geography] NULL,
    [estimatedDeliverDate] DATE              NULL,
    CONSTRAINT [PK_Shipments] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Shipments_Vendors] FOREIGN KEY ([vendorId]) REFERENCES [dbo].[Vendors] ([id])
);


CREATE TABLE [dbo].[Item] (
    [ItemId]   INT             IDENTITY (1, 1) NOT NULL,
    [DesignId] INT             NULL,
    [SKU]      VARCHAR (50)    NULL,
    [Quantity] INT             NULL,
    [Price]    DECIMAL (18, 2) NULL,
    [Color]    INT             NULL,
    [Size]     INT             NULL,
    PRIMARY KEY CLUSTERED ([ItemId] ASC)
);


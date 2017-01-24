CREATE TABLE [dbo].[Design] (
    [DesignId]    INT           IDENTITY (1, 1) NOT NULL,
    [ProductCode] VARCHAR (50)  NULL,
    [Title]       VARCHAR (500) NULL,
    [Description] VARCHAR (MAX) NULL,
    [ImageUrl]    VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([DesignId] ASC)
);


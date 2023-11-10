CREATE TABLE [dbo].[Queues] (
    [Id]              INT         IDENTITY (1, 1) NOT NULL,
    [QueueName]       NCHAR (100) NOT NULL,
    [DurationMinutes] INT         NOT NULL,
    CONSTRAINT [PK_Queues] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Queues]
    ON [dbo].[Queues]([Id] ASC);


CREATE TABLE [dbo].[Clients] (
    [Id]               INT         NOT NULL,
    [ClientName]       NCHAR (100) NOT NULL,
    [RegistrationDate] DATETIME    NOT NULL,
    [QueueId]          INT         NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Clients_Queues] FOREIGN KEY ([QueueId]) REFERENCES [dbo].[Queues] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Clients]
    ON [dbo].[Clients]([Id] ASC);


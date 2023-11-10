USE master
GO

-- Crear la base de datos
CREATE DATABASE INITIUM_TEST
GO

USE INITIUM_TEST
GO

-- Crear la tabla [dbo].[Queues]
CREATE TABLE [dbo].[Queues](
    [Id] [int] IDENTITY(1,1) PRIMARY KEY,
    [QueueName] [nchar](100) NOT NULL,
    [DurationMinutes] [int] NOT NULL
)
GO
-- Crear la tabla [dbo].[Clients]
CREATE TABLE [dbo].[Clients](
    [Id] [int] PRIMARY KEY,
    [ClientName] [nchar](100) NOT NULL,
    [RegistrationDate] [datetime] NOT NULL,
    [QueueId] [int] NOT NULL,
    CONSTRAINT [FK_Clients_Queues] FOREIGN KEY([QueueId]) REFERENCES [dbo].[Queues]([Id])
)
GO

-- Agregar dos colas a la tabla [dbo].[Queues]
INSERT INTO [dbo].[Queues] ([QueueName], [DurationMinutes]) VALUES ('Cola1', 2)
INSERT INTO [dbo].[Queues] ([QueueName], [DurationMinutes]) VALUES ('Cola2', 3)
GO



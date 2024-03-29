
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Category] (
    [CategoryID] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [IconName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([CategoryID])
);

GO

CREATE TABLE [TodoTask] (
    [TodoTaskID] int NOT NULL IDENTITY,
    [Description] nvarchar(250) NOT NULL,
    [CategoryId] int NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [FileName] nvarchar(max) NULL,
    [FileContentType] nvarchar(max) NULL,
    [FileContent] varbinary(max) NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_TodoTask] PRIMARY KEY ([TodoTaskID]),
    CONSTRAINT [FK_TodoTask_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryID]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'IconName', N'Name') AND [object_id] = OBJECT_ID(N'[Category]'))
    SET IDENTITY_INSERT [Category] ON;
INSERT INTO [Category] ([CategoryID], [IconName], [Name])
VALUES (1, N'bulb-outline', N'Work'),
(2, N'person-done-outline', N'Family'),
(3, N'map-outline', N'Vacation'),
(4, N'browser-outline', N'Shopping'),
(5, N'film-outline', N'Movies');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'IconName', N'Name') AND [object_id] = OBJECT_ID(N'[Category]'))
    SET IDENTITY_INSERT [Category] OFF;

GO

CREATE INDEX [IX_TodoTask_CategoryId] ON [TodoTask] ([CategoryId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191215111656_InitialModel', N'3.1.0');

GO



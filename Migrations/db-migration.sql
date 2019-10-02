IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Asset] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [IsGroup] bit NOT NULL,
    [Payload] nvarchar(max) NULL,
    CONSTRAINT [PK_Asset] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AuditTrail] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Action] nvarchar(max) NOT NULL,
    [ObjectId] uniqueidentifier NOT NULL,
    [Payload] nvarchar(max) NULL,
    CONSTRAINT [PK_AuditTrail] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Evidence] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Payload] nvarchar(max) NULL,
    CONSTRAINT [PK_Evidence] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Relationship] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [FromType] int NOT NULL,
    [FromId] uniqueidentifier NOT NULL,
    [ToType] int NOT NULL,
    [ToId] uniqueidentifier NOT NULL,
    [Payload] nvarchar(max) NULL,
    CONSTRAINT [PK_Relationship] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Risk] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Payload] nvarchar(max) NULL,
    CONSTRAINT [PK_Risk] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Risk_Payload] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Payload] nvarchar(max) NULL,
    CONSTRAINT [PK_Risk_Payload] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Treatment] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Type] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Treatment] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Treatment_Payload] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Payload] nvarchar(max) NULL,
    CONSTRAINT [PK_Treatment_Payload] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [User] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Username] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [AccountId] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Vulnerability] (
    [Id] uniqueidentifier NOT NULL,
    [Branch] nvarchar(max) NULL,
    [Version] int NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [CreateByUserId] uniqueidentifier NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Vulnerability] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191002113110_Initial migration', N'3.0.0');

GO


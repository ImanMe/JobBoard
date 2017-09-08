IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Countries] (
    [Id] int NOT NULL IDENTITY,
    [CountryCode] nvarchar(12) NOT NULL,
    [CountryName] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [States] (
    [Id] int NOT NULL IDENTITY,
    [CountryId] int NOT NULL,
    [StateCode] nvarchar(12) NOT NULL,
    [StateName] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_States_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_States_CountryId] ON [States] ([CountryId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170826015149_Initial', N'2.0.0-rtm-26452');

GO

CREATE TABLE [Applicants] (
    [Id] bigint NOT NULL IDENTITY,
    [Email] nvarchar(120) NOT NULL,
    [FileName] nvarchar(max) NULL,
    [FirstName] nvarchar(120) NOT NULL,
    [LastName] nvarchar(120) NOT NULL,
    [Phone] nvarchar(10) NULL,
    CONSTRAINT [PK_Applicants] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170826032454_Applicant', N'2.0.0-rtm-26452');

GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [EmploymentTypes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EmploymentTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SalaryTypes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_SalaryTypes] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170826032952_Others', N'2.0.0-rtm-26452');

GO

ALTER TABLE [Applicants] ADD [JobId] bigint NOT NULL DEFAULT 0;

GO

CREATE TABLE [JobBoards] (
    [Id] int NOT NULL IDENTITY,
    [EstreamJbsId] int NOT NULL,
    [IsEmailApply] bit NOT NULL,
    [IsOnlineApply] bit NOT NULL,
    [JobBoardName] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_JobBoards] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Occupations] (
    [Id] int NOT NULL IDENTITY,
    [OccupationCategory] nvarchar(120) NOT NULL,
    [OccupationName] nvarchar(120) NOT NULL,
    CONSTRAINT [PK_Occupations] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Jobs] (
    [Id] bigint NOT NULL IDENTITY,
    [ActivationDate] datetime2 NOT NULL,
    [Address] nvarchar(1200) NOT NULL,
    [ApsCl] int NOT NULL,
    [Author] nvarchar(max) NULL,
    [Bob] int NOT NULL,
    [CategoryId] int NOT NULL,
    [City] nvarchar(120) NOT NULL,
    [CloneFrom] bigint NOT NULL,
    [CompanyName] nvarchar(120) NOT NULL,
    [CountryId] int NOT NULL,
    [CreatedBy] nvarchar(120) NOT NULL,
    [Currency] nvarchar(120) NOT NULL,
    [Division] nvarchar(120) NOT NULL,
    [EditedBy] nvarchar(120) NOT NULL,
    [EditedDate] datetime2 NOT NULL,
    [EmailTo] nvarchar(120) NULL,
    [EmploymentTypeId] int NOT NULL,
    [EverGreenId] bigint NOT NULL,
    [ExpirationDate] datetime2 NOT NULL,
    [Intvs] int NOT NULL,
    [Intvs2] int NOT NULL,
    [IsBestPerforming] bit NOT NULL,
    [IsEverGreen] bit NOT NULL,
    [IsOnlineApply] bit NOT NULL,
    [JobBoardId] int NOT NULL,
    [JobDescription] nvarchar(max) NOT NULL,
    [JobRequirements] nvarchar(max) NOT NULL,
    [MaximumExperience] smallint NOT NULL,
    [MinimumExperience] smallint NOT NULL,
    [OfficeId] int NOT NULL,
    [Salary] decimal(18, 2) NOT NULL,
    [SalaryTypeId] int NOT NULL,
    [SchedulingPod] int NOT NULL,
    [Title] nvarchar(255) NOT NULL,
    [ZipCode] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Jobs_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Jobs_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Jobs_EmploymentTypes_EmploymentTypeId] FOREIGN KEY ([EmploymentTypeId]) REFERENCES [EmploymentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Jobs_JobBoards_JobBoardId] FOREIGN KEY ([JobBoardId]) REFERENCES [JobBoards] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Jobs_SalaryTypes_SalaryTypeId] FOREIGN KEY ([SalaryTypeId]) REFERENCES [SalaryTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [JobOccupations] (
    [JobId] bigint NOT NULL,
    [OccupationId] int NOT NULL,
    CONSTRAINT [PK_JobOccupations] PRIMARY KEY ([JobId], [OccupationId]),
    CONSTRAINT [FK_JobOccupations_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_JobOccupations_Occupations_OccupationId] FOREIGN KEY ([OccupationId]) REFERENCES [Occupations] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_JobOccupations_OccupationId] ON [JobOccupations] ([OccupationId]);

GO

CREATE INDEX [IX_Jobs_CategoryId] ON [Jobs] ([CategoryId]);

GO

CREATE INDEX [IX_Jobs_CountryId] ON [Jobs] ([CountryId]);

GO

CREATE INDEX [IX_Jobs_EmploymentTypeId] ON [Jobs] ([EmploymentTypeId]);

GO

CREATE INDEX [IX_Jobs_JobBoardId] ON [Jobs] ([JobBoardId]);

GO

CREATE INDEX [IX_Jobs_SalaryTypeId] ON [Jobs] ([SalaryTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170826034041_Fix', N'2.0.0-rtm-26452');

GO

ALTER TABLE [Jobs] ADD [StateId] int NOT NULL DEFAULT 0;

GO

CREATE INDEX [IX_Jobs_StateId] ON [Jobs] ([StateId]);

GO

ALTER TABLE [Jobs] ADD CONSTRAINT [FK_Jobs_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [States] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170826035536_AddState', N'2.0.0-rtm-26452');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Jobs') AND [c].[name] = N'Intvs2');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Intvs2] int NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Jobs') AND [c].[name] = N'Intvs');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Intvs] int NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Jobs') AND [c].[name] = N'Bob');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Bob] int NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Jobs') AND [c].[name] = N'ApsCl');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [ApsCl] int NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Jobs') AND [c].[name] = N'Address');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Address] nvarchar(1200) NULL;

GO

ALTER TABLE [Jobs] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.000';

GO

ALTER TABLE [Applicants] ADD [Date] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170826041527_KeysFixed', N'2.0.0-rtm-26452');

GO


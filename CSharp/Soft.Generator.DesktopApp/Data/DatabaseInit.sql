IF DB_ID('SoftGeneratorDA') IS NULL
BEGIN
    CREATE DATABASE SoftGeneratorDA;
END;
GO

USE SoftGeneratorDA;
GO

CREATE TABLE Company (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(500) NOT NULL,
    Email NVARCHAR(400) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL
);

CREATE TABLE Permission (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Code NVARCHAR(100) NOT NULL UNIQUE
);

INSERT INTO Permission (Name, Code) VALUES ('Dodavanje kompanije', 'InsertCompany');
INSERT INTO Permission (Name, Code) VALUES ('Menjanje kompanije', 'UpdateCompany');
INSERT INTO Permission (Name, Code) VALUES ('Brisanje kompanije', 'DeleteCompany');

CREATE TABLE Framework (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(500) NOT NULL,
    Code NVARCHAR(500) NOT NULL
);

CREATE TABLE Setting (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(500) not null,
    HasGoogleAuth BIT NOT NULL,
    PrimaryColor NCHAR(7) NOT NULL,
    HasLatinTranslate BIT NOT NULL,
    HasDarkMode BIT NOT NULL,
    HasNotifications BIT NOT NULL,
	EmailSender NVARCHAR(500) not null,
	SMTPUser NVARCHAR(500) not null,
	SMTPPass NVARCHAR(500) not null,
	JWTKey NVARCHAR(500) not null,
	BloblStorageConnectionString NVARCHAR(500) null,
	BloblStorageUrl NVARCHAR(500) null,
	EntitiesNamespaceEnding NVARCHAR(100) NOT NULL DEFAULT 'Entities',
	DTONamespaceEnding NVARCHAR(100) NOT NULL DEFAULT 'DTO',
	BaseProjectNamespace NVARCHAR(200) NOT NULL DEFAULT 'Playerty.Loyals',
	BaseBusinessServiceName NVARCHAR(100) NOT NULL DEFAULT 'Loyals',
	LimitLengthForTextArea INT NOT NULL DEFAULT 256,
    FrameworkId BIGINT NOT NULL,
    FOREIGN KEY (FrameworkId) REFERENCES Framework(Id)
);

CREATE TABLE WebApplication (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(500) NOT NULL,
    CompanyId BIGINT NOT NULL,
    SettingId BIGINT NOT NULL,
    FOREIGN KEY (CompanyId) REFERENCES Company(Id),
    FOREIGN KEY (SettingId) REFERENCES Setting(Id)
);

CREATE TABLE DllPath (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Path NVARCHAR(1000) NOT NULL,
	WebApplicationId BIGINT NOT NULL,
    FOREIGN KEY (WebApplicationId) REFERENCES WebApplication(Id),
);

CREATE TABLE WebApplicationFile (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    DisplayName NVARCHAR(500) NOT NULL,
    ClassName NVARCHAR(500) NOT NULL,
    Namespace NVARCHAR(1000) NOT NULL,
    Regenerate BIT NOT NULL,
	Generated BIT NOT NULL,
    WebApplicationId BIGINT NOT NULL,
    DllPathId BIGINT NOT NULL,
    FOREIGN KEY (WebApplicationId) REFERENCES WebApplication(Id),
    FOREIGN KEY (DllPathId) REFERENCES DllPath(Id)
);

CREATE TABLE CompanyPermission (
    CompanyId BIGINT,
    PermissionId BIGINT,
    PRIMARY KEY (CompanyId, PermissionId),
    FOREIGN KEY (CompanyId) REFERENCES Company(Id) ON DELETE CASCADE,
    FOREIGN KEY (PermissionId) REFERENCES Permission(Id) ON DELETE CASCADE
);
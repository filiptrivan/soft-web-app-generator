USE [master]
GO
/****** Object:  Database [SoftGeneratorDA]    Script Date: 8/2/2025 1:50:11 AM ******/
CREATE DATABASE [SoftGeneratorDA]
GO
USE [SoftGeneratorDA]
GO

GO

CREATE TABLE [dbo].[Company](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](400) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyPermission]    Script Date: 8/2/2025 1:50:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyPermission](
	[CompanyId] [bigint] NOT NULL,
	[PermissionId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DllPath]    Script Date: 8/2/2025 1:50:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DllPath](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](1000) NOT NULL,
	[WebApplicationId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Framework]    Script Date: 8/2/2025 1:50:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Framework](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Code] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 8/2/2025 1:50:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 8/2/2025 1:50:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[HasGoogleAuth] [bit] NOT NULL,
	[PrimaryColor] [nchar](7) NOT NULL,
	[HasLatinTranslate] [bit] NOT NULL,
	[HasDarkMode] [bit] NOT NULL,
	[HasNotifications] [bit] NOT NULL,
	[FrameworkId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebApplication]    Script Date: 8/2/2025 1:50:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebApplication](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[SettingId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebApplicationFile]    Script Date: 8/2/2025 1:50:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebApplicationFile](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](500) NOT NULL,
	[ClassName] [nvarchar](500) NOT NULL,
	[Namespace] [nvarchar](1000) NOT NULL,
	[Regenerate] [bit] NOT NULL,
	[Generated] [bit] NOT NULL,
	[WebApplicationId] [bigint] NOT NULL,
	[DllPathId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CompanyPermission]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyPermission]  WITH CHECK ADD FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DllPath]  WITH CHECK ADD  CONSTRAINT [FK_DllPath_WebApplication] FOREIGN KEY([WebApplicationId])
REFERENCES [dbo].[WebApplication] ([Id])
GO
ALTER TABLE [dbo].[DllPath] CHECK CONSTRAINT [FK_DllPath_WebApplication]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD FOREIGN KEY([FrameworkId])
REFERENCES [dbo].[Framework] ([Id])
GO
ALTER TABLE [dbo].[WebApplication]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[WebApplication]  WITH CHECK ADD FOREIGN KEY([SettingId])
REFERENCES [dbo].[Setting] ([Id])
GO
ALTER TABLE [dbo].[WebApplicationFile]  WITH CHECK ADD FOREIGN KEY([DllPathId])
REFERENCES [dbo].[DllPath] ([Id])
GO
ALTER TABLE [dbo].[WebApplicationFile]  WITH CHECK ADD FOREIGN KEY([WebApplicationId])
REFERENCES [dbo].[WebApplication] ([Id])
GO
USE [master]
GO
ALTER DATABASE [SoftGeneratorDA] SET  READ_WRITE 
GO

insert into Company values('Spiderly', 'ft', 'ft')
go
insert into Permission values('Dodavanje kompanije', 'InsertCompany')
insert into Permission values('Menjanje kompanije', 'UpdateCompany')
insert into Permission values('Brisanje kompanije', 'DeleteCompany')
go
insert into CompanyPermission values(1, 1)
insert into CompanyPermission values(1, 2)
insert into CompanyPermission values(1, 3)
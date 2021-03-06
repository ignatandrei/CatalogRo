USE [CatalogRO]
GO
ALTER TABLE [dbo].[ResursaAlternativa] DROP CONSTRAINT [DF_ResursaAlternativa_DataIntroducere]
GO
ALTER TABLE [dbo].[Resursa] DROP CONSTRAINT [DF_Resursa_ID]
GO
/****** Object:  Table [dbo].[ResursaAlternativa]    Script Date: 2/11/2018 12:37:07 PM ******/
DROP TABLE [dbo].[ResursaAlternativa]
GO
/****** Object:  Table [dbo].[Resursa]    Script Date: 2/11/2018 12:37:07 PM ******/
DROP TABLE [dbo].[Resursa]
GO
/****** Object:  Table [dbo].[Format]    Script Date: 2/11/2018 12:37:07 PM ******/
DROP TABLE [dbo].[Format]
GO
/****** Object:  Table [dbo].[Entuziast]    Script Date: 2/11/2018 12:37:07 PM ******/
DROP TABLE [dbo].[Entuziast]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 2/11/2018 12:37:07 PM ******/
DROP TABLE [dbo].[Categorie]
GO
USE [master]
GO
/****** Object:  Database [CatalogRO]    Script Date: 2/11/2018 12:37:07 PM ******/
DROP DATABASE [CatalogRO]
GO
/****** Object:  Database [CatalogRO]    Script Date: 2/11/2018 12:37:07 PM ******/
CREATE DATABASE [CatalogRO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CatalogRO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CatalogRO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CatalogRO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CatalogRO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CatalogRO] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CatalogRO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CatalogRO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CatalogRO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CatalogRO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CatalogRO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CatalogRO] SET ARITHABORT OFF 
GO
ALTER DATABASE [CatalogRO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CatalogRO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CatalogRO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CatalogRO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CatalogRO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CatalogRO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CatalogRO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CatalogRO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CatalogRO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CatalogRO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CatalogRO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CatalogRO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CatalogRO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CatalogRO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CatalogRO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CatalogRO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CatalogRO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CatalogRO] SET RECOVERY FULL 
GO
ALTER DATABASE [CatalogRO] SET  MULTI_USER 
GO
ALTER DATABASE [CatalogRO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CatalogRO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CatalogRO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CatalogRO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CatalogRO] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CatalogRO', N'ON'
GO
ALTER DATABASE [CatalogRO] SET QUERY_STORE = OFF
GO
USE [CatalogRO]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CatalogRO]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 2/11/2018 12:37:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[IDCategorie] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](150) NOT NULL,
	[Parent] [int] NULL,
	[EnglishName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[IDCategorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entuziast]    Script Date: 2/11/2018 12:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entuziast](
	[Id] [bigint] NOT NULL,
	[Nume] [nvarchar](500) NULL,
	[Prenume] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[Telefon] [nvarchar](500) NULL,
	[Note] [nvarchar](500) NULL,
	[Validat] [bit] NOT NULL,
	[Parola] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Format]    Script Date: 2/11/2018 12:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Format](
	[IDFormat] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](150) NOT NULL,
	[EnglishName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Format] PRIMARY KEY CLUSTERED 
(
	[IDFormat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resursa]    Script Date: 2/11/2018 12:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resursa](
	[ID] [uniqueidentifier] NOT NULL,
	[Titlu] [nvarchar](500) NOT NULL,
	[Autor] [nvarchar](500) NOT NULL,
	[Categorie] [int] NOT NULL,
	[Descriere] [nvarchar](max) NOT NULL,
	[Subiect] [nvarchar](2000) NOT NULL,
	[Format] [int] NOT NULL,
	[UrlResursa] [nvarchar](500) NULL,
	[Url2Resursa] [nvarchar](500) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Resursa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResursaAlternativa]    Script Date: 2/11/2018 12:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResursaAlternativa](
	[Id] [uniqueidentifier] NOT NULL,
	[IdResursa] [uniqueidentifier] NOT NULL,
	[Titlu] [nvarchar](500) NULL,
	[Autor] [nvarchar](500) NULL,
	[Descriere] [nvarchar](max) NULL,
	[Subiect] [nvarchar](2000) NULL,
	[Format] [int] NULL,
	[UrlResursa] [nvarchar](500) NULL,
	[Url2Resursa] [nvarchar](500) NULL,
	[Contributor] [nvarchar](500) NULL,
	[IDEntuziast] [int] NOT NULL,
	[DataIntroducere] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorie] ON 
GO
INSERT [dbo].[Categorie] ([IDCategorie], [Nume], [Parent], [EnglishName]) VALUES (1, N'Beletristica', NULL, NULL)
GO
INSERT [dbo].[Categorie] ([IDCategorie], [Nume], [Parent], [EnglishName]) VALUES (2, N'Poezie', 1, NULL)
GO
INSERT [dbo].[Categorie] ([IDCategorie], [Nume], [Parent], [EnglishName]) VALUES (3, N'Drama', 2, NULL)
GO
INSERT [dbo].[Categorie] ([IDCategorie], [Nume], [Parent], [EnglishName]) VALUES (4, N'Altele', NULL, NULL)
GO
INSERT [dbo].[Categorie] ([IDCategorie], [Nume], [Parent], [EnglishName]) VALUES (5, N'Eseu', 4, NULL)
GO
INSERT [dbo].[Categorie] ([IDCategorie], [Nume], [Parent], [EnglishName]) VALUES (6, N'Cronica', 4, NULL)
GO
SET IDENTITY_INSERT [dbo].[Categorie] OFF
GO
SET IDENTITY_INSERT [dbo].[Format] ON 
GO
INSERT [dbo].[Format] ([IDFormat], [Nume], [EnglishName]) VALUES (1, N'PDF', NULL)
GO
INSERT [dbo].[Format] ([IDFormat], [Nume], [EnglishName]) VALUES (2, N'JPG', NULL)
GO
INSERT [dbo].[Format] ([IDFormat], [Nume], [EnglishName]) VALUES (3, N'TXT', NULL)
GO
SET IDENTITY_INSERT [dbo].[Format] OFF
GO
ALTER TABLE [dbo].[Resursa] ADD  CONSTRAINT [DF_Resursa_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ResursaAlternativa] ADD  CONSTRAINT [DF_ResursaAlternativa_DataIntroducere]  DEFAULT (getutcdate()) FOR [DataIntroducere]
GO
USE [master]
GO
ALTER DATABASE [CatalogRO] SET  READ_WRITE 
GO

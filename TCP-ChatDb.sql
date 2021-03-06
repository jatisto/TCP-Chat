USE [master]
GO
/****** Object:  Database [TCPChatDB]    Script Date: 19.02.2019 11:03:31 ******/
CREATE DATABASE [TCPChatDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TCPChatDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TCPChatDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TCPChatDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TCPChatDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TCPChatDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
	EXEC [TCPChatDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TCPChatDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TCPChatDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TCPChatDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TCPChatDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TCPChatDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TCPChatDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TCPChatDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TCPChatDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TCPChatDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TCPChatDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TCPChatDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TCPChatDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TCPChatDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TCPChatDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TCPChatDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TCPChatDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TCPChatDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TCPChatDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TCPChatDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TCPChatDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TCPChatDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TCPChatDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TCPChatDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TCPChatDB] SET  MULTI_USER 
GO
ALTER DATABASE [TCPChatDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TCPChatDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TCPChatDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TCPChatDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TCPChatDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TCPChatDB] SET QUERY_STORE = OFF
GO
USE [TCPChatDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19.02.2019 11:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory]
(
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
	CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles]
(
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins]
(
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
	CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles]
(
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers]
(
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens]
(
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
	CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Connections]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connections]
(
	[ConnectionID] [nvarchar](450) NOT NULL,
	[UserAgent] [nvarchar](max) NULL,
	[Connected] [bit] NOT NULL,
	[LastActivity] [datetimeoffset](7) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Name] [nvarchar](max) NULL,
	CONSTRAINT [PK_Connections] PRIMARY KEY CLUSTERED 
(
	[ConnectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoryLogs]    Script Date: 19.02.2019 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryLogs]
(
	[Id] [nvarchar](450) NOT NULL,
	[UserToId] [nvarchar](450) NULL,
	[UserFromId] [nvarchar](450) NULL,
	[Context] [nvarchar](max) NULL,
	[Date] [datetimeoffset](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[UserGroupNik] [nvarchar](max) NULL,
	CONSTRAINT [PK_HistoryLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory]
	([MigrationId], [ProductVersion])
VALUES
	(N'20190213165534_Identity', N'2.2.1-servicing-10028')
INSERT [dbo].[__EFMigrationsHistory]
	([MigrationId], [ProductVersion])
VALUES
	(N'20190216081149_AddConnection', N'2.2.1-servicing-10028')
INSERT [dbo].[__EFMigrationsHistory]
	([MigrationId], [ProductVersion])
VALUES
	(N'20190216161259_AddHistoryLog', N'2.2.1-servicing-10028')
INSERT [dbo].[__EFMigrationsHistory]
	([MigrationId], [ProductVersion])
VALUES
	(N'20190216190613_AddNameOnConnection', N'2.2.1-servicing-10028')
INSERT [dbo].[__EFMigrationsHistory]
	([MigrationId], [ProductVersion])
VALUES
	(N'20190218135302_AddPropertyUserGroupNik', N'2.2.1-servicing-10028')
INSERT [dbo].[AspNetRoles]
	([Id], [Name], [NormalizedName], [ConcurrencyStamp])
VALUES
	(N'c7e58578-87b3-42d7-a883-33073c02be75', N'User', N'USER', N'7a06e79a-94c3-4ff4-a552-79d25a8df18a')
INSERT [dbo].[AspNetUserRoles]
	([UserId], [RoleId])
VALUES
	(N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'c7e58578-87b3-42d7-a883-33073c02be75')
INSERT [dbo].[AspNetUserRoles]
	([UserId], [RoleId])
VALUES
	(N'b40af916-cf43-41f1-8052-8c17372a7df6', N'c7e58578-87b3-42d7-a883-33073c02be75')
INSERT [dbo].[AspNetUserRoles]
	([UserId], [RoleId])
VALUES
	(N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'c7e58578-87b3-42d7-a883-33073c02be75')
INSERT [dbo].[AspNetUsers]
	([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount])
VALUES
	(N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Lo', N'LO', NULL, NULL, 0, N'AQAAAAEAACcQAAAAED9ustHph+jythvRd5mqmJo1BOUc+C/k738fu2rBO2ADMssVHb5hxg7acTC8xDlyDQ==', N'ACKEWRX63I24DFYD3WVMKYOYR3JROUEX', N'5d5d56ff-8dcc-449c-9965-91d1fdc7a3a9', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers]
	([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount])
VALUES
	(N'b40af916-cf43-41f1-8052-8c17372a7df6', N'Run', N'RUN', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEM6GRGoJhPS1nKxyGrBgtBtZnrtWOe+L3gCS8ML9uAGbsBDXQdOnGdGPEQw7JaRC6A==', N'ET34YSHG5TCC4L36ZEJ2TNVJHXBG6PSH', N'e39a3728-c175-42cb-bead-270295da2ea5', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers]
	([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount])
VALUES
	(N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Hong', N'HONG', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEPKsAy+oTNrzJY/Mmj/F4SPCB0luxPj/0NewkJrIuOln4RDJcN7PVGIhHGS2SI82bg==', N'XWWNSWXSB5NJVILCBI3ZW7XAVE6X3H3A', N'd7c4343d-f1f3-4ecf-9148-f5352ca917bc', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'1jzjWySxPr-BfTJxupv7Xw', NULL, 0, CAST(N'2019-02-19T04:19:29.3018615+00:00' AS DateTimeOffset), N'b40af916-cf43-41f1-8052-8c17372a7df6', N'Run')
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'2D4n24vSGtTtYKlJy01NDQ', NULL, 0, CAST(N'2019-02-19T04:32:03.4830261+00:00' AS DateTimeOffset), N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Lo')
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'8_AcGPUUUtveZOY9P9BYQQ', NULL, 0, CAST(N'2019-02-19T04:18:47.0456493+00:00' AS DateTimeOffset), N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Lo')
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'b37XZ0rtG6wwQJhL7hTmyQ', NULL, 0, CAST(N'2019-02-19T04:13:45.0293950+00:00' AS DateTimeOffset), N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Lo')
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'c5zGSpop8q0U_bAzMwylEQ', NULL, 0, CAST(N'2019-02-19T04:32:15.4214537+00:00' AS DateTimeOffset), N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Lo')
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'eKBIqKK7VZrugaOWtdjlVg', NULL, 0, CAST(N'2019-02-19T04:32:20.8354820+00:00' AS DateTimeOffset), N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Lo')
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'elNAp8r5PP59B5GSZz78Yg', NULL, 0, CAST(N'2019-02-19T04:10:53.1996157+00:00' AS DateTimeOffset), N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Hong')
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'gd0QhWujYk6qpVEWOP0sGQ', NULL, 0, CAST(N'2019-02-19T04:11:31.5713093+00:00' AS DateTimeOffset), N'b40af916-cf43-41f1-8052-8c17372a7df6', N'Run')
INSERT [dbo].[Connections]
	([ConnectionID], [UserAgent], [Connected], [LastActivity], [UserId], [Name])
VALUES
	(N'he4Qp76Ihzv8oN5QIIDKFw', NULL, 0, CAST(N'2019-02-19T04:20:11.3925153+00:00' AS DateTimeOffset), N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Lo')
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'06103ca1-6ccd-450c-b09a-a1b8e4b1340f', N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Thank you. We will sit there.', CAST(N'2019-02-19T04:14:16.9910383+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'175c46d8-4323-48c9-9200-d45aa5f2d27f', N'b40af916-cf43-41f1-8052-8c17372a7df6', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Great! Then, let’s do that, because the next good cafe is quite far from here. Besides this one serves tasty pancakes with fruit and cream.', CAST(N'2019-02-19T04:12:18.1840400+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'294da406-c896-47cc-8d6a-ee23c9ffee7c', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'As I thought. It’s a nice view from here. By the way, are you hungry?', CAST(N'2017-02-19T04:14:29.3707535+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'3aa4de19-75d4-4b93-a672-65be45fb3435', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'b40af916-cf43-41f1-8052-8c17372a7df6', N' Can you see that table for two near the window? I think it should be a good place.', CAST(N'2017-02-19T04:12:47.6389739+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'4694a246-938f-42e1-9743-368e63653532', NULL, N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Hello! All!', CAST(N'2019-02-19T04:19:07.7457013+00:00' AS DateTimeOffset), 0, N'Loo')
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'4803ebf7-b8bf-45e0-b3cb-52425b46d122', N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Oh, that’s a good choice. They are really delicious. Try the ones with strawberry and bananas. You’ll love them.', CAST(N'2017-02-19T04:14:58.5345222+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'482b1ac3-ac96-4ab1-a54d-9ffc25ab25e7', N'b40af916-cf43-41f1-8052-8c17372a7df6', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Yes, we can people watch from there. It’s fun.', CAST(N'2019-02-19T04:12:58.0434691+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'4901e78a-d3ad-4fd4-9180-0a31044247dd', N'b40af916-cf43-41f1-8052-8c17372a7df6', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Here we are. Where shall we sit?', CAST(N'2019-02-19T04:12:37.1870715+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'4a156de8-3c3e-4520-959c-d70b64451223', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'b40af916-cf43-41f1-8052-8c17372a7df6', N'That’s why I like sitting near the windows. You can always see people passing by and guess where they are going or make up stories about them, in one word – to gossip.', CAST(N'2019-02-19T04:13:08.7487155+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'5d0052b3-f42d-4382-b555-79c1b2ec2f44', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'b40af916-cf43-41f1-8052-8c17372a7df6', N'It looks like a nice place. I don’t mind going there.', CAST(N'2012-02-19T04:12:07.6572828+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'791b328b-4f60-4280-a534-432d27fe7842', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Ok, then we’ll choose a window table. I hope it’s not reserved. I’ll ask the waiter. Excuse me, is this table free?', CAST(N'2012-02-19T04:13:53.3426817+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'8b8e6e84-26d5-4d3d-a97e-133bfd40dbae', N'b40af916-cf43-41f1-8052-8c17372a7df6', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Kate, what do you think of this corner cafe?', CAST(N'2019-02-19T04:11:49.8951394+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'8f4b5194-7d9a-4c0a-bbce-4fddd444311d', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'Yes, sir. It’s not reserved. You can sit there if you want.', CAST(N'2019-02-19T04:14:01.2795933+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'a13ba3ed-e88a-4cb2-9523-11f5d260cf59', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'b40af916-cf43-41f1-8052-8c17372a7df6', N'Sounds delicious.', CAST(N'2012-02-19T04:12:28.2502091+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'c955373c-fcca-406e-819c-e3e0168cdeb6', NULL, N'b40af916-cf43-41f1-8052-8c17372a7df6', N'Hi! ', CAST(N'2019-02-19T04:19:48.2289109+00:00' AS DateTimeOffset), 0, N'Ruun')
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'cb9ef16f-a8de-48d0-8a41-9ccdf1d0c4a5', N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'Yes, a bit. Let’s see, what is there in a menu?', CAST(N'2019-02-19T04:14:37.3174745+00:00' AS DateTimeOffset), 1, NULL)
INSERT [dbo].[HistoryLogs]
	([Id], [UserToId], [UserFromId], [Context], [Date], [Status], [UserGroupNik])
VALUES
	(N'eccba8a4-b5ba-4f80-bc4a-1d2e90103550', N'da0611f5-68d6-4601-8de1-47961f2a94c9', N'8fae3e8a-b23c-4560-ab01-f72253ff5f96', N'I’m not very hungry. So, I’ll have only a cup of coffee and a pancake, which you advised.', CAST(N'2019-02-19T04:14:47.9321704+00:00' AS DateTimeOffset), 1, NULL)
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 19.02.2019 11:03:32 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 19.02.2019 11:03:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 19.02.2019 11:03:32 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 19.02.2019 11:03:32 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 19.02.2019 11:03:32 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 19.02.2019 11:03:32 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 19.02.2019 11:03:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Connections_UserId]    Script Date: 19.02.2019 11:03:32 ******/
CREATE NONCLUSTERED INDEX [IX_Connections_UserId] ON [dbo].[Connections]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HistoryLogs_UserFromId]    Script Date: 19.02.2019 11:03:32 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryLogs_UserFromId] ON [dbo].[HistoryLogs]
(
	[UserFromId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_HistoryLogs_UserToId]    Script Date: 19.02.2019 11:03:32 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryLogs_UserToId] ON [dbo].[HistoryLogs]
(
	[UserToId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Connections]  WITH CHECK ADD  CONSTRAINT [FK_Connections_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Connections] CHECK CONSTRAINT [FK_Connections_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[HistoryLogs]  WITH CHECK ADD  CONSTRAINT [FK_HistoryLogs_AspNetUsers_UserFromId] FOREIGN KEY([UserFromId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[HistoryLogs] CHECK CONSTRAINT [FK_HistoryLogs_AspNetUsers_UserFromId]
GO
ALTER TABLE [dbo].[HistoryLogs]  WITH CHECK ADD  CONSTRAINT [FK_HistoryLogs_AspNetUsers_UserToId] FOREIGN KEY([UserToId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[HistoryLogs] CHECK CONSTRAINT [FK_HistoryLogs_AspNetUsers_UserToId]
GO
USE [master]
GO
ALTER DATABASE [TCPChatDB] SET  READ_WRITE 
GO

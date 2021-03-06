USE [master]
GO
/****** Object:  Database [ProjeYemekSepeti]    Script Date: 18.06.2019 18:44:30 ******/
CREATE DATABASE [ProjeYemekSepeti]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjeYemekSepeti', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProjeYemekSepeti.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjeYemekSepeti_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProjeYemekSepeti_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjeYemekSepeti] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjeYemekSepeti].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjeYemekSepeti] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProjeYemekSepeti] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProjeYemekSepeti] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjeYemekSepeti] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjeYemekSepeti] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProjeYemekSepeti] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjeYemekSepeti] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProjeYemekSepeti] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjeYemekSepeti] SET  MULTI_USER 
GO
ALTER DATABASE [ProjeYemekSepeti] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjeYemekSepeti] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjeYemekSepeti] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjeYemekSepeti] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ProjeYemekSepeti]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Addresss]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresss](
	[ID] [uniqueidentifier] NOT NULL,
	[FullAddress] [nvarchar](900) NOT NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
	[RestaurantID] [uniqueidentifier] NOT NULL,
	[ProvinceID] [uniqueidentifier] NULL,
	[CountryID] [uniqueidentifier] NULL,
	[DistrictID] [uniqueidentifier] NULL,
	[AppUserID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Addresss] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SurName] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[BirthDate] [date] NULL,
	[IsAdministrator] [bit] NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AppUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](150) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countrys]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countrys](
	[ID] [uniqueidentifier] NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
	[ProvinceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Countrys] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Districts]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[ID] [uniqueidentifier] NOT NULL,
	[DistrictName] [nvarchar](50) NOT NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
	[CountryID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Districts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meals]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meals](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[imagePath] [nvarchar](250) NULL,
	[Price] [money] NOT NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
	[CategoryID] [uniqueidentifier] NOT NULL,
	[RestaurantID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Meals] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[ID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[MealID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [uniqueidentifier] NOT NULL,
	[OrderDate] [datetime] NULL,
	[SendingDate] [datetime] NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
	[RestaurantID] [uniqueidentifier] NOT NULL,
	[AppUserID] [uniqueidentifier] NOT NULL,
	[CustomerAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provinces]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[ID] [uniqueidentifier] NOT NULL,
	[ProvinceName] [nvarchar](25) NOT NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Provinces] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Restaurants]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurants](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](350) NOT NULL,
	[Working_Hour] [datetime] NOT NULL,
	[End_Time] [datetime] NOT NULL,
	[Service_Time] [nvarchar](50) NOT NULL,
	[imagePath] [nvarchar](259) NULL,
	[Packagefee] [nvarchar](20) NOT NULL,
	[Promotionalinformation] [nvarchar](1000) NULL,
	[WarningandInformation] [nvarchar](1000) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Restaurants] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestorantKategoris]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestorantKategoris](
	[ID] [uniqueidentifier] NOT NULL,
	[RestaurantID] [uniqueidentifier] NOT NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
	[CategoryID] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](150) NULL,
 CONSTRAINT [PK_dbo.RestorantKategoris] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShoppingCarts]    Script Date: 18.06.2019 18:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCarts](
	[ID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedIP] [nvarchar](max) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedIP] [nvarchar](max) NULL,
	[RestaurantID] [uniqueidentifier] NOT NULL,
	[MealID] [uniqueidentifier] NULL,
	[Name] [nvarchar](max) NULL,
	[AppUserID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.ShoppingCarts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_AppUserID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_AppUserID] ON [dbo].[Addresss]
(
	[AppUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CountryID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_CountryID] ON [dbo].[Addresss]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DistrictID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_DistrictID] ON [dbo].[Addresss]
(
	[DistrictID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProvinceID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_ProvinceID] ON [dbo].[Addresss]
(
	[ProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RestaurantID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_RestaurantID] ON [dbo].[Addresss]
(
	[RestaurantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProvinceID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_ProvinceID] ON [dbo].[Countrys]
(
	[ProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CountryID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_CountryID] ON [dbo].[Districts]
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryID] ON [dbo].[Meals]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RestaurantID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_RestaurantID] ON [dbo].[Meals]
(
	[RestaurantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MealID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_MealID] ON [dbo].[OrderDetails]
(
	[MealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_OrderID] ON [dbo].[OrderDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AppUserID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_AppUserID] ON [dbo].[Orders]
(
	[AppUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RestaurantID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_RestaurantID] ON [dbo].[Orders]
(
	[RestaurantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryID] ON [dbo].[RestorantKategoris]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RestaurantID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_RestaurantID] ON [dbo].[RestorantKategoris]
(
	[RestaurantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AppUserID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_AppUserID] ON [dbo].[ShoppingCarts]
(
	[AppUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MealID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_MealID] ON [dbo].[ShoppingCarts]
(
	[MealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RestaurantID]    Script Date: 18.06.2019 18:44:31 ******/
CREATE NONCLUSTERED INDEX [IX_RestaurantID] ON [dbo].[ShoppingCarts]
(
	[RestaurantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addresss] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Addresss] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [RestaurantID]
GO
ALTER TABLE [dbo].[AppUsers] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Countrys] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Countrys] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [ProvinceID]
GO
ALTER TABLE [dbo].[Districts] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Districts] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [CountryID]
GO
ALTER TABLE [dbo].[Meals] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Meals] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [CategoryID]
GO
ALTER TABLE [dbo].[Meals] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [RestaurantID]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [OrderID]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [RestaurantID]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [AppUserID]
GO
ALTER TABLE [dbo].[Provinces] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[Restaurants] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[RestorantKategoris] ADD  CONSTRAINT [DF_RestorantKategoris_ID]  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[ShoppingCarts] ADD  DEFAULT (newsequentialid()) FOR [ID]
GO
ALTER TABLE [dbo].[ShoppingCarts] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [RestaurantID]
GO
ALTER TABLE [dbo].[Addresss]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Addresss_dbo.AppUsers_AppUserID] FOREIGN KEY([AppUserID])
REFERENCES [dbo].[AppUsers] ([ID])
GO
ALTER TABLE [dbo].[Addresss] CHECK CONSTRAINT [FK_dbo.Addresss_dbo.AppUsers_AppUserID]
GO
ALTER TABLE [dbo].[Addresss]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Addresss_dbo.Countrys_CountryID] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countrys] ([ID])
GO
ALTER TABLE [dbo].[Addresss] CHECK CONSTRAINT [FK_dbo.Addresss_dbo.Countrys_CountryID]
GO
ALTER TABLE [dbo].[Addresss]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Addresss_dbo.Districts_DistrictID] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[Districts] ([ID])
GO
ALTER TABLE [dbo].[Addresss] CHECK CONSTRAINT [FK_dbo.Addresss_dbo.Districts_DistrictID]
GO
ALTER TABLE [dbo].[Addresss]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Addresss_dbo.Provinces_ProvinceID] FOREIGN KEY([ProvinceID])
REFERENCES [dbo].[Provinces] ([ID])
GO
ALTER TABLE [dbo].[Addresss] CHECK CONSTRAINT [FK_dbo.Addresss_dbo.Provinces_ProvinceID]
GO
ALTER TABLE [dbo].[Addresss]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Addresss_dbo.Restaurants_RestaurantID] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurants] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Addresss] CHECK CONSTRAINT [FK_dbo.Addresss_dbo.Restaurants_RestaurantID]
GO
ALTER TABLE [dbo].[Countrys]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Countrys_dbo.Provinces_ProvinceID] FOREIGN KEY([ProvinceID])
REFERENCES [dbo].[Provinces] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Countrys] CHECK CONSTRAINT [FK_dbo.Countrys_dbo.Provinces_ProvinceID]
GO
ALTER TABLE [dbo].[Districts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Districts_dbo.Countrys_CountryID] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countrys] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Districts] CHECK CONSTRAINT [FK_dbo.Districts_dbo.Countrys_CountryID]
GO
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Meals_dbo.Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meals] CHECK CONSTRAINT [FK_dbo.Meals_dbo.Categories_CategoryID]
GO
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Meals_dbo.Restaurants_RestaurantID] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurants] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meals] CHECK CONSTRAINT [FK_dbo.Meals_dbo.Restaurants_RestaurantID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Meals_MealID] FOREIGN KEY([MealID])
REFERENCES [dbo].[Meals] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Meals_MealID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.AppUsers_AppUserID] FOREIGN KEY([AppUserID])
REFERENCES [dbo].[AppUsers] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.AppUsers_AppUserID]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Restaurants_RestaurantID] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurants] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Restaurants_RestaurantID]
GO
ALTER TABLE [dbo].[RestorantKategoris]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RestorantKategoris_dbo.Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestorantKategoris] CHECK CONSTRAINT [FK_dbo.RestorantKategoris_dbo.Categories_CategoryID]
GO
ALTER TABLE [dbo].[RestorantKategoris]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RestorantKategoris_dbo.Restaurants_RestaurantID] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurants] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestorantKategoris] CHECK CONSTRAINT [FK_dbo.RestorantKategoris_dbo.Restaurants_RestaurantID]
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShoppingCarts_dbo.AppUsers_AppUserID] FOREIGN KEY([AppUserID])
REFERENCES [dbo].[AppUsers] ([ID])
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_dbo.ShoppingCarts_dbo.AppUsers_AppUserID]
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShoppingCarts_dbo.Meals_MealID] FOREIGN KEY([MealID])
REFERENCES [dbo].[Meals] ([ID])
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_dbo.ShoppingCarts_dbo.Meals_MealID]
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShoppingCarts_dbo.Restaurants_RestaurantID] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurants] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_dbo.ShoppingCarts_dbo.Restaurants_RestaurantID]
GO
USE [master]
GO
ALTER DATABASE [ProjeYemekSepeti] SET  READ_WRITE 
GO

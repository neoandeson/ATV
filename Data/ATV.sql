USE [master]
GO
/****** Object:  Database [ATV]    Script Date: 8/25/2019 11:18:13 AM ******/
CREATE DATABASE [ATV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ATV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.TIENTPSQL\MSSQL\DATA\ATV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ATV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.TIENTPSQL\MSSQL\DATA\ATV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ATV] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ATV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ATV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ATV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ATV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ATV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ATV] SET ARITHABORT OFF 
GO
ALTER DATABASE [ATV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ATV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ATV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ATV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ATV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ATV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ATV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ATV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ATV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ATV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ATV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ATV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ATV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ATV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ATV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ATV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ATV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ATV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ATV] SET  MULTI_USER 
GO
ALTER DATABASE [ATV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ATV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ATV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ATV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ATV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ATV] SET QUERY_STORE = OFF
GO
USE [ATV]
GO
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 8/25/2019 11:18:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ActorId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_BusinessLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 8/25/2019 11:18:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ContractTypeId] [int] NOT NULL,
	[Discount] [float] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndaDate] [datetime] NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteBy] [int] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractDetail]    Script Date: 8/25/2019 11:18:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nchar](10) NOT NULL,
	[DurationSecond] [int] NOT NULL,
	[JSONSchedule] [nvarchar](max) NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteBy] [int] NULL,
 CONSTRAINT [PK_ContractDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Phone1] [nvarchar](14) NOT NULL,
	[Phone2] [nvarchar](14) NULL,
	[Fax] [nvarchar](14) NULL,
	[TaxCode] [nvarchar](11) NULL,
	[CustomerTypeId] [nvarchar](10) NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteBy] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[Id] [int] NULL,
	[PriceRate] [float] NULL,
	[Dicount] [float] NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteBy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duration]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Length] [int] NOT NULL,
	[StatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteBy] [int] NULL,
 CONSTRAINT [PK_Duration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Level] [int] NOT NULL,
	[ParentName] [nvarchar](30) NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceTag]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [float] NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteBy] [int] NULL,
 CONSTRAINT [PK_PriceTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleHasMenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
 CONSTRAINT [PK_RoleHasMenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Clock] [int] NOT NULL,
	[PriceTagId] [int] NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteBy] [int] NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemLog]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_SystemLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/25/2019 11:18:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteBy] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[RoleHasMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_RoleHasMenuItem_MenuItem] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItem] ([Id])
GO
ALTER TABLE [dbo].[RoleHasMenuItem] CHECK CONSTRAINT [FK_RoleHasMenuItem_MenuItem]
GO
ALTER TABLE [dbo].[RoleHasMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_RoleHasMenuItem_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleHasMenuItem] CHECK CONSTRAINT [FK_RoleHasMenuItem_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [ATV] SET  READ_WRITE 
GO

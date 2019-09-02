USE [master]
GO
/****** Object:  Database [ATV]    Script Date: 03/09/2019 6:13:43 AM ******/
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
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[ActorId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_BusinessLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](10) NOT NULL,
	[CustomerCode] [nvarchar](20) NOT NULL,
	[ContractTypeId] [int] NOT NULL,
	[Cost] [float] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractDetail]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractCode] [nvarchar](10) NOT NULL,
	[ProductName] [nvarchar](80) NOT NULL,
	[DurationSecond] [int] NOT NULL,
	[NumberOfShow] [int] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_ContractDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractType]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_ContractType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 03/09/2019 6:13:44 AM ******/
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
	[TaxCode] [nvarchar](10) NULL,
	[CustomerTypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerType]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriceRate] [float] NULL,
	[Dicount] [float] NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duration]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Length] [int] NOT NULL,
	[StatusId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Duration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 03/09/2019 6:13:44 AM ******/
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
/****** Object:  Table [dbo].[ProductScheduleShow]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductScheduleShow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractDetailId] [int] NOT NULL,
	[ShowDate] [nvarchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[TimeSlot] [nvarchar](50) NOT NULL,
	[TimeSlotLength] [int] NOT NULL,
	[Cost] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[TotalCost] [float] NOT NULL,
 CONSTRAINT [PK_ProductScheduleShow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 03/09/2019 6:13:44 AM ******/
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
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 03/09/2019 6:13:44 AM ******/
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
/****** Object:  Table [dbo].[Session]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Session_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ValueString] [nvarchar](50) NULL,
	[ValueNumber] [float] NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_SystemConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemLog]    Script Date: 03/09/2019 6:13:44 AM ******/
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
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FromHour] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[SessionCode] [char](1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/09/2019 6:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateBy] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contract] ON 

INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [ContractTypeId], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'HD00020919', N'SAOTHUY', 2, 0, CAST(N'2019-09-02T10:07:37.803' AS DateTime), CAST(N'2019-09-30T10:07:37.000' AS DateTime), 1, CAST(N'2019-09-02T10:08:01.833' AS DateTime), CAST(N'2019-09-02T10:08:01.837' AS DateTime), 2)
INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [ContractTypeId], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'HD00030919', N'HOASEN', 3, 0, CAST(N'2019-09-04T10:31:00.000' AS DateTime), CAST(N'2019-09-29T10:31:00.000' AS DateTime), 1, CAST(N'2019-09-02T10:31:57.577' AS DateTime), CAST(N'2019-09-02T10:31:57.583' AS DateTime), 2)
INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [ContractTypeId], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'HD00010919', N'SAOTHUY', 2, 7720000, CAST(N'2019-09-04T12:30:20.000' AS DateTime), CAST(N'2019-09-30T12:30:20.000' AS DateTime), 1, CAST(N'2019-09-02T12:30:31.560' AS DateTime), CAST(N'2019-09-03T05:17:01.027' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Contract] OFF
SET IDENTITY_INSERT [dbo].[ContractDetail] ON 

INSERT [dbo].[ContractDetail] ([Id], [ContractCode], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'HD00010919', N'Hợp tác bánh kẹo', 15, 7, 7720000, 1, CAST(N'2019-09-02T13:34:23.863' AS DateTime), CAST(N'2019-09-03T05:17:00.077' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ContractDetail] OFF
SET IDENTITY_INSERT [dbo].[ContractType] ON 

INSERT [dbo].[ContractType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'Quảng cáo', NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[ContractType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'Tài trợ', NULL, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ContractType] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [CustomerTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'SAOTHUY', N'Công ty TNHH Sao Thủy', N'55 Võ Chí Công, Phường 4, Quận Tân Bình', N'0988457649', N'38386688', N'111222333', N'5643718296', 2, 1, NULL, NULL, NULL)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [CustomerTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'HOASEN', N'Công ty TMCP Tôn Hoa Sen', N'113/3B Dĩ An, Bình Dương', N'091872348', N'', N'012803812', N'9487639898', 6, 1, NULL, CAST(N'2019-08-27T00:04:43.053' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [CustomerTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'THAIDUONG', N'Công ty TNHH sao Thái Dương', N'15A CMT8, P3, Q.Tân Bình', N'0923423940', N'080913040', N'343489289', N'9280948021', 4, 1, NULL, CAST(N'2019-09-03T05:34:07.993' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[CustomerType] ON 

INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'Chính thức', NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'Ngắn hạn', NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'Dài hạn', NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'Tài trợ', NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'Quảng bá', NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (7, N'Rao vặt', N'thông tin mua bán hiển thị nhanh trong 5s', -1, NULL, CAST(N'2019-08-27T20:48:19.803' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([Id], [PriceRate], [Dicount], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (0, 1000000, 1, 1, CAST(N'2019-08-27T22:11:59.670' AS DateTime), CAST(N'2019-09-02T17:36:43.097' AS DateTime), 2)
INSERT [dbo].[Discount] ([Id], [PriceRate], [Dicount], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, 50000000, 7, -1, CAST(N'2019-08-27T22:19:29.817' AS DateTime), CAST(N'2019-08-27T22:21:37.563' AS DateTime), 2)
INSERT [dbo].[Discount] ([Id], [PriceRate], [Dicount], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, 5000000, 5, 1, CAST(N'2019-09-02T17:37:20.320' AS DateTime), CAST(N'2019-09-02T17:37:20.323' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Discount] OFF
SET IDENTITY_INSERT [dbo].[Duration] ON 

INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, 5, 1, CAST(N'2019-08-27T22:50:04.877' AS DateTime), CAST(N'2019-08-27T22:50:04.883' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, 10, 1, CAST(N'2019-08-27T22:51:01.190' AS DateTime), CAST(N'2019-08-27T22:51:01.190' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, 15, 1, CAST(N'2019-08-27T22:51:09.467' AS DateTime), CAST(N'2019-08-27T22:51:09.467' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, 20, -1, CAST(N'2019-08-27T22:51:16.787' AS DateTime), CAST(N'2019-08-27T22:53:10.553' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, 30, 1, CAST(N'2019-09-03T05:17:40.037' AS DateTime), CAST(N'2019-09-03T05:17:40.037' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Duration] OFF
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1, N'Danh mục', 0, NULL, 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (2, N'Danh mục khách hàng', 1, N'Danh mục', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (3, N'Danh mục loại hình khách hàng', 1, N'Danh mục', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (4, N'Danh mục giảm giá', 1, N'Danh mục', 7)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (5, N'Danh mục thời lượng', 1, N'Danh mục', 6)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (6, N'Danh mục buổi phát', 1, N'Danh mục', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (7, N'Danh mục thời điểm', 1, N'Danh mục', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (8, N'Nhập liệu', 0, NULL, 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (9, N'Hợp đồng quảng cáo', 1, N'Nhập liệu', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (10, N'In ấn', 1, N'Nhập liệu', 1)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[ProductScheduleShow] ON 

INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (1, 1, N'02/09/2019', 5, N'Chào buổi sáng', 15, 5000000, 5, 4750000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (2, 1, N'03/09/2019', 1, N'Chào buổi sáng', 15, 1000000, 1, 990000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (3, 1, N'04/09/2019', 1, N'Thời sự trưa', 15, 2000000, 1, 1980000)
SET IDENTITY_INSERT [dbo].[ProductScheduleShow] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'staff')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] ON 

INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (1, 2, 1)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (2, 2, 2)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (3, 2, 3)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (5, 2, 4)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (6, 2, 5)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (7, 2, 6)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (8, 2, 7)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (9, 2, 8)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (10, 2, 9)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (11, 2, 10)
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] OFF
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'S', N'Sáng', 1, CAST(N'2019-08-28T23:20:46.053' AS DateTime), CAST(N'2019-08-28T23:20:46.053' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'T', N'Trưa', 1, CAST(N'2019-08-28T23:22:41.523' AS DateTime), CAST(N'2019-08-28T23:22:49.480' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'C', N'Chiều', 1, CAST(N'2019-09-03T05:40:35.437' AS DateTime), CAST(N'2019-09-03T05:40:37.137' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Session] OFF
SET IDENTITY_INSERT [dbo].[SystemConfig] ON 

INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (1, N'ContractNumberInMonth', N'09', 4, N'Giá trị số để tạo ra mã của hợp đồng trong 1 tháng của 1 năm (VD: 00021219). Trở về 1 khi qua tháng mới. ValueString là tháng được ghi')
SET IDENTITY_INSERT [dbo].[SystemConfig] OFF
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [Length], [Price], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'S1        ', N'Chào buổi sáng', 500, 5, 1000000, N'S', 1, CAST(N'2019-08-31T22:18:01.497' AS DateTime), CAST(N'2019-09-01T18:34:14.453' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [Length], [Price], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'T1        ', N'Thời sự trưa', 1200, 10, 2000000, N'T', 1, CAST(N'2019-08-31T22:53:34.260' AS DateTime), CAST(N'2019-09-01T18:34:50.403' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [Length], [Price], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'S2        ', N'Tập thể dục', 500, 5, 2000000, N'S', 1, CAST(N'2019-09-03T05:46:54.540' AS DateTime), CAST(N'2019-09-03T05:46:56.937' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [Length], [Price], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'S3        ', N'Thời sự sáng', 530, 5, 2000000, N'S', 1, CAST(N'2019-09-03T05:50:44.623' AS DateTime), CAST(N'2019-09-03T05:50:44.623' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [Length], [Price], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'S1        ', N'Chào buổi sáng', 500, 10, 1500000, N'S', 1, CAST(N'2019-09-03T06:10:45.897' AS DateTime), CAST(N'2019-09-03T06:10:45.897' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'admin', N'ABEaDKz5yOzdvn2l6pc2iwzT8yPwXc/6Ikb8kxy1Qt6ejj8ZWwdws1F5PLbrIFIqWQ==', N'AD0001', N'Admin', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'staff', N'ABEaDKz5yOzdvn2l6pc2iwzT8yPwXc/6Ikb8kxy1Qt6ejj8ZWwdws1F5PLbrIFIqWQ==', N'NV0002', N'Admin', 2, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNIQUE_CODE_SESSION]    Script Date: 03/09/2019 6:13:44 AM ******/
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [UNIQUE_CODE_SESSION] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContractDetail] ADD  CONSTRAINT [DF_ContractDetail_ContractCode]  DEFAULT ((0)) FOR [ContractCode]
GO
ALTER TABLE [dbo].[TimeSlot] ADD  CONSTRAINT [DF_TimeSlot_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerType] FOREIGN KEY([CustomerTypeId])
REFERENCES [dbo].[CustomerType] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_CustomerType]
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

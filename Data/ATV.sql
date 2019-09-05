USE [master]
GO
/****** Object:  Database [ATV]    Script Date: 06/09/2019 1:07:39 AM ******/
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
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 06/09/2019 1:07:39 AM ******/
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
/****** Object:  Table [dbo].[Contract]    Script Date: 06/09/2019 1:07:39 AM ******/
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
/****** Object:  Table [dbo].[ContractDetail]    Script Date: 06/09/2019 1:07:39 AM ******/
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
/****** Object:  Table [dbo].[ContractType]    Script Date: 06/09/2019 1:07:39 AM ******/
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
/****** Object:  Table [dbo].[CostRule]    Script Date: 06/09/2019 1:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostRule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeSlotId] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_CostRule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 06/09/2019 1:07:39 AM ******/
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
/****** Object:  Table [dbo].[CustomerType]    Script Date: 06/09/2019 1:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](100) NULL,
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
/****** Object:  Table [dbo].[Discount]    Script Date: 06/09/2019 1:07:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriceRate] [float] NULL,
	[DiscountPercent] [float] NULL,
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
/****** Object:  Table [dbo].[Duration]    Script Date: 06/09/2019 1:07:39 AM ******/
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
/****** Object:  Table [dbo].[MenuItem]    Script Date: 06/09/2019 1:07:39 AM ******/
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
/****** Object:  Table [dbo].[ProductScheduleShow]    Script Date: 06/09/2019 1:07:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductScheduleShow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractDetailId] [int] NOT NULL,
	[ProductName] [nvarchar](80) NOT NULL,
	[ShowTime] [varchar](5) NOT NULL,
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
/****** Object:  Table [dbo].[Role]    Script Date: 06/09/2019 1:07:40 AM ******/
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
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 06/09/2019 1:07:40 AM ******/
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
/****** Object:  Table [dbo].[Session]    Script Date: 06/09/2019 1:07:40 AM ******/
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
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 06/09/2019 1:07:40 AM ******/
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
/****** Object:  Table [dbo].[SystemLog]    Script Date: 06/09/2019 1:07:40 AM ******/
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
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 06/09/2019 1:07:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FromHour] [int] NOT NULL,
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
/****** Object:  Table [dbo].[User]    Script Date: 06/09/2019 1:07:40 AM ******/
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

INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [ContractTypeId], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'HD00040919', N'VINAMILK', 1, 0, CAST(N'2019-09-05T00:13:58.387' AS DateTime), CAST(N'2019-09-30T00:13:58.000' AS DateTime), -2, CAST(N'2019-09-05T00:15:26.613' AS DateTime), CAST(N'2019-09-05T00:18:48.060' AS DateTime), 2)
INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [ContractTypeId], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'HD00010919', N'VINAMILK', 1, 32000000, CAST(N'2019-09-05T00:18:53.427' AS DateTime), CAST(N'2019-09-30T00:18:53.000' AS DateTime), 1, CAST(N'2019-09-05T00:19:03.077' AS DateTime), CAST(N'2019-09-06T00:15:28.097' AS DateTime), 2)
INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [ContractTypeId], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1002, N'HD00020919', N'DHGPHARMA', 1, 69500000, CAST(N'2019-09-06T00:32:32.317' AS DateTime), CAST(N'2019-09-30T00:32:32.000' AS DateTime), 1, CAST(N'2019-09-06T00:32:53.770' AS DateTime), CAST(N'2019-09-06T00:42:46.323' AS DateTime), 2)
INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [ContractTypeId], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1003, N'HD00030919', N'TANHIEPPHAT', 2, 130000000, CAST(N'2019-09-06T00:43:01.383' AS DateTime), CAST(N'2019-09-30T00:43:01.000' AS DateTime), 1, CAST(N'2019-09-06T00:43:19.590' AS DateTime), CAST(N'2019-09-06T00:50:31.730' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Contract] OFF
SET IDENTITY_INSERT [dbo].[ContractDetail] ON 

INSERT [dbo].[ContractDetail] ([Id], [ContractCode], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'HD00010919', N'Sữa tươi hộp pha sẵn', 15, 8, 32000000, 1, CAST(N'2019-09-05T00:19:27.017' AS DateTime), CAST(N'2019-09-06T00:15:27.057' AS DateTime), 2)
INSERT [dbo].[ContractDetail] ([Id], [ContractCode], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'HD00020919', N'Vì cuộc sống khỏe đẹp', 20, 4, 69500000, 1, CAST(N'2019-09-06T00:34:16.020' AS DateTime), CAST(N'2019-09-06T00:42:33.353' AS DateTime), 2)
INSERT [dbo].[ContractDetail] ([Id], [ContractCode], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'HD00030919', N'Dây chuyền sản xuất hiện đại', 120, 1, 108000000, 1, CAST(N'2019-09-06T00:43:47.207' AS DateTime), CAST(N'2019-09-06T00:45:24.560' AS DateTime), 2)
INSERT [dbo].[ContractDetail] ([Id], [ContractCode], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'HD00030919', N'Trà Doctor Thanh', 5, 2, 22000000, 1, CAST(N'2019-09-06T00:49:03.957' AS DateTime), CAST(N'2019-09-06T00:50:29.630' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ContractDetail] OFF
SET IDENTITY_INSERT [dbo].[ContractType] ON 

INSERT [dbo].[ContractType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'Quảng cáo', N'Video thông tin ngắn', 1, CAST(N'2019-09-04T23:31:46.770' AS DateTime), CAST(N'2019-09-04T23:31:46.770' AS DateTime), 2)
INSERT [dbo].[ContractType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'Tự giới thiệu', N'Video thông tin dài', 1, CAST(N'2019-09-04T23:31:46.770' AS DateTime), CAST(N'2019-09-04T23:31:46.770' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ContractType] OFF
SET IDENTITY_INSERT [dbo].[CostRule] ON 

INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1, 1, 10, 1000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (2, 1, 15, 2000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (3, 1, 20, 3000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (4, 2, 5, 2000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (5, 2, 10, 4000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (6, 2, 15, 5000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (7, 2, 20, 8000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (8, 3, 5, 8000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (9, 3, 10, 10000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (10, 3, 15, 15000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (11, 3, 20, 20000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1002, 1, 5, 0)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1003, 1002, 5, 10000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1004, 1002, 15, 15000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1005, 1003, 15, 20000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1006, 1003, 20, 25000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1007, 1004, 10, 10000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1008, 1004, 15, 15000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1009, 1004, 20, 20000000)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price]) VALUES (1010, 1004, 120, 120000000)
SET IDENTITY_INSERT [dbo].[CostRule] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [CustomerTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'VINAMILK', N'Công ty Cổ phần Sữa Việt Nam Vinamilk', N'Số 10, Đường Tân Trào, phường Tân Phú, quận 7, Tp. HCM', N'84028541', N'', N'840285416', N'5489098098', 6, 1, NULL, CAST(N'2019-09-04T23:25:30.570' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [CustomerTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'DHGPHARMA', N'Công Ty Cp Dược Hậu Giang', N'200 Cô Bắc, Phường Cô Giang, 1, Hồ Chí Minh', N'028 3836 9353', N'', N'', N'', 2, 1, NULL, CAST(N'2019-09-04T23:28:33.580' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [CustomerTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'TANHIEPPHAT', N'Tập đoàn Nước giải khát Tân Hiệp Phát', N'219 Đại lộ Bình Dương, Vĩnh Phú, Thuận An, Bình Dương', N'0898 760 066', N'', N'', N'7236472347', 4, 1, NULL, CAST(N'2019-09-04T23:29:40.380' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[CustomerType] ON 

INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'Giải trí', N'Quảng cáo, show truyền hình', 1, CAST(N'2019-09-04T23:17:24.093' AS DateTime), CAST(N'2019-09-04T23:18:33.290' AS DateTime), 2)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'Dược phẩm', N'Thuốc, thực phẩm chức năng', 1, CAST(N'2019-09-04T23:18:23.520' AS DateTime), CAST(N'2019-09-04T23:18:23.520' AS DateTime), 2)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'Thực phẩm', N'Ăn uống', 1, CAST(N'2019-09-04T23:18:56.613' AS DateTime), CAST(N'2019-09-04T23:18:56.613' AS DateTime), 2)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'Giải khát', N'Nước suối, nước ngọt, bia', 1, CAST(N'2019-09-04T23:19:38.707' AS DateTime), CAST(N'2019-09-04T23:19:38.707' AS DateTime), 2)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'Sản xuất', N'Hãng, xưởng, lắp ráp', 1, CAST(N'2019-09-04T23:20:27.707' AS DateTime), CAST(N'2019-09-04T23:20:27.707' AS DateTime), 2)
INSERT [dbo].[CustomerType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'Sữa', N'Sữa cho mẹ, cho bé, cho trẻ em', 1, CAST(N'2019-09-04T23:21:53.747' AS DateTime), CAST(N'2019-09-04T23:21:53.747' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([Id], [PriceRate], [DiscountPercent], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, 5000000, 0, 1, CAST(N'2019-09-04T23:36:23.533' AS DateTime), CAST(N'2019-09-04T23:36:23.533' AS DateTime), 2)
INSERT [dbo].[Discount] ([Id], [PriceRate], [DiscountPercent], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, 50000000, 7, 1, CAST(N'2019-09-04T23:36:38.123' AS DateTime), CAST(N'2019-09-04T23:36:38.123' AS DateTime), 2)
INSERT [dbo].[Discount] ([Id], [PriceRate], [DiscountPercent], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, 100000000, 10, 1, CAST(N'2019-09-04T23:37:21.397' AS DateTime), CAST(N'2019-09-04T23:37:21.397' AS DateTime), 2)
INSERT [dbo].[Discount] ([Id], [PriceRate], [DiscountPercent], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, 200000000, 12, 1, CAST(N'2019-09-04T23:37:49.190' AS DateTime), CAST(N'2019-09-04T23:37:49.190' AS DateTime), 2)
INSERT [dbo].[Discount] ([Id], [PriceRate], [DiscountPercent], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, 500000000, 15, 1, CAST(N'2019-09-04T23:38:08.490' AS DateTime), CAST(N'2019-09-04T23:38:08.490' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Discount] OFF
SET IDENTITY_INSERT [dbo].[Duration] ON 

INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, 5, 1, CAST(N'2019-09-04T23:34:13.217' AS DateTime), CAST(N'2019-09-04T23:34:13.217' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, 10, 1, CAST(N'2019-09-04T23:34:19.267' AS DateTime), CAST(N'2019-09-04T23:34:19.267' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, 15, 1, CAST(N'2019-09-04T23:34:24.580' AS DateTime), CAST(N'2019-09-04T23:34:24.580' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, 20, 1, CAST(N'2019-09-04T23:34:32.113' AS DateTime), CAST(N'2019-09-04T23:34:32.113' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, 30, 1, CAST(N'2019-09-04T23:34:41.683' AS DateTime), CAST(N'2019-09-04T23:34:41.683' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, 120, 1, CAST(N'2019-09-04T23:34:48.403' AS DateTime), CAST(N'2019-09-04T23:34:52.253' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (7, 60, 1, CAST(N'2019-09-04T23:34:59.370' AS DateTime), CAST(N'2019-09-04T23:34:59.370' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (8, 90, 1, CAST(N'2019-09-04T23:35:52.730' AS DateTime), CAST(N'2019-09-04T23:35:52.730' AS DateTime), 2)
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
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (10, N'In ấn', 0, NULL, 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (11, N'In lịch phát sóng', 1, N'In ấn', 1)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[ProductScheduleShow] ON 

INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (1, 1, N'Sữa tươi hộp pha sẵn', N'06:00', N'05/09/2019', 3, N'Thời sự buổi sáng', 5, 24000000, 0, 24000000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (2, 1, N'Sữa tươi hộp pha sẵn', N'05:00', N'06/09/2019', 1, N'Tập thể dục buổi sáng', 10, 1000000, 0, 1000000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (4, 1, N'Sữa tươi hộp pha sẵn', N'05:00', N'08/09/2019', 1, N'Tập thể dục buổi sáng', 10, 1000000, 0, 1000000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (5, 1, N'Sữa tươi hộp pha sẵn', N'05:30', N'07/09/2019', 3, N'Chào buổi sáng', 5, 6000000, 0, 6000000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (6, 2, N'Vì cuộc sống khỏe đẹp', N'05:30', N'06/09/2019', 1, N'Thông tin ngày mới', 20, 20000000, 0, 20000000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (7, 2, N'Vì cuộc sống khỏe đẹp', N'06:25', N'07/09/2019', 2, N'Phim truyện buổi sáng', 20, 50000000, 7, 46500000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (8, 2, N'Vì cuộc sống khỏe đẹp', N'05:05', N'06/09/2019', 1, N'Tập thể dục buổi sáng', 20, 3000000, 0, 3000000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (9, 3, N'Dây chuyền sản xuất hiện đại', N'07:00', N'06/09/2019', 1, N'Chuyên mục cải cách hành chính', 120, 120000000, 10, 108000000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (10, 4, N'Trà Doctor Thanh', N'05:10', N'06/09/2019', 1, N'Ca nhạc', 5, 2000000, 0, 2000000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (11, 4, N'Trà Doctor Thanh', N'06:25', N'06/09/2019', 1, N'Phim truyện buổi sáng', 15, 20000000, 0, 20000000)
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
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (12, 2, 11)
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] OFF
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'A', N'Sáng', 1, CAST(N'2019-09-04T23:30:21.223' AS DateTime), CAST(N'2019-09-04T23:31:46.770' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'B', N'Trưa', 1, CAST(N'2019-09-04T23:30:51.090' AS DateTime), CAST(N'2019-09-04T23:31:54.340' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'C', N'Xế', 1, CAST(N'2019-09-04T23:31:02.340' AS DateTime), CAST(N'2019-09-04T23:31:57.170' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'D', N'Chiều', 1, CAST(N'2019-09-04T23:31:11.707' AS DateTime), CAST(N'2019-09-04T23:31:59.780' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'E', N'Tối', 1, CAST(N'2019-09-04T23:33:14.517' AS DateTime), CAST(N'2019-09-04T23:33:14.517' AS DateTime), 2)
INSERT [dbo].[Session] ([Id], [Code], [Name], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'F', N'Khuya', 1, CAST(N'2019-09-04T23:33:31.090' AS DateTime), CAST(N'2019-09-04T23:50:34.867' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Session] OFF
SET IDENTITY_INSERT [dbo].[SystemConfig] ON 

INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (1, N'ContractNumberInMonth', N'09', 4, N'Giá trị số để tạo ra mã của hợp đồng trong 1 tháng của 1 năm (VD: 00021219). Trở về 1 khi qua tháng mới. ValueString là tháng được ghi')
SET IDENTITY_INSERT [dbo].[SystemConfig] OFF
SET IDENTITY_INSERT [dbo].[SystemLog] ON 

INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1, N'   at System.Data.Entity.Internal.InternalContext.SaveChanges()
   at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
   at System.Data.Entity.DbContext.SaveChanges()
   at DataService.Infrastructure.Repository`1.Add(TEntity entity) in H:\Project\ATV2\ATV_Advertisment\DataService\Infrastructure\IRepository.cs:line 49
   at ATV_Advertisment.Services.ProductScheduleShowService.AddProductScheduleShow(ProductScheduleShow input) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Services\ProductScheduleShowService.cs:line 42
   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 127', CAST(N'2019-09-05T00:19:50.903' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (2, N'   at System.Data.Entity.Internal.InternalContext.SaveChanges()
   at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
   at System.Data.Entity.DbContext.SaveChanges()
   at DataService.Infrastructure.Repository`1.Add(TEntity entity) in H:\Project\ATV2\ATV_Advertisment\DataService\Infrastructure\IRepository.cs:line 49
   at ATV_Advertisment.Services.ProductScheduleShowService.AddProductScheduleShow(ProductScheduleShow input) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Services\ProductScheduleShowService.cs:line 42
   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 130', CAST(N'2019-09-05T00:27:23.460' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1002, N'   at System.Data.Entity.Internal.InternalContext.SaveChanges()
   at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
   at System.Data.Entity.DbContext.SaveChanges()
   at DataService.Infrastructure.Repository`1.Update(TEntity entityToUpdate) in H:\Project\ATV2\ATV_Advertisment\DataService\Infrastructure\IRepository.cs:line 56
   at ATV_Advertisment.Services.ProductScheduleShowService.EditProductScheduleShow(ProductScheduleShow input) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Services\ProductScheduleShowService.cs:line 96
   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 154', CAST(N'2019-09-05T23:21:58.680' AS DateTime), 1)
INSERT [dbo].[SystemLog] ([Id], [Content], [Date], [TypeId]) VALUES (1003, N'   at ATV_Advertisment.Forms.DetailForms.ProductScheduleDetailForm.btnSave_Click(Object sender, EventArgs e) in H:\Project\ATV2\ATV_Advertisment\ATV_Advertisment\Forms\DetailForms\ProductScheduleDetailForm.cs:line 152', CAST(N'2019-09-05T23:55:59.197' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[SystemLog] OFF
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'S1', N'Tập thể dục buổi sáng', 505, N'A', 1, CAST(N'2019-09-05T00:06:57.023' AS DateTime), CAST(N'2019-09-06T00:26:30.210' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'S2', N'Ca nhạc', 510, N'A', 1, CAST(N'2019-09-05T00:07:54.950' AS DateTime), CAST(N'2019-09-06T00:19:34.403' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'S3', N'Thông tin ngày mới', 530, N'A', 1, CAST(N'2019-09-05T00:08:45.693' AS DateTime), CAST(N'2019-09-06T00:28:09.010' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1002, N'S4', N'Chương trình thiếu nhi', 600, N'A', 1, CAST(N'2019-09-06T00:27:25.727' AS DateTime), CAST(N'2019-09-06T00:27:25.727' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1003, N'S5', N'Phim truyện buổi sáng', 625, N'A', 1, CAST(N'2019-09-06T00:28:40.883' AS DateTime), CAST(N'2019-09-06T00:28:40.883' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1004, N'S6', N'Chuyên mục cải cách hành chính', 700, N'A', 1, CAST(N'2019-09-06T00:29:48.930' AS DateTime), CAST(N'2019-09-06T00:29:48.930' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'admin', N'ABEaDKz5yOzdvn2l6pc2iwzT8yPwXc/6Ikb8kxy1Qt6ejj8ZWwdws1F5PLbrIFIqWQ==', N'AD0001', N'Admin', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'staff', N'ABEaDKz5yOzdvn2l6pc2iwzT8yPwXc/6Ikb8kxy1Qt6ejj8ZWwdws1F5PLbrIFIqWQ==', N'NV0002', N'Admin', 2, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNIQUE_CODE_SESSION]    Script Date: 06/09/2019 1:07:40 AM ******/
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [UNIQUE_CODE_SESSION] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContractDetail] ADD  CONSTRAINT [DF_ContractDetail_ContractCode]  DEFAULT ((0)) FOR [ContractCode]
GO
ALTER TABLE [dbo].[CostRule] ADD  CONSTRAINT [DF_CostRule_Price]  DEFAULT ((0)) FOR [Price]
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

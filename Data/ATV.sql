USE [master]
GO
/****** Object:  Database [ATV]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[BusinessLog]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[Contract]    Script Date: 13/10/2019 9:12:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nchar](10) NOT NULL,
	[CustomerCode] [nvarchar](20) NOT NULL,
	[CustomerName] [nvarchar](200) NULL,
	[SumCost] [float] NOT NULL,
	[Discount] [float] NOT NULL,
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
/****** Object:  Table [dbo].[ContractItem]    Script Date: 13/10/2019 9:12:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractCode] [nvarchar](10) NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[DurationSecond] [int] NOT NULL,
	[NumberOfShow] [int] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[ShowTypeId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[CostRule]    Script Date: 13/10/2019 9:12:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostRule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeSlotId] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[ShowTypeId] [int] NOT NULL,
 CONSTRAINT [PK_CostRule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[Duration]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[MenuItem]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[ProductScheduleShow]    Script Date: 13/10/2019 9:12:48 PM ******/
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
	[ShowTypeId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Role]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[RoleHasMenuItem]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[Session]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[ShowType]    Script Date: 13/10/2019 9:12:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShowType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[SystemLog]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 13/10/2019 9:12:48 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 13/10/2019 9:12:48 PM ******/
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

INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [CustomerName], [SumCost], [Discount], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'HD0041019 ', N'VINAMILK', N'Vinamilk', 113400000, 10, 102060000, CAST(N'2019-10-13T14:29:35.050' AS DateTime), CAST(N'2019-10-30T14:29:35.000' AS DateTime), 1, CAST(N'2019-10-13T14:29:48.300' AS DateTime), CAST(N'2019-10-13T15:40:29.317' AS DateTime), 2)
INSERT [dbo].[Contract] ([Id], [Code], [CustomerCode], [CustomerName], [SumCost], [Discount], [Cost], [StartDate], [EndDate], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'HD0051019 ', N'TANHIEPPHAT', N'Tập đoàn Nước giải khát Tân Hiệp Phát', 0, 0, 0, CAST(N'2019-10-13T18:58:42.043' AS DateTime), CAST(N'2019-10-13T18:58:42.047' AS DateTime), 1, CAST(N'2019-10-13T18:58:51.470' AS DateTime), CAST(N'2019-10-13T18:58:51.470' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Contract] OFF
SET IDENTITY_INSERT [dbo].[ContractItem] ON 

INSERT [dbo].[ContractItem] ([Id], [ContractCode], [FileName], [ProductName], [DurationSecond], [NumberOfShow], [TotalCost], [ShowTypeId], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'HD0041019', N'123', N'abc', 10, 9, 113400000, 1, 1, CAST(N'2019-10-13T14:30:17.430' AS DateTime), CAST(N'2019-10-13T15:40:13.913' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ContractItem] OFF
SET IDENTITY_INSERT [dbo].[CostRule] ON 

INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (1, 1, 10, 1400000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (2, 1, 15, 1800000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (3, 1, 20, 2300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (4, 1, 30, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (5, 2, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (6, 2, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (7, 3, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (8, 3, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (9, 4, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (10, 4, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (11, 4, 20, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (12, 4, 30, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (13, 5, 10, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (14, 5, 15, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (15, 5, 20, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (16, 5, 30, 5000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (17, 6, 10, 2000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (18, 6, 15, 2500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (19, 6, 20, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (20, 6, 30, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (21, 7, 10, 5200000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (22, 7, 15, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (23, 7, 20, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (24, 7, 30, 9500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (25, 8, 10, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (26, 8, 15, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (27, 8, 20, 8400000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (28, 8, 30, 12000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (29, 9, 10, 5200000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (30, 9, 15, 6300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (31, 9, 20, 7300000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (32, 9, 30, 9500000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (33, 10, 10, 3000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (34, 10, 15, 4000000, 1)
INSERT [dbo].[CostRule] ([Id], [TimeSlotId], [Length], [Price], [ShowTypeId]) VALUES (35, 11, 10, 4500000, 1)
SET IDENTITY_INSERT [dbo].[CostRule] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'VINAMILK', N'Công ty Cổ phần Sữa Việt Nam Vinamilk', N'Số 10, Đường Tân Trào, phường Tân Phú, quận 7, Tp. HCM', N'84028541', N'', N'840285416', N'5489098098', 1, NULL, CAST(N'2019-09-20T14:31:05.460' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'DHGPHARMA', N'Công Ty Cp Dược Hậu Giang', N'200 Cô Bắc, Phường Cô Giang, 1, Hồ Chí Minh', N'028 3836 9353', N'', N'', N'', 1, NULL, CAST(N'2019-09-04T23:28:33.580' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'TANHIEPPHAT', N'Tập đoàn Nước giải khát Tân Hiệp Phát', N'219 Đại lộ Bình Dương, Vĩnh Phú, Thuận An, Bình Dương', N'0898 760 066', N'', N'', N'7236472347', 1, NULL, CAST(N'2019-09-04T23:29:40.380' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1002, N'TKL', N'Công ty CP Truyền thông TK-L', N'222 Pasteur - Phường 06 - Quận 3 - TP. Hồ Chí Minh', N'028-38232246', N'', N'028-38290507', N'0300993574', 1, NULL, CAST(N'2019-09-20T13:14:46.643' AS DateTime), 2)
INSERT [dbo].[Customer] ([Id], [Code], [Name], [Address], [Phone1], [Phone2], [Fax], [TaxCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1003, N'UNILEVER', N'Công ty TNHH Quốc tế Unilever Việt Nam', N'156 Nguyễn Lương Bằng, Phường Tân Phú, Quận 7, Tp Hồ Chí Minh', N'0283892024', N'02854135686', N'', N'', 1, NULL, CAST(N'2019-09-20T13:18:18.550' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Duration] ON 

INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, 10, 1, CAST(N'2019-09-15T11:22:34.643' AS DateTime), CAST(N'2019-09-15T11:22:48.263' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, 15, 1, CAST(N'2019-09-15T11:22:52.600' AS DateTime), CAST(N'2019-09-15T11:22:52.600' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, 20, 1, CAST(N'2019-09-15T11:22:57.657' AS DateTime), CAST(N'2019-09-15T11:22:57.657' AS DateTime), 2)
INSERT [dbo].[Duration] ([Id], [Length], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, 30, 1, CAST(N'2019-09-15T11:23:02.320' AS DateTime), CAST(N'2019-09-15T11:23:02.320' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Duration] OFF
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (1, N'Danh mục', 0, NULL, 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (2, N'Danh mục khách hàng', 1, N'Danh mục', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (3, N'Danh mục loại quảng cáo', 1, N'Danh mục', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (4, N'Báo cáo doanh thu', 1, N'In ấn', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (5, N'Danh mục thời lượng', 1, N'Danh mục', 6)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (6, N'Danh mục buổi phát', 1, N'Danh mục', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (7, N'Danh mục thời điểm', 1, N'Danh mục', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (8, N'Nhập liệu', 0, NULL, 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (9, N'Hợp đồng quảng cáo', 1, N'Nhập liệu', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (10, N'In ấn', 0, NULL, 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (11, N'In lịch phát sóng', 1, N'In ấn', 1)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[ProductScheduleShow] ON 

INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (36, 1, N'123', N'06:30', N'13/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (37, 1, N'123', N'06:30', N'14/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (38, 1, N'123', N'06:30', N'15/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (39, 1, N'123', N'06:30', N'16/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (40, 1, N'123', N'06:30', N'17/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (41, 1, N'123', N'06:30', N'20/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (42, 1, N'123', N'06:30', N'21/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (43, 1, N'123', N'06:30', N'22/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
INSERT [dbo].[ProductScheduleShow] ([Id], [ContractDetailId], [ProductName], [ShowTime], [ShowDate], [ShowTypeId], [Quantity], [TimeSlot], [TimeSlotLength], [Cost], [Discount], [TotalCost]) VALUES (44, 1, N'123', N'06:30', N'23/10/2019', 1, 1, N'Trước phim sáng (đợt I)', 10, 1400000, 0, 12600000)
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
SET IDENTITY_INSERT [dbo].[ShowType] ON 

INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'Quảng cáo', N'Video thông tin ngắn', 1, CAST(N'2019-09-04T23:31:46.770' AS DateTime), CAST(N'2019-09-04T23:31:46.770' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'Tự giới thiệu', N'Video thông tin dài', 1, CAST(N'2019-09-04T23:31:46.770' AS DateTime), CAST(N'2019-09-04T23:31:46.770' AS DateTime), 2)
INSERT [dbo].[ShowType] ([Id], [Type], [Description], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'Popup', N'Hiện cửa sổ nhỏ', 1, CAST(N'2019-09-08T13:42:44.933' AS DateTime), CAST(N'2019-09-08T13:42:44.933' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ShowType] OFF
SET IDENTITY_INSERT [dbo].[SystemConfig] ON 

INSERT [dbo].[SystemConfig] ([Id], [Name], [ValueString], [ValueNumber], [Description]) VALUES (1, N'ContractNumberInMonth', N'10', 6, N'Giá trị số để tạo ra mã của hợp đồng trong 1 tháng của 1 năm (VD: 0021219). Trở về 1 khi qua tháng mới. ValueString là tháng được ghi')
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

INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'A1', N'Trước phim sáng (đợt I)', 630, N'A', 1, CAST(N'2019-09-15T11:26:29.630' AS DateTime), CAST(N'2019-09-15T11:36:12.097' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'A2', N'Giữa phim sáng (đợt I)', 715, N'A', 1, CAST(N'2019-09-15T11:38:27.303' AS DateTime), CAST(N'2019-09-15T11:38:27.307' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (3, N'A3', N'Cuối phim sáng (đợt I)', 800, N'A', 1, CAST(N'2019-09-15T11:39:44.617' AS DateTime), CAST(N'2019-09-15T11:40:12.950' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (4, N'A4', N'Trước phim sáng (đợt II)', 905, N'A', 1, CAST(N'2019-09-20T12:44:26.430' AS DateTime), CAST(N'2019-09-20T12:44:26.430' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (5, N'A5', N'Giữa phim sáng (đợt II)', 925, N'A', 1, CAST(N'2019-09-20T12:47:21.527' AS DateTime), CAST(N'2019-09-20T12:47:21.527' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (6, N'A6', N'Cuối phim sáng', 945, N'A', 1, CAST(N'2019-09-20T12:48:45.707' AS DateTime), CAST(N'2019-09-20T12:48:45.707' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (7, N'B1', N'Trước phim trưa', 1200, N'B', 1, CAST(N'2019-09-20T12:50:30.937' AS DateTime), CAST(N'2019-09-20T12:50:30.937' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (8, N'B2', N'Giữa phim trưa', 1220, N'B', 1, CAST(N'2019-09-20T12:52:13.713' AS DateTime), CAST(N'2019-09-20T12:52:13.713' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (9, N'B3', N'Cuối phim trưa', 1245, N'B', 1, CAST(N'2019-09-20T13:07:19.687' AS DateTime), CAST(N'2019-09-20T13:07:30.483' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (10, N'C1', N'Trước phim xế trưa (I)', 1405, N'C', 1, CAST(N'2019-09-20T13:09:20.580' AS DateTime), CAST(N'2019-09-20T14:33:06.083' AS DateTime), 2)
INSERT [dbo].[TimeSlot] ([Id], [Code], [Name], [FromHour], [SessionCode], [StatusId], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (11, N'C2', N'Phim xe trua (II)', 1425, N'C', 1, CAST(N'2019-09-20T14:29:34.040' AS DateTime), CAST(N'2019-09-20T14:33:22.140' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (1, N'admin', N'ABEaDKz5yOzdvn2l6pc2iwzT8yPwXc/6Ikb8kxy1Qt6ejj8ZWwdws1F5PLbrIFIqWQ==', N'AD0001', N'Admin', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [Username], [Password], [Code], [Name], [RoleId], [StatusId], [LastLoginTime], [CreateDate], [LastUpdateDate], [LastUpdateBy]) VALUES (2, N'staff', N'ABEaDKz5yOzdvn2l6pc2iwzT8yPwXc/6Ikb8kxy1Qt6ejj8ZWwdws1F5PLbrIFIqWQ==', N'NV0002', N'Admin', 2, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UNIQUE_CODE_SESSION]    Script Date: 13/10/2019 9:12:49 PM ******/
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [UNIQUE_CODE_SESSION] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF_Contract_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[ContractItem] ADD  CONSTRAINT [DF_ContractDetail_ContractCode]  DEFAULT ((0)) FOR [ContractCode]
GO
ALTER TABLE [dbo].[CostRule] ADD  CONSTRAINT [DF_CostRule_Price]  DEFAULT ((0)) FOR [Price]
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

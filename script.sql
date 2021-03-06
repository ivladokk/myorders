USE [master]
GO
/****** Object:  Database [GoodsDB]    Script Date: 11/21/2018 6:09:00 PM ******/
CREATE DATABASE [GoodsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GoodsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GoodsDB.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GoodsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GoodsDB_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GoodsDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GoodsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GoodsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GoodsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GoodsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GoodsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GoodsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GoodsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GoodsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GoodsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GoodsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GoodsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GoodsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GoodsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GoodsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GoodsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GoodsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GoodsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GoodsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GoodsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GoodsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GoodsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GoodsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GoodsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GoodsDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GoodsDB] SET  MULTI_USER 
GO
ALTER DATABASE [GoodsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GoodsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GoodsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GoodsDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GoodsDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GoodsDB]
GO
/****** Object:  Table [dbo].[BalanceOnDays]    Script Date: 11/21/2018 6:09:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalanceOnDays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkDayID] [int] NULL,
	[CurrencyID] [int] NULL,
	[StartAmount] [numeric](18, 2) NULL,
	[CurrentAmount] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculatedItems]    Script Date: 11/21/2018 6:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculatedItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculatedProductID] [int] NULL,
	[ItemID] [int] NULL,
	[Value] [numeric](18, 2) NULL,
	[CalculationInstanceID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculatedProducts]    Script Date: 11/21/2018 6:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculatedProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculationInstanceID] [int] NULL,
	[ProductName] [nvarchar](900) NULL,
	[VendorCode] [nvarchar](900) NULL,
	[Price] [numeric](18, 2) NULL,
	[Count] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationConstants]    Script Date: 11/21/2018 6:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationConstants](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculationTypeID] [int] NULL,
	[ConstantType] [int] NULL,
	[Name] [nvarchar](900) NULL,
	[Value] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationInstances]    Script Date: 11/21/2018 6:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationInstances](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculationTypeID] [int] NULL,
	[Name] [nvarchar](900) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
	[ContrAgentID] [int] NULL,
	[ContrAgentID2] [int] NULL,
	[Comments] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationItems]    Script Date: 11/21/2018 6:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculationTypeID] [int] NULL,
	[ItemName] [nvarchar](900) NULL,
	[OrderID] [int] NULL,
	[WithSum] [int] NULL,
	[Expression] [varchar](900) NULL,
	[NeedRound] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationOrders]    Script Date: 11/21/2018 6:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationOrders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Order] [int] NULL,
	[CalculationTypeID] [int] NULL,
	[ItemType] [int] NULL,
	[ItemID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationResults]    Script Date: 11/21/2018 6:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationResults](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculationInstanseID] [int] NULL,
	[CalculatedProducts] [nvarchar](max) NULL,
	[CalculatedItemsJSON] [nvarchar](max) NULL,
	[CalculatedDynamicsJSON] [nvarchar](max) NULL,
	[CalculatedSumsJSON] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationStatus]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusValue] [nvarchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationTypes]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContrAgents]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContrAgents](
	[ContrAgentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](900) NULL,
	[Address] [nvarchar](900) NULL,
	[NameEng] [nvarchar](900) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContrAgentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrencyCodes]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyCodes](
	[CurrencyID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NULL,
	[CurrencyName] [nvarchar](50) NULL,
	[CurrencyNameEng] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomsGoods]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomsGoods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ND] [nvarchar](max) NULL,
	[G022] [nvarchar](max) NULL,
	[G081] [nvarchar](max) NULL,
	[G082] [nvarchar](max) NULL,
	[G23] [nvarchar](max) NULL,
	[G31_1] [nvarchar](max) NULL,
	[TEXT1] [nvarchar](max) NULL,
	[G31_11] [nvarchar](max) NULL,
	[G31_7] [nvarchar](max) NULL,
	[G31_71] [nvarchar](max) NULL,
	[G33] [nvarchar](max) NULL,
	[EXW] [nvarchar](max) NULL,
	[G42] [nvarchar](max) NULL,
	[G45] [nvarchar](max) NULL,
	[SelfValue] [nvarchar](max) NULL,
	[G474RUB] [nvarchar](max) NULL,
	[TOVG] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DynamicConstants]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DynamicConstants](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculationTypeID] [int] NULL,
	[Name] [nvarchar](900) NULL,
	[Expression] [nvarchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipments]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EquipName] [nvarchar](900) NULL,
	[EquipNameRus] [nvarchar](900) NULL,
	[ManufacterID] [int] NULL,
	[Code] [nvarchar](900) NULL,
	[Description] [nvarchar](max) NULL,
	[DescriptionRus] [nvarchar](max) NULL,
	[Price] [numeric](18, 2) NULL,
	[Image] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuturePayments]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuturePayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [date] NULL,
	[Sum] [numeric](18, 2) NULL,
	[PaymentType] [int] NULL,
	[PaymentCurrencyCode] [int] NULL,
	[CreditNum] [nvarchar](500) NULL,
	[Acc] [nvarchar](500) NULL,
	[PaymentID] [int] NULL,
	[ContrAgentID] [int] NULL,
	[Comments] [nvarchar](900) NULL,
	[ColorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goods]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Lenght] [int] NULL,
	[Weight] [int] NULL,
	[Comments] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacters]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](900) NULL,
	[NameRus] [nvarchar](900) NULL,
	[Logo] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferFooters]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferFooters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OfferID] [int] NULL,
	[Delivery] [nvarchar](900) NULL,
	[DeliveryRus] [nvarchar](900) NULL,
	[Payment] [nvarchar](900) NULL,
	[PaymentRus] [nvarchar](900) NULL,
	[GoodsDeliv] [nvarchar](900) NULL,
	[GoodsDelivRus] [nvarchar](900) NULL,
	[OfferTill] [datetime] NULL,
	[TechAssist] [nvarchar](900) NULL,
	[TechAssistRus] [nvarchar](900) NULL,
	[TechDoc] [nvarchar](900) NULL,
	[TechDocRus] [nvarchar](900) NULL,
	[Warranty] [nvarchar](900) NULL,
	[WarrantyRus] [nvarchar](900) NULL,
	[TotalAmountGoods] [numeric](18, 2) NULL,
	[PackPrice] [numeric](18, 2) NULL,
	[GeneralAmount] [numeric](18, 2) NULL,
	[Sign] [nvarchar](900) NULL,
	[SignRus] [nvarchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferHeaders]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferHeaders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OfferID] [int] NULL,
	[ManufacterID] [int] NULL,
	[Subject] [nvarchar](900) NULL,
	[SubjectRus] [nvarchar](900) NULL,
	[OfferNumber] [nvarchar](900) NULL,
	[HeaderText] [nvarchar](900) NULL,
	[HeaderTextRus] [nvarchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferItems]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OfferID] [int] NULL,
	[EquipmentID] [int] NULL,
	[Count] [int] NULL,
	[Price] [numeric](18, 2) NULL,
	[Amount] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContrAgentID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[OfferName] [nvarchar](900) NULL,
	[CurrencyID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddDate] [date] NULL,
	[OrderDate] [date] NULL,
	[ControlDate] [date] NULL,
	[Provider] [nvarchar](max) NULL,
	[AcceptNum] [int] NULL,
	[Status] [int] NULL,
	[PlaceCount] [int] NULL,
	[ContrAgentID] [int] NULL,
	[NumberKP] [varchar](500) NULL,
	[ProviderID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentColors]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentColors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](100) NULL,
	[Value] [nvarchar](100) NULL,
	[ColorRus] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sum] [decimal](18, 2) NULL,
	[PaymentDate] [datetime] NULL,
	[ContrAgentID] [int] NULL,
	[PaymentStatus] [int] NULL,
	[TransactionID] [int] NULL,
	[PaymentType] [int] NULL,
	[Comments] [nvarchar](900) NULL,
	[PaymentCurrencyCode] [int] NULL,
	[CreditNum] [nvarchar](50) NULL,
	[Acc] [nvarchar](50) NULL,
	[ControlDate] [datetime] NULL,
	[ColorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributes]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorCode] [nvarchar](900) NULL,
	[ProductName] [nvarchar](900) NULL,
	[Unit] [nvarchar](100) NULL,
	[TNVEDCode] [bigint] NULL,
	[TNVEDValue] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](900) NULL,
	[Price] [numeric](18, 2) NULL,
	[VendorCode] [varchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rates]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromCurID] [int] NULL,
	[ToCurID] [int] NULL,
	[RateValue] [float] NULL,
	[Scale] [int] NULL,
	[WorkDayID] [int] NULL,
	[RateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] NOT NULL,
	[StatusValue] [nvarchar](50) NULL,
	[StatusColor] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sum] [decimal](18, 2) NULL,
	[TransactionDate] [datetime] NULL,
	[PaymentID] [int] NULL,
	[TransactionCurrencyCode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportPackItems]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportPackItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransportPackID] [int] NULL,
	[CalculatedProductID] [int] NULL,
	[TotalValue] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportPacks]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportPacks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](900) NULL,
	[ContragentIDFrom] [int] NULL,
	[ContragentIdTo] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
	[TotalItemID] [int] NULL,
	[TotalSum] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportPackStatus]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportPackStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusValue] [nvarchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkDays]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkDays](
	[WorkDayID] [int] IDENTITY(1,1) NOT NULL,
	[WorkDayDate] [datetime] NULL,
	[isLast] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[WorkDayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[FindCalculationItemByName]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[FindCalculationItemByName]
(@name nvarchar(900))
as begin

select I.ID, I.Name, I.CreateDate from CalculatedProducts P
left join CalculationInstances I on I.ID=P.CalculationInstanceID
where UPPER(P.ProductName) like UPPER(@name)
	
end
GO
/****** Object:  StoredProcedure [dbo].[FindCalculationItemByVendor]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[FindCalculationItemByVendor]
(@vendorcode nvarchar(900))
as begin

select I.ID, I.Name, I.CreateDate from CalculatedProducts P
left join CalculationInstances I on I.ID=P.CalculationInstanceID
where UPPER(P.VendorCode) like UPPER(@vendorcode)
	
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllOffers]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllOffers]
as begin

select	O.ID,
		O.OfferName as N'Название',
		A.Name as N'Контрагент',
		O.CreateDate as N'Дата создания'
from Offers O
inner join ContrAgents A on A.ContrAgentID=O.ContrAgentID
end
GO
/****** Object:  StoredProcedure [dbo].[GetCalculationInstances]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetCalculationInstances]
as begin

	select	I.ID as 'ID',
			I.Name as 'Название',
			T.Name as 'Тип',
			A.Name as 'Контрагент',
			A2.Name as 'Получатель',
			S.StatusValue as 'Статус',
			I.Comments as 'Комментрарий',
			I.CreateDate as 'Дата создания'
	from CalculationInstances I 
	inner join CalculationTypes T on T.ID=I.CalculationTypeID
	left join ContrAgents A on A.ContrAgentID=I.ContrAgentID
	left join ContrAgents A2 on A2.ContrAgentID=I.ContrAgentID2
	inner join CalculationStatus S on S.ID = I.Status

end
GO
/****** Object:  StoredProcedure [dbo].[GetCustomsInfo]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetCustomsInfo]
as begin

select	ND as N'Номер декларации',
		G022 as N'Наименование отправителя',
		G082 as N'ИНН получателя',
		G082 as N'Наименование получателя',
		G23 as N'Курс валюты',
		G31_1 as N'Наименование и характеристики товаров',
		TEXT1 as N'TEXT1 (Оборотная сторона ГТД)',
		G31_11 as N'Фирма-изготовитель',
		G31_7 as N'Кол-во товара в доп.ед.',
		G31_71 as N'Наименование доп.ед.',
		G33 as N'Код товара по ТН ВЭД',
		EXW as N'Цена за 1 ед на EXW',
		G42 as N'Фактурная стоимость',
		G45 as N'Таможенная стоимость, руб.',
		SelfValue as N'Себестоимость с учетом логистики и таможни',
		G474RUB as N'Сумма по гр.47 в RUR',
		TOVG as N'Информация о товаре из Приложений'
		from CustomsGoods

end
GO
/****** Object:  StoredProcedure [dbo].[GetEquipments]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GetEquipments]
as begin


select  E.ID,
		E.EquipNameRus as N'Наименование',
		M.Name as N'Производитель'		
from Equipments E
inner join Manufacters M on M.ID = E.ManufacterID

end
GO
/****** Object:  StoredProcedure [dbo].[GetEquipmentsForOffer]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetEquipmentsForOffer]
as begin


select  E.ID,
		E.EquipNameRus as N'Наименование',
		M.Name as N'Производитель'		
from Equipments E
inner join Manufacters M on M.ID = E.ManufacterID

end
GO
/****** Object:  StoredProcedure [dbo].[GetFuturePayments]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetFuturePayments]
as begin

select P.CreateDate as N'Дата создания',
  A.Name as N'Поставщик', 
  P.[Sum] as N'Сумма',
  C.CurrencyName as N'Валюта',
  case 
   when P.PaymentType=1 then N'Приход'
   when P.PaymentType=2 then N'Расход'
  end as N'Тип платежа',
  P.Comments as N'Примечания',
  P.CreditNum as N' Номер договора',
  P.Acc as N'Счет'

from FuturePayments P
inner join ContrAgents A on A.ContrAgentID=P.ContrAgentID
left join CurrencyCodes C on C.Code=P.PaymentCurrencyCode
end
GO
/****** Object:  StoredProcedure [dbo].[GetManufactersDictionary]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetManufactersDictionary]
as begin

select ID, NameRus as N'Наименование', [Name] as N'Наименование (eng)' from Manufacters

end
GO
/****** Object:  StoredProcedure [dbo].[GetProductsAttributes]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetProductsAttributes]
as begin

	select  VendorCode as 'Артикул',
			ProductName as N'Наименование',
			Unit as N'Ед. изм.',
		 	TNVEDCode as N'Код ТНВЭД',
			TNVEDValue as N'Ставка НДС'
			
	from ProductAttributes

end
GO
/****** Object:  StoredProcedure [dbo].[GetTransportPackById]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTransportPackById]
(@ID int)
as begin

select	P.ProductName as N'Наименование',
		P.VendorCode as N'Артикул',
		P.Count as N'Кол-во',
		P.Price as N'Первоначальная цена',
		I.Name as N'Калькуляция'
from TransportPackItems T
left join CalculatedProducts P on P.ID=T.CalculatedProductID
left join CalculationInstances I on I.ID=P.CalculationInstanceID
where T.TransportPackID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[GetTransportPacks]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTransportPacks]
as begin

	select	T.ID,
			T.Name as N'Название',
			C1.Name as N'Отправитель',
			C2.Name as N'Получатель',
			T.CreateDate as N'Дата создания',
			S.StatusValue as N'Статус',
			T.TotalSum as N'Стомость пакета'

	from TransportPacks T
	left join ContrAgents C1 on C1.ContrAgentID = T.ContragentIDFrom
	left join ContrAgents C2 on C2.ContrAgentID = T.ContragentIDTo
	left join TransportPackStatus S on S.ID = T.Status

end
GO
/****** Object:  StoredProcedure [dbo].[GoodsReport]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GoodsReport]
as begin
select	isnull(A.Name,'') as N'Клиент',
		ISNULL(O.Provider,A2.Name) as N'Поставщик',
		isnull(O.NumberKP,'') as N'Номер КП',
		O.AcceptNum as N'Номер подтверждения',
		S.StatusValue as N'Статус',
		O.OrderDate as N'Дата доставки по СО',
		O.ControlDate as N'Контрольная дата',
		DATEPART(wk,O.ControlDate) as N'Номер недели'

from Orders O
left join ContrAgents A on A.ContrAgentID=O.ContrAgentID
left join ContrAgents A2 on A2.ContrAgentID=O.ProviderID
inner join Status S on S.StatusID=O.Status
end
GO
/****** Object:  StoredProcedure [dbo].[PaymentsReport]    Script Date: 11/21/2018 6:09:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PaymentsReport]
as begin
select P.PaymentDate as N'Дата платежа',
  A.Name as N'Поставщик', 
  P.[Sum] as N'Сумма',
  C.CurrencyName as N'Валюта',
  case 
   when P.PaymentType=1 then N'Приход'
   when P.PaymentType=2 then N'Расход'
  end as N'Тип платежа',
  case 
   when P.PaymentStatus=1 then N'Не оплачено'
   when P.PaymentStatus=2 then N'Оплачено'
  end as N'Статус платежа',
  P.Comments as N'Примечания',
  P.CreditNum as N' Номер договора',
  P.Acc as N'Счет',
  T.TransactionDate as N'Дата транзакции'

from Payments P
inner join ContrAgents A on A.ContrAgentID=P.ContrAgentID
left join Transactions T on T.PaymentID=P.Id
left join CurrencyCodes C on C.Code=P.PaymentCurrencyCode
end
GO
USE [master]
GO
ALTER DATABASE [GoodsDB] SET  READ_WRITE 
GO

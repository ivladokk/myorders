USE [GoodsDB]
GO
/****** Object:  Table [dbo].[BalanceOnDays]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[CalculatedItems]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[CalculatedProducts]    Script Date: 5/23/2018 5:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculatedProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculationInstanceID] [int] NULL,
	[ProductID] [int] NULL,
	[Count] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationConstants]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[CalculationInstances]    Script Date: 5/23/2018 5:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationInstances](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalculationTypeID] [int] NULL,
	[Name] [nvarchar](900) NULL,
	[CreateDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationItems]    Script Date: 5/23/2018 5:52:00 PM ******/
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
	[Expression] [varchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalculationOrders]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[CalculationTypes]    Script Date: 5/23/2018 5:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalculationTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](900) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContrAgents]    Script Date: 5/23/2018 5:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContrAgents](
	[ContrAgentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](900) NULL,
	[Address] [nvarchar](900) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContrAgentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrencyCodes]    Script Date: 5/23/2018 5:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyCodes](
	[CurrencyID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NULL,
	[CurrencyName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DynamicConstants]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[FuturePayments]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[Goods]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[PaymentColors]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[Payments]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[ProductAttributes]    Script Date: 5/23/2018 5:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorCode] [nvarchar](900) NULL,
	[TNVEDCode] [int] NULL,
	[TNVEDValue] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[Rates]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[Status]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[Transactions]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  Table [dbo].[WorkDays]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetFuturePayments]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetProductsAttributes]    Script Date: 5/23/2018 5:52:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetProductsAttributes]
as begin

	select	VendorCode as 'Артикул',
			TNVEDCode as 'Код ТНВЭД',
			TNVEDValue as 'Ставка'
			
	from ProductAttributes

end
GO
/****** Object:  StoredProcedure [dbo].[GoodsReport]    Script Date: 5/23/2018 5:52:00 PM ******/
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
/****** Object:  StoredProcedure [dbo].[PaymentsReport]    Script Date: 5/23/2018 5:52:00 PM ******/
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



create procedure GetCalculationInstances
as begin

	select	I.ID as 'ID',
			I.Name as 'Название',
			T.Name as 'Тип',
			I.CreateDate as 'Дата создания'
	from CalculationInstances I 
	inner join CalculationTypes T on T.ID=I.CalculationTypeID

end

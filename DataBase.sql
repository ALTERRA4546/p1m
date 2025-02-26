USE [master]
GO
/****** Object:  Database [WarehouseAccounting]    Script Date: 25.02.2025 16:54:13 ******/
CREATE DATABASE [WarehouseAccounting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CaMA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CaMA.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CaMA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CaMA_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WarehouseAccounting] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WarehouseAccounting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WarehouseAccounting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET ARITHABORT OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WarehouseAccounting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WarehouseAccounting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WarehouseAccounting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WarehouseAccounting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WarehouseAccounting] SET  MULTI_USER 
GO
ALTER DATABASE [WarehouseAccounting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WarehouseAccounting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WarehouseAccounting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WarehouseAccounting] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WarehouseAccounting] SET DELAYED_DURABILITY = DISABLED 
GO
USE [WarehouseAccounting]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IdCategory] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[IdCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](18) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IdEmployee] [int] NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Patronymic] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpenditureInvoice]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenditureInvoice](
	[IdExpenditureInvoice] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [nvarchar](max) NOT NULL,
	[ShipmentDate] [date] NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[IdClient] [int] NOT NULL,
 CONSTRAINT [PK_ExpenditureInvoice] PRIMARY KEY CLUSTERED 
(
	[IdExpenditureInvoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpenditureInvoiceWarehouse]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenditureInvoiceWarehouse](
	[IdExpenditureInvoiceWarehouse] [int] NOT NULL,
	[IdExpenditureInvoice] [int] NOT NULL,
	[IdWarehouse] [int] NOT NULL,
 CONSTRAINT [PK_ExpenditureInvoiceWarehouse] PRIMARY KEY CLUSTERED 
(
	[IdExpenditureInvoiceWarehouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[IdGoods] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Article] [nvarchar](max) NOT NULL,
	[Barcode] [nvarchar](max) NOT NULL,
	[IdCategory] [int] NOT NULL,
	[IdUnit] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[SerialNumber] [nvarchar](max) NULL,
	[MinimumBalance] [float] NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[IdGoods] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GoodsWarehouse]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoodsWarehouse](
	[IdGoodsWarehouse] [int] NOT NULL,
	[IdGoods] [int] NOT NULL,
	[IdWarehouse] [int] NOT NULL,
 CONSTRAINT [PK_GoodsWarehouse] PRIMARY KEY CLUSTERED 
(
	[IdGoodsWarehouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncomingInvoice]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomingInvoice](
	[IdIncomingInvoice] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [nvarchar](max) NOT NULL,
	[DateReceipt] [date] NOT NULL,
	[IdSupplier] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_IncomingInvoice] PRIMARY KEY CLUSTERED 
(
	[IdIncomingInvoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncomingInvoiceWarehouse]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomingInvoiceWarehouse](
	[IdIncomingInvoiceWarehouse] [int] NOT NULL,
	[IdIncomingInvoice] [int] NOT NULL,
	[IdWarehouse] [int] NOT NULL,
 CONSTRAINT [PK_IncomingInvoiceWarehouse] PRIMARY KEY CLUSTERED 
(
	[IdIncomingInvoiceWarehouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[IdInventory] [int] IDENTITY(1,1) NOT NULL,
	[DateEvent] [date] NOT NULL,
	[IdResponsible] [int] NOT NULL,
	[Result] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[IdInventory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InventoryWarehouse]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryWarehouse](
	[IdInventoryWarehouse] [int] NOT NULL,
	[IdIntentory] [int] NOT NULL,
	[IdWarehouse] [int] NOT NULL,
	[AccountingQuantity] [float] NOT NULL,
	[ActualQuantity] [float] NOT NULL,
 CONSTRAINT [PK_InventoryWarehouse] PRIMARY KEY CLUSTERED 
(
	[IdInventoryWarehouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageArea]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageArea](
	[IdStorageArea] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StorageArea] PRIMARY KEY CLUSTERED 
(
	[IdStorageArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[IdSupplier] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[INNOrKPP] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[IdSupplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unit]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[IdUnit] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[IdUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[IdWarehouse] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[IdWarehouseType] [int] NOT NULL,
	[IdStorageArea] [int] NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[IdWarehouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WarehouseType]    Script Date: 25.02.2025 16:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseType](
	[IdWarehouseType] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_WarehouseType] PRIMARY KEY CLUSTERED 
(
	[IdWarehouseType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ExpenditureInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ExpenditureInvoice_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[ExpenditureInvoice] CHECK CONSTRAINT [FK_ExpenditureInvoice_Client]
GO
ALTER TABLE [dbo].[ExpenditureInvoiceWarehouse]  WITH CHECK ADD  CONSTRAINT [FK_ExpenditureInvoiceWarehouse_ExpenditureInvoice] FOREIGN KEY([IdExpenditureInvoice])
REFERENCES [dbo].[ExpenditureInvoice] ([IdExpenditureInvoice])
GO
ALTER TABLE [dbo].[ExpenditureInvoiceWarehouse] CHECK CONSTRAINT [FK_ExpenditureInvoiceWarehouse_ExpenditureInvoice]
GO
ALTER TABLE [dbo].[ExpenditureInvoiceWarehouse]  WITH CHECK ADD  CONSTRAINT [FK_ExpenditureInvoiceWarehouse_Warehouse] FOREIGN KEY([IdWarehouse])
REFERENCES [dbo].[Warehouse] ([IdWarehouse])
GO
ALTER TABLE [dbo].[ExpenditureInvoiceWarehouse] CHECK CONSTRAINT [FK_ExpenditureInvoiceWarehouse_Warehouse]
GO
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Category]
GO
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Unit] FOREIGN KEY([IdUnit])
REFERENCES [dbo].[Unit] ([IdUnit])
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Unit]
GO
ALTER TABLE [dbo].[GoodsWarehouse]  WITH CHECK ADD  CONSTRAINT [FK_GoodsWarehouse_Goods] FOREIGN KEY([IdGoods])
REFERENCES [dbo].[Goods] ([IdGoods])
GO
ALTER TABLE [dbo].[GoodsWarehouse] CHECK CONSTRAINT [FK_GoodsWarehouse_Goods]
GO
ALTER TABLE [dbo].[GoodsWarehouse]  WITH CHECK ADD  CONSTRAINT [FK_GoodsWarehouse_Warehouse] FOREIGN KEY([IdWarehouse])
REFERENCES [dbo].[Warehouse] ([IdWarehouse])
GO
ALTER TABLE [dbo].[GoodsWarehouse] CHECK CONSTRAINT [FK_GoodsWarehouse_Warehouse]
GO
ALTER TABLE [dbo].[IncomingInvoice]  WITH CHECK ADD  CONSTRAINT [FK_IncomingInvoice_Supplier] FOREIGN KEY([IdSupplier])
REFERENCES [dbo].[Supplier] ([IdSupplier])
GO
ALTER TABLE [dbo].[IncomingInvoice] CHECK CONSTRAINT [FK_IncomingInvoice_Supplier]
GO
ALTER TABLE [dbo].[IncomingInvoiceWarehouse]  WITH CHECK ADD  CONSTRAINT [FK_IncomingInvoiceWarehouse_IncomingInvoice] FOREIGN KEY([IdIncomingInvoice])
REFERENCES [dbo].[IncomingInvoice] ([IdIncomingInvoice])
GO
ALTER TABLE [dbo].[IncomingInvoiceWarehouse] CHECK CONSTRAINT [FK_IncomingInvoiceWarehouse_IncomingInvoice]
GO
ALTER TABLE [dbo].[IncomingInvoiceWarehouse]  WITH CHECK ADD  CONSTRAINT [FK_IncomingInvoiceWarehouse_Warehouse] FOREIGN KEY([IdWarehouse])
REFERENCES [dbo].[Warehouse] ([IdWarehouse])
GO
ALTER TABLE [dbo].[IncomingInvoiceWarehouse] CHECK CONSTRAINT [FK_IncomingInvoiceWarehouse_Warehouse]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Employee] FOREIGN KEY([IdResponsible])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Employee]
GO
ALTER TABLE [dbo].[InventoryWarehouse]  WITH CHECK ADD  CONSTRAINT [FK_InventoryWarehouse_Inventory] FOREIGN KEY([IdIntentory])
REFERENCES [dbo].[Inventory] ([IdInventory])
GO
ALTER TABLE [dbo].[InventoryWarehouse] CHECK CONSTRAINT [FK_InventoryWarehouse_Inventory]
GO
ALTER TABLE [dbo].[InventoryWarehouse]  WITH CHECK ADD  CONSTRAINT [FK_InventoryWarehouse_Warehouse] FOREIGN KEY([IdWarehouse])
REFERENCES [dbo].[Warehouse] ([IdWarehouse])
GO
ALTER TABLE [dbo].[InventoryWarehouse] CHECK CONSTRAINT [FK_InventoryWarehouse_Warehouse]
GO
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_StorageArea] FOREIGN KEY([IdStorageArea])
REFERENCES [dbo].[StorageArea] ([IdStorageArea])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_StorageArea]
GO
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_WarehouseType] FOREIGN KEY([IdWarehouseType])
REFERENCES [dbo].[WarehouseType] ([IdWarehouseType])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_WarehouseType]
GO
USE [master]
GO
ALTER DATABASE [WarehouseAccounting] SET  READ_WRITE 
GO

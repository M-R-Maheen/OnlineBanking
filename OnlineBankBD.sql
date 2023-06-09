USE [master]
GO
/****** Object:  Database [MassBankDB]    Script Date: 4/9/2023 3:14:41 PM ******/
CREATE DATABASE [MassBankDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MassBankDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MassBankDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MassBankDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MassBankDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MassBankDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MassBankDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MassBankDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MassBankDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MassBankDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MassBankDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MassBankDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MassBankDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MassBankDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MassBankDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MassBankDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MassBankDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MassBankDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MassBankDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MassBankDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MassBankDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MassBankDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MassBankDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MassBankDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MassBankDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MassBankDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MassBankDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MassBankDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MassBankDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MassBankDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MassBankDB] SET  MULTI_USER 
GO
ALTER DATABASE [MassBankDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MassBankDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MassBankDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MassBankDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MassBankDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MassBankDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MassBankDB', N'ON'
GO
ALTER DATABASE [MassBankDB] SET QUERY_STORE = OFF
GO
USE [MassBankDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/9/2023 3:14:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 4/9/2023 3:14:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[AccountHolderName] [nvarchar](40) NOT NULL,
	[AccountNumber] [nvarchar](40) NOT NULL,
	[AccountType] [nvarchar](40) NOT NULL,
	[Gender] [nvarchar](40) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Picture] [nvarchar](250) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Balances]    Script Date: 4/9/2023 3:14:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Balances](
	[BalanceID] [int] IDENTITY(1,1) NOT NULL,
	[TotalBalance] [decimal](18, 2) NOT NULL,
	[AccountID] [int] NOT NULL,
 CONSTRAINT [PK_Balances] PRIMARY KEY CLUSTERED 
(
	[BalanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deposits]    Script Date: 4/9/2023 3:14:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deposits](
	[DepositID] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [nvarchar](max) NULL,
	[AccountHolderName] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DepositDate] [datetime2](7) NOT NULL,
	[AccountID] [int] NOT NULL,
 CONSTRAINT [PK_Deposits] PRIMARY KEY CLUSTERED 
(
	[DepositID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferMoneys]    Script Date: 4/9/2023 3:14:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferMoneys](
	[TransferMoneyID] [int] IDENTITY(1,1) NOT NULL,
	[SenderAccountNo] [nvarchar](max) NULL,
	[RecipientAccountNo] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DepositDate] [datetime2](7) NOT NULL,
	[AccountID] [int] NOT NULL,
 CONSTRAINT [PK_TransferMoneys] PRIMARY KEY CLUSTERED 
(
	[TransferMoneyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230405081754_InitialCode', N'3.1.32')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountID], [AccountHolderName], [AccountNumber], [AccountType], [Gender], [Address], [Picture], [CreatedDate], [Email], [Password]) VALUES (1, N'Mamunur', N'123456', N'Savings', N'Male', N'Agargaon', N'nvb.png', CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), N'mamunurmaheen@gmail.com', N'Mamunur$48')
INSERT [dbo].[Accounts] ([AccountID], [AccountHolderName], [AccountNumber], [AccountType], [Gender], [Address], [Picture], [CreatedDate], [Email], [Password]) VALUES (2, N'Hasan', N'234567', N'Savings', N'Male', N'Dhanmondi', N'pcj.jpg', CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), N'hasan@gmail.com', N'Hasan$48')
INSERT [dbo].[Accounts] ([AccountID], [AccountHolderName], [AccountNumber], [AccountType], [Gender], [Address], [Picture], [CreatedDate], [Email], [Password]) VALUES (3, N'Ayesha Khatun', N'232323', N'Savings', N'Female', N'Uttrara', N'anv.jpg', CAST(N'2023-04-08T00:00:00.0000000' AS DateTime2), N'ayesha@gmail.com', N'Ayesha$48')
INSERT [dbo].[Accounts] ([AccountID], [AccountHolderName], [AccountNumber], [AccountType], [Gender], [Address], [Picture], [CreatedDate], [Email], [Password]) VALUES (4, N'Sania Khatun', N'444444', N'Savings', N'Female', N'Uttrara', N'anv.jpg', CAST(N'2023-04-08T00:00:00.0000000' AS DateTime2), N'sania@gmail.com', N'Sania$48')
INSERT [dbo].[Accounts] ([AccountID], [AccountHolderName], [AccountNumber], [AccountType], [Gender], [Address], [Picture], [CreatedDate], [Email], [Password]) VALUES (5, N' Khatun', N'112323', N'Savings', N'Female', N'Uttrara', N'anv.jpg', CAST(N'2023-04-08T00:00:00.0000000' AS DateTime2), N'ayesha@gmail.com', N'Ayesha$48')
INSERT [dbo].[Accounts] ([AccountID], [AccountHolderName], [AccountNumber], [AccountType], [Gender], [Address], [Picture], [CreatedDate], [Email], [Password]) VALUES (6, N' Rashid Khan', N'333333', N'Savings', N'Male', N'Darusha', N'anv.jpg', CAST(N'2023-04-10T00:00:00.0000000' AS DateTime2), N'rashid@gmail.com', N'Rashid$48')
INSERT [dbo].[Accounts] ([AccountID], [AccountHolderName], [AccountNumber], [AccountType], [Gender], [Address], [Picture], [CreatedDate], [Email], [Password]) VALUES (7, N'Sunny', N'999999', N'Savings', N'Male', N'Mirpur-12', N'abc.jpg', CAST(N'2023-04-06T00:00:00.0000000' AS DateTime2), N'com@unigroupbd.com', N'Mamunur$528448#')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Balances] ON 

INSERT [dbo].[Balances] ([BalanceID], [TotalBalance], [AccountID]) VALUES (1, CAST(500000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Balances] ([BalanceID], [TotalBalance], [AccountID]) VALUES (2, CAST(400000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Balances] ([BalanceID], [TotalBalance], [AccountID]) VALUES (3, CAST(200000.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Balances] OFF
GO
SET IDENTITY_INSERT [dbo].[Deposits] ON 

INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (1, N'123456', N'Mamunur', CAST(123000.00 AS Decimal(18, 2)), CAST(N'2023-04-04T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (2, N'234567', N'Hasan', CAST(340000.00 AS Decimal(18, 2)), CAST(N'2023-05-05T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (3, N'123456', N'Mamunur', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-04-05T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (7, N'232323', N'Ani Khatun', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2023-04-05T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (10, N'123456', N'Ayesha Khatun', CAST(23400.00 AS Decimal(18, 2)), CAST(N'2023-04-07T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (11, N'123456', N'Ayesha Khatun', CAST(23400.00 AS Decimal(18, 2)), CAST(N'2023-04-07T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (12, N'234567', N'Hasan', CAST(40000.00 AS Decimal(18, 2)), CAST(N'2023-04-13T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (13, N'123456', N'Mamunur Roshid Maheen', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-04-06T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Deposits] ([DepositID], [AccountNumber], [AccountHolderName], [Amount], [DepositDate], [AccountID]) VALUES (14, N'123456', N'Mamunur Roshid Maheen', CAST(20000.00 AS Decimal(18, 2)), CAST(N'2023-04-08T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Deposits] OFF
GO
SET IDENTITY_INSERT [dbo].[TransferMoneys] ON 

INSERT [dbo].[TransferMoneys] ([TransferMoneyID], [SenderAccountNo], [RecipientAccountNo], [Amount], [DepositDate], [AccountID]) VALUES (1, N'234567', N'123456', CAST(30000.00 AS Decimal(18, 2)), CAST(N'2023-05-05T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[TransferMoneys] ([TransferMoneyID], [SenderAccountNo], [RecipientAccountNo], [Amount], [DepositDate], [AccountID]) VALUES (2, N'123456', N'234567', CAST(3453.00 AS Decimal(18, 2)), CAST(N'2023-05-05T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[TransferMoneys] ([TransferMoneyID], [SenderAccountNo], [RecipientAccountNo], [Amount], [DepositDate], [AccountID]) VALUES (3, N'234567', N'123456', CAST(230000.00 AS Decimal(18, 2)), CAST(N'2023-04-08T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[TransferMoneys] ([TransferMoneyID], [SenderAccountNo], [RecipientAccountNo], [Amount], [DepositDate], [AccountID]) VALUES (4, N'123456', N'234567', CAST(34000.00 AS Decimal(18, 2)), CAST(N'2023-04-04T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[TransferMoneys] ([TransferMoneyID], [SenderAccountNo], [RecipientAccountNo], [Amount], [DepositDate], [AccountID]) VALUES (5, N'234567', N'123456', CAST(2350.50 AS Decimal(18, 2)), CAST(N'2023-04-06T00:00:00.0000000' AS DateTime2), 2)
SET IDENTITY_INSERT [dbo].[TransferMoneys] OFF
GO
/****** Object:  Index [IX_Balances_AccountID]    Script Date: 4/9/2023 3:14:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_Balances_AccountID] ON [dbo].[Balances]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Deposits_AccountID]    Script Date: 4/9/2023 3:14:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_Deposits_AccountID] ON [dbo].[Deposits]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferMoneys_AccountID]    Script Date: 4/9/2023 3:14:43 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferMoneys_AccountID] ON [dbo].[TransferMoneys]
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Balances]  WITH CHECK ADD  CONSTRAINT [FK_Balances_Accounts_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Balances] CHECK CONSTRAINT [FK_Balances_Accounts_AccountID]
GO
ALTER TABLE [dbo].[Deposits]  WITH CHECK ADD  CONSTRAINT [FK_Deposits_Accounts_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deposits] CHECK CONSTRAINT [FK_Deposits_Accounts_AccountID]
GO
ALTER TABLE [dbo].[TransferMoneys]  WITH CHECK ADD  CONSTRAINT [FK_TransferMoneys_Accounts_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransferMoneys] CHECK CONSTRAINT [FK_TransferMoneys_Accounts_AccountID]
GO
/****** Object:  StoredProcedure [dbo].[SpBalanceSave]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpBalanceSave]
							@TotalBalance decimal(18, 2),
							@AccountID int
																			
AS
	BEGIN
		INSERT INTO Balances(TotalBalance,AccountID) 
		VALUES(@TotalBalance,@AccountID)
	END
GO
/****** Object:  StoredProcedure [dbo].[SpCreateAccounts]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpCreateAccounts]
							@AccountHolderName nvarchar(40),
							@AccountNumber nvarchar(40),
							@AccountType nvarchar(40),
							@Gender nvarchar(40),
							@Address nvarchar(500),
							@Picture nvarchar(250),
							@CreatedDate datetime2(7),
							@Email nvarchar(250),
							@Password nvarchar(200)
							
																			
AS
	BEGIN
		INSERT INTO Accounts(
						AccountHolderName,
						AccountNumber,
						AccountType,
						Gender,
						Address,
						Picture,
						CreatedDate,
						Email,
						Password
								) 
				VALUES(@AccountHolderName,
						@AccountNumber,	
						@AccountType,
						@Gender,
						@Address,
						@Picture,
						@CreatedDate,
						@Email,
						@Password)
	END

GO
/****** Object:  StoredProcedure [dbo].[SpDeleteRecordFromAccounts]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SpDeleteRecordFromAccounts]
(@AccountID int)

AS 
	BEGIN 
		Delete from Accounts
		Where AccountID = @AccountID
	END	
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteRecordFromBalances]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SpDeleteRecordFromBalances]
(@BalanceID int)

AS 
	BEGIN 
		Delete from Balances
		Where BalanceID = @BalanceID
	END	
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteRecordFromDeposit]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SpDeleteRecordFromDeposit]
(@DepositID int)

AS 
	BEGIN 
		Delete from Deposits
		Where DepositID = @DepositID
	END	
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteRecordFromTransferMoneys]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SpDeleteRecordFromTransferMoneys]
(@TransferMoneyID int)

AS 
	BEGIN 
		Delete from TransferMoneys
		Where TransferMoneyID = @TransferMoneyID
	END	
GO
/****** Object:  StoredProcedure [dbo].[SpDepositSave]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpDepositSave]
							@AccountNumber nvarchar(MAX),
							@AccountHolderName nvarchar(MAX),
							@Amount decimal(18, 2),
							@DepositDate datetime2(7),
							@AccountID int
																			
AS
	BEGIN
		INSERT INTO Deposits(AccountNumber,AccountHolderName,Amount,DepositDate,AccountID) 
		VALUES(@AccountNumber,@AccountHolderName,@Amount,@DepositDate,@AccountID)
	END
GO
/****** Object:  StoredProcedure [dbo].[SpGetAllAccounts]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetAllAccounts]
AS
	BEGIN
		select * from Accounts
	END
GO
/****** Object:  StoredProcedure [dbo].[SpGetAllBalances]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetAllBalances]
AS
	BEGIN
		select * from Balances
	END
GO
/****** Object:  StoredProcedure [dbo].[SpGetAllDeposits]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetAllDeposits]
AS
	BEGIN
		select * from Deposits 
	END
GO
/****** Object:  StoredProcedure [dbo].[SpGetAllTransferMoneys]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetAllTransferMoneys]
AS
	BEGIN
		select * from TransferMoneys
	END
GO
/****** Object:  StoredProcedure [dbo].[SpGetByAccountID]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetByAccountID]
								@AccountID int
AS
	BEGIN
		select * from Accounts
		Where AccountID = @AccountID
	END
GO
/****** Object:  StoredProcedure [dbo].[SpGetByBalanceID]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetByBalanceID]
								@BalanceID int
AS
	BEGIN
		select * from Balances
		Where BalanceID = @BalanceID
	END
GO
/****** Object:  StoredProcedure [dbo].[SpGetByDepositID]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetByDepositID]
								@DepositID int
AS
	BEGIN
		select * from Deposits
		Where DepositID = @DepositID
	END
GO
/****** Object:  StoredProcedure [dbo].[SpGetByTransferMoneyID]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGetByTransferMoneyID]
								@TransferMoneyID int
AS
	BEGIN
		select * from TransferMoneys
		Where TransferMoneyID = @TransferMoneyID
	END
GO
/****** Object:  StoredProcedure [dbo].[SpTransferMoneySave]    Script Date: 4/9/2023 3:14:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpTransferMoneySave]
							@SenderAccountNo nvarchar(MAX),
							@RecipientAccountNo nvarchar(MAX),
							@Amount decimal(18, 2),
							@DepositDate datetime2(7),
							@AccountID int
																			
AS
	BEGIN
		INSERT INTO TransferMoneys(SenderAccountNo,RecipientAccountNo, Amount,DepositDate,AccountID) 
		VALUES(@SenderAccountNo,@RecipientAccountNo,@Amount,@DepositDate,@AccountID)
	END
GO
USE [master]
GO
ALTER DATABASE [MassBankDB] SET  READ_WRITE 
GO

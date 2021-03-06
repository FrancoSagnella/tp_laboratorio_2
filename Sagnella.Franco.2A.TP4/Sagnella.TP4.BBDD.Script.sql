USE [master]
GO
/****** Object:  Database [ElectrodomesticosTP4]    Script Date: 22/11/2020 17:14:54 ******/
CREATE DATABASE [ElectrodomesticosTP4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ElectrodomesticosTP4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ElectrodomesticosTP4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ElectrodomesticosTP4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ElectrodomesticosTP4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ElectrodomesticosTP4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ElectrodomesticosTP4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ElectrodomesticosTP4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET ARITHABORT OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET  MULTI_USER 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ElectrodomesticosTP4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ElectrodomesticosTP4] SET QUERY_STORE = OFF
GO
USE [ElectrodomesticosTP4]
GO
/****** Object:  Table [dbo].[electrodomesticosTP4]    Script Date: 22/11/2020 17:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[electrodomesticosTP4](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[modelo] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
	[tipo] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[electrodomesticosTP4] ON 

INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (1, N'Philips', N'ModeloTV1', 123, N'Tv')
INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (7, N'Philips', N'ModeloTV1', 33221, N'Tv')
INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (8, N'Philips', N'ModeloTV2', 123, N'Tv')
INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (5, N'Oster', N'ModeloCafetera1', 3321, N'Cafetera')
INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (6, N'Philips', N'ModeloCafetera2', 33211, N'Cafetera')
INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (9, N'Philips', N'ModeloTV1', 333441, N'Tv')
INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (10, N'Oster', N'ModeloCafetera2', 333212, N'Cafetera')
INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (11, N'Oster', N'ModeloCafetera1', 333221216, N'Cafetera')
INSERT [dbo].[electrodomesticosTP4] ([id], [marca], [modelo], [precio], [tipo]) VALUES (13, N'Philips', N'ModeloTV2', 666, N'Tv')
SET IDENTITY_INSERT [dbo].[electrodomesticosTP4] OFF
GO
USE [master]
GO
ALTER DATABASE [ElectrodomesticosTP4] SET  READ_WRITE 
GO

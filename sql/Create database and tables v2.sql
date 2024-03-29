USE [master]
GO
/****** Object:  Database [MonitorLibrary]    Script Date: 02/03/2012 15:19:30 ******/
CREATE DATABASE [MonitorLibrary] ON  PRIMARY 
( NAME = N'MonitorLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.ENVY\MSSQL\DATA\MonitorLibrary.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MonitorLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.ENVY\MSSQL\DATA\MonitorLibrary_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MonitorLibrary] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MonitorLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MonitorLibrary] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MonitorLibrary] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MonitorLibrary] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MonitorLibrary] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MonitorLibrary] SET ARITHABORT OFF
GO
ALTER DATABASE [MonitorLibrary] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MonitorLibrary] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MonitorLibrary] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MonitorLibrary] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MonitorLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MonitorLibrary] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MonitorLibrary] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MonitorLibrary] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MonitorLibrary] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MonitorLibrary] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MonitorLibrary] SET  ENABLE_BROKER
GO
ALTER DATABASE [MonitorLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MonitorLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MonitorLibrary] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MonitorLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MonitorLibrary] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MonitorLibrary] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MonitorLibrary] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MonitorLibrary] SET  READ_WRITE
GO
ALTER DATABASE [MonitorLibrary] SET RECOVERY FULL
GO
ALTER DATABASE [MonitorLibrary] SET  MULTI_USER
GO
ALTER DATABASE [MonitorLibrary] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MonitorLibrary] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'MonitorLibrary', N'ON'
GO
USE [MonitorLibrary]
GO
/****** Object:  Table [dbo].[VariableType]    Script Date: 02/03/2012 15:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VariableType](
	[VariableTypeID] [int] IDENTITY(1,1) NOT NULL,
	[VariableType] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VariableTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service]    Script Date: 02/03/2012 15:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PluginType]    Script Date: 02/03/2012 15:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PluginType](
	[PluginTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PluginTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Plugin]    Script Date: 02/03/2012 15:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Plugin](
	[PluginID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[PluginTypeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PluginID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parameter]    Script Date: 02/03/2012 15:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parameter](
	[ParameterID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[VariableTypeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ParameterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Log]    Script Date: 02/03/2012 15:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Info] [varchar](max) NOT NULL,
	[PluginID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PluginServiceWire]    Script Date: 02/03/2012 15:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PluginServiceWire](
	[PluginServiceWireID] [int] IDENTITY(1,1) NOT NULL,
	[PluginID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PluginServiceWireID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PluginParameterWire]    Script Date: 02/03/2012 15:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PluginParameterWire](
	[PluginParameterWireID] [int] IDENTITY(1,1) NOT NULL,
	[PluginID] [int] NOT NULL,
	[ParameterID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PluginParameterWireID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__Plugin__PluginTy__108B795B]    Script Date: 02/03/2012 15:19:32 ******/
ALTER TABLE [dbo].[Plugin]  WITH CHECK ADD FOREIGN KEY([PluginTypeID])
REFERENCES [dbo].[PluginType] ([PluginTypeID])
GO
/****** Object:  ForeignKey [FK__Parameter__Varia__412EB0B6]    Script Date: 02/03/2012 15:19:32 ******/
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD FOREIGN KEY([VariableTypeID])
REFERENCES [dbo].[VariableType] ([VariableTypeID])
GO
/****** Object:  ForeignKey [FK__Log__PluginID__1367E606]    Script Date: 02/03/2012 15:19:32 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD FOREIGN KEY([PluginID])
REFERENCES [dbo].[Plugin] ([PluginID])
GO
/****** Object:  ForeignKey [FK__PluginSer__Plugi__1BFD2C07]    Script Date: 02/03/2012 15:19:32 ******/
ALTER TABLE [dbo].[PluginServiceWire]  WITH CHECK ADD FOREIGN KEY([PluginID])
REFERENCES [dbo].[Plugin] ([PluginID])
GO
/****** Object:  ForeignKey [FK__PluginSer__Servi__1CF15040]    Script Date: 02/03/2012 15:19:32 ******/
ALTER TABLE [dbo].[PluginServiceWire]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
/****** Object:  ForeignKey [FK__PluginPar__Param__4D94879B]    Script Date: 02/03/2012 15:19:32 ******/
ALTER TABLE [dbo].[PluginParameterWire]  WITH CHECK ADD FOREIGN KEY([ParameterID])
REFERENCES [dbo].[Parameter] ([ParameterID])
GO
/****** Object:  ForeignKey [FK__PluginPar__Plugi__4CA06362]    Script Date: 02/03/2012 15:19:32 ******/
ALTER TABLE [dbo].[PluginParameterWire]  WITH CHECK ADD FOREIGN KEY([PluginID])
REFERENCES [dbo].[Plugin] ([PluginID])
GO

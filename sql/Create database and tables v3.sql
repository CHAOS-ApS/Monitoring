USE [master]
GO
/****** Object:  Database [MonitorLibrary]    Script Date: 02/29/2012 15:31:58 ******/
CREATE DATABASE [MonitorLibrary] ON  PRIMARY 
( NAME = N'MonitorLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.ENVY\MSSQL\DATA\MonitorLibrary.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MonitorLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.ENVY\MSSQL\DATA\MonitorLibrary_log.LDF' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[Trigger]    Script Date: 02/29/2012 15:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trigger](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[Repetition] [int] NOT NULL,
 CONSTRAINT [PK_Trigger] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PluginType]    Script Date: 02/29/2012 15:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PluginType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Classpath] [nvarchar](max) NOT NULL,
	[Classname] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_PluginType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Trigger_Get]    Script Date: 02/29/2012 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Christoffer Johnsson
-- Create date: 2012-02-20
-- Description:	Selects all the triggers that are enabled
-- =============================================
CREATE PROCEDURE [dbo].[Trigger_Get]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ID],
	[StartDateTime],
	[Repetition],
	[Enabled]
	FROM [Trigger]
	WHERE Enabled = 1;
END
GO
/****** Object:  Table [dbo].[Plugin]    Script Date: 02/29/2012 15:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plugin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HostAdress] [nvarchar](max) NOT NULL,
	[PluginTypeID] [int] NOT NULL,
	[TriggerID] [int] NOT NULL,
 CONSTRAINT [PK_Plugin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Plugin] UNIQUE NONCLUSTERED 
(
	[PluginTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PluginInfo]    Script Date: 02/29/2012 15:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PluginInfo]
AS
SELECT     P.ID AS PluginID, P.TriggerID, P.HostAdress, PT.Classpath, PT.ID AS PluginTypeID, PT.Classname
FROM         dbo.Plugin AS P INNER JOIN
                      dbo.PluginType AS PT ON P.PluginTypeID = PT.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "P"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PT"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 126
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PluginInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PluginInfo'
GO
/****** Object:  StoredProcedure [dbo].[PluginInfo_Get]    Script Date: 02/29/2012 15:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Christoffer Johnsson
-- Create date: 2012-02-20
-- Description:	Selects all the plugins that are enabled
-- =============================================
CREATE PROCEDURE [dbo].[PluginInfo_Get] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM PluginInfo AS [PI]
	INNER JOIN [Trigger] AS T ON [PI].TriggerID = T.ID
	WHERE Enabled = 1;
	END
GO
/****** Object:  ForeignKey [FK_Plugin_PluginType]    Script Date: 02/29/2012 15:32:03 ******/
ALTER TABLE [dbo].[Plugin]  WITH CHECK ADD  CONSTRAINT [FK_Plugin_PluginType] FOREIGN KEY([PluginTypeID])
REFERENCES [dbo].[PluginType] ([ID])
GO
ALTER TABLE [dbo].[Plugin] CHECK CONSTRAINT [FK_Plugin_PluginType]
GO
/****** Object:  ForeignKey [FK_Plugin_Trigger]    Script Date: 02/29/2012 15:32:03 ******/
ALTER TABLE [dbo].[Plugin]  WITH CHECK ADD  CONSTRAINT [FK_Plugin_Trigger] FOREIGN KEY([TriggerID])
REFERENCES [dbo].[Trigger] ([ID])
GO
ALTER TABLE [dbo].[Plugin] CHECK CONSTRAINT [FK_Plugin_Trigger]
GO

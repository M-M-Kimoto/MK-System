USE [master]
GO
/****** Object:  Database [mk_system_wpf]    Script Date: 2020/06/09 6:57:25 ******/
CREATE DATABASE [mk_system_wpf]
GO
ALTER DATABASE [mk_system_wpf] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mk_system_wpf].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mk_system_wpf] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mk_system_wpf] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mk_system_wpf] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mk_system_wpf] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mk_system_wpf] SET ARITHABORT OFF 
GO
ALTER DATABASE [mk_system_wpf] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mk_system_wpf] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mk_system_wpf] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mk_system_wpf] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mk_system_wpf] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mk_system_wpf] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mk_system_wpf] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mk_system_wpf] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mk_system_wpf] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mk_system_wpf] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mk_system_wpf] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mk_system_wpf] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mk_system_wpf] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mk_system_wpf] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mk_system_wpf] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mk_system_wpf] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mk_system_wpf] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mk_system_wpf] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [mk_system_wpf] SET  MULTI_USER 
GO
ALTER DATABASE [mk_system_wpf] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mk_system_wpf] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mk_system_wpf] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mk_system_wpf] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mk_system_wpf] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [mk_system_wpf] SET QUERY_STORE = OFF
GO
USE [mk_system_wpf]
GO
/****** Object:  Table [dbo].[sys001]    Script Date: 2020/06/09 6:57:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys001](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[kigyo_name] [varchar](30) NOT NULL,
	[keiyaku_date] [date] NOT NULL,
	[license_kikan] [numeric](18, 0) NOT NULL,
	[manryo_date] [date] NOT NULL,
 CONSTRAINT [sys001_P] PRIMARY KEY CLUSTERED 
(
	[kigyo_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst001]    Script Date: 2020/06/09 6:57:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst001](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[user_id] [varchar](15) NOT NULL,
	[pass] [varchar](15) NOT NULL,
	[user_name] [varchar](30) NOT NULL,
	[status] [numeric](1, 0) NOT NULL,
 CONSTRAINT [mst001_P] PRIMARY KEY CLUSTERED 
(
	[kigyo_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vew001]    Script Date: 2020/06/09 6:57:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vew001]
AS
SELECT                      dbo.sys001.toroku_datetime, dbo.sys001.toroku_user_id, dbo.sys001.koshin_datetime, dbo.sys001.koshin_user_id, dbo.sys001.kigyo_code, dbo.sys001.kigyo_name, 
                                      dbo.sys001.keiyaku_date, dbo.sys001.license_kikan, dbo.sys001.manryo_date, dbo.mst001.user_name, dbo.mst001.status, dbo.mst001.user_id, dbo.mst001.pass
FROM                         dbo.sys001 INNER JOIN
                                      dbo.mst001 ON dbo.sys001.kigyo_code = dbo.mst001.kigyo_code
GO
/****** Object:  Table [dbo].[sys002]    Script Date: 2020/06/09 6:57:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys002](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[data_name] [varchar](30) NOT NULL,
	[data_code_name] [varchar](15) NOT NULL,
	[data_code_name_jp] [varchar](50) NOT NULL,
	[code] [varchar](15) NOT NULL,
	[code_min] [numeric](2, 0) NOT NULL,
	[code_max] [numeric](2, 0) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
 CONSTRAINT [sys002_P] PRIMARY KEY CLUSTERED 
(
	[data_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys003]    Script Date: 2020/06/09 6:57:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys003](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[news] [varchar](200) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
 CONSTRAINT [sys003_P] PRIMARY KEY CLUSTERED 
(
	[toroku_datetime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[mst001] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [user_id], [pass], [user_name], [status]) VALUES (CAST(N'2020-05-04T09:49:30.000' AS DateTime), N'mk_user', CAST(N'2020-05-04T09:49:30.000' AS DateTime), N'mk_user', N'mk3202', N'mirrorn', N'3202nori', N'M.Kimoto', CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[sys001] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [kigyo_name], [keiyaku_date], [license_kikan], [manryo_date]) VALUES (CAST(N'2020-05-04T09:49:30.000' AS DateTime), N'mirrorn', CAST(N'2020-05-04T09:49:30.000' AS DateTime), N'mirrorn', N'mk3202', N'withIT', CAST(N'1900-01-01' AS Date), CAST(0 AS Numeric(18, 0)), CAST(N'2999-12-31' AS Date))
INSERT [dbo].[sys003] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [news], [invalid_flg]) VALUES (CAST(N'2020-05-05T15:00:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-05T15:00:00.000' AS DateTime), N'mirrorn', N'新着情報です', CAST(0 AS Numeric(1, 0)))
ALTER TABLE [dbo].[mst001] ADD  DEFAULT ('mk123') FOR [pass]
GO
ALTER TABLE [dbo].[mst001] ADD  DEFAULT ('default user') FOR [user_name]
GO
ALTER TABLE [dbo].[mst001] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[sys001] ADD  DEFAULT ((12)) FOR [license_kikan]
GO
ALTER TABLE [dbo].[sys002] ADD  DEFAULT ((1)) FOR [code_min]
GO
ALTER TABLE [dbo].[sys002] ADD  DEFAULT ((1)) FOR [code_max]
GO
ALTER TABLE [dbo].[sys002] ADD  DEFAULT ((0)) FOR [invalid_flg]
GO
ALTER TABLE [dbo].[sys003] ADD  DEFAULT ((0)) FOR [invalid_flg]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'パスワード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'pass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ユーザ名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ステータス' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mst001', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'kigyo_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'契約日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'keiyaku_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ライセンス有効期間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'license_kikan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'満了日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys001', @level2type=N'COLUMN',@level2name=N'manryo_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'データコード名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'data_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'データコード名（日本語）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'data_code_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'データ名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'data_code_name_jp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'コード最低桁数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'code_min'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'コード最大桁数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'code_max'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys002', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys003', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys003', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys003', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys003', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新着情報' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys003', @level2type=N'COLUMN',@level2name=N'news'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sys003', @level2type=N'COLUMN',@level2name=N'invalid_flg'
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
         Begin Table = "sys001"
            Begin Extent = 
               Top = 6
               Left = 251
               Bottom = 351
               Right = 748
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mst001"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 346
               Right = 232
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
         Column = 3240
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vew001'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vew001'
GO
USE [master]
GO
ALTER DATABASE [mk_system_wpf] SET  READ_WRITE 
GO

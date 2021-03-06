USE [master]
GO
/****** Object:  Database [mk_system_wpf_01]    Script Date: 2020/05/17 9:21:03 ******/
CREATE DATABASE [mk_system_wpf_01]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mk_system_wpf_01', FILENAME = N'D:\システム\事務システム\DB\mk_system_wpf_01.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'mk_system_wpf_01_log', FILENAME = N'D:\システム\事務システム\DB\mk_system_wpf_01_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [mk_system_wpf_01] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mk_system_wpf_01].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mk_system_wpf_01] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET ARITHABORT OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mk_system_wpf_01] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mk_system_wpf_01] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mk_system_wpf_01] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mk_system_wpf_01] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [mk_system_wpf_01] SET  MULTI_USER 
GO
ALTER DATABASE [mk_system_wpf_01] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mk_system_wpf_01] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mk_system_wpf_01] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mk_system_wpf_01] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mk_system_wpf_01] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [mk_system_wpf_01] SET QUERY_STORE = OFF
GO
USE [mk_system_wpf_01]
GO
/****** Object:  Table [dbo].[program_mst]    Script Date: 2020/05/17 9:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[program_mst](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[program_id] [varchar](10) NOT NULL,
	[program_name] [varchar](50) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
 CONSTRAINT [program_mst_P] PRIMARY KEY CLUSTERED 
(
	[program_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu_mst]    Script Date: 2020/05/17 9:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu_mst](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[menu_id] [numeric](3, 0) NOT NULL,
	[menu_name] [varchar](50) NOT NULL,
	[program_id] [varchar](10) NULL,
	[in_menu_id] [numeric](3, 0) NULL,
	[unvisible_flg] [numeric](1, 0) NOT NULL,
 CONSTRAINT [menu_mst_P] PRIMARY KEY CLUSTERED 
(
	[kigyo_code] ASC,
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_kigyo_menu]    Script Date: 2020/05/17 9:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[v_kigyo_menu] as (


select
	dbo.menu_mst.kigyo_code, 
	dbo.menu_mst.menu_id AS id, 
	menu_name AS name, 
    dbo.menu_mst.in_menu_id, 
	'' as program_id,
	dbo.menu_mst.unvisible_flg
from menu_mst
where 1 = 1
and (program_id is null or rtrim(program_id) = '')

union all

SELECT
	dbo.menu_mst.kigyo_code, 
	dbo.menu_mst.menu_id AS id, 
	program_mst.program_name as name ,
    dbo.menu_mst.in_menu_id, 
	program_mst.program_id as program_id,
	dbo.menu_mst.unvisible_flg
FROM dbo.menu_mst INNER JOIN (
	SELECT 
		toroku_datetime, 
		toroku_user_id, 
		koshin_datetime, 
		koshin_user_id, 
		program_id, 
		program_name, 
		invalid_flg
		FROM dbo.program_mst AS program_mst_1
        WHERE 1 = 1
			AND (invalid_flg = 0)
) AS program_mst ON 1 = 1 AND dbo.menu_mst.program_id = program_mst.program_id

)
GO
INSERT [dbo].[menu_mst] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(1 AS Numeric(3, 0)), N'マスタメンテ', NULL, CAST(0 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[menu_mst] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(2 AS Numeric(3, 0)), N'生産', NULL, CAST(0 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[menu_mst] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(3 AS Numeric(3, 0)), N'発注', NULL, CAST(0 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[menu_mst] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(4 AS Numeric(3, 0)), N'', N'MK1101', CAST(1 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[menu_mst] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(5 AS Numeric(3, 0)), N'', N'MK1102', CAST(1 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[program_mst] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [program_id], [program_name], [invalid_flg]) VALUES (CAST(N'2020-05-13T00:00:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T00:00:00.000' AS DateTime), N'mirrorn', N'MK1101', N'資材コードマスタメンテ', CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[program_mst] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [program_id], [program_name], [invalid_flg]) VALUES (CAST(N'2020-05-13T00:00:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T00:00:00.000' AS DateTime), N'mirrorn', N'MK1102', N'受注単価マスタ', CAST(1 AS Numeric(1, 0)))
ALTER TABLE [dbo].[menu_mst] ADD  DEFAULT ((0)) FOR [unvisible_flg]
GO
ALTER TABLE [dbo].[program_mst] ADD  DEFAULT ((0)) FOR [invalid_flg]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メニューID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'menu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メニュー名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'menu_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'プログラムID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'program_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属メニューID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'in_menu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'非表示フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu_mst', @level2type=N'COLUMN',@level2name=N'unvisible_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'program_mst', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'program_mst', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'program_mst', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'program_mst', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'プログラムID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'program_mst', @level2type=N'COLUMN',@level2name=N'program_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'プログラム名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'program_mst', @level2type=N'COLUMN',@level2name=N'program_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'program_mst', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
USE [master]
GO
ALTER DATABASE [mk_system_wpf_01] SET  READ_WRITE 
GO

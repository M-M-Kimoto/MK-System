USE [master]
GO
/****** Object:  Database [mk_system_wpf_01]    Script Date: 2020/06/09 6:57:38 ******/
CREATE DATABASE [mk_system_wpf_01]
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
/****** Object:  Table [dbo].[m_material]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_material](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[toroku_program] [varchar](10) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[koshin_program] [varchar](10) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
	[material_code] [varchar](50) NOT NULL,
	[material_name] [varchar](200) NULL,
	[unit_kbn] [varchar](4) NULL,
	[type_name] [varchar](200) NULL,
	[kikaku_shiyo] [varchar](200) NULL,
	[biko] [varchar](200) NULL,
	[yobi1] [varchar](200) NULL,
	[yobi2] [varchar](200) NULL,
	[yobi3] [varchar](200) NULL,
	[yobi4] [varchar](200) NULL,
	[yobi5] [varchar](200) NULL,
 CONSTRAINT [m_material_P] PRIMARY KEY CLUSTERED 
(
	[kigyo_code] ASC,
	[material_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_material_code]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_material_code] as(
select* from m_material)
GO
/****** Object:  Table [dbo].[m_kbn]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_kbn](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[toroku_program] [varchar](10) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[koshin_program] [varchar](10) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
	[data_code] [varchar](20) NOT NULL,
	[data_name] [varchar](50) NOT NULL,
	[kbn] [varchar](10) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[komoku1] [varchar](50) NULL,
	[komoku2] [varchar](50) NULL,
	[komoku3] [varchar](50) NULL,
	[komoku4] [varchar](50) NULL,
	[komoku5] [varchar](50) NULL,
	[flg1] [numeric](1, 0) NULL,
	[flg2] [numeric](1, 0) NULL,
	[flg3] [numeric](1, 0) NULL,
	[flg4] [numeric](1, 0) NULL,
	[flg5] [numeric](1, 0) NULL,
 CONSTRAINT [m_kbn_P] PRIMARY KEY CLUSTERED 
(
	[kigyo_code] ASC,
	[data_code] ASC,
	[kbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_kbn]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_kbn] as(
select * from m_kbn)
GO
/****** Object:  Table [dbo].[m_menu]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_menu](
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
 CONSTRAINT [m_menu_P] PRIMARY KEY CLUSTERED 
(
	[kigyo_code] ASC,
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_program]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_program](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[program_id] [varchar](10) NOT NULL,
	[program_name] [varchar](50) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
 CONSTRAINT [m_program_P] PRIMARY KEY CLUSTERED 
(
	[program_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_kigyo_menu]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[v_kigyo_menu] as (


select
	dbo.m_menu.kigyo_code, 
	dbo.m_menu.menu_id AS id, 
	menu_name AS name, 
    dbo.m_menu.in_menu_id, 
	'' as program_id,
	dbo.m_menu.unvisible_flg
from m_menu
where 1 = 1
and (program_id is null or rtrim(program_id) = '')

union all

SELECT
	dbo.m_menu.kigyo_code, 
	dbo.m_menu.menu_id AS id, 
	m_program.program_name as name ,
    dbo.m_menu.in_menu_id, 
	m_program.program_id as program_id,
	dbo.m_menu.unvisible_flg
FROM dbo.m_menu INNER JOIN (
	SELECT 
		toroku_datetime, 
		toroku_user_id, 
		koshin_datetime, 
		koshin_user_id, 
		program_id, 
		program_name, 
		invalid_flg
		FROM dbo.m_program AS m_program_1
        WHERE 1 = 1
			AND (invalid_flg = 0)
) AS m_program ON 1 = 1 AND dbo.m_menu.program_id = m_program.program_id

)
GO
/****** Object:  View [dbo].[v_Teigi]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[v_Teigi] as(

SELECT
     DatabaseName            = C.TABLE_CATALOG
    ,SchemaName             = C.TABLE_SCHEMA
    ,TableName              = C.TABLE_NAME
	,ColumnID               = COLUMNPROPERTY(OBJECT_ID(C.TABLE_SCHEMA + '.' + C.TABLE_NAME), C.COLUMN_NAME, 'ColumnID')
	,PrimaryKey             =
	CASE
		WHEN P.constraint_name is not null or P.constraint_name <> '' THEN '〇'
		ELSE ''
		END
    ,ColumnName             = C.COLUMN_NAME
    ,ColumnName_JP          = ep.value
    ,IS_NULLABLE          = 
        CASE
            WHEN C.IS_NULLABLE  = 'YES'   THEN 'Y'
            WHEN C.IS_NULLABLE  = 'NO'    THEN 'N'
            ELSE 'Undefined'
        END
    ,data_type = C.DATA_TYPE
	,REPLACE(REPLACE(COLUMN_DEFAULT,'((','('), '))',')') as default_val
	,MaxInteger             =
	CASE
		WHEN C.DATA_TYPE = 'varchar' THEN C.CHARACTER_OCTET_LENGTH
		WHEN C.DATA_TYPE = 'numeric' THEN C.NUMERIC_PRECISION - C.NUMERIC_SCALE
		ELSE '0'
	END
	,MaxDecimal             =
	CASE
		WHEN C.DATA_TYPE = 'numeric' THEN C.NUMERIC_SCALE
		ELSE '0'
	END
FROM
    INFORMATION_SCHEMA.COLUMNS C
    LEFT OUTER JOIN sys.identity_columns i
ON
    OBJECT_ID(C.TABLE_SCHEMA + '.' + C.TABLE_NAME) = i.object_id
    AND C.COLUMN_NAME = i.name
	LEFT OUTER JOIN (
	SELECT
	     tbls.name AS table_name
	    ,key_const.name AS constraint_name
	    ,idx_cols.key_ordinal AS key_ordinal
	    ,cols.name AS col_name
	FROM
	    sys.tables AS tbls
	        INNER JOIN sys.key_constraints AS key_const ON
	            tbls.object_id = key_const.parent_object_id AND key_const.type = 'PK'
	        INNER JOIN sys.index_columns AS idx_cols ON
	            key_const.parent_object_id = idx_cols.object_id
	            AND key_const.unique_index_id  = idx_cols.index_id
	        INNER JOIN sys.columns AS cols ON
	            idx_cols.object_id = cols.object_id
	            AND idx_cols.column_id = cols.column_id
	) P
ON
	    P.table_name = C.TABLE_NAME
	AND P.col_name = C.COLUMN_NAME
	LEFT OUTER JOIN sys.extended_properties AS ep
ON
        OBJECT_ID(C.TABLE_SCHEMA + '.' + C.TABLE_NAME) = ep.major_id
    AND COLUMNPROPERTY(OBJECT_ID(C.TABLE_SCHEMA + '.' + C.TABLE_NAME), C.COLUMN_NAME, 'ColumnID') = ep.minor_id

	
WHERE 1 = 1
/*
    (
        C.TABLE_CATALOG = @DatabaseName OR (@DatabaseName IS NULL)
    ) AND (
        C.TABLE_SCHEMA = @SchemaName OR (@SchemaName IS NULL)
    ) AND (
        C.TABLE_NAME = @TableName OR (@TableName IS NULL)
    )
	)
	*/
	/*
ORDER BY
    C.TABLE_CATALOG
    ,C.TABLE_SCHEMA
    ,C.TABLE_NAME
    ,C.ORDINAL_POSITION
	*/
	)
GO
/****** Object:  Table [dbo].[m_hacchu_tanka]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_hacchu_tanka](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[toroku_program] [varchar](10) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[koshin_program] [varchar](10) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[material_code] [varchar](50) NOT NULL,
	[kaisha_code] [varchar](10) NOT NULL,
	[tekiyou_ymd] [datetime] NOT NULL,
	[tanka] [numeric](11, 2) NOT NULL,
 CONSTRAINT [m_hacchu_tanka_P] PRIMARY KEY CLUSTERED 
(
	[kigyo_code] ASC,
	[material_code] ASC,
	[kaisha_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_kaisya]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_kaisya](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[toroku_program] [varchar](10) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[koshin_program] [varchar](10) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
	[kaisya_code] [varchar](6) NOT NULL,
	[kaisya_name] [varchar](200) NOT NULL,
	[kaisya_name_kana] [varchar](200) NOT NULL,
	[kaisya_name_ryaku] [varchar](200) NOT NULL,
	[address] [varchar](200) NULL,
	[postal_code] [varchar](8) NULL,
	[tel_no] [varchar](20) NULL,
	[fax_no] [varchar](20) NULL,
	[mail_address] [varchar](100) NULL,
 CONSTRAINT [m_kaisya_P] PRIMARY KEY CLUSTERED 
(
	[kigyo_code] ASC,
	[kaisya_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_kaisya_history]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_kaisya_history](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[toroku_program] [varchar](10) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[koshin_program] [varchar](10) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
	[kaisya_code] [varchar](6) NOT NULL,
	[kaisya_name] [varchar](200) NOT NULL,
	[kaisya_name_kana] [varchar](200) NOT NULL,
	[kaisya_name_ryaku] [varchar](200) NOT NULL,
	[address] [varchar](200) NULL,
	[postal_code] [varchar](8) NULL,
	[tel_no] [varchar](20) NULL,
	[fax_no] [varchar](20) NULL,
	[mail_address] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[m_material_history]    Script Date: 2020/06/09 6:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_material_history](
	[toroku_datetime] [datetime] NOT NULL,
	[toroku_user_id] [varchar](15) NOT NULL,
	[toroku_program] [varchar](10) NOT NULL,
	[koshin_datetime] [datetime] NOT NULL,
	[koshin_user_id] [varchar](15) NOT NULL,
	[koshin_program] [varchar](10) NOT NULL,
	[kigyo_code] [varchar](10) NOT NULL,
	[invalid_flg] [numeric](1, 0) NOT NULL,
	[material_code] [varchar](50) NOT NULL,
	[material_name] [varchar](200) NULL,
	[unit_kbn] [varchar](4) NULL,
	[type_name] [varchar](200) NULL,
	[kikaku_shiyo] [varchar](200) NULL,
	[biko] [varchar](200) NULL,
	[yobi1] [varchar](200) NULL,
	[yobi2] [varchar](200) NULL,
	[yobi3] [varchar](200) NULL,
	[yobi4] [varchar](200) NULL,
	[yobi5] [varchar](200) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[m_kaisya] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [kaisya_code], [kaisya_name], [kaisya_name_kana], [kaisya_name_ryaku], [address], [postal_code], [tel_no], [fax_no], [mail_address]) VALUES (CAST(N'2020-06-07T09:00:00.000' AS DateTime), N'mirrorn', N'SSMS', CAST(N'2020-06-07T07:12:33.000' AS DateTime), N'', N'MK1102', N'mk3202', CAST(1 AS Numeric(1, 0)), N'200607', N'株式会社テスト', N'カブシキガイシャテスト', N'テスト', N'東京都千代田区千代田１?１', N'111-8111', N'03-3231-0878', N'03-3231-0879', N'kokyo@ntt.co.jp')
INSERT [dbo].[m_kaisya] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [kaisya_code], [kaisya_name], [kaisya_name_kana], [kaisya_name_ryaku], [address], [postal_code], [tel_no], [fax_no], [mail_address]) VALUES (CAST(N'2020-06-07T07:09:52.000' AS DateTime), N'', N'MK1102', CAST(N'2020-06-07T07:12:21.000' AS DateTime), N'', N'MK1102', N'mk3202', CAST(0 AS Numeric(1, 0)), N'A10001', N'株式会社カイシャ', N'ｶﾌﾞｼｷｶﾞｲｼｬ　ｶｲｼｬ', N'ｶｲｼｬ', N'ASDF', N'123-4321', N'1234', N'5678', N'POIU')
INSERT [dbo].[m_kaisya_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [kaisya_code], [kaisya_name], [kaisya_name_kana], [kaisya_name_ryaku], [address], [postal_code], [tel_no], [fax_no], [mail_address]) VALUES (CAST(N'2020-06-07T09:00:00.000' AS DateTime), N'mirrorn', N'SSMS', CAST(N'2020-06-07T07:02:50.000' AS DateTime), N'', N'MK1102', N'mk3202', CAST(1 AS Numeric(1, 0)), N'200607', N'株式会社テスト', N'カブシキガイシャテスト', N'テスト', N'東京都千代田区千代田１?１', N'111-8111', N'03-3231-0878', N'03-3231-0879', N'kokyo@ntt.co.jp')
INSERT [dbo].[m_kaisya_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [kaisya_code], [kaisya_name], [kaisya_name_kana], [kaisya_name_ryaku], [address], [postal_code], [tel_no], [fax_no], [mail_address]) VALUES (CAST(N'2020-06-07T09:00:00.000' AS DateTime), N'mirrorn', N'SSMS', CAST(N'2020-06-07T07:03:05.000' AS DateTime), N'', N'MK1102', N'mk3202', CAST(0 AS Numeric(1, 0)), N'200607', N'株式会社テスト', N'カブシキガイシャテスト', N'テスト', N'東京都千代田区千代田１?１', N'111-8111', N'03-3231-0878', N'03-3231-0879', N'kokyo@ntt.co.jp')
INSERT [dbo].[m_kaisya_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [kaisya_code], [kaisya_name], [kaisya_name_kana], [kaisya_name_ryaku], [address], [postal_code], [tel_no], [fax_no], [mail_address]) VALUES (CAST(N'2020-06-07T07:09:52.000' AS DateTime), N'', N'MK1102', CAST(N'2020-06-07T07:09:52.000' AS DateTime), N'', N'MK1102', N'mk3202', CAST(0 AS Numeric(1, 0)), N'A10001', N'株式会社カイシャ', N'ｶﾌﾞｼｷｶﾞｲｼｬ　ｶｲｼｬ', N'ｶｲｼｬ', N'ASDF', N'-', N'1234', N'5678', N'POIU')
INSERT [dbo].[m_kaisya_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [kaisya_code], [kaisya_name], [kaisya_name_kana], [kaisya_name_ryaku], [address], [postal_code], [tel_no], [fax_no], [mail_address]) VALUES (CAST(N'2020-06-07T07:09:52.000' AS DateTime), N'', N'MK1102', CAST(N'2020-06-07T07:12:21.000' AS DateTime), N'', N'MK1102', N'mk3202', CAST(0 AS Numeric(1, 0)), N'A10001', N'株式会社カイシャ', N'ｶﾌﾞｼｷｶﾞｲｼｬ　ｶｲｼｬ', N'ｶｲｼｬ', N'ASDF', N'123-4321', N'1234', N'5678', N'POIU')
INSERT [dbo].[m_kaisya_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [kaisya_code], [kaisya_name], [kaisya_name_kana], [kaisya_name_ryaku], [address], [postal_code], [tel_no], [fax_no], [mail_address]) VALUES (CAST(N'2020-06-07T09:00:00.000' AS DateTime), N'mirrorn', N'SSMS', CAST(N'2020-06-07T07:12:33.000' AS DateTime), N'', N'MK1102', N'mk3202', CAST(1 AS Numeric(1, 0)), N'200607', N'株式会社テスト', N'カブシキガイシャテスト', N'テスト', N'東京都千代田区千代田１?１', N'111-8111', N'03-3231-0878', N'03-3231-0879', N'kokyo@ntt.co.jp')
INSERT [dbo].[m_kbn] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [data_code], [data_name], [kbn], [name], [komoku1], [komoku2], [komoku3], [komoku4], [komoku5], [flg1], [flg2], [flg3], [flg4], [flg5]) VALUES (CAST(N'2020-05-31T08:12:00.000' AS DateTime), N'mirrorn', N'ssms', CAST(N'2020-05-31T08:12:00.000' AS DateTime), N'mirrorn', N'ssms', N'', CAST(0 AS Numeric(1, 0)), N'unit_code', N'単位コード', N'0001', N'個', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[m_kbn] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [data_code], [data_name], [kbn], [name], [komoku1], [komoku2], [komoku3], [komoku4], [komoku5], [flg1], [flg2], [flg3], [flg4], [flg5]) VALUES (CAST(N'2020-05-31T08:12:00.000' AS DateTime), N'mirrorn', N'ssms', CAST(N'2020-05-31T08:12:00.000' AS DateTime), N'mirrorn', N'ssms', N'', CAST(0 AS Numeric(1, 0)), N'unit_code', N'単位コード', N'1001', N'cm', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[m_material] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-05-31T09:29:40.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-02T05:52:45.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test0531-001', N'hinmei', N'1001', N'katamei', N'kikaku', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:05:57.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-04T09:05:57.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(1 AS Numeric(1, 0)), N'test604-001', N'hinmei-001', N'1001', N'katamei', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:09:23.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-05T06:16:17.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(1 AS Numeric(1, 0)), N'test604-002', N'hinmei-002', N'0001', N'katamei', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:14:59.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-05T07:56:40.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-003', N'hinmei-003', N'1001', N'katamei', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:15:39.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-04T09:20:33.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-004', N'hinmei-004', N'0001', N'katamei-004', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:21:32.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-04T09:21:32.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-005', N'hinmei-005', N'0001', N'katamei-005', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:15:39.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-04T09:15:39.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-004', N'hinmei-004', N'0001', N'katamei', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:15:39.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-04T09:15:39.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-004', N'hinmei-004', N'0001', N'katamei-004', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:15:39.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-04T09:20:33.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-004', N'hinmei-004', N'0001', N'katamei-004', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:21:32.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-04T09:21:32.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-005', N'hinmei-005', N'0001', N'katamei-005', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:09:23.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-05T06:16:10.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-002', N'hinmei-002', N'0001', N'katamei', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:09:23.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-05T06:16:17.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(1 AS Numeric(1, 0)), N'test604-002', N'hinmei-002', N'0001', N'katamei', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_material_history] ([toroku_datetime], [toroku_user_id], [toroku_program], [koshin_datetime], [koshin_user_id], [koshin_program], [kigyo_code], [invalid_flg], [material_code], [material_name], [unit_kbn], [type_name], [kikaku_shiyo], [biko], [yobi1], [yobi2], [yobi3], [yobi4], [yobi5]) VALUES (CAST(N'2020-06-04T09:14:59.000' AS DateTime), N'', N'MK1101', CAST(N'2020-06-05T07:56:40.000' AS DateTime), N'', N'MK1101', N'mk3202', CAST(0 AS Numeric(1, 0)), N'test604-003', N'hinmei-003', N'1001', N'katamei', N'siyo', N'biko', N'', N'', N'', N'', N'')
INSERT [dbo].[m_menu] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(1 AS Numeric(3, 0)), N'マスタメンテ', NULL, CAST(0 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[m_menu] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(2 AS Numeric(3, 0)), N'生産', NULL, CAST(0 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[m_menu] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(3 AS Numeric(3, 0)), N'発注', NULL, CAST(0 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[m_menu] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(4 AS Numeric(3, 0)), N'', N'MK1101', CAST(1 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[m_menu] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [kigyo_code], [menu_id], [menu_name], [program_id], [in_menu_id], [unvisible_flg]) VALUES (CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T05:32:00.000' AS DateTime), N'mirrorn', N'mk3202', CAST(5 AS Numeric(3, 0)), N'', N'MK1102', CAST(1 AS Numeric(3, 0)), CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[m_program] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [program_id], [program_name], [invalid_flg]) VALUES (CAST(N'2020-05-13T00:00:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T00:00:00.000' AS DateTime), N'mirrorn', N'MK1101', N'資材コードマスタメンテ', CAST(0 AS Numeric(1, 0)))
INSERT [dbo].[m_program] ([toroku_datetime], [toroku_user_id], [koshin_datetime], [koshin_user_id], [program_id], [program_name], [invalid_flg]) VALUES (CAST(N'2020-05-13T00:00:00.000' AS DateTime), N'mirrorn', CAST(N'2020-05-13T00:00:00.000' AS DateTime), N'mirrorn', N'MK1102', N'受注単価マスタ', CAST(1 AS Numeric(1, 0)))
ALTER TABLE [dbo].[m_kbn] ADD  CONSTRAINT [DF_m_kbn_invalid_flg]  DEFAULT ((0)) FOR [invalid_flg]
GO
ALTER TABLE [dbo].[m_kbn] ADD  DEFAULT (NULL) FOR [flg1]
GO
ALTER TABLE [dbo].[m_kbn] ADD  DEFAULT (NULL) FOR [flg2]
GO
ALTER TABLE [dbo].[m_kbn] ADD  DEFAULT (NULL) FOR [flg3]
GO
ALTER TABLE [dbo].[m_kbn] ADD  DEFAULT (NULL) FOR [flg4]
GO
ALTER TABLE [dbo].[m_kbn] ADD  DEFAULT (NULL) FOR [flg5]
GO
ALTER TABLE [dbo].[m_material] ADD  CONSTRAINT [DF_m_material_invalid_flg]  DEFAULT ((0)) FOR [invalid_flg]
GO
ALTER TABLE [dbo].[m_material_history] ADD  CONSTRAINT [DF_m_material_history_invalid_flg]  DEFAULT ((0)) FOR [invalid_flg]
GO
ALTER TABLE [dbo].[m_menu] ADD  DEFAULT ((0)) FOR [unvisible_flg]
GO
ALTER TABLE [dbo].[m_program] ADD  DEFAULT ((0)) FOR [invalid_flg]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'toroku_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'koshin_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'material_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'kaisha_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'適用日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'tekiyou_ymd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'単価' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_hacchu_tanka', @level2type=N'COLUMN',@level2name=N'tanka'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'toroku_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'koshin_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'kaisya_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'kaisya_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社名（カナ）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'kaisya_name_kana'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社略称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'kaisya_name_ryaku'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'住所' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'郵便番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'postal_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電話番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'tel_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FAX番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'fax_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メールアドレス' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya', @level2type=N'COLUMN',@level2name=N'mail_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'toroku_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'koshin_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'kaisya_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'kaisya_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社名（カナ）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'kaisya_name_kana'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会社略称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'kaisya_name_ryaku'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'住所' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'郵便番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'postal_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電話番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'tel_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FAX番号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'fax_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メールアドレス' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kaisya_history', @level2type=N'COLUMN',@level2name=N'mail_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'toroku_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'koshin_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'データコード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'data_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'データ名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'data_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'kbn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'項目1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'komoku1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'項目2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'komoku2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'項目3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'komoku3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'項目4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'komoku4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'項目5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'komoku5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'フラグ1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'flg1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'フラグ2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'flg2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'フラグ3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'flg3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'フラグ4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'flg4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'フラグ5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_kbn', @level2type=N'COLUMN',@level2name=N'flg5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'toroku_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'koshin_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'material_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'material_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'単位コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'unit_kbn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'type_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'規格・仕様' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'kikaku_shiyo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'備考' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'biko'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'yobi1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'yobi2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'yobi3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'yobi4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material', @level2type=N'COLUMN',@level2name=N'yobi5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'toroku_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新プログラム' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'koshin_program'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'material_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'material_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'単位コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'unit_kbn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'type_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'規格・仕様' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'kikaku_shiyo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'備考' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'biko'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'yobi1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'yobi2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'yobi3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'yobi4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'予備5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_material_history', @level2type=N'COLUMN',@level2name=N'yobi5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企業コード' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'kigyo_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メニューID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'menu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'メニュー名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'menu_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'プログラムID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'program_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属メニューID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'in_menu_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'非表示フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_menu', @level2type=N'COLUMN',@level2name=N'unvisible_flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_program', @level2type=N'COLUMN',@level2name=N'toroku_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登録ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_program', @level2type=N'COLUMN',@level2name=N'toroku_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新日時' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_program', @level2type=N'COLUMN',@level2name=N'koshin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新ユーザID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_program', @level2type=N'COLUMN',@level2name=N'koshin_user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'プログラムID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_program', @level2type=N'COLUMN',@level2name=N'program_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'プログラム名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_program', @level2type=N'COLUMN',@level2name=N'program_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'無効フラグ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'm_program', @level2type=N'COLUMN',@level2name=N'invalid_flg'
GO
USE [master]
GO
ALTER DATABASE [mk_system_wpf_01] SET  READ_WRITE 
GO
